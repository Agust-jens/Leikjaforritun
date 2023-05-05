using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>(); //finnur ruby script

        if (controller != null)
        {
            if (controller.health < controller.maxHealth) //ef �g er me� l�ti� l�f f� �g health
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}