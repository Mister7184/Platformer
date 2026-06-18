using UnityEngine;

[RequireComponent(typeof(Flipper), typeof(EnemyPatrol), typeof(EnemyVision))]

public class Enemy : MonoBehaviour
{
    private EnemyPatrol _patrol;
    private EnemyVision _vision;
    private Flipper _flipper;

    public void Initialize() 
    {
        _flipper = GetComponent<Flipper>();
        _patrol = GetComponent<EnemyPatrol>();
        _vision = GetComponent<EnemyVision>();

        _vision.Initialize(_flipper);
        _patrol.Initialize(_flipper);
    }

    public void UseUpdateLogic()
    {
        _patrol.SetPLayerVisible(_vision.HasPlayer());

        _patrol.UpdateLogic();
    }
}
