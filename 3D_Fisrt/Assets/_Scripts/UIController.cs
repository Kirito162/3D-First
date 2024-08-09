using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField] private float minY;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float streng =0.1f;
    [SerializeField] private int vibrato=2;
    [SerializeField] private float randomness=50f;
    //[SerializeField] private float minY;

    void Start()
    {

        transform.DOLocalMoveX(minY, duration).SetEase(Ease.OutSine);
        //transform.DOScale(0.8f,duration).SetEase(Ease.OutSine);
        transform.DOShakeScale(duration, streng, vibrato, randomness, true, ShakeRandomnessMode.Full).SetLoops(-1);
    }


}
