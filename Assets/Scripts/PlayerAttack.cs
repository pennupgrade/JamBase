using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] books;

    private Animator anim;
    private PlayerMovement playerMovement;
    private Health playerHealth;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<Health>();
    }

    private void Update()
    {
        //Switchboard making sure the cooldown is not active and the player can attack 
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack() && !playerHealth.isDead()){
            Attack();
        } 
            
        
        cooldownTimer += Time.deltaTime;
    }

    //Controlls the attack 
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //resets any re-summoned books to the position of the firepoint 
        books[FindBook()].transform.position = firePoint.position;
        //Sends the fireball into the direction the player is facing 
        books[FindBook()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    
    //Assigns which book in the array to use, given that it's not currently already in use
    private int FindBook()
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (!books[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}