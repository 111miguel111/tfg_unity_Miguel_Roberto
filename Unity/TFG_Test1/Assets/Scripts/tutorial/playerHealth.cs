using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    float currentHealth;
    public float fullHealth;

    public GameObject playerDeathFX;
    public GameObject playerDeathFX2;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0) {
            makeDead();
        }
    }
    public void makeDead()
    {
        Instantiate(playerDeathFX2, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Instantiate(playerDeathFX,transform.position, Quaternion.Euler(new Vector3(-90,0,0)));
        Destroy (gameObject);
    }
}
