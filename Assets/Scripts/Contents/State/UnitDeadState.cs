using UnityEngine;

public class UnitDeadState : IUnitState
{
    public Define.EUnitState StateType => Define.EUnitState.DEAD;

    private BaseController owner;
    private Animator anim;

    public UnitDeadState(BaseController owner)
    {
        this.owner = owner; 
        anim = owner.GetComponent<Animator>();
    }
    public void StateEnter()
    {
        anim.CrossFade("Dead", 0.1f);
    }

    public void StateExit()
    {
    }

    public void StateUpdate()
    {
    }
}
