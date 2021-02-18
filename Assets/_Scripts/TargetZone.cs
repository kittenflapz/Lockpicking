using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LockState
{
    LOCKED,
    UNLOCKED
}

public class TargetZone : MonoBehaviour
{
    public int pinsInZone;
    Color translucentRed = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
    Color translucentGreen = new Color(Color.green.r, Color.green.g, Color.green.b, 0.5f);
    public LockState lockState;



    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pin")
        {
            pinsInZone++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pin")
        {
            pinsInZone--;
        }
    }

    public void SetLockState(LockState _lockState)
    {
        switch (_lockState)
        {
            case LockState.LOCKED:
                lockState = LockState.LOCKED;
                GetComponent<Renderer>().material.SetColor("_Color", translucentRed);
                break;
            case LockState.UNLOCKED:
                lockState = LockState.UNLOCKED;
                GetComponent<Renderer>().material.SetColor("_Color", translucentGreen);
               
                break;
        }  
    }
}
