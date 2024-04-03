using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "GhostPieceScriptableObject", menuName = "ScriptableObjects/GhostPiece/GhostPieceScriptableObject")]
public class GhostPieceScriptableObject : ScriptableObject
{
    public Tile tile;
}