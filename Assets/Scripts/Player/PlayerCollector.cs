using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] PlayerWallet _wallet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.AddCoin();
            coin.Collect();
        }
    }
}
