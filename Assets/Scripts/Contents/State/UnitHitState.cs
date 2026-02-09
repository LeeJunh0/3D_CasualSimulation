using UnityEngine;

public class UnitHitState : IUnitState
{
    public Define.EUnitState StateType => Define.EUnitState.HIT;

    private BaseController owner;
    private Animator anim;

    public UnitHitState(BaseController owner)
    {
        this.owner = owner;
        anim = owner.GetComponent<Animator>();
    }

    public void StateEnter()
    {
        anim.CrossFade("Hit", 0.1f);
    }

    public void StateExit()
    {
    }

    public void StateUpdate()
    {
    }
}
