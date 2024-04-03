using UnityEngine;

public class EventService
{
    public EventController<BoardController> SpawnRandomPiece;
    public EventController<int> ClearGhostPieceRow;
    public EventController RestartGame;
    public EventController AddScore;
    public EventController<Sounds> PlaySoundEffect;
    public EventService()
    {
        SpawnRandomPiece = new EventController<BoardController>();
        ClearGhostPieceRow = new EventController<int>();
        RestartGame = new EventController();
        AddScore = new EventController();
        PlaySoundEffect = new EventController<Sounds>();
    }
}
