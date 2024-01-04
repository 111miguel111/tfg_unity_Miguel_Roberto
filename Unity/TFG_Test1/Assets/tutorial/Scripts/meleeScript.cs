using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeScript : MonoBehaviour
{
    public float damage;
    public float knockBack;
    public float knockBackRadius;
    public float meleeRate;

    float nextMelee;
    int shootableMask;

    Animator myAnim;
    playerController myPC;

    // Start is called before the first frame update
    void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        myAnim =transform.root.GetComponent<Animator>();
        myPC = transform.root.GetComponent<playerController>();
        nextMelee = Time.time + meleeRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float melee = Input.GetAxis("Fire2");
        if (melee > 0 && nextMelee<Time.time && !(myPC.getShooting())) 
        {
            myAnim.SetTrigger("gunMelee");
            nextMelee = Time.time+meleeRate;
            //do damage
            Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);
            int i = 0;
            while (i < attacked.Length)
            {
                if (attacked[i].tag == "Enemy")
                {
                    EnemyHealth doDamage = attacked[i].GetComponent<EnemyHealth>();
                    doDamage.addDamage(damage);

                    GameObject enemy = attacked[i].gameObject;
                    pushBack(enemy.transform);
                }
            i++;
            }
        }
        
    }

    void pushBack(Transform pushedObject)
    {
        //Variable que determina cuanto se mueve el enemigo
        float movimientoX = pushedObject.position.x + transform.position.x;
        //Si la variable es negativa se cambia a positivo para que no se acerque mas en vez de alejarse
        if (movimientoX < 0)
        {
            movimientoX *=-1;
        }
        //Knockback vertical no funciona no se porque
        Vector3 pushDirection = new Vector3(transform.root.GetComponent<playerController>().getFacing()*(movimientoX), (pushedObject.position.y - transform.position.y), 0).normalized;
        pushDirection *= knockBack;

        Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();
        pushedRB.velocity = Vector3.zero;
        pushedRB.AddForce(pushDirection, ForceMode.Impulse);
    }

}
