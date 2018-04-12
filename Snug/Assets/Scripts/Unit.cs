using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{

    public Transform target;
    
    Vector3[] path;
 

    public bool Selected = false;

    public bool isWalkable = true;

    public float startHealth = 100;

    private float health;

    public Image healthbar;

    public bool isFriend;

    public bool canAttack;

    void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthbar.fillAmount = health /startHealth;

        if(health <=0)
        {
            Die();
        }

    }

    public void beginAttack(GameObject obj)
    {

    }

    public void Die()
    {
        GameObject.Destroy(this, 0.0f);
    }


   


}
