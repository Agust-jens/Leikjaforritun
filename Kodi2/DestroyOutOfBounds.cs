using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30; // stoppar projectile/pizza ofan player
    private float lowerBound = -10; //stoppar projectile/dýr undir player

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound) // finnur position af pizzuna
        {
            Destroy(gameObject); // eyðir food þegar það fer út úr boundary
        } else if (transform.position.z < lowerBound) //finnur position af dýrinu
        {
            Debug.Log("Leikurinn Búinn!"); //ef dýrið fer fram hjá leikmanninum. leikurinn klárast
            Destroy(gameObject); // eyðir dýrinu þegar það fer út úr boundary
        }
    }
}
