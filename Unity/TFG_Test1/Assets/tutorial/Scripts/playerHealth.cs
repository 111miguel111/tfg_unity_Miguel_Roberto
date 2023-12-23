using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    float currentHealth;
    public float fullHealth;

    public GameObject playerDeathFX;
    public GameObject playerDeathFX2;

    //HUD
    public Slider playerHealthSlider;
    public Image damageScreen;
    Color flashColor = new Color(255f, 0f, 0f,1f);
    float flashSpeed = 5f;
    bool damaged = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //are we hurt
        if (damaged)
        {
            damageScreen.color = flashColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color,Color.clear, flashSpeed * Time.time);
        }
        damaged = false;
    }

    public void addDamage(float damage)
    {
        damageScreen.color = flashColor;
        damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, flashSpeed * Time.time);
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        damaged = true;
        if(currentHealth <= 0) {
            makeDead();
        }
    }
    public void makeDead()
    {
        Instantiate(playerDeathFX2, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Instantiate(playerDeathFX,transform.position, Quaternion.Euler(new Vector3(-90,0,0)));
        damageScreen.color = flashColor;
        Destroy (gameObject);
    }
}
