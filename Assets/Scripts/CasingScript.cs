using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingScript : MonoBehaviour
{
    private float gravity = 1f;
    private Vector3 velocityY;

    // Start is called before the first frame update
    void Start()
    {
        velocityY = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(0.005f, 0.02f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        velocityY = new Vector3(velocityY.x, velocityY.y - gravity / 15 * Time.deltaTime, 0);
        transform.position += velocityY;

        if(transform.position.y <= -5)
        {
            Destroy(this.gameObject);
        }
    }
}
