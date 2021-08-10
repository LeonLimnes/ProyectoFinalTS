using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    Image ammoBar;
    Gun gun;

    float currentAmmo;
    float maxAmmo = 220f;

    private void Start()
    {
        ammoBar = transform.GetComponent<Image>();
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
    }

    private void Update()
    {
        currentAmmo = gun.ammo;
        ammoBar.fillAmount = currentAmmo / maxAmmo;
    }

}
