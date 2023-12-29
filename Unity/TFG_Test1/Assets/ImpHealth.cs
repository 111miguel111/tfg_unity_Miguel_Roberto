using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpHealth : MonoBehaviour{

    public float enemyMaxHealth;
    public float currentHealth;
    public float damageModifier;
    public GameObject damageParticles;//Sangre
    public GameObject deathParticles;//Muerte
    public GameObject drop;//Lo que dropean
    public bool drops;//Si dropean algo
    public AudioClip deathSound;
    AudioSource enemyAS;

    // Start is called before the first frame update
    void Start(){
        currentHealth = enemyMaxHealth;
        enemyAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void addDamage(float damage){
        damage = damage * damageModifier;
        if(damage > 0f){
            currentHealth -= damage;
            damageFX(damageParticles, transform.position, new Vector3(0, 0, 0));
            enemyAS.Play();
            if (currentHealth <= 0){
                makeDead();
            }
        }
    }

    public void damageFX(GameObject particle, Vector3 point, Vector3 rotation)
    {
        Instantiate(particle, point, Quaternion.Euler(rotation));
    }

    void makeDead(){
        //turn off movement
        //create ragdoll
        
        AudioSource.PlayClipAtPoint(deathSound,transform.position, 1f);
        damageFX(deathParticles, transform.position, new Vector3(0, 0, 0));
        if (drops){
            Instantiate(drop, transform.position, drop.transform.rotation);
        }
        Destroy(gameObject.transform.root.gameObject);
    }
}
