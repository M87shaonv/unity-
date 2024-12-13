using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private AbstractSkillHandler _AbstractSkillHandler;
    private int _energy;

    private void Start()
    {
        _AbstractSkillHandler = new AOEHandle(null);
        var halfAoeHandle = new HalfAOEHandle(_AbstractSkillHandler);
        var attackThreeEnemiesHandle = new AttackThreeEnemiesHandle(halfAoeHandle);
        var attackOneEnemyHalfDamageHandle = new AttackOneEnemyHalfDamageHandle(attackThreeEnemiesHandle);
        _AbstractSkillHandler = new CannotAttackHandler(attackOneEnemyHalfDamageHandle);
        _energy = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _AbstractSkillHandler.Handle(_energy);
            if (_energy > 20)
                _energy -= 20;
            else
                _energy = 0;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _energy = 100;
        }

        Debug.Log("Current energy: " + _energy);
    }
}