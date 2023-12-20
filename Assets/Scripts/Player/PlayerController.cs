using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<GameObject> animalForms;
    [SerializeField] int potionHealth;
    private GameObject currentAnimal;
    private InventoryController inventory;
    Animator animator;
    
    public int maxHealth = 100;
    public int maxMana = 100;
    public int currentHealth;
    public int currentMana;
    public ManaBar manaBar;
    public HealthBar healthBar;

    public void ReachedCheckPoint(Vector3 position)
    {
        HealFountain();
    }

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
        if (inventory == null) 
        {
            inventory = InventoryController.Instance;
        }

        if (currentHealth <= 0 && !Death)
        {
            Die();
        }
        else 
        {
            if (!IsCurrentAnimal(currentAnimal))
            {
                currentAnimal = animalForms[FindAnimal()];
                animator = currentAnimal.GetComponent<Animator>();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1)) 
            {
                inventory.ConsumeItem(ItemType.HEALTH_POTION);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) 
            {
                inventory.ConsumeItem(ItemType.MANA_POTION);
            }
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
        if (animator == null) return;

        Death = true;
        animator.SetBool("isDead", Death);
        animator.SetTrigger("deadTrigger");
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
        Mana(maxMana);
    }


    private void Mana(int amount)
    {
        currentMana += amount;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        manaBar.setMana(currentMana);
    }

    private void Heal(int amount) 
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        healthBar.setHealth(currentHealth);
    }

    public int currentTransformation()
    {
        if (currentAnimal.name == "Boar")
        {
            return 0;
        }

        else
            return 1;
    }
}
