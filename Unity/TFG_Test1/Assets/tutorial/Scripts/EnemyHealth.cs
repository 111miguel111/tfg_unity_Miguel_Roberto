using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour{

    public float enemyMaxHealth;
    public float currentHealth;
    public float damageModifier;
    public GameObject damageParticles;//Sangre
    public GameObject deathParticles;//Muerte
    public GameObject drop;//Lo que dropean
    public bool drops;//Si dropean algo
    public AudioClip[] deathSounds;
    public AudioClip[] damageSounds;
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
            playSound(damageSounds);
            damageFX(damageParticles, transform.position, new Vector3(0, 0, 0));
            if (currentHealth <= 0f){
                makeDead();
            }
            
        }
    }

    public void damageFX(GameObject particle, Vector3 point, Vector3 rotation)
    {
        Instantiate(particle, point, Quaternion.Euler(rotation));
    }
    public void playSound(AudioClip[] sounds)
    {
        AudioClip tempClip = sounds[Random.Range(0, sounds.Length)];
        enemyAS.PlayOneShot(tempClip);
        //enemyAS.clip = tempClip;
        //enemyAS.Play();
    }
    void makeDead(){
        //turn off movement
        //create ragdoll
        //playSound(deathSounds);
        AudioClip tempClip = deathSounds[Random.Range(0, deathSounds.Length)];
        AudioSource.PlayClipAtPoint(tempClip,transform.position);
        damageFX(deathParticles, transform.position, new Vector3(0, 0, 0));
        if (drops){
            Instantiate(drop, transform.position, drop.transform.rotation);
        }
        Destroy(gameObject.transform.root.gameObject);
        
    }
}
