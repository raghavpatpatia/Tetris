using UnityEngine;

[CreateAssetMenu(fileName = "BoardScriptableObject", menuName = "ScriptableObjects/Board/BoardScriptableObject")]
public class BoardScriptableObject : ScriptableObject
{
    public Vector2Int boardSize;
    public Vector3Int spawnPosition;
}