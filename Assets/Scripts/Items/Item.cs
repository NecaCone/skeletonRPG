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
        public BaseWeaponItem baseWeaponItem;
        
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
            if (gameObject.name != string.Empty)
            {
                caser = gameObject.name;
                CreateClickedItem(caser);
            }
            basePotionItem = CreateNewPotion.newPotion;

            Player.GetComponent<ClickToMove>().item = gameObject;
        }
        
        void CreateClickedItem(string caser)
        {
            switch (caser)
            {
                case "Mana":
                    CreateNewPotion.CreatePotion(1,spriteNeutral,spriteHighlighted, maxSize);
                    break;
                case "Health":
                    CreateNewPotion.CreatePotion(2, spriteNeutral, spriteHighlighted, maxSize);
                    break;
                case "Strenght":
                    CreateNewPotion.CreatePotion(3, spriteNeutral, spriteHighlighted, maxSize);
                    break;
                case "Agility":
                    CreateNewPotion.CreatePotion(4, spriteNeutral, spriteHighlighted,maxSize);
                    break;
            }
        }

    }
}
