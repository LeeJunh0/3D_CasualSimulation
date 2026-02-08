using UnityEngine;

public class PlayerDeadState : IPlayerState
{
    public Define.EUnitState StateType => Define.EUnitState.DEAD;

    public void StateEnter()
    {
        throw new System.NotImplementedException();
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
