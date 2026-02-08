using DG.Tweening;
using UnityEngine;

/// <summary>
/// 플레이어를 관리하는 컨트롤러
/// 움직임은 캐릭터 컨트롤러를 기반으로 만들었다.
/// </summary>
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

        Vector3 velocity = new Vector3(direction.x, 0, direction.z) * unitData.MoveSpeed * Time.deltaTime;
        characterController.Move(velocity);
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.DORotateQuaternion(targetRotation, 0.1f);
    }

    public void MovementReset()
    {
        direction = Vector3.zero;
    }
    #endregion
}
