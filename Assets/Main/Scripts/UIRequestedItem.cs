using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRequestedItem : MonoBehaviour {

    [SerializeField]
    Toggle _isReadyTgl;
    [SerializeField]
    Text _itemNameTxt;
    [SerializeField]
    Image _itemImg;

    public void Init(InvenoryItemData data)
    {
        _isReadyTgl.isOn = data.IsReady;
        _itemNameTxt.text = data.Name;
        _itemImg.sprite = data.Img;
    }
}
