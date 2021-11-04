using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotPrefab;

    public float shootingRate = 0.25f;


    private float shotCoolDown;
    void Start()
    {
        shotCoolDown = 0f;
    }

    void Update()
    {
        
        if(shotCoolDown > 0)
        {
            shotCoolDown -= Time.deltaTime;
        }
    }

    public bool _canAttack
    {
        get
        {
            return shotCoolDown <= 0f;
        }
    }


    public void _attack(bool isEnemy)
    {
        if(_canAttack)
        {
            shotCoolDown = shootingRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;

            Shot shot = shotTransform.gameObject.GetComponent<Shot>();
            if(shot  != null)
            {
                shot.isEnemyShot = isEnemy;
            }
            Move move = shot.gameObject.GetComponent<Move>();
            if(move != null)
            {
                move.direction = this.transform.right;
            }
        }
    }
}
