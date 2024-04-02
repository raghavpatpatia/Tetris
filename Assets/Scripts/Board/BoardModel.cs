using UnityEngine;

public class BoardModel
{
    public Vector2Int boardSize { get; private set; }
    public Vector3Int spawnPosition { get; private set; }
    public RectInt bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }

    public BoardModel(BoardScriptableObject boardSO)
    {
        this.boardSize = boardSO.boardSize;
        this.spawnPosition = boardSO.spawnPosition;
    }
}
