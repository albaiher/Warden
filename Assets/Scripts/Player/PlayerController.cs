using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<GameObject> animalForms;
    [SerializeField] int potionHealth;
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

        if (!IsCurrentAnimal(currentAnimal))
        {
            currentAnimal = animalForms[FindAnimal()];
            animator = currentAnimal.GetComponent<Animator>();
        }

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

    private bool IsCurrentAnimal(GameObject animal)
    {
        return animal.activeSelf;
    }

    private int FindAnimal()
    {
        int index = -1;

        foreach (GameObject animal in animalForms)
        {
            if (IsCurrentAnimal(animal))
            {
                index = animalForms.IndexOf(animal);
            }
        }

        return index;
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

    public void HealPotion(int amount) 
    {
        Heal(amount);
    }

    public void ManaPotion(int amount)
    {
        Mana(amount);
    }

    public void HealFountain()
    {
        Heal(maxHealth);
    }


    private void Mana(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.setHealth(currentHealth);
    }

    private void Heal(int amount) 
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        healthBar.setHealth(currentHealth);
    }
}
