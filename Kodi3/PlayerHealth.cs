using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health; //Heldur utan um núverandi health playerinum
    public float maxHealth; // Hversu mikla health þú hefur þegar þú ert við fulla health
    public Image healthBar; // nær í image

    private bool isDead;

    public GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health; // set your current health to full
    }

    public void TakeDamage(int amount)
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        health -= amount;
        if (health <= 0 && !isDead) // if the damage takes the player down to zero, the the player will be destroyed
        {
            isDead = true;
            gameObject.SetActive(false);
            gameManager.gameOver();
            Debug.Log("Dead");

        }
    }
}
