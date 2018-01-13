using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public enum ArmorTypes
    {
        HEAD,
        CHEST,
        LEGS,
        HANDS
    }
    public class BaseArmorItem : BaseEquipmentItem
    { 
       

        private ArmorTypes armorType;

        public BaseArmorItem()
        {
        }
        public BaseArmorItem(
            string itemName,
            string itemDescription,
            int itemId,
            EquipmentTypes equipmentType,
            ItemTypes itemType,
            ArmorTypes armorType,
            int stackSize,
            Sprite spriteNeutral,
            Sprite spriteHighlighted,
            int stamina,
            int strenght,
            int agility,
            int endurance,
            int intelect,
            int resistance,
            int magicResistance
            )
            : base(
                itemName,
                itemDescription,
                itemId,
                equipmentType,
                itemType,
                stackSize,
                spriteNeutral,
                spriteHighlighted,
                stamina,
                strenght,
                agility,
                endurance,
                intelect,
                resistance,
                magicResistance
             )
        {
            this.armorType = armorType;
        }
        

        public ArmorTypes ArmorType
        {
            get
            {
                return armorType;
            }

            set
            {
                armorType = value;
            }
        }

       
    }
}
