using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public float speed = 0; //hra�i boltanum
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count; //teljar stiginn
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //�yngdarafl af player
        count = 0; //byrja telja 0

        SetCountText(); //UI �arf l�ka a� uppf�ra � hvert skipti sem talningarbreytunni er auki� eftir a� spilarinn hefur safna� teningi
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementvalue)
    {
        Vector2 movementVector = movementvalue.Get<Vector2>();

        movementX = movementVector.x; //l�tur mig hreyfa til hli�ar
        movementY = movementVector.y; //l�tur mig hreyfa upp og ni�ur
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); // teljarinn �arf a� hafa gildi sem h�gt er a� nota til a� stilla UI textan
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
        if (other.gameObject.CompareTag("PickUp")) //� hvert skipti sem k�lan Gameobject snertir colliderinn
                                                   //�a� mun f� tilv�sun fyrir colliderinn sem k�lan hefur lent � og athugar s��an tagi�

        {
            other.gameObject.SetActive(false); //ef �a� er collectible mun scripti� heita SetActive sem mun gera gameobject �virkt
            count = count + 1; //gefur alltaf 1 stig til a� telja

            SetCountText();
        }
    }
    
}
