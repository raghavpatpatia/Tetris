public class RotateCommand : PieceUnitCommand
{
    private int direction;
    public RotateCommand(PieceController pieceController, BoardController boardController, int direction) : base(pieceController, boardController)
    {
        this.pieceController = pieceController;
        this.boardController = boardController;
        this.direction = direction;
    }

    public override void Execute() 
    {
        pieceMovement.Rotate(direction);
    }
}