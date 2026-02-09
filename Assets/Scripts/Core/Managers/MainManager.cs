using Unity.VisualScripting;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private AddressableManager addressableManager = new AddressableManager();
    private ResourceManager resourceManager = new ResourceManager();

    public static AddressableManager Addressable => Instance.addressableManager;
    public static ResourceManager Resource => Instance.resourceManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        addressableManager.LoadAsyncAll<Object>("MainGame", (key, cur, total) =>
        {
#if UNITY_EDITOR
            string log = $"[LOADING] {key} {cur} / {total}";
            Debug.Log($"<color=cyan>{log}</color>");
#endif
        });
        DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        addressableManager.Release();
    }
}
