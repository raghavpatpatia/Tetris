using System.Collections.Generic;
using UnityEngine;

public class LeaderboardPool : GenericObjectPool<LeaderboardEntityController>
{
    private LeaderboardEntityView entityView;
    private Transform position;
    private List<LeaderboardEntityController> leaderboardEntityControllers;

    public LeaderboardPool(LeaderboardEntityView entityView, Transform position)
    {
        this.entityView = entityView;
        this.position = position;
        this.leaderboardEntityControllers = new List<LeaderboardEntityController>();
    }

    public void ReturnAllItems()
    {
        foreach (LeaderboardEntityController controller in leaderboardEntityControllers)
        {
            controller.DisableView();
            ReturnItem(controller);
        }
    }

    public LeaderboardEntityController GetLeaderboardEntityController() => GetItem();

    protected override LeaderboardEntityController CreateItem()
    {
        LeaderboardEntityController item = new LeaderboardEntityController(entityView, position);
        leaderboardEntityControllers.Add(item);
        return item;
    }
}