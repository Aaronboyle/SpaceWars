
using System.Collections;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("EnemyBoss"))
        {
            return;
        }

        if(explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);

            if (!other.CompareTag("Player") && !other.CompareTag("EnemyBoss"))
                Destroy(other.gameObject);
        }

        float bossHealth;
        if (this.CompareTag("EnemyBoss"))
        {
            bossHealth = gameController.BossHit();
           // Debug.Log(bossHealth);
            if (bossHealth < 0.0f)
            {
                Destroy(gameObject);
                gameController.ResetBoss();
                gameController.AddScore(scoreValue);
            }
            return;
        }

        if (other.CompareTag("Player"))
        {
            gameController.PlayerHit();
        }
        else
            gameController.AddScore(scoreValue);

        Destroy(gameObject);
    }
}
