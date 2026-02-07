using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventHandler : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<PointerEventData> LeftClickHandler;
    public event Action<PointerEventData> RightClickHandler;
    public event Action<PointerEventData> BeginDragHandler;
    public event Action<PointerEventData> DragHandler;
    public event Action<PointerEventData> EndDragHandler;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            LeftClickHandler?.Invoke(eventData);
        else if (eventData.button == PointerEventData.InputButton.Right)
            RightClickHandler?.Invoke(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData) =>  BeginDragHandler?.Invoke(eventData);
    public void OnDrag(PointerEventData eventData) =>       DragHandler?.Invoke(eventData);
    public void OnEndDrag(PointerEventData eventData) =>    EndDragHandler?.Invoke(eventData);


}
