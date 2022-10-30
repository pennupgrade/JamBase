using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Sprite[] casingTextures;
    public GameObject casing;
    public GameObject laser;

    public AudioSource[] sfx;
    public AudioSource[] monsterSfx;

    private Color[] laserColors = { Color.red, Color.blue, Color.green, Color.yellow };


    // Start is called before the first frame update
    void Start()
    {
        //nothing should happen
    }

    // Update is called once per frame
    void Update()
    {
        int indx = -1;
        if (Input.GetKeyDown(KeyCode.Z)){
            indx = 0;
        }else if(Input.GetKeyDown(KeyCode.X)){
            indx = 1;
        }else if (Input.GetKeyDown(KeyCode.C)){
            indx = 2;
        }else if (Input.GetKeyDown(KeyCode.V)){
            indx = 3;
        }


        if (indx != -1)
        {
            //get current lane...
            List<GameObject> currLane = MobSpawnerScript.laneObj[PlayerScript.playerLane];

            float laserY_Final = 1f; //the start should always be -2.7
            float laserY_initial = -2.7f;

            /*string str = "";
            foreach (var x in currLane)
            {
                str += x.ToString() + " ";
            }
            Debug.Log(str);
            */
            //Debug.Log("lane " + PlayerScript.playerLane + ", has #: " + currLane.Count);

            GameObject target = null; //get the head

            if (!currLane.Count.Equals(0)) {
                target = currLane[0];
            }

            if(target != null)
            {
                if (indx == target.GetComponent<MobScript>().lane) //if the guntype corresponds with the monster lane
                {
                    //Debug.Log("found enemy, shoot!");
                    MobScript tgScr = target.GetComponent<MobScript>();
                    tgScr.lives -= 1;
                    laserY_Final = target.transform.position.y;

                    if (tgScr.lives <= 0)
                    {
                        monsterSfx[tgScr.lane].Play();
                        currLane.RemoveAt(0);
                        tgScr.isDead = true;
                    }

                    //ebug.Log(target.GetComponent<MobScript>().lives);
                }
            }

            //funny detail that probably is the shoot animation
            var cs = Instantiate(casing);
            cs.transform.position = new Vector3(GameManager.lanes[PlayerScript.playerLane], -4, 0);
            cs.GetComponent<SpriteRenderer>().sprite = casingTextures[indx];

            sfx[indx].Play();

            float laser_h = laserY_Final - (laserY_initial);

            var ls = Instantiate(laser);
            ls.GetComponent<SpriteRenderer>().color = laserColors[indx];

            ls.transform.localScale = new Vector3(0.35f, laser_h, 0);
            ls.transform.position = new Vector3(
                GameManager.lanes[PlayerScript.playerLane],
                laser_h / 2,
                0);


        }
    }
}
