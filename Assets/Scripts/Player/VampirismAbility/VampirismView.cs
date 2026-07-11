using UnityEngine;

public class VampirismView : MonoBehaviour
{
    [SerializeField] SpriteRenderer _radiusRenderer;

    public void Show() 
    {
        _radiusRenderer.enabled = true;
    }

    public void Hide() 
    {
        _radiusRenderer.enabled = false;
    }
}
