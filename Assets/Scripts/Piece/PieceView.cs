using UnityEngine;

public class PieceView : MonoBehaviour
{
    private PieceController controller;
    public void SetPieceController(PieceController controller)
    {
        this.controller = controller;
    }

    private void Update()
    {
        if (controller != null)
        {
            controller.board.Clear(controller);
            controller.SetLockTime(controller.lockTime + Time.deltaTime);
            HandleMovementandRotation();
            if (Time.time > controller.stepTime)
            {
                controller.Step();
            }
            controller.board.Set(controller);
        }
    }

    private void HandleMovementandRotation()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            controller.MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            controller.MoveRight();
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
    }
}
