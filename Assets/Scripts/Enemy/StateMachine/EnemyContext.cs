using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContext
{
    public Transform Player;
    public EnemyVision Vision;
    public EnemyPatrol Patrol;
    public Flipper Flipper;
    public EnemyAttacker Attacker;
    public EnemyChaser Chaser;
    public CharacterAnimator Animator;
}
