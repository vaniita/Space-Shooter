using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
     int score = 0;
     int lives = 3;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;
    public string levelName = "Level2";
    public string gameOverLevel= "GameOver";

    private void Awake()
    {
        if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreUI.text = "score: " + score;
        livesUI.text = "lives: " + lives;  
    }

    public void AddScore(int points){
        score += points;
        scoreUI.text = "score: " + score;
        if (score == 100){
            SceneManager.LoadScene(levelName);
        }
    }

    public void loseLife(int points){
        score += 20;
        lives -= points;
        scoreUI.text = "score: " + score;
        livesUI.text = "lives: " + lives;

        if (lives<=0){
            SceneManager.LoadScene(gameOverLevel);
        }

    }

    
    public void Update()
    {
        // quit game is esc
#if !UNITY_WEBGL
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }
}
