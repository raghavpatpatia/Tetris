using UnityEngine;

public class EventService
{
    public EventController<BoardController> SpawnRandomPiece;
    public EventService()
    {
        SpawnRandomPiece = new EventController<BoardController>();
    }
}
