using System.Collections.Generic;
using Contents.Controller.Player;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private List<InteractionObject> SceneInInteractionObjects;

    public void Init()
    {
        player.Init();
        foreach (var ob in SceneInInteractionObjects)
            ob.InteractionSet();
    }
}
