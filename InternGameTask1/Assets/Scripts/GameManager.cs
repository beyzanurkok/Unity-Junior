using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameObject[] obstacleBlockPrefabs;
    [SerializeField]  GameObject titleScreen;
    
    int score;
    int highScore;
    public float globalBlockPos;
    public float globalBlockDif;
    float BlockPos;
    public bool isGameActive;

    private void Update()
    { //Setting and saving the highscore
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "Highscore: " + highScore;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void SpawnRandomObstacleBlock(float BlockPos)
    {
        globalBlockPos = BlockPos;
        int randomObstacle = Random.Range(0, obstacleBlockPrefabs.Length);
        Vector3 spawnPos = new Vector3(0, transform.position.y + BlockPos, 0);
        Instantiate(obstacleBlockPrefabs[randomObstacle], spawnPos, obstacleBlockPrefabs[randomObstacle].transform.rotation);
    }

    public void StartGame(float difficulty)
    {
        titleScreen.gameObject.SetActive(false);

        isGameActive = true;
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore", highScore);
        highScoreText.text = "Highscore: " + highScore;
        scoreText.text = "Score: " + 0;

        // to access difficulty parameter from BlockDestroy class.
        globalBlockDif = difficulty;
        BlockPos = 0;
       
        Spawn();
       

    }

    public void Spawn()
    {
        for (int i = 0; i < 2; i++)
        {
            float RandomPos = Random.Range(6, 9);
            SpawnRandomObstacleBlock(BlockPos);
            BlockPos += (RandomPos / globalBlockDif);
        }
    }

  

}