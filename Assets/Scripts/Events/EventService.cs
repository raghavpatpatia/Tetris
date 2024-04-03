using UnityEngine;

public class EventService
{
    public EventController<BoardController> SpawnRandomPiece;
    public EventController<int> ClearGhostPieceRow;
    public EventController RestartGame;
    public EventService()
    {
        SpawnRandomPiece = new EventController<BoardController>();
        ClearGhostPieceRow = new EventController<int>();
        RestartGame = new EventController();
    }
}
