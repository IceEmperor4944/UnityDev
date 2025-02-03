using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject loseUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject playUI;
    [SerializeField] TMP_Text scoreUI;

    enum eState
    {
        TITLE,
        GAME,
        WIN,
        LOSE
    }

    eState state = eState.TITLE;
    float timer = 0;
    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        switch (state)
        {
            case eState.TITLE:
                winUI.SetActive(false);
                loseUI.SetActive(false);
                playUI.SetActive(false);
                titleUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    titleUI.SetActive(false);
                    state = eState.GAME;
                }
                break;
            case eState.GAME:
                titleUI.SetActive(false);
                winUI.SetActive(false);
                loseUI.SetActive(false);
                playUI.SetActive(true);
                break;
            case eState.WIN:
                playUI.SetActive(false);
                winUI.SetActive(true);
                break;
            case eState.LOSE:
                playUI.SetActive(false);
                loseUI.SetActive(true);
                break;
            default:
                break;
        }
        scoreUI.text = score.ToString("0000");
    }

    public void OnStartGame()
    {
        titleUI.SetActive(false);
        state = eState.GAME;
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void PlayAgainPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        state = eState.TITLE;
    }

    public void SetWin()
    {
        state = eState.WIN;
    }

    public void SetLose()
    {
        state = eState.LOSE;
    }

    public void AddPoints(int points)
    {
        score += points;
    }
}