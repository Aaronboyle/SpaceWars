using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float bossHealth;
    public bool bossIsDead;

    // Start is called before the first frame update
    public void Start()
    {
        bossHealth = 100;
        bossIsDead = false;

    }

    public float TakeDamage()
    {
        bossHealth -= 10;

        if (bossHealth <= 0)
            bossIsDead = true;

        return bossHealth;
    }

    public float Health()
    {
        return bossHealth;
    }

    public bool Death()
    {
        return bossIsDead;
    }

    public void Explode()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
