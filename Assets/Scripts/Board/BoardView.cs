using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardView : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TetrominoDataScriptableObjectList tetrominoes;
    public Tilemap TileMap { get { return tilemap; } }
    public TetrominoData[] tetrominoData { get { return tetrominoes.tetrominoData; } }
    private BoardController controller;
    private void Awake()
    {
        foreach(TetrominoData tetromino in tetrominoes.tetrominoData)
        {
            tetromino.Initialize();
        }
    }

    public void Initialize(BoardController controller)
    {
        this.controller = controller;
    }

    private void Start()
    {
        if (controller != null)
        {
            controller.SpawnPiece();
        }
    }
}