using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int playerLane = 0;
    public static int gunType = 0;

    public RawImage[] guns;
    public Texture[] gunTextures;
    public Texture[] unselectedTextures;
    public AudioSource sw;
    public Sprite[] gunModes;
    private int indx = 0;
    private bool chngd = false;

    //spacebar shoot, up key to move up a level, down key to move down

    //GunType {FireRate, isAuto, damage, etc...}


    void Start()

    {

    }

    // Update is called once per frame
    void Update()
    {
        // change the lane
        chngd = false;
        for (int i = 0; i < 4; i++)
        {
            guns[i].texture = unselectedTextures[i];
        }


        if (Input.GetKeyDown(KeyCode.RightArrow) && playerLane < GameManager.lanes.Length - 1)
        {
            chngd = true;
            playerLane += 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && playerLane > 0)
        {
            chngd = true;
            playerLane -= 1;
        }

        // change the gun
        /*
        if (Input.GetKeyDown(KeyCode.X))
        {
            gunType = (gunType + 1) % 4;
            for(int i=0; i<guns.Length; i++)
            {
                if (i == gunType)
                {
                    guns[i].texture = gunTextures[i];
                }
                else
                {
                    guns[i].texture = unselectedTextures[i];
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z))    
        {
            gunType -= 1;
            if(gunType < 0) gunType = 3;
            for (int i = 0; i < guns.Length; i++)
            {
                if (i == gunType)
                {
                    guns[i].texture = gunTextures[i];
                }
                else
                {
                    guns[i].texture = unselectedTextures[i];
                }
            }
        }*/

        if (Input.GetKey(KeyCode.Z))
        {
            indx = 0;
            guns[indx].texture = gunTextures[indx];
            //chngd = true;

        }
        else if (Input.GetKey(KeyCode.X))
        {
            indx = 1;
            guns[indx].texture = gunTextures[indx];
            //chngd = true;

        }
        else if (Input.GetKey(KeyCode.C))
        {
            indx = 2;
            guns[indx].texture = gunTextures[indx];
            //chngd = true;

        }
        else if (Input.GetKey(KeyCode.V))
        {
            indx = 3;
            guns[indx].texture = gunTextures[indx]; //very ugly but i am losing it bro
            //chngd = true;
        }
        if (chngd)
        {
            sw.Play();
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = gunModes[indx];


        transform.position = new Vector3(GameManager.lanes[playerLane] - 0.15f, -3.5f , 0);
    }
}
