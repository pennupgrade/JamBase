using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] public Transform enemy;

    [Header ("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

     [Header ("Idle Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header ("Animator")]
    [SerializeField] private Animator anim;

    [Header("Target Behavior")]
    [SerializeField] private GameObject targetLight;
    private bool isSeeking;


    private void Awake(){
        isSeeking = false; 
        initScale = enemy.localScale;
    }


    private void Update(){
        if (!isSeeking) {
            if (movingLeft)
            {
                if (enemy.position.x >= leftEdge.position.x)
                {
                    MoveInDirection(-1);
                }
                else
                {
                    DirectionChange();
                }
            }
            else
            {
                if (enemy.position.x <= rightEdge.position.x)
                {
                    MoveInDirection(1);
                }
                else
                {
                    DirectionChange();
                }
            }
        }
        else
        {
            if (enemy.position.x <= targetLight.GetComponent<Transform>().position.x + 0.5 && enemy.position.x > targetLight.GetComponent<Transform>().position.x - 0.5) {
                    Debug.Log("Turn off");
                    this.gameObject.SetActive(false);
            } else {
                if (targetLight.GetComponent<Transform>().position.x > enemy.position.x)
                    {
                        this.MoveInDirection(1);
                    }
                    else
                    {
                        this.MoveInDirection(-1);
                    }
                }

             
        }


    }
    
    private void MoveInDirection(int _direction){
        idleTimer = 0; 
        anim.SetBool("moving", true);
        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        //Move indirection
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    private void DirectionChange(){
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration){
            movingLeft = !movingLeft;
        }
    }

    private void onDisable(){
        anim.SetBool("moving", false);
    }

    public void startSeeking(GameObject l)
    {
        Debug.Log("Seekin babyyy");
        isSeeking = true;
        targetLight = l;
    }

    public bool enemyIsSeeking()
    {
        return isSeeking;
    }
}
