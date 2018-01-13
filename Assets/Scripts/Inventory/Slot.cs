using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    private Stack<BaseItem> items;

    public Text stackText;

    public Sprite slotEmpty;
    public Sprite slotHighlighted;


    public bool IsEmpty
    {
       get { return items.Count == 0; }
    }

    public bool isAvailabele
    {
        get { return CurrentItem.StackSize > items.Count; }
    }
    public BaseItem CurrentItem
    {
        get { return items.Peek(); }
    }

	// Use this for initialization
	void Start () {
        items = new Stack<BaseItem>();

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

    private void ChangeSprite(Sprite neutral, Sprite highlighted)
    {
        GetComponent<Image>().sprite = neutral;

        SpriteState spriteState = new SpriteState();

        spriteState.highlightedSprite = highlighted;
        spriteState.pressedSprite = neutral;

        gameObject.GetComponent<Button>().spriteState = spriteState;
    }

    public void AddItem(BasePotionItem item)
    {
        items.Push(item);
        if (items.Count > 1)
        {
            stackText.text = items.Count.ToString();
        }


        ChangeSprite(item.SpriteNeutral, item.SpriteHighlighted);
    }

}
