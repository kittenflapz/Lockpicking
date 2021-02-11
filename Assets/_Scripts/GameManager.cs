using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

enum GameMode
{
    START,
    PLAYING
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

    private void SwitchGameModes()
    {
        if (gameMode == GameMode.START)
        {
            startStuff.SetActive(false);
            playingStuff.SetActive(true);
            gameMode = GameMode.PLAYING;
        }
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
        SwitchGameModes();
    }

    public void Win()
    {
        Baa();
        winText.gameObject.SetActive(true);
        playingStuff.SetActive(false);
    }
}
