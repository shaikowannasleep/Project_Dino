
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class enemyHealth : MonoBehaviour
{


    public double enemy_health;
    public int enemyStrength;
    public bool isDead;
    private Rigidbody2D myRigidbody;

    private DropItem itemDrop;

    /*
     * @ pre none
     * @ param none
     * @ post initialize enemy health before frame gets updated
     * @ return none
     */
    void Start()  // Start is called before the first frame update
    {
        isDead = false;
        itemDrop = GetComponent<DropItem>();
    }

    /*
     * @ pre none
     * @ param none
     * @ post updated every frame to check mob's health condition
     * @ return none
     */
    void Update()  // Update is called once per frame
    {
        if (enemy_health <= 0.0)
        {
            isDead = true;
            DestroyEnemy();
        }
    }
    
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("swordHitbox") && enemy_health > 0.0)
        {
            enemy_health -= 1.0;

           // Vector2 difference = transform.position - other.transform.position;
            //transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
    
    /*
     * @ pre none
     * @ param a collider2D object
     * @ post if player collider intersect with other collider function got called and knockback player
     * @ return none
     */
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && isDead != true)
        {
        //    Vector2 difference = other.transform.position - transform.position;
         //   other.transform.position = new Vector2(other.transform.position.x + difference.x, other.transform.position.y + difference.y);
        } 
    }
    
    /*
     * @ pre none
     * @ param a collider2D object
     * @ post  player get correct damage when they are hit by mob
     * @ return none
     */
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          //  other.gameObject.GetComponent<playerHealth>().harmPlayer(enemyStrength);
        }
    }

    /*
     * @ pre none
     * @ param none
     * @ post destroy enemy once mob health is under 0
     * @ return none
     */
    private void DestroyEnemy()
    {
        if (itemDrop != null)
        {
            itemDrop.ItemDrop(); 
        }
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
    
}
