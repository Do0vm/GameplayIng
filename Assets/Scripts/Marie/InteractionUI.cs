using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    private static InteractionUI _instance;
    public static InteractionUI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InteractionUI>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("InteractionUI");
                    go.AddComponent<Canvas>();
                    go.AddComponent<CanvasScaler>();
                    go.AddComponent<GraphicRaycaster>();
                    _instance = go.AddComponent<InteractionUI>();
                }
            }
            return _instance;
        }
    }

    public TextMeshProUGUI interactionText;

    private void Start()
    {
        // Ensure the InteractionUI GameObject has a Canvas, CanvasScaler, and GraphicRaycaster component
        Canvas canvas = GetComponent<Canvas>();
        if (canvas == null)
        {
            canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
        if (canvasScaler == null)
        {
            canvasScaler = gameObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
        }

        GraphicRaycaster graphicRaycaster = GetComponent<GraphicRaycaster>();
        if (graphicRaycaster == null)
        {
            gameObject.AddComponent<GraphicRaycaster>();
        }

        // Get the TextMeshProUGUI component
        interactionText = GetComponentInChildren<TextMeshProUGUI>();
        if (interactionText == null)
        {
            GameObject textGO = new GameObject("InteractionText");
            textGO.transform.SetParent(transform, false);
            interactionText = textGO.AddComponent<TextMeshProUGUI>();
            interactionText.alignment = TextAlignmentOptions.Center;
            interactionText.fontSize = 24;
        }
    }

    public void ShowInteraction(string text)
    {
        interactionText.gameObject.SetActive(true);
        interactionText.text = text;
    }

    public void HideInteraction()
    {
        interactionText.gameObject.SetActive(false);
    }
}