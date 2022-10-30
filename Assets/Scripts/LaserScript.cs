using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float speed = 5.0f;
    public float threshold = float.Epsilon;

    public bool faded = false;

    public SpriteRenderer sprite;

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (faded)
        {
            sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(sprite.color.a, maximum, step));
            if (Mathf.Abs(maximum - sprite.color.a) <= threshold)
                faded = false;

        }
        else
        {
            sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(sprite.color.a, minimum, step));
            if (Mathf.Abs(sprite.color.a - minimum) <= threshold)
                faded = true;
        }
        Destroy(gameObject, 0.6f);
    }
}
