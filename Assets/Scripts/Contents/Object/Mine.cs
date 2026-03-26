using Contents.Controller.Player;
using TMPro;
using UnityEngine;
using static Define;

public class Mine : InteractionObject
{
    public TextMeshProUGUI tempUI;

    private void OnTriggerEnter(Collider other)
    {
        InteractionObject io = other.GetComponent<InteractionObject>();
        if (io == null)
            return;

        EInteractionType type = io.GetComponent<InteractionObject>().InteractionType;
        InteractionEnter(type);
    }

    private void OnTriggerExit(Collider other)
    {
        InteractionObject io = other.GetComponent<InteractionObject>();
        if (io == null)
            return;

        EInteractionType type = io.gameObject.GetComponent<InteractionObject>().InteractionType;
        InteractionExit(type);
    }

    public override void InteractionEnter(EInteractionType type)
    {
        if (type != EInteractionType.SCV && type != EInteractionType.PLAYER)
            return;

        base.InteractionEnter(type);
    }

    public override void InteractionExit(EInteractionType type)
    {
        if (type != EInteractionType.SCV && type != EInteractionType.PLAYER)
            return;

        base.InteractionExit(type);
    }

    public override void InteractionStay(EInteractionType type)
    {
        if (type != EInteractionType.SCV && type != EInteractionType.PLAYER)
            return;        
    }

    public override void InteractionExcute(EInteractionType type)
    {
        WeakEventBus.Publish<MoneyEvent>(new MoneyEvent(5));
    }
}
