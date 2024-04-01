using System.Data;
using UnityEngine;

public abstract class PieceUnitCommand : ICommand
{
    protected BoardController boardController;
    protected PieceController pieceController;
    protected PieceMovement pieceMovement;
    public PieceUnitCommand(PieceController pieceController, BoardController boardController)
    {
        this.pieceController = pieceController;
        this.boardController = boardController;
        pieceMovement = new PieceMovement(pieceController, boardController);
    }
    public abstract void Execute();
}