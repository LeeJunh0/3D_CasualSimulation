using System;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Util
{
    public static void AddEvent(this GameObject go, Action<PointerEventData> action = null, Define.EEventType type = Define.EEventType.LEFTCLICK)
    {
        EventHandler eventHandler = go.GetComponent<EventHandler>();
        if (eventHandler == null)
            eventHandler = go.AddComponent<EventHandler>();

        switch (type)
        {
            case Define.EEventType.LEFTCLICK:
                eventHandler.LeftClickHandler -= action;
                eventHandler.LeftClickHandler += action;
                break;
            case Define.EEventType.RIGHTCLICK:
                eventHandler.RightClickHandler -= action;
                eventHandler.RightClickHandler += action;
                break;
            case Define.EEventType.BEGINDRAG:
                eventHandler.BeginDragHandler -= action;
                eventHandler.BeginDragHandler += action;
                break;
            case Define.EEventType.DRAG:
                eventHandler.DragHandler -= action;
                eventHandler.DragHandler += action;
                break;
            case Define.EEventType.ENDDRAG:
                eventHandler.EndDragHandler -= action;
                eventHandler.EndDragHandler += action;
                break;
        }
    }
}
