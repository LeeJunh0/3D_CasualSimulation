using System;
using UnityEngine;
using static Define;

public class BaseController : MonoBehaviour
{
    [SerializeField] private EUnitState curState = EUnitState.IDLE;
    [SerializeField] protected UnitData unitData;

    private Animator anim;
    private float currentHp;

    public EUnitState State 
    {
        get => curState;
        set 
        {
            curState = value;
            if (anim == null)
                anim = GetComponent<Animator>();

            switch (curState)
            {
                case EUnitState.IDLE:
                    anim.CrossFade("Idle", 0.1f);
                    break;
                case EUnitState.MOVE:
                    anim.CrossFade("Move", 0.1f);
                    break;
                case EUnitState.ATTACK:
                    anim.CrossFade("Attack", 0.1f);
                    break;
                case EUnitState.HIT:
                    anim.CrossFade("Hit", 0.1f);
                    break;
                case EUnitState.DEAD:
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
            State = EUnitState.DEAD;
            DeadProcess();
        }
        else
            State = EUnitState.HIT;
    }

    public virtual void DeadProcess()
    {

    }
}
