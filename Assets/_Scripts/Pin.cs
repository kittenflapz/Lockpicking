using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public char keybind;
    public float fallSpeed;
    public float maxHeight;
    public float minHeight;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-0.5f, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keybind.ToString()))
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
                transform.position = new Vector2(transform.position.x, transform.position.y - fallSpeed * 0.005f);
            }
        }
    }

    public void CalcFallSpeed(PlayerSkill skill)
    {
        switch (skill)
        {
            case PlayerSkill.BAD:
                fallSpeed = Random.Range(0.1f, 0.4f);
                break;
            case PlayerSkill.OK:
                fallSpeed = Random.Range(0.15f, 0.3f);
                break;
            case PlayerSkill.GOOD:
                fallSpeed = Random.Range(0.15f, 0.2f);
                break;
            case PlayerSkill.GOAT:
                fallSpeed = 0.15f;
                break;

        }
    }
}
