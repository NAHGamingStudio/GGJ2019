using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    
    public List<GameObject> InventoryItems;

    [SerializeField]
    GameObject ItemSlot;
    [SerializeField]
    GameObject InventoryContent;

    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<InventoryManager>();
            }
            return _instance;
        }
    }

    public void CollectItem(GameObject item)
    {
        InventoryItems.Add(item);
        if (ItemSlot)
        {
            GameObject temp = Instantiate(ItemSlot);
            temp.GetComponentInChildren<TextMeshPro>().text = "";
            //temp.GetComponentInChildren<Image>().sprite;
            int x = InventoryItems.IndexOf(item);
            temp.GetComponent<Button>().onClick.AddListener(() => { DropItem(x); });
        }
    }

    public GameObject DropItem(int index)
    {
        GameObject temp = InventoryItems[index];
        InventoryItems.Remove(temp);
        return temp;
    }

    public bool CheckItemAvailability(GameObject item)
    {
        bool hasItem = false;
        for (int i = 0; i < InventoryItems.Count; i++)
        {
            if(InventoryItems[i]== item)
            {
                hasItem = true;
                break;
            }
        }
        return hasItem;
    }
}
