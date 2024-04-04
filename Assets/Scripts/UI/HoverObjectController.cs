using UnityEngine;
using System.Collections;
using TMPro;
using System.Threading.Tasks;

public class HoverObjectController
{
    private GameObject hoverObject;
    private TextMeshProUGUI hoverObjectText;
    public HoverObjectController(GameObject hoverObject, TextMeshProUGUI hoverObjectText)
    {
        this.hoverObject = hoverObject;
        this.hoverObjectText = hoverObjectText;
    }

    public void OnPointerEnter(string newText)
    {
        this.hoverObjectText.text = newText;
        hoverObject.SetActive(true);
    }

    public void OnPointerExit()
    {
        this.hoverObjectText.text = null;
        hoverObject.SetActive(false);
    }

    public async Task LoginFailed(float time, string text)
    {
        hoverObjectText.text = text;
        hoverObject.SetActive(true);
        await Task.Delay((int)(time * 1000));
        hoverObject.SetActive(false);
        hoverObjectText.text = null;
    }
}