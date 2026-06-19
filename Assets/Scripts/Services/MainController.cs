using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GamePlayController _gamePlayManager;

    private void Awake()
    {
        _gamePlayManager.Initialize(_player.transform);
        _player.Initialize();
    }

    private void Update()
    {
        _player.UseUpdateLogic();
        _gamePlayManager.UseUpdateLogic();
    }

    private void FixedUpdate()
    {
        _player.UseFixedUpdateLogic();
    }
}
