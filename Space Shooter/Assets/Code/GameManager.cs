using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    int score = 0;
    int lives = 3;
    private int bossHealth = 100;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;
    public TextMeshProUGUI bossHealthUI;
    public string currLvl = "Level1";
    public string nextLevelName = "Level2";
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
        if (currLvl == "lvl3") {
            lives = 10;
        }
        scoreUI.text = "score: " + score;
        livesUI.text = "lives: " + lives;  
        if (currLvl == "lvl3") {
            bossHealthUI.text = "Boss Health: " + bossHealth;
        } else {
            bossHealthUI.text = "";
        }
        
    }

    public void AddScore(int points){
        score += points;
        scoreUI.text = "score: " + score;
        if (score == 100 && currLvl == "Level1"){
            SceneManager.LoadScene(nextLevelName);
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

    public int GetLives() {
        return lives;
    }

    public void BossTakeDmg(int dmg) {
        bossHealth -= dmg;
        bossHealthUI.text = "Boss Health: " + bossHealth;
        if (bossHealth <= 0) {
            SceneManager.LoadScene("Victory");
        }
    }

    public int GetBossHealth() {
        return bossHealth;
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
