using UnityEngine;

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

    private BoardController boardController;
    private EventService eventService;

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
        eventService.SpawnRandomPiece.AddListener(SpawnRandomPiece);
        SpawnRandomPiece(boardController);
    }

    private void Initialize()
    {
        eventService = new EventService();
        boardController = new BoardController(boardScriptableObject, boardView, eventService);
    }

    private void SpawnRandomPiece(BoardController board)
    {
        TetrominoData data = tetrominoDataScriptableObject.tetrominoData[Random.Range(0, tetrominoDataScriptableObject.tetrominoData.Length)];
        PieceController activePiece = new PieceController(board, boardScriptableObject.spawnPosition, data, pieceScriptableObject, pieceView, eventService);

        GhostPieceController ghostPieceController = new GhostPieceController(ghostPieceScriptableObject, ghostPieceView, boardController, activePiece, eventService);

        if (boardController.IsValidPosition(activePiece, boardController.boardModel.spawnPosition))
            boardController.Set(activePiece);
        else
            eventService.RestartGame.Invoke();
    }

    private void OnDisable()
    {
        eventService.SpawnRandomPiece.RemoveListener(SpawnRandomPiece);
    }
}
