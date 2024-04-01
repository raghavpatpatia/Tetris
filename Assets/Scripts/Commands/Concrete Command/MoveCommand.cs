using UnityEngine;

public class MoveCommand : PieceUnitCommand
{
    private Vector2Int translation;
    public MoveCommand(PieceController pieceController, BoardController boardController, Vector2Int translation) : base(pieceController, boardController)
    {
        this.pieceController = pieceController;
        this.boardController = boardController;
        this.translation = translation;
    }

    public override void Execute() 
    {
        pieceMovement.Move(translation);
    }
}