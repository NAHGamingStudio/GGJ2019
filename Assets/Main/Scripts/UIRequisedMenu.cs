using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UIRequisedMenu : MonoBehaviour {

    [SerializeField]
    GameObject _UIRequistedItemPrefab;
    [SerializeField]
    Transform _parent;
    [SerializeField]
    CanvasGroup _myCanvasGroub;
    [SerializeField]
    FirstPersonController fps;

    static UIRequisedMenu _instance;

    public static UIRequisedMenu Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<UIRequisedMenu>();
            }
            return _instance;
        }
    }

    public void Init(InvenoryItemData[] data)
    {
        foreach (Transform item in _parent)
        {
            Destroy(item.gameObject);
        }
        for (int i = 0; i < data.Length; i++)
        {
            GameObject obj = Instantiate(_UIRequistedItemPrefab);
            obj.transform.SetParent(_parent);
            obj.transform.localScale = Vector3.one;
            UIRequestedItem item = obj.GetComponent<UIRequestedItem>();
            item.Init(data[i]);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _myCanvasGroub.alpha = 1;
            fps.enabled = false;
            
        }
    }

    public void Close()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _myCanvasGroub.alpha = 0;
        fps.enabled = true;
    }
}
