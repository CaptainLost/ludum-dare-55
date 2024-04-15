using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    [SerializeField]
    private float m_hideTime;
    [SerializeField]
    private float m_showTime;
    [SerializeField]
    private Image m_image;
    [SerializeField]
    private Transform m_canvasTransform;

    public void HideScreen(Action onFinishHide)
    {
        m_canvasTransform.gameObject.SetActive(true);

        DOVirtual.Float(0f, 1f, m_hideTime, (value) => { UpdateImage(value); })
            .SetEase(Ease.InCubic)
            .OnComplete(() => { onFinishHide?.Invoke(); });
    }

    public void ShowScreen(Action onFinishShow)
    {
        DOVirtual.Float(1f, 0f, m_showTime, (value) => { UpdateImage(value); })
            .SetEase(Ease.OutCubic)
            .OnComplete(() => { onFinishShow?.Invoke(); m_canvasTransform.gameObject.SetActive(false); });
    }

    private void UpdateImage(float alpha)
    {
        Color newColor = m_image.color;
        newColor.a = alpha;

        m_image.color = newColor;
    }
}
