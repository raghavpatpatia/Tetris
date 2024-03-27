using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TetrominoData
{
    public Tetromino tetromino;
    public Tile tile;
    public Vector2Int[] cells { get; private set; }
    public void Initialize()
    {
        this.cells = Data.Cells[tetromino];
    }
}