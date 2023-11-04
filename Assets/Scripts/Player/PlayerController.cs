using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{
    [SerializeField] List<GameObject> animalForms;
    private GameObject currentAnimal;
    Animator animator;
    
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private bool Death;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        Death = false;

        currentAnimal = animalForms[0];
        animator = currentAnimal.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the character is out of life
        if (currentHealth <= 0 && !Death)
        {
            Die();
        }
    }

    public void takeDamage(int amount)
    {

        if (animator != null)
        {
            animator.SetTrigger("isFrontHit");

            currentHealth -= amount;
            healthBar.setHealth(currentHealth);
        }
    }

    void Die()
    {
        if (animator != null)
        {
            animator.SetBool("isDead", true);
            animator.SetTrigger("deadTrigger");
            Death = true;
        }

    }
}
