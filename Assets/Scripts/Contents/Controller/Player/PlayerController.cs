using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Contents.Controller.Player
{

    public struct MoneyEvent : IEvent
    {
        public readonly int money;

        public MoneyEvent(int _money)
        {
            money = _money;
        }
    }

    public class PlayerController : BaseController
    {
        // ���̽�ƽUI
        [SerializeField] private JoyStickController joystick;
        [SerializeField] private TextMeshProUGUI text;

        private CharacterController characterController;
        private Vector3 direction;

        public int curMoney = 0;

        public override void Init()
        {
            base.Init();

            InteractionType = Define.EInteractionType.PLAYER;
            InteractionSet();
            characterController = GetComponent<CharacterController>();
            joystick.Init(this);

            WeakEventBus.Subcribe<MoneyEvent>(MoneyUpdate);
            text.SetText(0.ToString());
        }

        private void Update()
        {
            Movement();
        }

        private void MoneyUpdate(MoneyEvent moneyEvent)
        {
            curMoney += moneyEvent.money;
            text.SetText(curMoney.ToString());
        }

        #region Move ����
        public void MoveDirectionSet(Vector3 dir)
        {
            direction = dir;
        }

        public void MoveStart()
        {
            stateController.ChangeState(Define.EUnitState.MOVE);
        }

        private void Movement()
        {
            if (direction.magnitude < 0.01f)
                return;

            Vector3 velocity = new Vector3(direction.x, 0, direction.z) * (unitData.MoveSpeed * Time.deltaTime);
            characterController.Move(velocity);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.DORotateQuaternion(targetRotation, 0.2f);
        }

        public void MovementReset()
        {
            direction = Vector3.zero;

            stateController.ChangeState(Define.EUnitState.IDLE);
        }
        #endregion
    }
}
