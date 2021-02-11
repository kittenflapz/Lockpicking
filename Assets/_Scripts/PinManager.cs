using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// keeps list of the pins currently active, controls keybinds maybe

public class PinManager : MonoBehaviour
{
    Pin[] pins;
    string[] keybinds = { "g", "f", "d", "s", "a" };

    // Start is called before the first frame update

    private void Awake()
    {
        pins = FindObjectsOfType<Pin>();
    }
    void Start()
    {
        // assigns a key to each pin in the game
        if (keybinds.Length > pins.Length) // no crashy
        {
            for (int i = 0; i < pins.Length; i++)
            {
                pins[i].keybind = keybinds[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
