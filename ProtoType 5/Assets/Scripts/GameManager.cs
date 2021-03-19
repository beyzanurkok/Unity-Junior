using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;

    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    
    private int score;
    private float spawnRate = 1.0f;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        
        
       
    }

    // Update is called once per frame
    void Update() // When we do not put access modifiers in front of methods that are automatically assigned private.

    {
        
    }
    //objects are created randomly in spawnRate intervals.
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
   
    }
    //   Score increases with different values ​​when good items are destroyed.Score decreases when bad items are destroyed


    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score :" + score;

    }
    //when good objects touch the sensor , game over.
    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // to start game
    public void startGame(int difficulty)
    {
        
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        spawnRate /= difficulty;
        updateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}
