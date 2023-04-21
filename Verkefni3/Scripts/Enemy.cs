using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    public float health;

    public void Damage(float damage)
    {
        health -= damage; // tekur líf af player
        if (health < 0) Destroy(gameObject); // ef enemy health 0 deyr Enemy
    }
}