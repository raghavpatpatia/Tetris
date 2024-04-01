using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Board")]
    [SerializeField] private BoardView boardView;
    [SerializeField] private BoardScriptableObject boardScriptableObject;
    [Header("Piece")]
    [SerializeField] private PieceView pieceView;

    private BoardController boardController;
    private EventService eventService;
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        eventService = new EventService();
        boardController = new BoardController(boardScriptableObject, boardView, pieceView);
    }
}