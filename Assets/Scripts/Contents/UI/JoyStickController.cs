using Contents.Controller.Player;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ���̽�ƽ�� �����ϴ� ��Ʈ�ѷ�
/// �������� ���� �� �÷��̾�� ������ �����Ѵ�.
/// </summary>
public class JoyStickController : MonoBehaviour
{
    [SerializeField] private RectTransform frame;
    [SerializeField] private RectTransform handle;

    private RectTransform rect;
    private PlayerController player;

    public void Init(PlayerController player)
    {
        rect = GetComponent<RectTransform>();
        this.player = player;

        gameObject.AddEvent(OnBeginDrag, Define.EEventType.BEGINDRAG);
        gameObject.AddEvent(OnDrag, Define.EEventType.DRAG);
        gameObject.AddEvent(OnEndDrag, Define.EEventType.ENDDRAG);

        frame.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        frame.position = eventData.position;
        frame.gameObject.SetActive(true);
        player.MoveStart();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (handle == null)
            return;

        float radius = frame.rect.width * 0.5f;
        Vector3 dir = (Vector3)eventData.position - frame.position;
        if (dir.magnitude > radius)
            handle.anchoredPosition = dir.normalized * radius;
        else
            handle.anchoredPosition = dir;

        Vector3 moveDir = new Vector3(dir.x, 0, dir.y).normalized;
        player.MoveDirectionSet(moveDir);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        frame.gameObject.SetActive(false);
        player.MovementReset();
    }
}
