using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int Hp { get; private set; }
    public int Shield { get; private set; }
    public float ShieldDecreaseTime { get; private set; } = 0.0f;

    void Start()
    {
        Hp = 10;
        Shield = 0;
    }

    private void Update()
    {
        // Shield가 남아있는 경우 5초에 1씩 자연 감소시킨다.
        if (Shield > 0)
        {
            ShieldDecreaseTime += Time.deltaTime;
            if (ShieldDecreaseTime >= 5.0f)
            {
                ShieldDecreaseTime = 0.0f;
                Shield -= 1;
            }
        }
    }

    public void Damage(int amount)
    {
        if (Shield > 0)
        {
            if (amount > Shield)
            {
                Hp -= amount - Shield;
                Shield = 0;
            }
            else
            {
                Shield -= amount;
            }
        }
        else
        {
            Hp -= amount;
        }
    }

    public void Heal(int amount)
    {
        Hp += amount;
        if (Hp > 10) Hp = 10;
    }

    public void AddShield(int amount)
    {
        Shield += amount;
        ShieldDecreaseTime = 0.0f;
    }
}
