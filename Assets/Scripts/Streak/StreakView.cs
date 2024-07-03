using UnityEngine;
using TMPro;
using System.Collections;

public class StreakView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI streakText;
    private StreakController streakController;
    private Coroutine setStreakTextCoroutine;
    public void Init(StreakController streakController)
    {
        this.streakController = streakController;
    }
    public void SetStreakText(int amount)
    {
        if (setStreakTextCoroutine != null)
        {
            StopCoroutine(setStreakTextCoroutine);
        }
        setStreakTextCoroutine = StartCoroutine(SetTextCoroutine(amount));
    }

    private IEnumerator SetTextCoroutine(int amount)
    {
        streakText.gameObject.SetActive(true);
        streakText.text = string.Format("Streak: {0}", amount);
        yield return new WaitForSeconds(2f);
        streakText.gameObject.SetActive(false);
    }
}
