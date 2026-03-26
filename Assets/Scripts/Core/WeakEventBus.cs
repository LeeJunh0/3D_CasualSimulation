using System;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{ }

public static class WeakEventBus
{
    public static Dictionary<Type, List<WeakReference>> eventDict = new Dictionary<Type, List<WeakReference>>();

    // 이벤트 구독
    public static void Subcribe<T>(Action<T> eventData) where T : IEvent
    {
        Type type = typeof(T);
        if (eventDict.TryGetValue(type, out var eventList) == false)
        {
            eventList = new List<WeakReference>();
            eventDict[type] = eventList;
        }

        for (int i = eventList.Count - 1; i >=0; --i)
        {
            // 좀비 삭제
            if (eventList[i].Target == null)
            {
                eventList.RemoveAt(i);
                continue;
            }

            // 이미 같은 이벤트가 있다면 추가안함
            if (eventList[i].Target.Equals(eventData) == true)
                return;
        }

        // 구독
        eventList.Add(new WeakReference(eventData));
    }

    // 이벤트 실행
    public static void Publish<T>(T eventValue) where T : IEvent
    {
        Type type = typeof(T);
        if (eventDict.TryGetValue(type, out List<WeakReference> eventList) == false)
            return;

        for (int i = eventList.Count - 1; i >= 0; --i)
        {
            object target = eventList[i].Target;
            if (target is Action<T> eventData)
                eventData.Invoke(eventValue);
            else
                eventDict[type].RemoveAt(i);
        }
    }

    public static void UnSubcribe<T> (Action<T> eventData) where T : IEvent
    {
        Type type = typeof(T);
        if (eventDict.TryGetValue(type, out List<WeakReference> eventList) == false)
            return;

        for (int i = eventList.Count - 1; i >= 0; --i)
        {
            object target = eventList[i].Target;
            // 좀비객체거나 해제할 이벤트면 삭제
            if (target == null || target.Equals(eventData) == true)
            {
                eventList.RemoveAt(i);
                if (target != null)
                    return;
            }
        }
    }
}
