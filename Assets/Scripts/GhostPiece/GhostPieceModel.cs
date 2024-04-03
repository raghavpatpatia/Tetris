using UnityEngine.Tilemaps;

public class GhostPieceModel
{
    public Tile tile { get; private set; }

    public GhostPieceModel(GhostPieceScriptableObject ghostPieceSO)
    {
        tile = ghostPieceSO.tile;
    }
}