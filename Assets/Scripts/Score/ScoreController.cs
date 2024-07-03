using TMPro;
public class ScoreController
{
    private TextMeshProUGUI scoreText;
    private int Score;
    private EventService eventService;
    public ScoreController(TextMeshProUGUI scoreText, EventService eventService)
    {
        this.scoreText = scoreText;
        this.Score = 0;
        this.eventService = eventService;
        SubscribeEvents();
    }

    private void SubscribeEvents() 
    {
        eventService.AddScore.AddListener(AddScore);
        eventService.RestartGame.AddListener(ResetScore);
    }

    private void AddScore(int score)
    {
        Score += score;
        scoreText.text = Score.ToString();
        eventService.PlaySoundEffect.Invoke(Sounds.ScorePoints);
    }

    private void ResetScore()
    {
        Score = 0;
        scoreText.text = Score.ToString();
    }

    public int GetCurrentScore() => Score;

    ~ScoreController()
    {
        eventService.AddScore.RemoveListener(AddScore);
        eventService.RestartGame.RemoveListener(ResetScore);
    }
}