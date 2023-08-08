using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private SO_WeaponData weaponData;

    Animator animator;
    protected PlayerAttackState attackState;
    protected int attackCounter;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void EnterWeapon()
    {
        if (attackCounter >= 2)
        {
            attackCounter = 0;
        }
        animator.SetBool("attack", true);
        animator.SetInteger("attackCounter", attackCounter);
    }
    public virtual void ExitWeapon()
    {
        animator.SetBool("attack", false);

        attackCounter++;
    }

    public virtual void AnimationStartMovementTrigger()
    {
        //attackState.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    }
    public virtual void AnimationStopMovementTrigger()
    {
        //attackState.SetPlayerVelocity(0f);
    }

    public void InitializeWeapon(PlayerAttackState state)
    {
        this.attackState = state;
    }
}
