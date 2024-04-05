using UnityEngine;
using UnityEngine.UI;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform positionToSpawn;
    [SerializeField] private LeaderboardEntityView entityView;
    [SerializeField] private string leaderboardId;
    [SerializeField] private Button backButton;
    private LeaderboardController controller;
    public void Init(LeaderboardController controller) => this.controller = controller;
    private void Start()
    {
        backButton.onClick.AddListener(controller.OnBackButtonClick);
    }
    public Transform SpawnPosition { get { return positionToSpawn; } }
    public LeaderboardEntityView EntityView { get { return entityView; } }
    public string LeaderboardId { get { return leaderboardId; } }
}