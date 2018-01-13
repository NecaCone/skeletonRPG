using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Item : MonoBehaviour
    {

        GameObject Player;

        public BasePotionItem basePotionItem;

        public Sprite spriteNeutral;
        public Sprite spriteHighlighted;

        public int maxSize;

        private string caser;

        private void Start()
        {
            
        }

        private void Update()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        public void OnMouseDown()
        {
            ClickToMove.pickingMode = true;
            if (gameObject.name == "Health" || gameObject.name == "Mana")
            {
                caser = gameObject.name;
                switch (caser)
                {
                    case "Mana":
                        basePotionItem.PotionType = PotionTypes.ENDURANCE;
                        basePotionItem.Agility = 0;
                        basePotionItem.Strenght = 0;
                        basePotionItem.Stamina = 0;
                        basePotionItem.Intelect = 0;
                        basePotionItem.Endurance = 50;
                        basePotionItem.SpellEffect = 0;
                        basePotionItem.ItemID = 0;
                        basePotionItem.ItemDescription = "";
                        basePotionItem.ItemName = "Mana";
                        basePotionItem.ItemType = ItemTypes.POTION;
                        basePotionItem.SpriteNeutral = spriteNeutral;
                        basePotionItem.SpriteHighlighted = spriteHighlighted;
                        basePotionItem.StackSize = maxSize;
                        break;
                    case "Health":
                        basePotionItem.PotionType = PotionTypes.HEALTH;
                        basePotionItem.Agility = 0;
                        basePotionItem.Strenght = 0;
                        basePotionItem.Stamina = 50;
                        basePotionItem.Intelect = 0;
                        basePotionItem.Endurance = 0;
                        basePotionItem.SpellEffect = 0;
                        basePotionItem.ItemID = 0;
                        basePotionItem.ItemDescription = "";
                        basePotionItem.ItemName = "Health";
                        basePotionItem.ItemType = ItemTypes.POTION;
                        basePotionItem.SpriteNeutral = spriteNeutral;
                        basePotionItem.SpriteHighlighted = spriteHighlighted;
                        basePotionItem.StackSize = maxSize;
                        break;
                }
            }
            basePotionItem = new BasePotionItem(
                basePotionItem.ItemName, 
                basePotionItem.ItemDescription,
                basePotionItem.ItemID, 
                basePotionItem.Stamina, 
                basePotionItem.Endurance, 
                basePotionItem.Strenght, 
                basePotionItem.Intelect, 
                basePotionItem.Agility, 
                basePotionItem.PotionType,
                basePotionItem.SpellEffect, 
                basePotionItem.ItemType, 
                basePotionItem.SpriteNeutral,
                basePotionItem.SpriteHighlighted, 
                basePotionItem.StackSize);

            Player.GetComponent<ClickToMove>().item = gameObject;
        }

        public void Use()
        {
            switch (basePotionItem.PotionType)
            {
                case PotionTypes.HEALTH:
                    Debug.Log("Used health");
                    break;
                case PotionTypes.ENDURANCE:
                    Debug.Log("Used endurance");
                    break;
                case PotionTypes.STRENGHT:
                    break;
                case PotionTypes.AGILITY:
                    break;
            }
        }


    }
}
