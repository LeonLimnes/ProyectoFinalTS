using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider c)
    {
        print("I am collected");
        if (c.gameObject.name == "Player")
        {
            switch (transform.tag)
            {
                case "Gummy Bear":
                    GummyBears gummyBear = GameObject.Find("GummyBears_text").GetComponent<GummyBears>();
                    gummyBear.IncrementCount();
                    break;
                case "Health Pickup":
                    Target target = c.transform.GetComponent<Target>();
                    target.IncrementHealth();
                    break;
                case "Ammo Pickup":
                    Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
                    gun.IncremenAmmo();
                    break;

            }

            Destroy(gameObject);
        }

    }
}
