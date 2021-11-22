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
    [SerializeField]
    public GameObject lookRoot;
    public Slots[] slots;
    MouseLook Look;

   // PlayerStats stats; 

    void Start()
    {
        inventoryObject.SetActive(false);

        foreach (Slots i in slots)
        {
            i. CustomStart();
        }
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
                 lookRoot.SetActive(false);
              //   Look.LockAndUnlockCursor(); Cursor.lockState = CursorLockMode.None;
                // Look.LockAndUnlockCursor(); Cursor.visible = true;
        }
            else
            {
                 staminaBar.SetActive(true);
                 healthBar.SetActive(true);
                 crossHair.SetActive(true);
                 lookRoot.SetActive(true);
                // Look.LockAndUnlockCursor(); Cursor.lockState = CursorLockMode.Locked;
                // Look.LockAndUnlockCursor(); Cursor.visible = false;
            }
   
        foreach (Slots i in slots)
        {
            i.CheckForItem();
        }
    }

    public void AddItem(Item itemToAdd, Item startingItem = null)
    {
        int amountInStack = itemToAdd.amountInStack;

        List<Item> stackableItems = new List<Item>();

        List<Slots> emptySlots = new List<Slots>();

        if (startingItem && startingItem.ItemId == itemToAdd.ItemId && startingItem.amountInStack < startingItem.maxStackSize)
            stackableItems.Add(startingItem);

        foreach (Slots i in slots)
        {
            if(i.slotsItem)
            {
                Item z = i.slotsItem;
                if (z.ItemId == itemToAdd.ItemId && z.amountInStack < z.maxStackSize && z != startingItem)
                    stackableItems.Add(z);


            }
            else
            {
                emptySlots.Add(i);
            }
        
        
            
        }
    
       
        foreach (Item i in stackableItems)
        {
            int amountThatCanBeAdded = i.maxStackSize - i.amountInStack;
            if(amountInStack <= amountThatCanBeAdded)
            {
                i.amountInStack += amountInStack;
                Destroy(itemToAdd.gameObject);
                return;
            }
        }

        itemToAdd.amountInStack = amountInStack;
        if(emptySlots.Count > 0)
        {
            itemToAdd.transform.parent = emptySlots[0].transform;
            itemToAdd.gameObject.SetActive(false);
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
