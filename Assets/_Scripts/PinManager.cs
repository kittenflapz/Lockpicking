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
    string[] keybinds = { "g", "f", "d", "s", "a" };

    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
       
    }
    void Start()
    {

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

    public void SetUpPins()
    {
        pins = FindObjectsOfType<Pin>();
        // assigns a key to each pin in the game
        if (keybinds.Length >= pins.Length) // no crashy
        {
            for (int i = 0; i < pins.Length; i++)
            {
                pins[i].keybind = keybinds[i];
            }
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
