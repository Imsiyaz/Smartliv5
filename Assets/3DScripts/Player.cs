using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    public HealthBar healthBar;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Cube"))
        {
            Destroy(other.gameObject);
            TakeDamage(20);
        }
    }


    void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        Die();
    }

    void Die() 
    {
        if (currentHealth <= 0)
        {
            Invoke(nameof(ReloadLevel), 0.2f);
            Debug.Log("Died");
        }
    }

    void ReloadLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
