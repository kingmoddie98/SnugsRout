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

    public bool isMelee;

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
        Debug.Log("I am attacking " + obj);
        if (isMelee)
        {
            //Debug.Log(Vector2.Distance(this.transform.position, obj.transform.position));
            if(Vector2.Distance(this.transform.position, obj.transform.position) <= 1)
            {
                Debug.Log("I am in range to attack!");
                obj.GetComponent<Unit>().TakeDamage(10);
            }
            //
        }
        else if(!isMelee)
        {
            obj.GetComponent<Unit>().TakeDamage(20);
        }
    }

    public void Die()
    {
        GameObject.Destroy(this.gameObject, 0.0f);
    }


   


}
