using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardView : MonoBehaviour
{
    [Header("Board Tile Map")]
    [SerializeField] private Tilemap tilemap;
    public Tilemap TileMap { get { return tilemap; } }
    private BoardController controller;
    public void Initialize(BoardController controller)
    {
        this.controller = controller;
    }
}
