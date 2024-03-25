using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animator_Controller : MonoBehaviour
{
    public Animator _animator;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        _animator.SetFloat("speed", rb.velocity.x);
        


    }
}
