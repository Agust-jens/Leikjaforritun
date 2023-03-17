using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public float speed = 0; //hraði boltanum
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count; //teljar stiginn
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //þyngdarafl af player
        count = 0; //byrja telja 0

        SetCountText(); //UI þarf líka að uppfæra í hvert skipti sem talningarbreytunni er aukið eftir að spilarinn hefur safnað teningi
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementvalue)
    {
        Vector2 movementVector = movementvalue.Get<Vector2>();

        movementX = movementVector.x; //lætur mig hreyfa til hliðar
        movementY = movementVector.y; //lætur mig hreyfa upp og niður
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); // teljarinn þarf að hafa gildi sem hægt er að nota til að stilla UI textan
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) //í hvert skipti sem kúlan Gameobject snertir colliderinn
                                                   //það mun fá tilvísun fyrir colliderinn sem kúlan hefur lent í og athugar síðan tagið

        {
            other.gameObject.SetActive(false); //ef það er collectible mun scriptið heita SetActive sem mun gera gameobject óvirkt
            count = count + 1; //gefur alltaf 1 stig til að telja

            SetCountText();
        }
    }
    
}
