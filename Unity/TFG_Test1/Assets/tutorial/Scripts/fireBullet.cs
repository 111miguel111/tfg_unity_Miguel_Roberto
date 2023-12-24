using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour{

    public float timeBetweenBullets;
    public GameObject projectile;

    float nextBullet;
    public float startBullet;

    //Audio
    AudioSource gunMuzzleAS;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Awake(){
        nextBullet = Time.time + startBullet;
        gunMuzzleAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        playerController myPlayer = transform.root.GetComponent<playerController>();
        if (Input.GetAxisRaw("Fire1")>0 && nextBullet<Time.time){
            nextBullet = Time.time+timeBetweenBullets;
            Vector3 rot;
            if (myPlayer.getFacing()==-1f){
                rot = new Vector3(0, -90, 0);
            }
            else{
                rot = new Vector3(0, 90, 0);
            }
            Instantiate(projectile, transform.position, Quaternion.Euler(rot));
            playASound(shootSound);
        }
        if (Input.GetAxisRaw("Fire1") < 1)
        {
            nextBullet = Time.time + startBullet;
        }
    }
    void playASound(AudioClip theSound)
    {
        gunMuzzleAS.clip = theSound;
        gunMuzzleAS.Play();
    }
}
