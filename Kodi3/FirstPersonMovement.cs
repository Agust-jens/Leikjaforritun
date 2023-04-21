using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5; //hraði á leikmanninum
    public TextMeshProUGUI countText; // finnur CountText
    public GameObject winTextObject; // finnur Win Text

    private int count; //teljar stiginn

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Start()
    {
        count = 0; //byrja telja 0

        SetCountText(); //UI þarf líka að uppfæra í hvert skipti sem talningarbreytunni er aukið eftir að spilarinn hefur safnað teningi
        winTextObject.SetActive(false);
    }

    void Awake() // void start
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); // teljarinn þarf að hafa gildi sem hægt er að nota til að stilla UI textan
        if (count >= 5)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
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