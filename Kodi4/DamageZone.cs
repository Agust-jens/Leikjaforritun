using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>(); //n�r � ruby script

        if (controller != null) // ef ruby fer on � missir hann 1 l�f
        {
            controller.ChangeHealth(-1);
        }
    }

}
