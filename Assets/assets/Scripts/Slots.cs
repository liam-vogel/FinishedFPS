using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public GameObject playerDropPos;
    public void CustomStart()
    {
        defaultSprite = GetComponent<Image>().sprite;
        amountText = transform.GetChild(0).GetComponent<Text>();
    }

    public void DropItem()
    {
        if (slotsItem)
        {
            slotsItem.transform.parent = null;
            slotsItem.gameObject.SetActive(true);
            slotsItem.transform.position = playerDropPos.transform.position;
        }
    }
    public Item slotsItem;

    Sprite defaultSprite;
    Text amountText;

   

    public void CheckForItem()
    {
        if(transform.childCount > 1 )
        {
          slotsItem = transform.GetChild(1).GetComponent<Item>();
       
            GetComponent<Image>().sprite = slotsItem.itemSprite;
            if(slotsItem.amountInStack > 0)
            {
                amountText.text = slotsItem.amountInStack.ToString();
            }

        }
        else
        {
            slotsItem = null;
            GetComponent<Image>().sprite = defaultSprite;
            amountText.text = "0x";
        }
        
    }


}
