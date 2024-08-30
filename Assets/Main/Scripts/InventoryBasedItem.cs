using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryBasedItem : Interctable {

    [SerializeField]
    protected InventoryItem[] RequiredItems;
    [SerializeField]
    protected UnityEvent _onInteract;

    public override void Interact()
    {
        base.Interact();
        if (IsReady())
        {
            Debug.Log("ready");
            _onInteract.Invoke();
        }
        else
        {
            Debug.Log("knot ready");
            UIRequisedMenu.Instance.Init(GetItems());
        }
    }
    InvenoryItemData[] GetItems()
    {
        InvenoryItemData[] items = new InvenoryItemData[RequiredItems.Length];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new InvenoryItemData(InventoryManager.Instance.CheckItemAvailability(RequiredItems[i].gameObject), RequiredItems[i].MyName, RequiredItems[i].MySprite);
        }
        return items;
    }

    bool IsReady()
    {
        bool isReady = true;
        for (int i = 0; i < RequiredItems.Length; i++)
        {
            isReady &= InventoryManager.Instance.CheckItemAvailability(RequiredItems[i].gameObject);
        }
        return isReady;
    }

}

public class InvenoryItemData
{
    public bool IsReady
    {
        get;
        private set;
    }

    public string Name
    {
        get;
        private set;
    }

    public Sprite Img
    {
        get;
        private set;
    }

    public InvenoryItemData(bool isReady, string name, Sprite img)
    {
        IsReady = isReady;
        Name = name;
        Img = img;
    }
}
