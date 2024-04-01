using UnityEngine;

public class PieceView : MonoBehaviour
{
    private PieceController controller;
    public void SetPieceController(PieceController controller) => this.controller = controller;

    private void Update()
    {
        controller.board.Clear(controller);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            controller.MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            controller.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            controller.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.HardDrop();
        }
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            controller.RotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            controller.RotateRight();
        }
        controller.board.Set(controller);
    }
}