using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovableItem : Interctable {

    const float interval = 0.5f;

    Vector3 _initialPosition;
    [SerializeField]
    Vector3 _destinationPosition;

    bool isFirst = true;

    public override void Interact()
    {
        base.Interact();
        Vector3 dest = isFirst ? _destinationPosition : _initialPosition;
        transform.DOLocalMove(dest, interval);
        isFirst = !isFirst;
    }

    private void Start()
    {
        _initialPosition = transform.localPosition;
    }




}
