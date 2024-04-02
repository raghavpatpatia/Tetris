using UnityEngine;

public class HardDropCommand : PieceUnitCommand
{
    public HardDropCommand(PieceController pieceController, BoardController boardController) : base(pieceController, boardController)
    {
        this.pieceController = pieceController;
        this.boardController = boardController;
    }

    public override void Execute()
    {
        while (pieceMovement.Move(Vector2Int.down))
        {
            continue;
        }
        pieceController.Lock();
    }
}