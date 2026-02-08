public interface IPlayerState
{
    Define.EUnitState StateType { get; }

    void StateEnter();
    void StateExit();
    void StateUpdate();
}

/// <summary>
/// 플레이어 상태 관리 컨트롤러
/// </summary>
public class PlayerStateController
{
    private PlayerIdleState idleState;
    private PlayerMoveState moveState;
    private PlayerAttackState attackState;
    private PlayerHitState hitState;
    private PlayerDeadState deadState;

    private IPlayerState curState;

    public IPlayerState CurState => curState;

    public PlayerStateController()
    {
        idleState = new PlayerIdleState();
        moveState = new PlayerMoveState();
        attackState = new PlayerAttackState();
        hitState = new PlayerHitState();
        deadState = new PlayerDeadState();
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
            case Define.EUnitState.ATTACK:
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

    private void SetState(IPlayerState newState)
    {
        curState?.StateExit();
        curState = newState;
        curState?.StateEnter();
    }
}
