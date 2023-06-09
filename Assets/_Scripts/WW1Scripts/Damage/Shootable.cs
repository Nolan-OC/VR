using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public enum MadeOf
    {
        metal,
        wood,
        dirt,
        flesh,
        bone
    }
    public MadeOf madeOf;
    public Health health;

    public void Shot(float amount, Transform attacker)
    {
        if (health != null)
            health.TakeDamage(amount, attacker);
    }
}
