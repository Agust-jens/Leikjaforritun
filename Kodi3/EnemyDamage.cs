using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth; //nær í scriptuna playerhealth
    public int damage = 20; //enemy gerir 20 damage í player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerHealth.TakeDamage(damage);
            gameObject.SetActive(false); // Enemy hverfur þegar hann hittir player
        }
    }
}
