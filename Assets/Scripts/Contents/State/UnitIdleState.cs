using UnityEngine;

public class UnitIdleState : IUnitState
{
    public Define.EUnitState StateType => Define.EUnitState.IDLE;

    private BaseController owner;
    private Animator anim;

    public UnitIdleState(BaseController owner)
    {
        this.owner = owner;
        anim = owner.GetComponent<Animator>();
    }

    public void StateEnter()
    {
        anim.CrossFade("Idle", 0.1f);
    }

    public void StateExit()
    {
        
    }

    public void StateUpdate()
    {
        
    }
}
