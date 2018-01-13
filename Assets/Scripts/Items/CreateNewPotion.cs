using UnityEngine;
using System.Collections;
using System;

public class CreateNewPotion
{
    public static BasePotionItem newPotion;

    private static string[] potionLevelName = new string[7] { "Common", "Good", "Medium", "Very good", "Nice", "Impresive", "Exelent" };
   

    public static void CreatePotion(int potionType,Sprite spriteNeutral, Sprite spriteHighlighted, int stackSize)
    {
        newPotion = new BasePotionItem();

        string typePotion = ChoosePotionType(potionType);

        int indexLevelName = UnityEngine.Random.Range(0, (potionLevelName.Length));

        if (indexLevelName == 0)
        {
            newPotion.ItemDescription = "Common " + typePotion + " most of poor people use it mob and helots";
        }
        else if (indexLevelName == 1)
        {
            newPotion.ItemDescription = "Good " + typePotion + " use by milit and light infantry";
            PowerPotionMultiplier(1, potionType);
        }
        else if (indexLevelName == 2)
        {
            newPotion.ItemDescription = "Medium " + typePotion + " veri useful";
            PowerPotionMultiplier(2, potionType);
        }
        else if (indexLevelName == 3)
        {
            newPotion.ItemDescription = "Very good " + typePotion + " used by medium troops";
            PowerPotionMultiplier(3, potionType);
        }
        else if (indexLevelName == 4)
        {
            newPotion.ItemDescription = "Nice " + typePotion + " used by legio protectores";
            PowerPotionMultiplier(4, potionType);
        }
        else if (indexLevelName == 5)
        {
            newPotion.ItemDescription = "Impresive " + typePotion + " wore by generals and centurions";
            PowerPotionMultiplier(5, potionType);
        }
        else if (indexLevelName == 6)
        {
            newPotion.ItemDescription = "Exelend " + typePotion + " is epic pice of art work";
            PowerPotionMultiplier(6, potionType);
        }

        newPotion.ItemName = potionLevelName[indexLevelName] + typePotion;
        newPotion.ItemType = ItemTypes.POTION;
        newPotion.StackSize = stackSize;
        newPotion.SpriteNeutral = spriteNeutral;
        newPotion.SpriteHighlighted = spriteHighlighted;
        newPotion = new BasePotionItem(
             newPotion.ItemName,
             newPotion.ItemDescription,
             newPotion.ItemID,
             newPotion.ItemType,
             newPotion.StackSize,
             newPotion.SpriteNeutral,
             newPotion.SpriteHighlighted,
             newPotion.PotionType,
             newPotion.Stamina,
             newPotion.Endurance,
             newPotion.Agility,
             newPotion.Strenght
            );
        
    }


    public static string ChoosePotionType(int tempPT)
    {

        switch (tempPT)
        {
            case 1:
                newPotion.PotionType = PotionTypes.ENDURANCE;
                newPotion.Stamina = 0;
                newPotion.Strenght = 0;
                newPotion.Agility = 0;
                newPotion.Endurance = 20;
                break;
            case 2:
                newPotion.PotionType = PotionTypes.HEALTH;
                newPotion.Stamina = 20;
                newPotion.Strenght = 0;
                newPotion.Agility = 0;
                newPotion.Endurance = 0;
                break;
            case 3:
                newPotion.PotionType = PotionTypes.STRENGHT;
                newPotion.Stamina = 0;
                newPotion.Strenght = 1;
                newPotion.Agility = 0;
                newPotion.Endurance = 0;
                break;
            case 4:
                newPotion.PotionType = PotionTypes.AGILITY;
                newPotion.Stamina = 0;
                newPotion.Strenght = 0;
                newPotion.Agility = 1;
                newPotion.Endurance = 0;
                break;
        }

        if (tempPT == 1)
        {
            return "EnduranceHealth";
        }
        else if (tempPT == 2)
        {
            return "Health";
        }
        else if (tempPT == 3)
        {
            return "Strenght";
        }
        else if (tempPT == 4)
        {
            return "Agility";
        }
        return "No potion";
    }

    private static void PowerPotionMultiplier(int index,int tmpPT)
    {
        switch (tmpPT)
        {
            case 1:
                newPotion.Stamina =+ index * 5;
                break;
            case 2:
                newPotion.Agility = +Convert.ToInt32(Math.Floor(index * 0.5));
                break;
            case 3:
                newPotion.Endurance = +index * 5;
                break;
            case 4:
                newPotion.Strenght = +Convert.ToInt32(Math.Floor(index * 0.5));
                break;

        }


    }
}
