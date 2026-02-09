using System;
using UnityEngine;
using static Define;

public class BaseController : MonoBehaviour
{
    [SerializeField] protected UnitData unitData;

    protected UnitStateController stateController;
    private Animator anim;
    private float currentHp;

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
            DeadProcess();
        }
    }

    public virtual void DeadProcess()
    {

    }
}
