using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAlert : MonoBehaviour
{
    private bool isOn;
    [SerializeField] KeyCode onKey;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(onKey)){
            turnOn();
        }
    }

    public void turnOn()
    {
        isOn = !isOn;
        if (isOn)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        
    }

    //public void turnOff()
    //{
    //    isOn = false;
    //    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    //}

    public bool lightIsOn()
    {
        return isOn;
    }
}
