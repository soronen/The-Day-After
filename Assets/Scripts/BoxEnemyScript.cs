using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemyScript : MonoBehaviour
{

    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;


    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        if (dead)
        {
            return;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerControlScript player = other.gameObject.GetComponent<PlayerControlScript>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
    public void Kill()
    {
        dead = true;
        rigidbody2D.simulated = false;
    }
}
