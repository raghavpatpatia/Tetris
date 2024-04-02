using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardController
{
    private BoardView boardView;
    private BoardModel boardModel;
    private EventService eventService;

    public BoardController(BoardScriptableObject boardSO, BoardView boardView, EventService eventService)
    {
        boardModel = new BoardModel(boardSO);
        this.boardView = boardView;
        boardView.Initialize(this);
        this.eventService = eventService;
    }

    public void SpawnPiece(PieceController activePiece)
    {
        if (IsValidPosition(activePiece, boardModel.spawnPosition))
            Set(activePiece);
        else
            GameOver();
    }

    private void GameOver()
    {
        boardView.TileMap.ClearAllTiles();
    }

    public void Set(PieceController piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            boardView.TileMap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(PieceController piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            boardView.TileMap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPosition(PieceController piece, Vector3Int position)
    {
        RectInt bounds = boardModel.bounds;
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;
            if (boardView.TileMap.HasTile(tilePosition))
            {
                return false;
            }
            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }
        }
        return true;
    }

    public void ClearTiles()
    {
        for (int row = boardModel.bounds.yMin; row < boardModel.bounds.yMax; row++)
        {
            if (IsRowFull(row))
            {
                ClearRow(row);
            }
        }
    }

    private bool IsRowFull(int row)
    {
        for (int column = boardModel.bounds.xMin; column < boardModel.bounds.xMax; column++)
        {
            Vector3Int position = new Vector3Int(column, row, 0);
            if (!boardView.TileMap.HasTile(position))
            {
                return false;
            }
        }
        return true;
    }

    private void ClearRow(int row)
    {
        for (int column = boardModel.bounds.xMin; column < boardModel.bounds.xMax; column++)
        {
            Vector3Int position = new Vector3Int(column, row, 0);
            boardView.TileMap.SetTile(position, null);
        }

        while (row < boardModel.bounds.yMax)
        {
            for (int column = boardModel.bounds.xMin; column < boardModel.bounds.xMax; column++)
            {
                Vector3Int position = new Vector3Int(column, row + 1, 0);
                TileBase above = boardView.TileMap.GetTile(position);
                position = new Vector3Int(column, row, 0);
                boardView.TileMap.SetTile(position, above);
            }
            row++;
        }
    }
}
