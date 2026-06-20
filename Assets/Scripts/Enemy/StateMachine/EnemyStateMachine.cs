using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    private IEnemyState _current;

    public void ChangeState(IEnemyState next) 
    {
        if (_current == next)
            return;

        _current?.Exit();

        _current = next;

        _current.Enter();
    }

    public void Update()
    {
        _current?.Update();
    }
}
