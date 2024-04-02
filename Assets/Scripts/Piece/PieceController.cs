using UnityEngine;

public class PieceController
{
    private PieceView pieceView;
    public Vector3Int position;
    public PieceModel pieceModel { get; private set; }
    public BoardController board { get; private set; }
    public TetrominoData data { get; private set; }
    public Vector3Int[] cells { get; private set; }
    public CommandInvoker commandInvoker { get; private set; }
    private EventService eventService;
    public float stepTime { get; private set; }
    public float lockTime { get; private set; }

    public PieceController(BoardController board, Vector3Int position, TetrominoData data, PieceScriptableObject pieceSO, PieceView pieceView, EventService eventService)
    {
        this.eventService = eventService;
        this.pieceModel = new PieceModel(pieceSO);
        this.pieceView = pieceView;
        pieceView.SetPieceController(this);
        this.board = board;
        this.position = position;
        this.data = data;
        this.stepTime = Time.time + pieceModel.stepDelay;
        this.lockTime = 0f;
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

    public void SetLockTime(float time) => lockTime = time;

    public void Step()
    {
        stepTime = Time.time + pieceModel.stepDelay;

        MoveDown();
        board.ClearTiles();

        if (lockTime >= pieceModel.lockDelay)
        {
            Lock();
        }
    }

    public void Lock()
    {
        board.Set(this);
        board.ClearTiles();
        eventService.SpawnRandomPiece.Invoke(board);
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

    private void MoveDown()
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
