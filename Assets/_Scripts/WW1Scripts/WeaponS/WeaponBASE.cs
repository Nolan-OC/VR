using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBASE : MonoBehaviour
{
    public bool weaponReady = true;
    public ScriptableObject weaponStats;

    //DEBUG TODO these should be read in from weapon stats?
    //or they could just be set in prefab... probably less complicated.
    public float damage;
    public float range = 5f;

    private void Awake()
    {
        //read stats from weaponstats
        //damage = weaponStats.damage;
        damage = 10;
    }
    public virtual void WeaponAttackHit(Vector3 rayEndPoint, RaycastHit hit)
    {
        //called when the attack button is held down

    }
    public virtual void WeaponAttackMiss(Vector3 shotDir)
    {
        //only plays the vfx of attack, muzzle flash, raycast etc.
        //doesnt actually hit or hurt anyhting
    }
    public virtual void StopAttacking()
    {
        //called when the attack button is released
    }




}
