using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : WeaponBASE
{
    private ParticleSystem hitEffects = null;

    [SerializeField]public float cooldown = .3f;
    private float timer = 0f;

    [Header("ParticleHitEffects")]
    [SerializeField] ParticleSystem hitMetal;
    [SerializeField] ParticleSystem hitFlesh;
    [SerializeField] ParticleSystem hitDirt;
    [SerializeField] ParticleSystem hitWood;

    public TrailRenderer tracerRenderer;
    public ParticleSystem muzzleFlash;
    public Transform firePointTransform;
    //Sits on weapon, is called by third person combat contoller to attack bia WeaponBASE
    private void Start()
    {
        
    }
    private void Update()
    {
        //check attack cooldown if readytoattack or not
        timer -= Time.deltaTime;
        if (timer <= 0) 
        { 
            timer = cooldown; 
            weaponReady = true; 
        }
    }
    public override void WeaponAttackHit(Vector3 rayHitPoint, RaycastHit hit)
    {
        //in this case weapon is a hit, hit effects are displayed on hitpoint
        weaponReady = false;
        muzzleFlash.Emit(1);
        Debug.DrawLine(firePointTransform.position, rayHitPoint, Color.green, 1f);
        //create tracer round
        var tracer = Instantiate(tracerRenderer, firePointTransform.position, Quaternion.identity);
        tracer.AddPosition(firePointTransform.position);

        hit.transform.TryGetComponent(out Shootable shootable);
        {
            hitEffects = DetermineHitEffects(shootable);
            hitEffects.transform.position = hit.point;
            hitEffects.transform.forward = hit.normal;
            hitEffects.Emit(1);
        }
        //move tracer round to hit point
        tracer.transform.position = hit.point;
    }
    public override void WeaponAttackMiss(Vector3 shotDir)
    {
        //in this case no hit effects are played, but still muzzle flash and shoot tracer
        muzzleFlash.Emit(1);

        //create tracer
        var tracer = Instantiate(tracerRenderer, firePointTransform.position, Quaternion.identity);
        tracer.AddPosition(firePointTransform.position);

        Debug.DrawLine(transform.position, shotDir, Color.red, 1f);
        weaponReady = false;

        //move tracer
        tracer.transform.position = shotDir;
    }

    public override void StopAttacking()
    {
        muzzleFlash.Stop();
    }

    private ParticleSystem DetermineHitEffects(Shootable shootable)
    {
        //returns an int to be used in particle system array
        if (shootable.madeOf == Shootable.MadeOf.metal)
        {
            return hitMetal;
        }
        else if (shootable.madeOf == Shootable.MadeOf.flesh)
        {
            return hitFlesh;
        }
        else if (shootable.madeOf == Shootable.MadeOf.dirt)
        {
            return hitDirt;
        }
        else if (shootable.madeOf == Shootable.MadeOf.wood)
        {
            return hitWood;
        }

        return hitMetal;
    }
}
