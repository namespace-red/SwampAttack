using System;
using UnityEngine;

[RequireComponent(typeof(MinotaurAnimationsController))]
[RequireComponent(typeof(MoveTowardsTarget))]
[RequireComponent(typeof(MeleeAreaAttack))]
public class Minotaur : Enemy
{
    private MinotaurAnimationsController _animationsController;
    private StateMachine _stateMachine;
    
    private void Awake()
    {
        _animationsController = GetComponent<MinotaurAnimationsController>();
        Health = GetComponent<Health>();
        Move = GetComponent<MoveTowardsTarget>();
        Attack = GetComponent<MeleeAreaAttack>();
        
        EnemyType = EnemyType.Minotaur;
    }

    private void Update()
    {
        _stateMachine?.Tick();
    }

    public void Init(ITargetWithHeathData target)
    {
        target = target ?? throw new ArgumentException("Target can't be null");
        
        Move.Target = target.Transform;
        
        StateMachineFactory smFactory = new StateMachineFactory();
        _stateMachine = smFactory.CreateEnemyStateMachine(
            this, target, _animationsController);
    }
}
