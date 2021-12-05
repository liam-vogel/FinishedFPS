using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropScript : MonoBehaviour
{

    public InventoryScript inv;

    GameObject curSlot;
    Item curSlotItem;
    private Item slotsItem;
    
    public GameObject playerDropPos;
    public Image followMouseImage;


   
    private void Update()
    {
        followMouseImage.transform.position = Input.mousePosition;

        if(Input.GetKeyDown(KeyCode.G))
        {
            GameObject obj = GetGameObjectUnderMouse();
            if (obj)
                obj.GetComponent<Slots>().DropItem();
        }


        if(Input.GetMouseButtonDown(0))
        {
          //  GameObject obj = GetGameObjectUnderMouse();
            curSlot = GetGameObjectUnderMouse();
        }
        else if(Input.GetMouseButton(0))
        {
            if(curSlot && curSlot.GetComponent<Slots>().slotsItem)
            {
                followMouseImage.color = new Color(255, 255, 255, 255);
                followMouseImage.sprite = curSlot.GetComponent<Image>().sprite;
            }
            
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(curSlot && curSlot.GetComponent<Slots>().slotsItem)
            {
                curSlotItem = curSlot.GetComponent<Slots>().slotsItem;

                GameObject newObj = GetGameObjectUnderMouse();

                if (newObj && newObj != curSlot)
                {
                    if (newObj.GetComponent<ArmorSlots>() && newObj.GetComponent<ArmorSlots>().equipmentType != curSlotItem.equipmetType)
                        return;
                  //  if (newObj.GetComponent<HotBar>() && newObj.GetComponent<HotBar>().equipmentType != curSlotItem.equipmetType)
                  //      return;
                    if (newObj.GetComponent<Slots>().slotsItem)
                    {
                        Item objectsItem = newObj.GetComponent<Slots>().slotsItem;
                        if (objectsItem.ItemId == curSlotItem.ItemId && objectsItem.amountInStack != objectsItem.maxStackSize && !newObj.GetComponent<ArmorSlots>())
                        {
                            curSlotItem.transform.parent = null;
                            inv.AddItem(curSlotItem, objectsItem);
                        }
                        else
                        {
                            objectsItem.transform.parent = curSlot.transform;
                            curSlotItem.transform.parent = newObj.transform;
                        }

                    }

                    else
                    {
                        curSlotItem.transform.parent = newObj.transform;
                    }
                }
            }
        }
        else
        {
            followMouseImage.sprite = null;
            followMouseImage.color = new Color(0, 0, 0, 0);
        }
    
     foreach(Slots i in inv.equipSlots)
        {
            i.GetComponent<ArmorSlots>().Equip();
        }
    }   


    GameObject GetGameObjectUnderMouse()
    {
        GraphicRaycaster raycaster = GetComponent<GraphicRaycaster>();
        PointerEventData eventData = new PointerEventData(EventSystem.current);

        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(eventData, results);

        foreach(RaycastResult i in results)
        {
            if (i.gameObject.GetComponent<Slots>())
                return i.gameObject;
        }
        return null;
    }
   
}
