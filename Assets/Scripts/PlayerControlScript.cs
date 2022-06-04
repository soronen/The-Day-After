using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControlScript : MonoBehaviour
{
    public int speed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1000;
    private float moveX;
    public bool isGrounded;
    public Animator animator;
    public float timeInvincible = 2.0f;
    public int maxHealth = 3;
    public int currentHealth;
    public int coins = 0;
    bool isInvincible;
    float invincibleTimer;

    private void Start()
    {
        // fps capped to 60
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        currentHealth = maxHealth;
        Userinterface.instance.SetMaxHealth(maxHealth);
        Userinterface.instance.SetHealth(currentHealth);

        coins = SaveNReload.LoadCoins();
        currentHealth = SaveNReload.LoadHealth();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        Userinterface.instance.SetCoins(coins);
        Userinterface.instance.SetHealth(currentHealth);
    }

    void PlayerMove()
    {
        // This is the horizontal movement float which we need to move the player,
        // and we need this for the flipping method as well.
        moveX = Input.GetAxis("Horizontal");

        // Allowing the player to jump
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }

        // This method flips the player picture to face other direction.
        // When the player moves to other side the boolean changes and the "FlipPlayer"-method is being called.
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        // Giving speed to the player
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    // Jumping method
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    /// <summary>
    /// This changes the direction of the player when they move.
    /// When the player move to other direction the boolean "facingRight" changes, 
    /// and the player picture is flipped in the PlayerMove method.
    /// </summary>
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    /// <summary>
    /// When the player is no more on collision with the ground then the boolean "isGrounded" changes to false,
    /// and the player can't jump anymore.
    /// This is made to prevent endless jumping possibility.
    /// </summary>
    /// <param name="collider"></param>
    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    /// <summary>
    /// When the player hits ground (which has a tag "Ground) the boolean "isGrounded" changes to true, and the player is able to jump
    /// </summary>
    /// <param name="collider"></param> 

    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    /// <summary>
    /// tracks changes to player health. If player loses health makes the player invincible for a period.
    /// Also calls for Die() method from Userinterface when health reaches 0.
    /// </summary>
    /// <param name="amount">amount of health lost / gained</param>
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
        Userinterface.instance.SetHealth(currentHealth);

        SaveNReload.SaveHealth(currentHealth);

        if (currentHealth == 0)
        {
            Debug.Log("you died");
            Userinterface.instance.Die();
        }
    }

    /// <summary>
    /// adds coins to player, also sends the new total value to Userinterface.SetCoins method.
    /// </summary>
    /// <param name="amount">number of coins added</param>
    public void AddCoins(int amount)
    {
        coins += amount;
        Userinterface.instance.SetCoins(coins);

        SaveNReload.SaveCoins(coins);

        Debug.Log("coin added and saved");
    }
}
