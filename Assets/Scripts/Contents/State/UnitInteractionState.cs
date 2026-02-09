using UnityEngine;

public class UnitInteractionState : IUnitState
{
    public Define.EUnitState StateType => Define.EUnitState.INTERACTION;

    private BaseController owner;
    private Animator anim;

    public UnitInteractionState(BaseController owner)
    {
        this.owner = owner; 
        anim = owner.GetComponent<Animator>();
    }

    public void StateEnter()
    {
        //anim.CrossFade("Attack", 0.1f);
    }

    public void StateExit()
    {
    }

    public void StateUpdate()
    {
    }

}
