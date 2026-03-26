using DG.Tweening;
using UnityEngine;
using static Define;

public interface IInteraction
{
    void InteractionEnter(EInteractionType type);
    void InteractionExit(EInteractionType type);
    void InteractionStay(EInteractionType type);

    void InteractionExcute(EInteractionType type);

    public bool IsInteraction { get; set; }
}

public class InteractionObject : MonoBehaviour, IInteraction
{
    public bool IsInteraction { get; set; }
    public EInteractionType InteractionType { get; set; } = EInteractionType.OBJECT;

    protected SpriteRenderer interactionArea;

    public const int InteractionLayer = 10;

    protected float radius;

    private Collider[] results;
    private Vector2 defaultSize;

    public void InteractionSet()
    {
        gameObject.layer = InteractionLayer;
        InteractionAreaInit();
    }

    /// <summary>
    /// Renderer Bounds로 넓이를 구함.
    /// </summary>
    private void InteractionAreaInit()
    {
        Debug.Log(gameObject.name);
        GameObject go = MainManager.Resource.Instantiate("InteractionArea");
        go.transform.position = new Vector3(0f, go.transform.position.y + 0.001f, 0f);
        go.transform.SetParent(transform);
        go.transform.localPosition = new Vector3(0, go.transform.localPosition.y, 0);
        interactionArea = go.GetComponent<SpriteRenderer>();

        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        foreach (var component in gameObject.GetComponentsInChildren<Renderer>())
            bounds.Encapsulate(component.bounds);

        radius = bounds.extents.magnitude / transform.localScale.x;
        interactionArea.size = new Vector2(radius, radius) * 0.9f;
        defaultSize = interactionArea.size;
    }

    protected void EnterArea()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(interactionArea.DOSize(interactionArea.size * 1.1f, 0.2f));
        sequence.Play();
    }

    protected void ExitArea()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(interactionArea.DOSize(defaultSize, 0.2f));
        sequence.Play();
    }

    public virtual void InteractionEnter(EInteractionType type)
    {
        if (IsInteraction == true)
            return;

        IsInteraction = true;
        EnterArea();
        InteractionExcute(type);
    }

    public virtual void InteractionExit(EInteractionType type)
    {
        if (IsInteraction == false)
            return;

        IsInteraction = false;
        ExitArea();
    }

    public virtual void InteractionStay(EInteractionType type)
    {
    }

    public virtual void InteractionExcute(EInteractionType type)
    {
        
    }
}
