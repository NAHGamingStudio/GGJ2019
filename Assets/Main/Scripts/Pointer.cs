using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {
    const float AnimationTime = 0.2f;
    [SerializeField]
    float _selectedScale;
    public void Select()
    {
        transform.DOScale(_selectedScale, AnimationTime);
    }

    public void Deselect()
    {
        transform.DOScale(1, AnimationTime);
    }
}
