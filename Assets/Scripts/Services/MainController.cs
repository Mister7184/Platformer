using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GamePlayController _gamePlayManager;

    private void Awake()
    {
        _gamePlayManager.PlayGame();
        _player.Initialize();
    }

    private void Update()
    {
        _player.UseUpdateLogic();
    }

    private void FixedUpdate()
    {
        _player.UseFixedUpdateLogic();
    }
}
