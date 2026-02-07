using DG.Tweening;
using UnityEngine;

public class PlayerController : BaseController
{
    // 조이스틱UI
    [SerializeField] private JoyStickController joystick;

    private CharacterController characterController;
    private Vector3 direction;

    public void Init()
    {
        characterController = GetComponent<CharacterController>();
        joystick.Init(this);
    }

    private void Update()
    {
        Movement();
    }

    #region Move 관련
    public void MoveDirectionSet(Vector3 dir)
    {
        direction = dir;
    }

    private void Movement()
    {
        if (direction.magnitude < 0.01f)
            return;

        characterController.Move(new Vector3(direction.x * unitData.MoveSpeed * Time.deltaTime, 0, direction.z * unitData.MoveSpeed * Time.deltaTime));
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.DORotateQuaternion(targetRotation, 0.1f);
    }

    public void MovementReset()
    {
        direction = Vector3.zero;
    }
    #endregion
}
