using UnityEngine;

public class LeaderboardEntityController
{
    private LeaderboardEntityView view;
    public LeaderboardEntityController(LeaderboardEntityView view, Transform position)
    {
        this.view = GameObject.Instantiate<LeaderboardEntityView>(view, position);
    }

    public void SetData(int score, string tier, string playerName)
    {
        view.gameObject.SetActive(true);
        view.SetScore(score);
        view.SetTier(tier);
        view.SetPlayerName(playerName);
    }

    public void DisableView()
    {
        view.gameObject.SetActive(false);
    }
}