using UnityEngine;

public class PieceMovement
{
    private PieceController pieceController;
    private BoardController boardController;
    private int rotationIndex;
    public PieceMovement(PieceController pieceController, BoardController boardController)
    {
        this.pieceController = pieceController;
        this.boardController = boardController;
        this.rotationIndex = 0;
    }
    public bool Move(Vector2Int translation)
    {
        Vector3Int newPosition = pieceController.position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;

        bool valid = boardController.IsValidPosition(pieceController, newPosition);
        if (valid)
        {
            pieceController.position = newPosition;
            pieceController.SetLockTime(0);
        }
        return valid;
    }
    public void Rotate(int direction)
    {
        int originalRotation = rotationIndex;
        rotationIndex = Wrap(rotationIndex + 1, 0, 4);
        ApplyRotationMatrix(direction);
        if (!RotationWallKicks(rotationIndex, direction))
        {
            rotationIndex = originalRotation;
            ApplyRotationMatrix(-direction);
        }
    }
    private void ApplyRotationMatrix(int direction)
    {
        float[] matrix = Data.RotationMatrix;
        for (int i = 0; i < pieceController.cells.Length; i++)
        {
            Vector3 cell = pieceController.cells[i];
            int x, y;
            switch (pieceController.data.tetromino)
            {
                case Tetromino.I:
                case Tetromino.O:
                    cell.x -= 0.5f;
                    cell.y -= 0.5f;
                    x = Mathf.CeilToInt((cell.x * matrix[0] * direction) + (cell.y * matrix[1] * direction));
                    y = Mathf.CeilToInt((cell.x * matrix[2] * direction) + (cell.y * matrix[3] * direction));
                    break;
                default:
                    x = Mathf.RoundToInt((cell.x * matrix[0] * direction) + (cell.y * matrix[1] * direction));
                    y = Mathf.RoundToInt((cell.x * matrix[2] * direction) + (cell.y * matrix[3] * direction));
                    break;
            }
            pieceController.cells[i] = new Vector3Int(x, y, 0);
        }
    }
    private bool RotationWallKicks(int rotationIndex, int rotationDirection)
    {
        int wallKickIndex = GetWallKicks(rotationIndex, rotationDirection);
        for (int i = 0; i < pieceController.data.wallKicks.GetLength(1); i++)
        {
            Vector2Int translation = pieceController.data.wallKicks[wallKickIndex, i];
            if (Move(translation))
                return true;
        }
        return false;
    }
    private int GetWallKicks(int rotationIndex, int rotationDirection)
    {
        int wallKicks = rotationIndex * 2;
        if (rotationDirection < 0)
            wallKicks--;
        return Wrap(wallKicks, 0, pieceController.data.wallKicks.GetLength(0));
    }
    private int Wrap(int input, int min, int max)
    {
        if (input < min)
        {
            return max - (min - input) % (max - min);
        }
        else
        {
            return min + (input - min) % (max - min);
        }
    }
}
