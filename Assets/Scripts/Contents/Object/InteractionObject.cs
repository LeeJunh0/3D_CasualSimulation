using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    protected SpriteRenderer interactionArea;

    public const int InteractionLayer = 10;

    public virtual void Init()
    {
        gameObject.layer = InteractionLayer;
        InteractionAreaInit();
    }

    /// <summary>
    /// Todo: 렌더러에서 bounds를 이용해 크기를 가져올수 있는데 그걸 이용해 반지름을 구해 링 크기를 만들기.
    /// </summary>
    private void InteractionAreaInit()
    {
        GameObject go = MainManager.Resource.Instantiate("InteractionArea");
        interactionArea = go.GetComponent<SpriteRenderer>();

        
    }
}
