using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return; //cuts down code prematurely if the projectile hits
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0); //moves the object 

        lifetime += Time.deltaTime;//Ensures that the object despawns past its current lifetime. 
        if (lifetime > 5) gameObject.SetActive(false);
    }
    
    //Deactivates the fireball given it hits another collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("hit");

        if (collision.tag == "Enemy"){
            collision.GetComponent<Health>().TakeDamage(1);
        }
    }

    //Determines the directin of the fireball, as well as resets the fireball
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        //Makes sure that the sprite renders int he correct direction
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }


    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}