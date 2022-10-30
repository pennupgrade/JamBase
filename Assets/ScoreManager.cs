using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(this.GetComponentInParent<RectTransform>().rect.width/2,
            this.GetComponentInParent<RectTransform>().rect.height - 0.05f, 1);
        
    }
}
