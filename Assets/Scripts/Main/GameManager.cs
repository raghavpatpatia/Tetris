using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Board")]
    [SerializeField] private BoardView boardView;
    [SerializeField] private BoardScriptableObject boardScriptableObject;
    [Header("Piece")]
    [SerializeField] private PieceView pieceView;

    private BoardController boardController;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        boardController = new BoardController(boardScriptableObject, boardView, pieceView);
    }
}