using UnityEngine;

public interface IUnitState
{
    Define.EUnitState StateType { get; }

    void StateEnter();
    void StateExit();
    void StateUpdate();
}

/// <summary>
/// 유닛 상태 관리 컨트롤러
/// </summary>
public class UnitStateController
{
    private UnitIdleState idleState;
    private UnitMoveState moveState;
    private UnitInteractionState attackState;
    private UnitHitState hitState;
    private UnitDeadState deadState;

    private IUnitState curState;

    public IUnitState CurState => curState;

    protected BaseController owner;

    public UnitStateController(BaseController owner)
    {
        this.owner = owner;

        idleState = new UnitIdleState(owner);
        moveState = new UnitMoveState(owner);
        attackState = new UnitInteractionState(owner);
        hitState = new UnitHitState(owner);
        deadState = new UnitDeadState(owner);
    }

    public void ChangeState(Define.EUnitState state)
    {
        switch (state)
        {
            case Define.EUnitState.IDLE:
                SetState(idleState);
                break;
            case Define.EUnitState.MOVE:
                SetState(moveState);
                break;
            case Define.EUnitState.INTERACTION:
                SetState(attackState);
                break;
            case Define.EUnitState.HIT:
                SetState(hitState);
                break;
            case Define.EUnitState.DEAD:
                SetState(deadState);
                break;
        }
    }

    private void SetState(IUnitState newState)
    {
        curState?.StateExit();
        curState = newState;
        curState?.StateEnter();
    }
}
