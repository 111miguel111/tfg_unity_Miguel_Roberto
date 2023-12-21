using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Importante las variables de unity empiezan con mayuscula las que creamos nosotros en miniscula
    public float runSpeed;//Velocidad de correr
    public float shootSpeed;//Velocidad al disparar

    Rigidbody myRB;//El muñeco
    Animator myAnim;//La informacion del muñeco

    bool facingRight;//Para saber si esta mirando a la derecha

    //for jumping
    bool grounded = false;//Si esta tocando suelo
    Collider[] groundCollisions;//Lo que va a detectar si esta en el suelo
    float groundCheckRadius = 0.2f;//La pelota que detecta el suelo
    public LayerMask groundLayer;//Lo que vamos a entender como suelo
    public Transform groundCheck;//Lo que unity leera para detectar el suelo
    public float jumpHeight;//La altura del salto

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();//Donde aplicamos las fuerzas
        myAnim = GetComponent<Animator>();//Donde informamos de los cambios en el estado del muñeco para unity
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //jumping code
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("grounded", grounded);
            myRB.AddForce(new Vector3(0, jumpHeight, 0));
        }
        

        //landing code
        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(groundCollisions.Length > 0 )
        {
            grounded = true;
        }
        else
        {
            grounded=false;
        }
        myAnim.SetBool("grounded", grounded);

        //Para moverse
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed",Mathf.Abs(move));
        
        //Para moverse disparando
        float shooting = Input.GetAxisRaw("Fire1");
        myAnim.SetFloat("shooting", shooting);
        //Para mover al personaje con las siguientes cndiciones
        if(shooting > 0 && grounded)//Si esta disparando y esta en el suelo se mueve a la velocidad de disparo
        {
            myRB.velocity = new Vector3(move * shootSpeed, myRB.velocity.y, 0);
        }
        else//Si no esta disparando se movera a la velocidad de correr independientemente de si esta en el suelo o en el aire
        {
            myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
        }
        
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
        Vector3 theScale=transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
}
