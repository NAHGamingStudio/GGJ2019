using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : Interctable
{
    [SerializeField]
    private string _myName;

    public string MyName
    {
        get
        {
            return _myName;
        }
    }

    [SerializeField]
    private Sprite _mySprite;

    public Sprite MySprite
    {
        get
        {
            return _mySprite;
        }
    }

    public override void Interact()
    {
        base.Interact();
        InventoryManager.Instance.CollectItem(gameObject);
        
        gameObject.SetActive(false);
    }
}
