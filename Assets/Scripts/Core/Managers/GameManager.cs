using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        player.Init();
    }
}
