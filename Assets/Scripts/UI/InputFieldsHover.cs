using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputFieldsHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField, TextArea] private string textToBeDisplayed;
    [SerializeField] private GameObject hoverObject;
    [SerializeField] private TextMeshProUGUI hoverText;
    private HoverObjectController hoverObjectController;
    private void Start()
    {
        hoverObjectController = new HoverObjectController(hoverObject, hoverText);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverObjectController.OnPointerEnter(textToBeDisplayed);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverObjectController.OnPointerExit();
    }
}