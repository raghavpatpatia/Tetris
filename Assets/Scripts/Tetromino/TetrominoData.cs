using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TetrominoData
{
    public Tetromino tetromino;
    public Tile tile;
    public Vector2Int[] cells { get; private set; }
    public Vector2Int[,] wallKicks { get; private set; }
    public void Initialize()
    {
        this.cells = Data.Cells[tetromino];
        this.wallKicks = Data.WallKicks[tetromino];
    }
}