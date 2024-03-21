using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float range = -15;
    public float rangeScale = 0.05f;
    public float speed = 10;
    

    // Update is called once per frame
    void Update()
    {
        transform.position += -Vector3.forward * Time.deltaTime *speed;
        transform.localScale += Vector3.one*rangeScale;
        if (transform.position.z < range)
        {
            Destroy(gameObject);
        }
    }
}
