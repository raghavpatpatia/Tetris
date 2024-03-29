using UnityEngine;

public class PieceController
{
    private PieceView pieceView;
    private BoardController board;
    public Vector3Int position { get; private set; }
    public TetrominoData data { get; private set; }
    public Vector3Int[] cells { get; private set; }

    public PieceController(PieceView pieceView, BoardController board, Vector3Int position, TetrominoData data)
    {
        this.pieceView = pieceView;
        this.board = board;
        this.position = position;
        this.data = data;
        InitializeCells(data);
    }

    private void InitializeCells(TetrominoData data)
    {
        if (this.cells == null)
            this.cells = new Vector3Int[data.cells.Length];

        for (int i = 0; i < data.cells.Length; i++)
            this.cells[i] = (Vector3Int)data.cells[i];
    }
}