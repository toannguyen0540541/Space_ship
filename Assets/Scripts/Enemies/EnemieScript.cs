using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieScript : MonoBehaviour
{
    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }
    void Update()
    {
        if(weapon != null && weapon._canAttack)
        {
            weapon._attack(true);
        }
    }
}
