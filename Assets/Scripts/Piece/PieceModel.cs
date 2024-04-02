public class PieceModel
{
    public float stepDelay { get; private set; }
    public float lockDelay { get; private set; }
    public PieceModel(PieceScriptableObject pieceSO)
    {
        stepDelay = pieceSO.stepDelay;
        lockDelay = pieceSO.lockDelay;
    }
}
