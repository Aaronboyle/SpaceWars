
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

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        waveText.text = "";


        
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();

        
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

    public void GameOver()
    {
        Instantiate(playerExplosion, playerObject.transform.position, playerObject.transform.rotation);
        Destroy(playerObject);
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
