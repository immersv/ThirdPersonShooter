using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int enemyIntialHealth,enemyCurrentHealth;

    private void OnEnable()
    {
        enemyCurrentHealth = enemyIntialHealth;
    }
    public void OnDamage(int healthReceivedDamage)
    {
        enemyCurrentHealth -= healthReceivedDamage;
        if (enemyCurrentHealth <= 0)
        {
            DeathToEnemy();
        }
    }
    private void DeathToEnemy()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
