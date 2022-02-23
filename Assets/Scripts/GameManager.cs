using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
  
    [SerializeField]
    private GameObject gameOver;
    
    [SerializeField]
    private Text scoreUi;

    private float score;
    private Player player;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnLost += Player_OnLost;
        gameOver.SetActive(false);
        score = 0;
    }

    private void Player_OnLost()
    {
        Destroy(player.gameObject);
        gameOver.SetActive(true);
    }


    void OnDestroy()
    {
        player.OnLost -= Player_OnLost;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        CheckExitGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SquareJump");
    }

    private void UpdateScore()
    {
        if (!gameOver.activeSelf)
        {
            score += Time.deltaTime;
            scoreUi.text = score.ToString("F0");
        }
    }

    private void CheckExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
