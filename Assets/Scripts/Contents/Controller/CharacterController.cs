using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Serializable]
    public struct Status
    {
        public float speed;
        public float att;
        public float health;
    }

    public enum CharacterState
    {
        Idle,
        Move,
        Attack,
    }

    private Animator anim;

    [SerializeField] private Status status;
    [SerializeField] private CharacterState curState = CharacterState.Idle;

    public CharacterState State 
    {
        get => curState;
        set 
        {
            curState = value;

            switch (curState)
            {
                case CharacterState.Idle:
                    anim.CrossFade("Idle", 0.1f);
                    break;
                case CharacterState.Move:
                    anim.CrossFade("Move", 0.1f);
                    break;
                case CharacterState.Attack:
                    anim.CrossFade("Attack", 0.1f);
                    break;
            }
        }
    }
}
