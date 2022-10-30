using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] books;
    [SerializeField] private int damage;

    private Animator anim;
    private PlayerMovement playerMovement;
    private Health playerHealth;
    private float cooldownTimer = Mathf.Infinity;

    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enemyLayer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<Health>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //Switchboard making sure the cooldown is not active and the player can attack 

        // check for melee
        if (Input.GetKeyDown(KeyCode.M) && playerMovement.canAttack() && !playerHealth.isDead())
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.up, 0.1f, enemyLayer);
            if (raycastHit.collider != null)
            {
                Debug.Log("hit");

                RaycastHit2D hit = Physics2D.BoxCast(
                boxCollider.bounds.center, 
                new Vector3(boxCollider.bounds.size.x, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 
                0, 
                Vector2.left, 
                0, 
                enemyLayer);

                if(hit.collider != null){
                    playerHealth = hit.transform.GetComponent<Health>();
                    playerHealth.TakeDamage(damage);
                    Debug.Log(playerHealth.isDead());
                }
                
            
            }
        }
            
        
        cooldownTimer += Time.deltaTime;
    }

    //Controlls the attack 
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }

    // claire: melees enemy
    private void Melee()
    {
        

    }
    
   
}