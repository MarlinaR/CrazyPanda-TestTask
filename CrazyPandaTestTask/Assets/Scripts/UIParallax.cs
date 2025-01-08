using UnityEngine;
using UnityEngine.UI;

public class UIParallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public RectTransform uiElement;  // UI element to apply parallax
        public float parallaxFactor = 0.1f;  // How strong the parallax effect is
        [HideInInspector] public Vector2 originalPosition;  // Store original position
    }

    public ParallaxLayer[] layers;
    public float sensitivity = 0.1f;
    public bool parallaxOnYAxis = true;  // Toggle for parallax on Y-axis
    private Vector2 screenCenter;

    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        
        foreach (ParallaxLayer layer in layers)
        {
            if (layer.uiElement != null)
            {
                layer.originalPosition = layer.uiElement.anchoredPosition;
            }
        }
    }

    void Update()
    {
        Vector2 mouseDelta = (Vector2)Input.mousePosition - screenCenter;
        
        foreach (ParallaxLayer layer in layers)
        {
            if (layer.uiElement != null)
            {
                Vector3 newPosition = layer.originalPosition;
                newPosition.x += -mouseDelta.x * layer.parallaxFactor * sensitivity;
                if (parallaxOnYAxis)
                {
                    newPosition.y += -mouseDelta.y * layer.parallaxFactor * sensitivity;
                }
                layer.uiElement.anchoredPosition = newPosition;
            }
        }
    }
}