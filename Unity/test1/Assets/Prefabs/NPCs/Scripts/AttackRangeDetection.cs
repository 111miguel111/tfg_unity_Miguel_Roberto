using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeDetection : MonoBehaviour
{
    private Animator enemyAnim;

    private void Awake()
    {
        enemyAnim = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !(enemyAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))) {
            enemyAnim.SetTrigger("Attack");
        }
    }
}
