using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private string leaderboardId;
    private EventService eventService;
    private ScoreController scoreController;

    private async void Awake()
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


    private void Start()
    {
        SubscribeEvents();
    }

    public void Init(EventService eventService, ScoreController scoreController)
    {
        this.eventService = eventService;
        this.scoreController = scoreController;
    }

    private void SubscribeEvents()
    {
        eventService.GameOver.AddListener(AddScore);
    }

    public async Task GetPlayerScore()
    {
        try
        {
            var score = await LeaderboardsService.Instance.GetPlayerScoreAsync(leaderboardId);
            Debug.Log(JsonConvert.SerializeObject(score));
            Debug.Log("Player score received successfully.");
        }
        catch (RequestFailedException ex)
        {
            Debug.LogError("Failed to add/update player score: " + ex.Message);
        }
    }

    private async void AddScore()
    {
        var playerEntry = await LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboardId, scoreController.GetCurrentScore());
        Debug.Log(JsonConvert.SerializeObject(playerEntry));
    }

    private void OnDisable()
    {
        eventService.GameOver.RemoveListener(AddScore);
    }
}
