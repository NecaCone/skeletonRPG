using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler {

    private Stack<BasePotionItem> potionitems;

    public Text stackText;

    public Sprite slotEmpty;
    public Sprite slotHighlighted;


    //pitamo dal je broj itema == 0
    public bool IsEmpty
    {
       get { return Potionitems.Count == 0; }
    }

    // pitamo da li je slot i item omoguven za stackovanje
    public bool isAvailabele
    {
        get { return CurrentItem.StackSize > Potionitems.Count; }
    }

    // dohbatamo item u slotu koji je stack-ovan  i preko peek dohvatamo poslednji ubaceni
    public BasePotionItem CurrentItem
    {
        get { return Potionitems.Peek(); }
    }

    public Stack<BasePotionItem> Potionitems
    {
        get
        {
            return potionitems;
        }

        set
        {
            potionitems = value;
        }
    }

    // Use this for initialization
    void Start () {
        Potionitems = new Stack<BasePotionItem>();

        RectTransform slotRect = gameObject.GetComponent<RectTransform>();

        RectTransform textRect = stackText.GetComponent<RectTransform>();

        int textScale = (int)(slotRect.sizeDelta.x * 0.60);

        stackText.resizeTextMaxSize = textScale;
        stackText.resizeTextMinSize = textScale;

        textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
        textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Unosimo trenutni item u ovom slucaju potion u stack colekciju 
    //i ispitujemo da li je veca od 1 ukoliko jeste 
    //ispisujemo u slotu broj koliko imamo potion
    public void AddPotionItem(BasePotionItem potion)
    {
        Potionitems.Push(potion);
        if (Potionitems.Count > 1)
        {
            stackText.text = Potionitems.Count.ToString();
        }


        ChangeSprite(potion.SpriteNeutral, potion.SpriteHighlighted);
    }
    public void AddPotionItems(Stack<BasePotionItem> items)
    {
        this.Potionitems = new Stack<BasePotionItem>(items);
        stackText.text = Potionitems.Count > 1 ? Potionitems.Count.ToString() : string.Empty;
        ChangeSprite(CurrentItem.SpriteNeutral, CurrentItem.SpriteHighlighted);
    }

    //pozivamo  ovu funkciu da bi prikazali kako izgleda ovaj item u inventaru
    // tako sto menjamo trenutni izgled sprite preko spritestate i prosledjujemo mu itemov sprite
    private void ChangeSprite(Sprite neutral, Sprite highlighted)
    {
        GetComponent<Image>().sprite = neutral;

        SpriteState spriteState = new SpriteState();

        spriteState.highlightedSprite = highlighted;
        spriteState.pressedSprite = neutral;

        gameObject.GetComponent<Button>().spriteState = spriteState;
    }

    private void UseItem()
    {//ako slot nije prazan
        if(!IsEmpty)
        {

            // uzima prvi item iz stack i iskoristi ga
            Potionitems.Pop().Use();
            //ako je broj potiona veci od 1 ispisacemo broj poutina ako nije necemo
            stackText.text = Potionitems.Count > 1 ? Potionitems.Count.ToString() : string.Empty;
            if (IsEmpty)
            {
                ChangeSprite(slotEmpty, slotHighlighted);
                Inventory.EmptySlot++;

            }

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            UseItem();
        }

    }

    public void ClearSlot()
    {
        potionitems.Clear();
        ChangeSprite(slotEmpty, slotHighlighted);
        stackText.text = string.Empty;
    }

}
