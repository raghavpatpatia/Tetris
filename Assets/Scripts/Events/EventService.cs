using UnityEngine;

public class EventService
{
    public EventController<BoardController> SpawnRandomPiece;
    public EventController<int> ClearGhostPieceRow;
    public EventController RestartGame;
    public EventController AddScore;
    public EventController GameOver;
    public EventController<Sounds> PlaySoundEffect;
    public EventController QuitGame;
    public EventService()
    {
        SpawnRandomPiece = new EventController<BoardController>();
        ClearGhostPieceRow = new EventController<int>();
        RestartGame = new EventController();
        AddScore = new EventController();
        GameOver = new EventController();
        PlaySoundEffect = new EventController<Sounds>();
        QuitGame = new EventController();
    }
}
