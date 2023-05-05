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
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        if (transform.position.magnitude > 1000.0f)// Þetta lætur svo projectile drífi ekki of langt
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>(); // þetta lætur projectile drepa Enemy
        if (e != null)
        {
            e.Fix(); //ef ég hitti enemy með projectile kemur animation
        }

        Destroy(gameObject);
    }
}
