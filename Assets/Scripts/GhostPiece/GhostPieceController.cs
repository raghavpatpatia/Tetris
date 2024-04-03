using UnityEngine;
using UnityEngine.Tilemaps;

public class GhostPieceController
{
    private GhostPieceModel model;
    private GhostPieceView view;

    private BoardController mainBoard;
    private PieceController trackingPiece;

    private Vector3Int[] cells;
    private Vector3Int position;
    private EventService eventService;

    public GhostPieceController(GhostPieceScriptableObject ghostPieceSO, GhostPieceView ghostPieceView, BoardController mainBoard, PieceController trackingPiece, EventService eventService)
    {
        model = new GhostPieceModel(ghostPieceSO);
        view = ghostPieceView;
        view.SetController(this);

        this.mainBoard = mainBoard;
        this.trackingPiece = trackingPiece;

        cells = new Vector3Int[trackingPiece.cells.Length];
        this.eventService = eventService;
        eventService.ClearGhostPieceRow.AddListener(ClearRow);
        eventService.RestartGame.AddListener(ClearBoard);
    }

    public void Clear() 
    {
        for (int i = 0; i < cells.Length; i++)
        {
            Vector3Int tilePosition = cells[i] + position;
            view.TileMap.SetTile(tilePosition, null);
        }
    }

    public void Copy() 
    {
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = trackingPiece.cells[i];
        }
    }

    public void Drop() 
    {
        Vector3Int position = trackingPiece.position;
        
        int current = position.y;
        int bottom = -mainBoard.boardModel.boardSize.y / 2 - 1;

        mainBoard.Clear(trackingPiece);

        for (int row = current; row >= bottom; row--)
        {
            position.y = row;
            if (mainBoard.IsValidPosition(trackingPiece, position))
            {
                this.position = position;
            }
            else
            {
                break;
            }
        }
        mainBoard.Set(trackingPiece);
    }
    
    public void Set() 
    {
        for (int i = 0; i < cells.Length; i++)
        {
            Vector3Int tilePosition = cells[i] + position;
            view.TileMap.SetTile(tilePosition, model.tile);
        }
    }

    private void ClearRow(int row)
    {
        for (int column = mainBoard.boardModel.bounds.xMin; column < mainBoard.boardModel.bounds.xMax; column++)
        {
            Vector3Int position = new Vector3Int(column, row, 0);
            view.TileMap.SetTile(position, null);
        }

        while (row < mainBoard.boardModel.bounds.yMax)
        {
            for (int column = mainBoard.boardModel.bounds.xMin; column < mainBoard.boardModel.bounds.xMax; column++)
            {
                Vector3Int position = new Vector3Int(column, row + 1, 0);
                TileBase above = view.TileMap.GetTile(position);
                position = new Vector3Int(column, row, 0);
                view.TileMap.SetTile(position, above);
            }
            row++;
        }
    }

    private void ClearBoard()
    {
        view.TileMap.ClearAllTiles();
    }

    ~GhostPieceController()
    {
        eventService.ClearGhostPieceRow.RemoveListener(ClearRow);
        eventService.RestartGame.RemoveListener(ClearBoard);
    }
}