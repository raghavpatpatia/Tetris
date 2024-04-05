using TMPro;
using UnityEngine;

public class LeaderboardEntityView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI tier;
    [SerializeField] private TextMeshProUGUI score;

    public void SetScore(int score) => this.score.text = score.ToString();
    public void SetTier(string tier) => this.tier.text = tier;
    public void SetPlayerName(string playerName) => this.playerName.text = playerName;
}