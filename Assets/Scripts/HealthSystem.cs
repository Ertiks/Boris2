using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnDamaged;

    [SerializeField]private int HealthAmountMax;
    private int HealthAmount;

    private void Awake()
    {
        HealthAmount = HealthAmountMax;
    }

    public void Damage(int damage)
    {
        HealthAmount -= damage;
        OnDamaged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Pv : " + HealthAmount);
    }
}
