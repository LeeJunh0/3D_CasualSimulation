using System;
using UnityEngine;
using static Define;

public class BaseController : MonoBehaviour
{
    [SerializeField] private ECharacterState curState = ECharacterState.IDLE;
    [SerializeField] protected UnitData unitData;

    private Animator anim;
    private float currentHp;


    public ECharacterState State 
    {
        get => curState;
        set 
        {
            curState = value;
            if (anim == null)
                anim = GetComponent<Animator>();

            switch (curState)
            {
                case ECharacterState.IDLE:
                    anim.CrossFade("Idle", 0.1f);
                    break;
                case ECharacterState.MOVE:
                    anim.CrossFade("Move", 0.1f);
                    break;
                case ECharacterState.ATTACK:
                    anim.CrossFade("Attack", 0.1f);
                    break;
                case ECharacterState.HIT:
                    anim.CrossFade("Hit", 0.1f);
                    break;
                case ECharacterState.DEAD:
                    anim.CrossFade("Dead", 0.1f);
                    break;

            }
        }
    }

    public float CurrentHp
    {
        get => currentHp;
        set
        {
            currentHp = Mathf.Max(0, Mathf.Min(currentHp, value));
        }
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHp -= damage;
        // »ç¸Á
        if (currentHp <= 0)
        {
            State = ECharacterState.DEAD;
            DeadProcess();
        }
        else
            State = ECharacterState.HIT;
    }

    public virtual void DeadProcess()
    {

    }
}
