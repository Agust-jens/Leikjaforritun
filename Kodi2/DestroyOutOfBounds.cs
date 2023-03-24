using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30; // stoppar projectile/pizza ofan player
    private float lowerBound = -10; //stoppar projectile/d�r undir player

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound) // finnur position af pizzuna
        {
            Destroy(gameObject); // ey�ir food �egar �a� fer �t �r boundary
        } else if (transform.position.z < lowerBound) //finnur position af d�rinu
        {
            Debug.Log("Leikurinn B�inn!"); //ef d�ri� fer fram hj� leikmanninum. leikurinn kl�rast
            Destroy(gameObject); // ey�ir d�rinu �egar �a� fer �t �r boundary
        }
    }
}
