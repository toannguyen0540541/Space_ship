using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int hp = 1;

    public bool isEnemy = false;
    //public bool isPlayer = false;


    public void _dame(int dameCount)
    {
        hp = -dameCount;
        if(hp <= 0)
        {
            if (isPlayer == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
            }
            Destroy(gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Shot shotOut = otherCollider.gameObject.GetComponent<Shot>();
        if(shotOut != null)
        {
            if(shotOut.isEnemyShot != isEnemy)
            {
                _dame(shotOut.damage);
                Destroy(shotOut.gameObject);
            }
        }
    }


    public bool isPlayer = false;
    void OnCollisionEnter2D(Collision2D target)
    {
        EnemieScript enemie = target.gameObject.GetComponent<EnemieScript>();
        if (target.gameObject.tag == "enemies" && isPlayer == true)
        {
            Destroy(enemie.gameObject);
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
        }
    }









}
