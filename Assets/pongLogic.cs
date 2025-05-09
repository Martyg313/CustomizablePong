using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pongLogic : MonoBehaviour
{
    public static Text playerScoreText;
    public static Text botScoreText;
    public static Text highestScoreText;

    public GameObject ball;
    public GameObject canvas;
    private bool isPaused = false;

    private static int highestScore = 0;
    private static int playerScore = 0;
    private static int botScore = 0;
    public static GameObject[] ballMovements;

    public GameObject backgroundBlack;
    public GameObject backgroundSpiral;
    public GameObject backgroundStars;

    private void saveHighest()
    {
        PlayerPrefs.SetInt("highestScore", highestScore);
    }

    private void loadHighest()
    {
        if (PlayerPrefs.HasKey("highestScore"))
        {
            highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScoreText = GameObject.FindGameObjectWithTag("playerScore").GetComponent<Text>();
        botScoreText = GameObject.FindGameObjectWithTag("botScore").GetComponent<Text>();
        highestScoreText = GameObject.FindGameObjectWithTag("highestScore").GetComponent<Text>();

        loadHighest();
        highestScoreText.text = $"HighestScore: {highestScore.ToString()}";

        loadBackGround();

        spawnAmount();
    }

    private void loadBackGround()
    {
        switch (Menu.backgroundOption)
        {
            case 0:
                backgroundBlack.SetActive(true);
                backgroundSpiral.SetActive(false);
                backgroundStars.SetActive(false);
                break;
            case 1:
                backgroundSpiral.SetActive(true);
                backgroundBlack.SetActive(false);
                backgroundStars.SetActive(false);
                break;
            case 2:
                backgroundStars.SetActive(true);
                backgroundBlack.SetActive(false);
                backgroundSpiral.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        pauseGame();
    }

    private void pauseGame()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            canvas.SetActive(true);
            isPaused = true;
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            canvas.SetActive(false);
            isPaused = false;
        }
    }

    // Main Menu Button Event
    public void toMainMenu()
    {
        saveHighest();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menus");
    }

    private void spawnAmount()
    {
        ballMovements = new GameObject[Convert.ToInt32(Menu.amount)]; 
        for (int i = 0; i < Menu.amount; i++)
        {
            ballMovements[i] = Instantiate(ball, new Vector3(0f, 0f, 0f), ball.transform.rotation);
        }
    }

    public static void addScoreToPlayer()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();     

        if (playerScore > highestScore) // Highest Score Check
        {
            highestScore = playerScore;
            highestScoreText.text = $"HighestScore: {highestScore.ToString()}";
        }
    }

    public static void addScoreToBot()
    {
        botScore++;
        botScoreText.text = botScore.ToString();
    }

    // Quit Button Event 
    public void quitGame()
    {
        saveHighest();

        Debug.Log("quit");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        //Application.Quit();                                 // Quits the client build
        //UnityEditor.EditorApplication.isPlaying = false;    // Quits Unity Build
    }
}
