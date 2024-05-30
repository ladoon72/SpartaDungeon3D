using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagalbe
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour , IDamagalbe
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }

    public event Action onTakeDamage;

    void Update()
    {
        if(health.curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amout)
    {
        health.Add(amout);
    }

    public void Die()
    {
        Debug.Log("ав╬З╢ы.");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
}
