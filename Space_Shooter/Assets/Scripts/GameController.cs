
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    private GameObject playerObject;
    private PlayerController player;
    private float playerHealth;
    public GameObject playerExplosion;
    public Slider healthBar;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();

        
        score = 0;

        UpdateScore();

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

        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        */
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
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
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

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        Instantiate(playerExplosion, playerObject.transform.position, playerObject.transform.rotation);
        Destroy(playerObject);
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
