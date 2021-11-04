using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Vector2 speed = new Vector2(15, 15);



    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;



    float min_X = -7.34f, max_X = 7.62f, max_Y = 3.81f, min_Y = -4.12f;


    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        _checkBound();
            bool shoot = Input.GetButtonDown("Fire1");
            shoot |= Input.GetButtonDown("Fire2");

            if (shoot)
            {
                Weapon weapon = GetComponent<Weapon>();
                if (weapon != null)
                {
                    weapon._attack(false);
                }
            }

            // ...
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null)
        {
            rigidbodyComponent = GetComponent<Rigidbody2D>();
        }
        rigidbodyComponent.velocity = movement;
    }

    void _checkBound()
    {
        Vector2 temp = transform.position;
        if(temp.x < min_X)
        {
            temp.x = min_X;
        }
        if (temp.x > max_X)
        {
            temp.x = max_X;
        }
        if(temp.y < min_Y)
        {
            temp.y = min_Y;
        }
        if(temp.y > max_Y)
        {
            temp.y = max_Y;
        }

        transform.position = temp;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        EnemieScript enemy = collision.gameObject.GetComponent<EnemieScript>();

        if (enemy != null)
        {
            Heal enemyHealth = enemy.GetComponent<Heal>();
            damagePlayer = true;
        }

        if (damagePlayer)
        {
            Heal playerHealth = this.GetComponent<Heal>();
            if (playerHealth != null) playerHealth._dame(1);
        }
    }













}
