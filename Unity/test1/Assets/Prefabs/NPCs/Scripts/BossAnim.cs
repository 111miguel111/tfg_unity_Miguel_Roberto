using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    public float timeBetweenAttacks;
    float nextAttack;
    public int AttackNumber;
    Animator animator;

    bool IsLock;

    // Start is called before the first frame update
    void Start()
    {
        nextAttack = Time.time;
        animator = GetComponent<Animator>();
        IsLock = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        IsLock = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            IsLock = false;
        }
        else
        {
            IsLock = true;
        }

        if (other.CompareTag("Player") && IsLock)
        {
            //transform.LookAt((0f,other.transform.position.y,0f), Vector3.back);

            Vector3 directionToPlayer = other.transform.position - transform.position;

            // Mantener solo la rotación en el plano horizontal (Y)
            directionToPlayer.y = 0f;

            // Rotar para mirar hacia el jugador
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }        

        if (other.CompareTag("Player") && nextAttack < Time.time && !(animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")))
        {
            
            nextAttack = Time.time + timeBetweenAttacks;
            animator.SetInteger("AttackNum", Random.Range(0,AttackNumber));
            animator.SetTrigger("AttackTrigger");

        }
    }
}
