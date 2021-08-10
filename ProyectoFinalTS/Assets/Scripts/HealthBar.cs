using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    GameObject player;
    Target target;

    float currentHealth;
    float maxHealth = 100f;

    private void Start()
    {
        healthBar = transform.GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.GetComponent<Target>();
    }

    private void Update()
    {
        currentHealth = target.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }


}
