
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    [SerializeField] float range = 20f;

    [SerializeField] Camera fpsCamera;

    [SerializeField] ParticleSystem muzzleFlash;

    [SerializeField] GameObject impactEffect;

    [SerializeField] float fireRate = 5f;

    [SerializeField] public float ammo = 220.0f;

    float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if(ammo > 0)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
        
    }

    public void IncremenAmmo()
    {
        ammo += 45f;
        if (ammo > 220)
            ammo = 220f;
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;

        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {

            Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.25f);
            ammo -= 1;
        }
    }
}
