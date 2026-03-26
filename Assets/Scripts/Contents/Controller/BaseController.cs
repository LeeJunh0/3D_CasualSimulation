using System;
using UnityEngine;
using static Define;

public class BaseController : InteractionObject
{
    public InteractionObject CurrentTarget { get; set; }

    [SerializeField] protected UnitData unitData;

    protected UnitStateController stateController;
    private float currentHp;

    public float CurrentHp
    {
        get => currentHp;
        set
        {
            currentHp = Mathf.Max(0, Mathf.Min(currentHp, value));
        }
    }

    public virtual void Init()
    {
        stateController = new PlayerStateController(this);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != InteractionLayer)
            return;

        InteractionObject target = other.GetComponent<InteractionObject>();
        CurrentTarget = target;
        stateController.ChangeState(EUnitState.INTERACTION);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != InteractionLayer)
            return;

        CurrentTarget = null;
        stateController.ChangeState(EUnitState.INTERACTION);
    }
}
