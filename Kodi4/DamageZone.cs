using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>(); //nær í ruby script

        if (controller != null) // ef ruby fer on á missir hann 1 líf
        {
            controller.ChangeHealth(-1);
        }
    }

}
