using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 1)
        {
            Destroy(gameObject);
        }
    }
}
