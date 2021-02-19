using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

enum GameMode
{
    START,
    PLAYING,
    LOST
}

public enum GameDifficulty
{
    EASY,
    NORMAL,
    HARD,
    NIGHTMARE
}

public class GameManager : MonoBehaviour
{
    // Game mode management
    [SerializeField]
    GameObject startStuff;
    [SerializeField]
    GameObject playingStuff;
    GameMode gameMode;


    // Transition to playing mode
    AudioSource startSound;
    [SerializeField]
    TumblerSpawner tumblerSpawner;

    [SerializeField]
    Image playButtonSprite;
    [SerializeField]
    Image logoSprite;
    [SerializeField]
    GameObject dropdown;
    [SerializeField]
    TextMeshProUGUI titleText;
    [SerializeField]
    TextMeshProUGUI endStuff;

    // Gameplay
    public GameDifficulty gameDifficulty;
    [SerializeField]
    float timeLeft;
    [SerializeField]
    TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
      startSound = GetComponent<AudioSource>();
        timeLeft = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMode == GameMode.PLAYING)
        {
            decrementTimer();
            if (timeLeft < 0)
            {
                Lose();
                gameMode = GameMode.LOST;
            }    
        }
    }

    public void Baa()
    {
        startSound.Play();
    }

    public void StartGame()
    {
        Baa();
        StartCoroutine(playButtonAnimThenStartGame(1.2f));
    }

    private void PlayGame()
    {
        if (gameMode == GameMode.START)
        {
            startStuff.SetActive(false);
            playingStuff.SetActive(true);
            gameMode = GameMode.PLAYING;
            tumblerSpawner.SpawnTumblers(gameDifficulty);
            
        }
    }

    public void Restart()
    {
        // lol
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator playButtonAnimThenStartGame(float secondsToWait)
    {
        float timestep = 0;
        dropdown.SetActive(false);
        while (timestep < secondsToWait)
        {
            timestep += Time.deltaTime;
            playButtonSprite.fillAmount = Mathf.Lerp(1, 0, timestep);
            logoSprite.color = new Color (0, 0, 0, Mathf.Lerp(1, 0, timestep));
            titleText.color = new Color (0, 0, 0, Mathf.Lerp(1, 0, timestep));
            yield return null;
        }
        PlayGame();
    }

    public void Win()
    {
        Baa();
        endStuff.gameObject.SetActive(true);
        playingStuff.SetActive(false);
    }

    public void Lose()
    {
        Baa();
        endStuff.SetText("you lose");
        endStuff.gameObject.SetActive(true);
        playingStuff.SetActive(false);
    }

    public void SetDifficulty(int dropdownValue)
    {
        switch (dropdownValue)
        {
            case 0:
                gameDifficulty = GameDifficulty.EASY;
                timeLeft = 30.0f;
                timerText.SetText(timeLeft.ToString());
                break;
            case 1:
                gameDifficulty = GameDifficulty.NORMAL;
                timeLeft = 60.0f;
                timerText.SetText(timeLeft.ToString());
                break;
            case 2:
                gameDifficulty = GameDifficulty.HARD;
                timeLeft = 90.0f;
                timerText.SetText(timeLeft.ToString());
                break;
            case 3:
                gameDifficulty = GameDifficulty.NIGHTMARE;
                timeLeft = 1000.0f;
                timerText.SetText(timeLeft.ToString());
                break;
        }

       
    }

    private void decrementTimer()
    {
        timeLeft -= Time.deltaTime;
        timerText.SetText(Mathf.Floor(timeLeft).ToString());
    }
}
