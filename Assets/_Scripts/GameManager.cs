using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

enum GameMode
{
    START,
    PLAYING
}

public enum GameDifficulty
{
    EASY,
    NORMAL,
    HARD
}

public class GameManager : MonoBehaviour
{
    // Game mode management
    [SerializeField]
    GameObject startStuff;
    [SerializeField]
    GameObject playingStuff;
    GameMode gameMode;
    public GameDifficulty gameDifficulty;

    // Transition to playing mode
    AudioSource startSound;
    [SerializeField]
    TumblerSpawner tumblerSpawner;

    [SerializeField]
    Image playButtonSprite;
    [SerializeField]
    Image logoSprite;
    [SerializeField]
    TextMeshProUGUI titleText;

    [SerializeField]
    TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        startSound = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void ExitGame()
    {
        // lol
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator playButtonAnimThenStartGame(float secondsToWait)
    {
        float timestep = 0;
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
        winText.gameObject.SetActive(true);
        playingStuff.SetActive(false);
    }

    public void SetDifficulty(int dropdownValue)
    {
        switch (dropdownValue)
        {
            case 0:
                gameDifficulty = GameDifficulty.EASY;
                break;
            case 1:
                gameDifficulty = GameDifficulty.NORMAL;
                break;
            case 2:
                gameDifficulty = GameDifficulty.HARD;
                break;
        }
    }
}
