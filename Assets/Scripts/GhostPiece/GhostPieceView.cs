using UnityEngine;
using UnityEngine.Tilemaps;

public class GhostPieceView : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap;
    public Tilemap TileMap { get { return tileMap; } }
    private GhostPieceController controller;
    public void SetController(GhostPieceController controller) => this.controller = controller;

    private void LateUpdate()
    {
        if (controller != null)
        {
            controller.Clear();
            controller.Copy();
            controller.Drop();
            controller.Set();
        }
    }
}