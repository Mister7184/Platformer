using UnityEngine;

public class GameOverState : IGameState
{
    private float _delay = 2f;
    private float _startTime;
    private bool _stopped;

    public void Enter()
    {
        _startTime = Time.unscaledTime;
        _stopped = false;
    }

    public void Update()
    {
        if (_stopped)
            return;

        if (Time.unscaledTime - _startTime >= _delay)
        {
            Time.timeScale = 0f;
            _stopped = true;
        }
    }

    public void FixedUpdate() { }

    public void Exit() { }
}
