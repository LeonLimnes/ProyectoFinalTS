using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public float health = 100f;

    [SerializeField] ParticleSystem explosion;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void IncrementHealth()
    {
        health += 15f;
        if (health > 100)
            health = 100f;
    }
    public void Die()
    {
        if (explosion != null)
            explosion.Play();
        switch (gameObject.tag)
        {
            case "Player":
                health = 0;
                EndGame gameEnd = GameObject.Find("Canvas").GetComponent<EndGame>();
                gameEnd.GameOver();
                Destroy(gameObject);
                break;
            case "Turret":
                gameObject.SetActive(false);
                Destroy(gameObject, 2f);
                break;
            default:
                Destroy(gameObject);
                break;
        }
        
    }
}
