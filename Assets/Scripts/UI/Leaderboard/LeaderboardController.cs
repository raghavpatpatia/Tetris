using Newtonsoft.Json;
using System;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine;

public class LeaderboardController
{
    private LeaderboardView view;
    private EventService eventService;
    private ScoreController scoreController;
    private LeaderboardPool leaderboardPool;
    private const string LeaderboardId = "TetrisLeaderboard";
    public LeaderboardController(LeaderboardView view, EventService eventService, ScoreController scoreController) 
    {
        Initialize();
        this.view = view;
        view.Init(this);
        this.eventService = eventService;
        this.scoreController = scoreController;
        leaderboardPool = new LeaderboardPool(view.EntityView, view.SpawnPosition);
        SubscribeEvents();
    }

    private async void Initialize()
    {
        try
        {
            await UnityServices.InitializeAsync();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void SubscribeEvents()
    {
        eventService.GameOver.AddListener(AddScore);
    }

    public async void GetAllLeaderboardEntries()
    {
        var options = new GetScoresOptions
        {
            Limit = 50,
            Offset = 0,
        };

        try
        {
            var page = await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId, options);
            foreach (var entry in page.Results)
            {
                leaderboardPool.GetLeaderboardEntityController().SetData((int)entry.Score, entry.Tier, entry.PlayerName);
            }
        }
        catch (RequestFailedException ex)
        {
            Debug.LogError("Failed to get leaderboard entries: " + ex.Message);
        }
    }

    public void OnBackButtonClick()
    {
        eventService.PlaySoundEffect.Invoke(Sounds.ButtonClick);
        leaderboardPool.ReturnAllItems();
    }

    private async void AddScore()
    {
        var playerEntry = await LeaderboardsService.Instance.AddPlayerScoreAsync(LeaderboardId, scoreController.GetCurrentScore());
        Debug.Log(JsonConvert.SerializeObject(playerEntry));
    }
    ~LeaderboardController()
    {
        eventService.GameOver.RemoveListener(AddScore);
    }
}