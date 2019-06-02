using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour
{
    public float bossHealth;
    public float currentbossHealth;
    public bool bossIsDead;
    public Slider bossHealthBar;

    // Start is called before the first frame update
    public void Start()
    {
        bossHealth = 100.0f;
        currentbossHealth = bossHealth;
        bossIsDead = false;
        bossHealthBar.value = CalculateHealth();
    }


    public bool IsDead
    {
        get => bossIsDead;
    }

    float CalculateHealth()
    {
        return currentbossHealth / bossHealth;
    }

    public float TakeDamage()
    {
        if (bossHealth <= 0.0f)
            bossIsDead = true;

        bossHealth -= 10.0f;
        bossHealthBar.value = CalculateHealth();
        return bossHealth;
    }

    public void Reset()
    {
        bossHealth = 100.0f;
        bossIsDead = false;
        bossHealthBar.value = CalculateHealth();
    }

    public void Explode()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
