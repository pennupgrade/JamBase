using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttackScript : MonoBehaviour
{
    private float laserDamage = 10;
    public PlayerScript player;
    private float timer = 1.5f;

    private BoxCollider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        hitbox = this.GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 0)
        {
            hitbox.enabled = true;
        }
        timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "player")
        {
            player.getHit(laserDamage);
        }
    }
}
