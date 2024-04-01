using UnityEngine;

public class PieceController
{
    private PieceView pieceView;
    public Vector3Int position;
    public BoardController board { get; private set; }
    public TetrominoData data { get; private set; }
    public Vector3Int[] cells { get; private set; }
    public CommandInvoker commandInvoker { get; private set; }

    public PieceController(PieceView pieceView, BoardController board, Vector3Int position, TetrominoData data)
    {
        this.pieceView = pieceView;
        pieceView.SetPieceController(this);
        this.board = board;
        this.position = position;
        this.data = data;
        InitializeCells(data);
        commandInvoker = new CommandInvoker();
    }

    private void InitializeCells(TetrominoData data)
    {
        if (this.cells == null)
            this.cells = new Vector3Int[data.cells.Length];

        for (int i = 0; i < data.cells.Length; i++)
            this.cells[i] = (Vector3Int)data.cells[i];
    }

    public void MoveLeft()
    {
        PieceUnitCommand moveLeft = new MoveCommand(this, board, Vector2Int.left);
        commandInvoker.ProcessCommand(moveLeft as ICommand);
    }

    public void MoveRight()
    {
        PieceUnitCommand moveRight = new MoveCommand(this, board, Vector2Int.right);
        commandInvoker.ProcessCommand(moveRight as ICommand);
    }

    public void MoveDown()
    {
        PieceUnitCommand moveDown = new MoveCommand(this, board, Vector2Int.down);
        commandInvoker.ProcessCommand(moveDown as ICommand);
    }

    public void HardDrop()
    {
        PieceUnitCommand hardDrop = new HardDropCommand(this, board);
        commandInvoker.ProcessCommand(hardDrop as ICommand);
    }

    public void RotateLeft()
    {
        PieceUnitCommand rotatePiece = new RotateCommand(this, board, -1);
        commandInvoker.ProcessCommand(rotatePiece as ICommand);
    }
    public void RotateRight()
    {
        PieceUnitCommand rotatePiece = new RotateCommand(this, board, 1);
        commandInvoker.ProcessCommand(rotatePiece as ICommand);
    }
}