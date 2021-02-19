using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// keeps list of the pins currently active, controls keybinds maybe

public class PinManager : MonoBehaviour
{
    [SerializeField]
    TargetZone targetZone;

    [SerializeField]
    Image goatButton;

    GameManager gameManager;

    [SerializeField]
    Pin[] pins;
    string keybinds;

    string ezKeys = "asd";
    string normalKeys = "asdf";
    string hardKeys = "asdfg";
    string why = "abcdefghijklmnopqrstuvwxyz";

    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetZone.pinsInZone == pins.Length)
        {
            targetZone.SetLockState(LockState.UNLOCKED);
            goatButton.color = Color.green;
        }
        else
        {
            targetZone.SetLockState(LockState.LOCKED);
            goatButton.color = Color.white;
        }
    }

    public void SetUpKeybinds()
    {
        switch (gameManager.gameDifficulty)
        {
            case GameDifficulty.EASY:
                keybinds = ezKeys;
                break;
            case GameDifficulty.NORMAL:
                keybinds = normalKeys;
                break;
            case GameDifficulty.HARD:
                keybinds = hardKeys;
                break;
            case GameDifficulty.NIGHTMARE:
                keybinds = why;
                break;
        }   
    }

    public void SetUpPins()
    {
        pins = FindObjectsOfType<Pin>();

        // assigns a random key to each pin in the game
        // i wish this wasn't like this but life is hard
        if (keybinds.Length >= pins.Length) 
        {
            for (int i = 0; i < pins.Length; i++)
            {
                string tempKeybinds;
                int keyPicker = Random.Range(0, keybinds.Length);
                char c = keybinds[keyPicker];
                pins[i].keybind = c;
                tempKeybinds = keybinds.Remove(keyPicker, 1);
                keybinds = tempKeybinds;
            }
        }

       foreach(Pin pin in pins)
        {
            pin.CalcFallSpeed(gameManager.playerSkill);
        }
    }

    public void AttemptWin()
    { 
        if (targetZone.lockState == LockState.UNLOCKED)
        {
            gameManager.Win();
            print("win"); 
        }
        else
        {
            print("nice try");
        }
    }
}
