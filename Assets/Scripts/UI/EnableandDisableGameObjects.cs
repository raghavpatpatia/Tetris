using UnityEngine;
using UnityEngine.UI;

public class EnableandDisableGameObjects : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject[] gameObjectsToBeEnabled;
    [SerializeField] private GameObject[] gameObjectsToBeDisabled;

    private void Start()
    {
        if (button != null)
            button.onClick.AddListener(EnableandDisableObjects);
    }

    private void EnableandDisableObjects()
    {
        foreach (GameObject item in gameObjectsToBeEnabled)
            item.SetActive(true);

        foreach (GameObject item in gameObjectsToBeDisabled)
            item.SetActive(false);
    }
}