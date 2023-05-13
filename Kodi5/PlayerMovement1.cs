using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement1 : MonoBehaviour
{
    public CharacterController controller;

    public int maxHealth = 5; //health af player

    public GameObject projectilePrefab; //lætur mig setja projectile inn í Player Inspectorinn

    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f; //Tími til að ég recover-a aftur þegar enemy damage-ar mig
    bool isInvincible;
    float invincibleTimer;

    public GameManagerScript gameManager;
    public CoinManager cm;
    public Text WINTEXT;

    public float speed = 40f; // Hraði á playerinum

    Rigidbody2D rigidbody2d;
    float horizontal = 0f;
    //float vertical;
    bool jump = false;
    private bool isDead;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed;
        // vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, 0);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(0, 0.0f))
        {
            lookDirection.Set(move.x, 0);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontal * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if(currentHealth <= 0 && !isDead) //ef healthið er 0 þá dey ég og finnur gameover í gamemanager
        {
            isDead = true;
            gameManager.gameOver();
            gameObject.SetActive(false);
            Debug.Log("DEAD");
        }

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Win") 
        {
            WINTEXT.gameObject.SetActive(true); // ef ég collider við collider sem er í endanum af leiknum fæ ég Win texta
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
