using System;
using System.Collections;
using UnityEngine;

public class StreakController : IDisposable
{
    private StreakView streakView;
    private EventService eventService;
    private int streakCount;
    private int maxStreakCount;
    private const float streakTimeout = 2.0f;
    private int scorePerRow;
    private Coroutine streakCoroutine;
    public StreakController(StreakView streakView, EventService eventService, int scorePerRow)
    {
        this.streakView = streakView;
        this.streakView.Init(this);
        this.eventService = eventService;
        this.scorePerRow = scorePerRow;
        this.streakCount = 0;
        this.maxStreakCount = 0;
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        eventService.OnLineCleared.AddListener(OnLineCleared);
        eventService.GameOver.AddListener(OnGameOver);
    }

    private void OnLineCleared()
    {
        if (streakCoroutine != null)
        {
            streakCount++;
            maxStreakCount = Mathf.Max(maxStreakCount, streakCount);
            streakView.SetStreakText(streakCount);
            streakView.StopCoroutine(streakCoroutine);
        }
        else
        {
            streakCount = 1;
            maxStreakCount = 1;
            streakView.SetStreakText(streakCount);
        }

        streakCoroutine = streakView.StartCoroutine(ResetStreakAfterDelay());
    }

    private IEnumerator ResetStreakAfterDelay()
    {
        yield return new WaitForSeconds(streakTimeout);
        ResetStreak();
    }

    private void ResetStreak()
    {
        if (streakCount > 0)
        {
            int scoreToAdd = scorePerRow * maxStreakCount;
            eventService.AddScore.Invoke(scoreToAdd);
        }
        streakCount = 0;
        maxStreakCount = 0;
        streakView.SetStreakText(streakCount);
    }

    private void OnGameOver()
    {
        if (streakCoroutine != null)
        {
            streakView.StopCoroutine(streakCoroutine);
            streakCoroutine = null;
        }
        ResetStreak();
    }


    private void UnsubscribeEvents()
    {
        eventService.OnLineCleared.RemoveListener(OnLineCleared);
        eventService.GameOver.RemoveListener(OnGameOver);
    }
    public void Dispose() => UnsubscribeEvents();
}