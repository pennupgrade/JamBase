
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Creating instance variables
    [SerializeField] private float speed; 
    [SerializeField] private float jumpPower; 
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private LayerMask wallLayer; 
    private Rigidbody2D body; //Allows basic forces and physics
    private Animator anim; 
    private BoxCollider2D boxCollider; 
    private float wallJumpCooldown; 
    private float horizontalInput; 

    //The Awake method is instantiated whenever the game is started
    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    private void Update(){
        horizontalInput = Input.GetAxis("Horizontal");
        
        //Flips player when moving left/right
        if(horizontalInput>0.01f){
            transform.localScale = new Vector2(2,2); 
        } else if(horizontalInput<-0.01f)
        {
            transform.localScale = new Vector2(-2, 2);
        }
        
        anim.SetBool("falling", isFalling());
        Debug.Log("falling: " + isFalling()); 

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //Wall Jump Logic
        if (wallJumpCooldown > 0.2){
             body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
            if (onWall() && !isGrounded()){
                body.gravityScale = 1.3f;
                body.velocity = Vector2.zero;
                anim.SetBool("onWall", true);
            } else{ //ensures the player falls back to the ground after touching a wall
                body.gravityScale = 2; 
                anim.SetBool("onWall", false);
            }
            if(Input.GetKey(KeyCode.Space)){
                Jump();
                anim.SetBool("onWall", false);
            }
        } else{ // Ensures the cooldown between jumps
            wallJumpCooldown += Time.deltaTime;
        }
    }

    //Allows the player to jump off the ground/walljump
    private void Jump(){
        if (isGrounded()){
            body.velocity = new Vector2(body.velocity.x, jumpPower); 
            anim.SetTrigger("jump");
        } else if(onWall() && !isGrounded()){ 
            if(horizontalInput == 0){
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 6, 0); 
                transform.localScale = new Vector2(-Mathf.Sign(transform.localScale.x), transform.localScale.y);
            }
            else{
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }
            wallJumpCooldown = 0; 
        }
        
    }
    
    //Checks whether the player is in contact with the ground
    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer); 
        return raycastHit.collider != null; 
    }

    private bool isFalling(){
        if(body.velocity.y < 0){
            return true;
        } else {
            return false; 
        }
    }

    //Checks whether the player is in contact with the wall
    private bool onWall(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer); 
        return raycastHit.collider != null; 
    }
    
    //Defines when the player should be able to attack. Defined when the player is not moving.
    public bool canAttack(){
        return ((horizontalInput == 0 && isGrounded()) || (!isGrounded() && !onWall()));
    }

}
