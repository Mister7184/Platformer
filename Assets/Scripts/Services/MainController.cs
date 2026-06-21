using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GamePlayController _gamePlayController;

    private void Awake()
    {
        _gamePlayController.Initialize(_player.transform);
        _player.Initialize();
    }

    private void Update()
    {
        _player.UseUpdateLogic();
        _gamePlayController.UseUpdateLogic();
    }

    private void FixedUpdate()
    {
        _player.UseFixedUpdateLogic();
    }
}
