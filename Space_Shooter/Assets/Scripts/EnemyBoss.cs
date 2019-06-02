using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour
{
    public float bossMaxHealth = 100.0f;
    public float bossCurrentHealth;
    public bool bossIsDead;
    public Slider bossHealthBar;

    // Start is called before the first frame update
    public void Start()
    {
        bossCurrentHealth = bossMaxHealth;
        bossIsDead = false;
        bossHealthBar.value = bossCurrentHealth;
    }


    public bool IsDead
    {
        get => bossIsDead;
    }

    public float TakeDamage()
    {
        if (bossCurrentHealth <= 0.0f)
            bossIsDead = true;

        bossCurrentHealth -= 10.0f;
        bossHealthBar.value = bossCurrentHealth;
        Debug.Log(bossHealthBar.value); //Check for the health bar value
        return bossCurrentHealth;
    }

    public void Reset()
    {
        bossCurrentHealth = bossMaxHealth;
        bossIsDead = false;
        bossHealthBar.value = bossCurrentHealth;
    }

    public void Explode()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
