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
        bossHealth = 100.0f;
        bossIsDead = true;
    }

    public bool IsDead
    {
        get => bossIsDead;
    }



    public float TakeDamage()
    {
        if (bossHealth <= 0.0f)
            bossIsDead = true;

        bossHealth -= 10.0f;
        return bossHealth;
    }


    public void Reset()
    {
        bossHealth = 100.0f;
        bossIsDead = false;
    }




    public void Explode()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
