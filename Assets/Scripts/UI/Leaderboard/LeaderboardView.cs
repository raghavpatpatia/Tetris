using System;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform positionToSpawn;
    [SerializeField] private LeaderboardEntityView entityView;
    [SerializeField] private Button backButton;
    private LeaderboardController controller;
    public void Init(LeaderboardController controller) => this.controller = controller;
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
        backButton.onClick.AddListener(controller.OnBackButtonClick);
    }
    public Transform SpawnPosition { get { return positionToSpawn; } }
    public LeaderboardEntityView EntityView { get { return entityView; } }
}