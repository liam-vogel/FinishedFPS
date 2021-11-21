using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryScript : MonoBehaviour
{
    public GameObject inventoryObject;

    public Slots[] slots;



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryObject.SetActive(!inventoryObject.activeInHierarchy);
        }
    }

    public void AddItem(Item itemToAdd, Item startingItem = null)
    {
        foreach(Slots i in slots)
        {
            if (!i.hasItem)
            {
                itemToAdd.transform.parent = i.transform;
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Item>())
        {
            AddItem(col.GetComponent<Item>());
        }
    }


}
