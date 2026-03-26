using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class UnitInteractionState : IUnitState
{
    public Define.EUnitState StateType => Define.EUnitState.INTERACTION;

    private BaseController owner;
    private Animator anim;
    private CancellationTokenSource cancelToken;

    public UnitInteractionState(BaseController owner)
    {
        this.owner = owner; 
        anim = owner.GetComponent<Animator>();        
    }

    public void StateEnter()
    {
        cancelToken = new CancellationTokenSource();
        Test(cancelToken).Forget();
    }

    private async UniTaskVoid Test(CancellationTokenSource token)
    {
        try
        {
            //await UniTask.Delay
        }
        catch (System.Exception)
        {

            throw;
        }
        await UniTask.WaitForSeconds(0.1f);
        Debug.Log("Ä³´ÂÁß");
    }
    public void StateExit()
    {
        cancelToken?.Cancel();
        cancelToken?.Dispose();
    }

    public void StateUpdate()
    {
    }

}
