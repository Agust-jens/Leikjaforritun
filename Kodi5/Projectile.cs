using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); //n�r og finnur rigidbody
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force); //hva� �tt �a� fer og velur force
    }

    void Update()
    {
        if (transform.position.magnitude > 70.0f) // �etta l�tur svo projectile dr�fi ekki of langt
        {
            Destroy(gameObject); //ey�ileggur projectile
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>(); // �etta l�tur projectile drepa Enemy
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject); // �etta ey�ileggur enemy
    }
}