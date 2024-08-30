using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RottbleItem : Interctable
{
    const float interval = 0.5f;

    Vector3 _initialRotation;
    [SerializeField]
    Vector3 _destinationRotation;

    bool isFirst = true;

    private void Start()
    {
        _initialRotation = transform.localRotation.eulerAngles;
    }

    public override void Interact()
    {
        base.Interact();
        Vector3 dest = isFirst ? _destinationRotation : _initialRotation;
        transform.DOLocalRotate(dest, interval);
        isFirst = !isFirst;
    }
}
