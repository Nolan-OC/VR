using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rbBones;
    Animator animator;

    void Start()
    {
        rbBones = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        DeactivateRagdoll();
    }

    public void DeactivateRagdoll()
    {
        foreach(var rb in rbBones)
        {
            rb.isKinematic = true;
        }
        animator.enabled = true;
    }
    public void ActivateRagdoll()
    {
        foreach (var rb in rbBones)
        {
            rb.isKinematic = false;
        }
        animator.enabled = false;
    }
}
