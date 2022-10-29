using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    private float playerAttack = 1;
    public PlayerScript player;
    //public BossScript boss; Add reference to boss

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "boss")
        {
            //call function in boss to reduce boss health
        }
    }
}
