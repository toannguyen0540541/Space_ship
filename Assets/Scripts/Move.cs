using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);


    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;





    public float bound_X = -8f, bound_XR = 9f;
    public bool isShot = false;

    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);



        _platformMove();
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null)
        {
            rigidbodyComponent = GetComponent<Rigidbody2D>();
        }
        rigidbodyComponent.velocity = movement;
    }




    void _platformMove()
    {
        Vector2 movePlatform = transform.position;

        if (movePlatform.x <= bound_X)
        {
            gameObject.SetActive(false);
        }
        if (movePlatform.x >= bound_XR)
            {
                gameObject.SetActive(false);
        }
    }
}
