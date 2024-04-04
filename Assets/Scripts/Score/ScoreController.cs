using TMPro;
public class ScoreController
{
    private TextMeshProUGUI scoreText;
    private int Score;
    private int scorePerRow;
    private EventService eventService;
    public ScoreController(TextMeshProUGUI scoreText, int scorePerRow, EventService eventService)
    {
        this.scoreText = scoreText;
        this.scorePerRow = scorePerRow;
        this.Score = 0;
        this.eventService = eventService;
        SubscribeEvents();
    }

    private void SubscribeEvents() 
    {
        eventService.AddScore.AddListener(AddScore);
        eventService.RestartGame.AddListener(ResetScore);
    }

    private void AddScore()
    {
        Score += scorePerRow;
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