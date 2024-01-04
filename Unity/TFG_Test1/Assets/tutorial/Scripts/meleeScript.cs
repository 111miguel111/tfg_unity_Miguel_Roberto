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
        nextMelee = 3f;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float melee = Input.GetAxis("Fire2");
        if (melee > 0 && nextMelee<Time.time && !(myPC.getShooting())) 
        {
            myAnim.SetTrigger("gunMelee");
            nextMelee += Time.deltaTime+meleeRate;
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
        //Knockback vertical no funciona no se porque y la direccion del knockback depende del lado del mapa en el que estes (ambos pasan a estar negativos, habria que invertir facing o algo)
        Vector3 pushDirection = new Vector3(transform.root.GetComponent<playerController>().getFacing()*(pushedObject.position.x + transform.position.x), (pushedObject.position.y - transform.position.y), 0).normalized;
        Debug.Log("PO"+pushedObject.position.x+" | "+"Tf"+ transform.position.x);
        pushDirection *= knockBack;

        Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();
        pushedRB.velocity = Vector3.zero;
        pushedRB.AddForce(pushDirection, ForceMode.Impulse);
    }

}
