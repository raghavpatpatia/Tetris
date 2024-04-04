using UnityEngine;
using UnityEngine.UI;

public class GameOverController
{
    private GameObject GameOverPanel;
    private Button RestartButton;
    private Button QuitButton;
    private EventService eventService;
    public GameOverController(GameObject GameOverPanel, Button RestartButton, Button QuitButton, EventService eventService)
    {
        this.GameOverPanel = GameOverPanel;
        this.RestartButton = RestartButton;
        this.QuitButton = QuitButton;
        this.eventService = eventService;
        SubscribeEvents();
        OnButtonClick();
    }

    private void SubscribeEvents() 
    {
        eventService.GameOver.AddListener(GameOver);
    }
    private void OnButtonClick() 
    {
        RestartButton.onClick.AddListener(OnRestartButtonClick);
        QuitButton.onClick.AddListener(OnQuitButtonClick);
    }
    private void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1f;
        eventService.RestartGame.Invoke();
        eventService.PlaySoundEffect.Invoke(Sounds.ButtonClick);
    } 

    private void OnQuitButtonClick()
    {
        eventService.QuitGame.Invoke();
    }

    ~GameOverController()
    {
        eventService.GameOver.RemoveListener(GameOver);
    }
}