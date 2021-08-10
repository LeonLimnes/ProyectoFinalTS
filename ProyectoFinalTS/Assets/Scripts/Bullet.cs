using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{

    [SerializeField] float speed = 30f;

    [SerializeField] float damage = 5f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }

   
    void OnCollisionEnter(Collision c)
    {

    if(c.collider.gameObject.tag == "Player" || c.collider.gameObject.tag == "Crate ")
        {
            Target target = c.collider.gameObject.GetComponent<Target>();
            target.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    
    
}
