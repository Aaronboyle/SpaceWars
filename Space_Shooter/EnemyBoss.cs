using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float bossHealth;
    public bool bossIsDead;

    // Start is called before the first frame update
    void Start()
    {
        bossHealth = 100;
        bossIsDead = false;

    }

    public float TakeDamage()
    {
        if (bossHealth <= 0)
            bossIsDead = true;

        bossHealth -= 10;
        return bossHealth;
    }

    public void Explode()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
