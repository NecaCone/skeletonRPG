using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private RectTransform inventoryRect;

    //broj praznih slotova
    private static int emptySlot;

    private float inventoryWidth;
    private float inventoryHeight;

    public int slots;
    public int rows;

    public float slotPaddingLeft;
    public float slotPaddingTop;

    public float slotSize;

    public GameObject slotPrefab;

    private Slot from, to;

    private List<GameObject> allSlots;

    public static int EmptySlot
    {
        get
        {
            return emptySlot;
        }

        set
        {
            emptySlot = value;
        }
    }

    // Use this for initialization
    void Start () {
        CreateLayout();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateLayout()
    {
        allSlots = new List<GameObject>();
        // na pocetku su svi slobodni
        EmptySlot = slots;

        inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;
        inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

        inventoryRect = gameObject.GetComponent<RectTransform>();

        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);

        int colums = slots / rows;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < colums; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);

                RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                newSlot.name = "Slot";

                newSlot.transform.SetParent(this.transform.parent);

                float osaX = slotPaddingLeft * (x + 1) + (slotSize * x);
                float osaY = -slotPaddingTop * (y + 1) - (slotSize * y);

                slotRect.transform.localScale = new Vector3(1f, 1f, 1f);

                slotRect.localPosition = inventoryRect.localPosition + new Vector3(osaX,osaY);

                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                allSlots.Add(newSlot);
            }

        }

    }



    public bool AddItemPotion(BasePotionItem item)
    {
        // ako ovaj item ne moze da se stackuje tj da se prelepi preko sebe u slot 
        //onda ga postavljamo na novi slot
        if (item.StackSize == 1)
        {
            PlaceEmpty(item);
            return true;
        }
        else
        {
            //u slucaju da moze da se stavi preko sebe onda idemo ovako
            foreach (GameObject slot  in allSlots)
            {
                //dohbata slot kalsu
                Slot tmp = slot.GetComponent<Slot>();
                //pitamo dal je  slot prazan
                // ako nije a moze da se stackuje
                if (!tmp.IsEmpty)
                {
                    //
                    if (tmp.CurrentItem.ItemType == item.ItemType && tmp.isAvailabele)
                    {
                        tmp.AddPotionItem(item);
                        tmp.CurrentItem.StackSize--;
                        return true;
                    }
                }
            }
            //ako nismo nasli da postavimo item koji moze da se postavi preko drugog onda trazimo novi 
            //slobodan slot i postavljamo ga tu
            if (EmptySlot > 0)
            {
                PlaceEmpty(item);
            }
        }
        return false;
    }

    //ova funkcija ce da preleti kroz sve objekte u slotovima i kad nadje slobodan slot tu ce ubaciti item
    private bool PlaceEmpty(BasePotionItem item)
    {
        // ako je broj praznih slotova  veci od nula
        if (EmptySlot > 0)
        {
            //za svaki slot u slotovima
            foreach (GameObject slot in allSlots)
            {
                //dohvati komponentu slot
                Slot tmp = slot.GetComponent<Slot>();
                //i ukoliko je prazan
                if (tmp.IsEmpty)
                {
                    //pozivamo da se doda item
                    tmp.AddPotionItem(item);
                    //smanjujemo broj slotova
                    EmptySlot--;
                    return true;
                }
            }
        }
        return false;
    }

    public void MoveItem(GameObject clicked)
    {
        if (from == null)
        {
            if (!clicked.GetComponent<Slot>().IsEmpty)
            {
                from = clicked.GetComponent<Slot>();
                from.GetComponent<Image>().color = Color.red;
            }
        }
        else if (to == null)
        {
            to = clicked.GetComponent<Slot>();
        }
        if (to != null && from != null)
        {
            Stack<BasePotionItem> tmpTo = new Stack<BasePotionItem>(to.Potionitems);
            to.AddPotionItems(from.Potionitems);
            if (tmpTo.Count == 0)
            {
                from.ClearSlot();
            }
            else
            {
                from.AddPotionItems(tmpTo);
            }
            from.GetComponent<Image>().color = Color.white;
            to = null;
            from = null;
        }

    }
}
