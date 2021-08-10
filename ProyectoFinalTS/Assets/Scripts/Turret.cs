using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform target = null;

    [SerializeField] float range = 15f;

    [SerializeField] Transform PartToRotate;

    float offset = 1f;


    [SerializeField] ParticleSystem muzzleFlash;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    [SerializeField] float fireRate = 2f;


    float nextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        float playerDistance = range + 1;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerDistance = Vector3.Distance(transform.position, player.transform.position);

        if(playerDistance <= range)
        {
            target = player.transform;
        }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        direction = direction - new Vector3(0, offset, 0);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        PartToRotate.rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, 0.85f);

        if(Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        GameObject bulletGo = Instantiate(bullet, firePoint.position, firePoint.rotation);
 
        Destroy(bulletGo, 1f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
