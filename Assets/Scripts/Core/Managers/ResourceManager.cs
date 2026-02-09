using UnityEngine;

public class ResourceManager
{
    public GameObject Instantiate(string name, Transform parent = null)
    {
        GameObject prefab = MainManager.Addressable.Load<GameObject>(name);
        if (prefab == null)
        {
            Debug.LogError($"肋给等 积己 {name}");
            return null;
        }

        GameObject go = Object.Instantiate(prefab, parent);
        return go;
    }
}
