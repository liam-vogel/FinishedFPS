using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{

    private void Start()
    {
        defaultSprite = GetComponent<Image>().sprite;
        amountText = transform.GetChild(0).GetComponent<Text>();
    }

    public bool hasItem = false;

    Sprite defaultSprite;
    Text amountText;

    private void Update()
    {
        CheckForItem();
    }

    public void CheckForItem()
    {
        if(transform.childCount > 1 )
        {
            Item i = transform.GetChild(4).GetComponent<Item>();
            hasItem = true;
            GetComponent<Image>().sprite = i.itemSprite;

        }
        else
        {
            GetComponent<Image>().sprite = defaultSprite;
            amountText.text = "100x";
        }
        
    }


}
