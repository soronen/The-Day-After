using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI1 : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float moveSpeed;
    public int health = 2;
    Rigidbody2D rb;

    // daze time is a time when the enemy is being hit and they stop moving towards the player for the time that is being decided.
    private float dazedTime;
    public float startDazedTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.position);

        if (dazedTime <= 0)
        {
            moveSpeed = 5;
        }
        else
        {
            moveSpeed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (dist < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChase();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// The enemy takes damage in this method.
    /// The amount of damage depends on how much damage the player does in attack script.
    /// Dazetime also begins when damage is being taken.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// This method makes the enemy to chase the player.
    /// When the player gets inside the agrorange (in update method),
    /// the enemy starts to move towards the player horizontally.
    /// </summary>
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = false;

        }
    }

    // Stops the enemy moving towards the palyer.
    void StopChase()
    {
        rb.velocity = new Vector2(0, 0);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// This method causes damage to player if the player is being touched.
    /// </summary>
    /// <param name="other"></param> 
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerControlScript player = other.gameObject.GetComponent<PlayerControlScript>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
