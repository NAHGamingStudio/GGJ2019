using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interacting : MonoBehaviour {
    [SerializeField]
    LayerMask _interactableLayer;
    [SerializeField]
    Pointer _myPointer;
    [SerializeField]
    UIMessage _myUIMessage;

    Interctable _selectedObject;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        bool isHit = Physics.Raycast(ray, out hit, _interactableLayer);

        if(isHit)
        {
            Interctable interactable = hit.transform.gameObject.GetComponent<Interctable>();
            if(interactable != null)
            {
                SetSelected(interactable);
            }
            else
            {
                DeSelect();
            }
        }
        else
        {
            DeSelect();
        }

        if(_selectedObject && Input.GetMouseButtonDown(0))
        {
            _selectedObject.Interact();
        }
    }


    void SetSelected(Interctable interactable)
    {
        
        if(interactable != _selectedObject)
        {
            _myPointer.Select();
            _myUIMessage.SetMessage(interactable.Action);
            _selectedObject = interactable;
            interactable._onActionChanged.AddListener(ChangeMessage);
        }
    }
    void DeSelect()
    {
        if (!_selectedObject) return;
        _selectedObject._onActionChanged.RemoveListener(ChangeMessage);
        _selectedObject = null;
        _myPointer.Deselect();
        _myUIMessage.ClearMessage();
    }

    void ChangeMessage()
    {
        _myUIMessage.SetMessage(_selectedObject.Action);
    }
}
