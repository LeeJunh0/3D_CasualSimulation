using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    public Define.EUnitState StateType => Define.EUnitState.IDLE;

    public void StateEnter()
    {
        
    }

    public void StateExit()
    {
        throw new System.NotImplementedException();
    }

    public void StateUpdate()
    {
        throw new System.NotImplementedException();
    }
}
