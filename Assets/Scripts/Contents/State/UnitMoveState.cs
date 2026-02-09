using UnityEngine;

public class UnitMoveState : IUnitState
{
    public Define.EUnitState StateType => Define.EUnitState.MOVE;

    private BaseController owner;
    private Animator anim;

    public UnitMoveState(BaseController owner)
    {
        this.owner = owner;
        anim = owner.GetComponent<Animator>();
    }

    public void StateEnter()
    {
        anim.CrossFade("Move", 0.1f);
    }

    public void StateExit()
    {
    }

    public void StateUpdate()
    {
    }
}
