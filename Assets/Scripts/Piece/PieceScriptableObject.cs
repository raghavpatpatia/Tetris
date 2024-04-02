using UnityEngine;

[CreateAssetMenu(fileName = "PieceScriptableObject", menuName = "ScriptableObjects/Piece/PieceScriptableObject")]
public class PieceScriptableObject : ScriptableObject
{
    public float stepDelay;
    public float lockDelay;
}
