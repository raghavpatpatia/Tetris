using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Board")]
    [SerializeField] private BoardView boardView;
    [SerializeField] private BoardScriptableObject boardScriptableObject;
    [Header("TetrominoDataScriptableObjectList")]
    [SerializeField] private TetrominoDataScriptableObjectList tetrominoDataScriptableObject;
    [Header("Piece")]
    [SerializeField] private PieceView pieceView;
    [SerializeField] private PieceScriptableObject pieceScriptableObject;
    [Header("Ghost Piece")]
    [SerializeField] private GhostPieceScriptableObject ghostPieceScriptableObject;
    [SerializeField] private GhostPieceView ghostPieceView;
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int ScorePerRow;
    [Header("Buttons")]
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button quitButton;
    [Header("Music")]
    [SerializeField] private SoundType[] sounds;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private Slider bgMusicSlider;
    [Header("GameOver")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button leaderboardButton;
    [SerializeField] private Button gameOverQuitButton;
    [Header("LeaderBoard")]
    [SerializeField] private LeaderboardView leaderboardView;

    private BoardController boardController;
    private EventService eventService;
    private SoundController soundController;
    private ScoreController scoreController;
    private GameOverController gameOverController;
    private LeaderboardController leaderboardController;

    private void Awake()
    {
        if (tetrominoDataScriptableObject != null && tetrominoDataScriptableObject.tetrominoData != null)
        {
            foreach (TetrominoData tetromino in tetrominoDataScriptableObject.tetrominoData)
            {
                tetromino.Initialize();
            }
        }
    }

    private void Start()
    {
        Initialize();
        SubscribeEvents();
        SpawnRandomPiece(boardController);
        soundController.PlayBGMusic(Sounds.BGMusic);
        OnButtonClick();
        
    }

    private void SubscribeEvents()
    {
        eventService.QuitGame.AddListener(OnQuitButtonClick);
        eventService.SpawnRandomPiece.AddListener(SpawnRandomPiece);
        bgMusicSlider.onValueChanged.AddListener(ChangeBackgroundVolume);
    }

    private void OnButtonClick()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClick);
        resumeButton.onClick.AddListener(OnResumebuttonClick);
        optionButton.onClick.AddListener(PlayButtonClickSound);
        quitButton.onClick.AddListener(OnQuitButtonClick);
        backButton.onClick.AddListener(PlayButtonClickSound);
        leaderboardButton.onClick.AddListener(OnLeaderboardButtonClick);
    }

    private void Initialize()
    {
        eventService = new EventService();
        boardController = new BoardController(boardScriptableObject, boardView, eventService);
        scoreController = new ScoreController(scoreText, ScorePerRow, eventService);
        soundController = new SoundController(soundEffect, backgroundMusic, sounds, eventService);
        gameOverController = new GameOverController(gameOverPanel, restartButton, gameOverQuitButton, eventService);
        leaderboardController = new LeaderboardController(leaderboardView, eventService, scoreController);
    }

    private void SpawnRandomPiece(BoardController board)
    {
        TetrominoData data = tetrominoDataScriptableObject.tetrominoData[Random.Range(0, tetrominoDataScriptableObject.tetrominoData.Length)];
        PieceController activePiece = new PieceController(board, boardScriptableObject.spawnPosition, data, pieceScriptableObject, pieceView, eventService);

        GhostPieceController ghostPieceController = new GhostPieceController(ghostPieceScriptableObject, ghostPieceView, boardController, activePiece, eventService);

        if (boardController.IsValidPosition(activePiece, boardController.boardModel.spawnPosition))
            boardController.Set(activePiece);
        else
        {
            pauseButton.gameObject.SetActive(false);
            eventService.GameOver.Invoke();
        }
    }

    private void OnLeaderboardButtonClick()
    {
        leaderboardController.GetAllLeaderboardEntries();
        PlayButtonClickSound();
    }

    private void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        PlayButtonClickSound();
    }

    private void OnResumebuttonClick()
    {
        Time.timeScale = 1;
        PlayButtonClickSound();
    }

    private void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        PlayButtonClickSound();
    }

    private void PlayButtonClickSound() => eventService.PlaySoundEffect.Invoke(Sounds.ButtonClick);

    private void ChangeBackgroundVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }

    private void OnDisable()
    {
        eventService.QuitGame.RemoveListener(OnQuitButtonClick);
        eventService.SpawnRandomPiece.RemoveListener(SpawnRandomPiece);
    }
}
