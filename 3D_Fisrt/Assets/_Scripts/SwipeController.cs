using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;
    [SerializeField] float tweenTime;
    //[SerializeField] dot

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
    }
    public void Next()
    {
        if(currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }
    public void Previous()
    {
        if(currentPage > 1) 
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }
    private void MovePage()
    {
        levelPagesRect.DOLocalMove(targetPos, tweenTime).SetEase(Ease.OutCubic);
    }

}
