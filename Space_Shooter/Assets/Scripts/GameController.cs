
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject boss1;
    private float bossHealth;
    private EnemyBoss enemyBoss;

    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text waveText;

    private bool gameOver;
    private bool restart;
    private int score;
    private int wave;

    private GameObject playerObject;
    private PlayerController player;
    private float playerHealth;
    public GameObject playerExplosion;
    public Slider healthBar;

    public Boundary boundary;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        waveText.text = "";

        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();

        enemyBoss = boss1.GetComponent<EnemyBoss>();


        score = 0;
        wave = 1;

        UpdateScore();
        UpdateWaveCount();

        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        healthBar.value = player.PlayerHealth;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            if( wave % 2 == 0)
            {
                int numberOfBosses = wave / 2;
                for(int i = 0; i < numberOfBosses; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(boss1, spawnPosition, spawnRotation);
                }
                yield return new WaitForSeconds(5);
            }



            hazardCount = (int)(hazardCount * 1.5);

            yield return new WaitForSeconds(waveWait);
           
          if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
            else
            {
                 wave++;
                 UpdateWaveCount();
            }
        }
    }

    public void PlayerHit()
    {
        playerHealth = player.PlayerIsHit();
        healthBar.value = playerHealth;

        if (playerHealth <= 0)
            GameOver();
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateWaveCount()
    {
        waveText.text = "Wave: " + wave;
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void ResetBoss()
    {
        enemyBoss.Reset();
    }

    public float BossHit()
    {
        bossHealth = enemyBoss.TakeDamage();

        if (bossHealth <= 0.0f)
            enemyBoss.Explode();

        return bossHealth;
    }

    public void GameOver()
    {
        Instantiate(playerExplosion, playerObject.transform.position, playerObject.transform.rotation);
        Destroy(playerObject);
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
