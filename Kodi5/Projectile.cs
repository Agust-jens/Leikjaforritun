using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); //nær og finnur rigidbody
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force); //hvað átt það fer og velur force
    }

    void Update()
    {
        if (transform.position.magnitude > 70.0f) // Þetta lætur svo projectile drífi ekki of langt
        {
            Destroy(gameObject); //eyðileggur projectile
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>(); // þetta lætur projectile drepa Enemy
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject); // þetta eyðileggur enemy
    }
}