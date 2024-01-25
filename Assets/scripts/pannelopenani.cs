using UnityEngine;
using UnityEngine.UI;
using static LeanTween;

public class pannelopenani : MonoBehaviour
{
    
    public RectTransform panelTransform;
    public float openDuration = 0.5f;
    public float closeDuration = 0.3f;
    public LeanTweenType openEaseType = LeanTweenType.easeOutExpo;
    public LeanTweenType closeEaseType = LeanTweenType.easeInExpo;

    private Vector3 originalScale;
    private Vector3 openScale;
    private Vector3 closedScale;
    private bool isOpen = false;

    private void Start()
    {
        // originalScale = panelTransform.localScale;
        panelTransform.localScale = Vector3.zero;
        openScale = Vector3.one;
        closedScale = Vector3.zero;
    }

    public void TogglePanel()
    {
        if (isOpen)
        {
            ClosePanel();
        }
        else
        {
            OpenPanel();
        }
    }

    public void OpenPanel()
    {

        LeanTween.scale(panelTransform, openScale, openDuration)
            .setEase(openEaseType);

        isOpen = true;
    }

    public void ClosePanel()
    {
        LeanTween.scale(panelTransform, closedScale, closeDuration)
            .setEase(closeEaseType);

        isOpen = false;
    }
}
