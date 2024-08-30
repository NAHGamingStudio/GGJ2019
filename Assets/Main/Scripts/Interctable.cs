using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interctable : MonoBehaviour {
    [SerializeField]
    protected string[] _actions;

    public UnityEvent _onActionChanged = new UnityEvent();
    protected int _currentAction;
    public string Action
    {
        get
        {
            return _actions[_currentAction];
        }
    }
    public virtual void Interact()
    {
        if (_actions.Length > 1)
        {
            _currentAction = (int)Mathf.Repeat(_currentAction + 1, _actions.Length);
            _onActionChanged.Invoke();
        }
        Debug.Log(_currentAction);
    }
}
