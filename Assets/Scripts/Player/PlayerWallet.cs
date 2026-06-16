using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _coins;

    public void AddCoin() 
    {
        _coins++;
        Debug.Log(_coins);
    }
}
