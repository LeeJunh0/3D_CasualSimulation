using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;
using Unity.VisualScripting;

/// <summary>
/// 어드레서블을 관리하는 매니저
/// </summary>
public class AddressableManager
{
    private Dictionary<string, UnityEngine.Object> resourceDict = new Dictionary<string, UnityEngine.Object>();
    private Dictionary<string, AsyncOperationHandle> handleDict = new Dictionary<string, AsyncOperationHandle>();

    public T Load<T>(string name) where T : UnityEngine.Object
    {
        if (resourceDict.TryGetValue(name, out UnityEngine.Object obj) == true)
            return obj as T;

        return null;
    }

    private void LoadAsync<T>(string name, Action<T> action = null) where T : UnityEngine.Object
    {
        if (resourceDict.TryGetValue(name, out UnityEngine.Object resource))
        {
            action?.Invoke(resource as T);
            return;
        }

        AsyncOperationHandle<T> asyncOp = Addressables.LoadAssetAsync<T>(name);
        asyncOp.Completed += (op) =>
        {
            if (resourceDict.ContainsKey(name) == false)
            {
                resourceDict.Add(name, op.Result);
                handleDict.Add(name, asyncOp);
            }

            action?.Invoke(op.Result);
        };
    }

    public void LoadAsyncAll<T>(string label, Action<string, int, int> loadingAction = null) where T : UnityEngine.Object
    {
        var opHandle = Addressables.LoadResourceLocationsAsync(label, typeof(T));
        opHandle.Completed += (op) =>
        {
            int cur = 0;
            int total = op.Result.Count;

            foreach (var result in op.Result)
            {
                LoadAsync<T>(result.PrimaryKey, (obj) =>
                {
                    cur++;
                    loadingAction?.Invoke(result.PrimaryKey, cur, total);
                });
            }
        };
    } 

    public void Release()
    {
        resourceDict.Clear();
        foreach (var handle in handleDict.Values)
        {
            if (handle.IsValid() == true)
                Addressables.Release(handle);
        }

        handleDict.Clear();
    }
}
