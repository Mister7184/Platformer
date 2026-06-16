using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GamePlayManager _gamePlayManager;

    public void Awake()
    {
        _gamePlayManager.PlayGame();
        _player.Initialize();
    }
}
