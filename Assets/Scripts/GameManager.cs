using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;  

     private float score = 0f;
    public bool isGameRunning = false;

     private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isGameRunning)
        {
            score += Time.deltaTime;
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        isGameRunning = true;
         scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            player.GetComponent<PlayerController>().isGameStarted = true;
    }

     public void GameOver()
    {
        isGameRunning = false;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameRunning() {
        return isGameRunning;
    }

    public void AddScore(int amount)
{
    score += amount;
}
}
