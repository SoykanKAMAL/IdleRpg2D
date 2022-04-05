using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimatedButton : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent OnTap;
    public Transform animateTarget;
    public float endVal;
    
    private Tween m_AnimationTween;
    private void Start()
    {
        m_AnimationTween = animateTarget.DOPunchScale(new Vector3(0.1f, 0.1f, 0), 0.5f, 10, 1).SetAutoKill(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UiManager.OnNavigationButtonClicked?.Invoke(endVal);
        StartCoroutine(CallOnTap(UiManager.I.GlobalAnimationTime / 2f));
        m_AnimationTween.Restart();
    }

    private IEnumerator CallOnTap(float time)
    {
        yield return new WaitForSeconds(time);
        OnTap.Invoke();
    }
}
