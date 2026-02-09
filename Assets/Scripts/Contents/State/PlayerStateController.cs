using UnityEngine;

public class PlayerStateController : UnitStateController
{
    public PlayerStateController(BaseController owner) : base(owner)
    {
        this.owner = owner;
    }
}
