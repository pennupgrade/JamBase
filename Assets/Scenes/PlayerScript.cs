using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float health = 100;
    private float attack = 1;
    private float velocity = 8;
    public float jumpForce = 20 ;
    private float gravity = 5;
    private float dir = 1;
    private float attackDir = 0;
    private bool onGround = false;
    private bool canDoubleJump = true;
    private bool canInput = true;
    private bool canAttack = true;

    private Rigidbody2D body;
    private BoxCollider2D hitbox;
    private BoxCollider2D collider;

    public PlayerAttackScript playerAttack;

    IEnumerator waitAttackInput(float time)
    {
        yield return new WaitForSeconds(time);
        canInput = true;
    }

    IEnumerator waitAttackCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        canAttack = true;
    }

    public float getHealth()
    {
        return health;
    }

    public void setHealth(float newHealth)
    {
        health = newHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        hitbox = this.gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
        body = this.GetComponent<Rigidbody2D>();
        collider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (canInput)
        {
            this.transform.position += new Vector3(horizontalInput * velocity * Time.deltaTime, 0, 0);
        }
    }

    void Update()
    {
        Debug.Log(onGround);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = 1;
            attackDir = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = -1;
            attackDir = -1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            attackDir = 2;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            attackDir = -2;
        }
        if (canInput)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (onGround)
                {
                    body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        body.velocity = Vector3.zero;
                        body.AddForce(Vector3.up * (jumpForce * 0.8f), ForceMode2D.Impulse);

                        canDoubleJump = false;
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (attackDir == -2 && !onGround)
                {
                    PlayerAttackScript attack = Instantiate(playerAttack, this.gameObject.transform);
                    attack.gameObject.transform.position += new Vector3(0, -collider.bounds.extents.y - 0.5f, 0);
                }
                else if (attackDir != -2)
                {
                    PlayerAttackScript attack = Instantiate(playerAttack, this.gameObject.transform);
                    if (attackDir == 1)
                    {
                        attack.gameObject.transform.position += new Vector3(-collider.bounds.extents.x - 0.5f, 0, 0);
                    }
                    if (attackDir == -1)
                    {
                        attack.gameObject.transform.position += new Vector3(collider.bounds.extents.x + 0.5f, 0, 0);
                    }
                    if (attackDir == 2)
                    {
                        attack.gameObject.transform.position += new Vector3(0, collider.bounds.extents.y + 0.5f, 0);
                    }
                    canInput = false;
                    StartCoroutine(waitAttackInput(0.15f));
                    StartCoroutine(waitAttackCooldown(0.5f));
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "floor")
        {
            onGround = true;
            canDoubleJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "floor")
        {
            onGround = false;
        }
    }

    void OnCollisionStay2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "floor")
        {
            onGround = true;
            canDoubleJump = true;
        }
    }
}
