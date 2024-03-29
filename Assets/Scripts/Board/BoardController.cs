using UnityEngine;
public class BoardController
{
    private BoardView boardView;
    private BoardModel boardModel;
    private PieceView pieceView;
    private PieceController activePiece;
    public BoardController(BoardScriptableObject boardSO, BoardView boardView, PieceView pieceView)
    {
        boardModel = new BoardModel(boardSO);
        this.boardView = boardView;
        boardView.Initialize(this);
        this.pieceView = pieceView;
    }

    public void SpawnPiece()
    {
        TetrominoData data = boardView.tetrominoData[Random.Range(0, boardView.tetrominoData.Length)];
        activePiece = new PieceController(pieceView, this, boardModel.spawnPosition, data);
        Set(activePiece);
    }

    public void Set(PieceController piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            boardView.TileMap.SetTile(tilePosition, piece.data.tile);
        }
    }
}