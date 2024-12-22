using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highscore;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI highscoreText;
    [Header("GameOver Panel")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverPanelScoreText;
    public TextMeshProUGUI gameoverPanelHighscoretext;
    public Button ClaimButton;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;
    private void Awake()
    {
        gameOverPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoretext.text = score.ToString();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = score.ToString();
        }
    }
    public void OnCookBookHit()
    {
        Time.timeScale = 0;
        gameOverPanelScoreText.text = "Your Score was " + score.ToString();
        gameoverPanelHighscoretext.text = "Best: " + highscore.ToString();
        gameOverPanel.SetActive(true);
        
    }
    public void RestartGame()
    {
        score = 0;
        scoretext.text = score.ToString();
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore.ToString();
        gameOverPanel.SetActive(false);

        gameOverPanelScoreText.text = gameOverPanelScoreText.text = "Your Score was 0.";
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
        Time.timeScale = 1;
    }
    public void PlayRandomCutSound()
    {
        AudioClip randomcut = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomcut);
    }
    private void Start()
    {
        ClaimButton.enabled = false;
    }
    void Update()
        {
            
            if (score >= 200)
            {
                Blade butcherknife = new Blade();
            }
            else
            {
                ClaimButton.enabled = false;
            }
        }
        
    
}
