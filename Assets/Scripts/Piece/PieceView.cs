using UnityEngine;

public class PieceView : MonoBehaviour
{
    private PieceController controller;
    public void SetPieceController(PieceController controller) => this.controller = controller;
}