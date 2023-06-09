using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private Ragdoll ragdoll;

    private void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;
    }

    public void takeDamage(float amount, Transform attacker)
    {

        currentHealth -= amount;
        if (currentHealth <= 0.0f)
            Die();
    }

    private void Die()
    {
        //if player do playerdeath
        if(TryGetComponent(out CharacterController controller))
        {
            ragdoll.ActivateRagdoll();
        }
        else
        {
            Debug.Log(transform.name + " is dead");
        }

        //disable all components on object
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
        {
            c.enabled = false;
        }
    }
    public void TakeDamage(float amount, Transform attacker)
    {
        Debug.Log(transform.name + " is damaged by " + attacker.name + " for " + amount);
        currentHealth -= amount;
    }
}
