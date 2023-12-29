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

        }
        
    }
}
