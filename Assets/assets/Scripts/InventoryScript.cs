using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryScript : MonoBehaviour
{
    public GameObject inventoryObject;
    [SerializeField]
    public GameObject healthBar;
    [SerializeField]
    public GameObject staminaBar;
     [SerializeField]
    public GameObject crossHair;
    public Slots[] slots;

   // PlayerStats stats; 

    void Start()
    {
        inventoryObject.SetActive(false);
    } 
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryObject.SetActive(!inventoryObject.activeInHierarchy);
           
           
        }

         if( (inventoryObject.activeInHierarchy))
            {
                 staminaBar.SetActive(false);
                 healthBar.SetActive(false);
                 crossHair.SetActive(false);
            }
            else
            {
                 staminaBar.SetActive(true);
                 healthBar.SetActive(true);
                 crossHair.SetActive(true);
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
