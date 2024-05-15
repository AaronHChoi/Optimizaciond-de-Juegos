using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public int lives = 3;

    public Text scoreText;

    public Text livesText;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // Load the main menu scene
        
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;

        livesText.text = "Lives: " + lives;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
}
