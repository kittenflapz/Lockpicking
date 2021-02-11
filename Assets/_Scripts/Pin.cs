using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public string keybind;
    public float fallSpeed;
    public float maxHeight;
    public float minHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keybind))
        {
            if (transform.position.y < maxHeight)
            { 
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.02f); 
            }
        }
        else
        {
            if (transform.position.y > minHeight)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - fallSpeed * 0.01f);
            }
        }
    }
}
