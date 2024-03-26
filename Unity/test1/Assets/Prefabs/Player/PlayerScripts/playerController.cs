using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    

    bool runningBool;
    bool shootingBool;
    public bool facingRight;//Para saber si esta mirando a la derecha



    // Start is called before the first frame update
    void Start()
    {facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

        //Para moverse
        float move = Input.GetAxis("Horizontal");
        
        
        
        //Para girar el personaje
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight) 
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight= !facingRight;
        
    }
    public float getFacing()
    {
        if (facingRight)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
