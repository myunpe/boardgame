using System.Collections;
using System.Threading;
using UniRx.Async;
using UnityEngine;

public abstract class SceneBase : MonoBehaviour
{
    protected readonly CancellationTokenSource cts = new CancellationTokenSource();
    
    public abstract UniTask BeforeInitializeScene();

    protected virtual void OnDestroy()
    {
        cts.Cancel();
        cts.Dispose();
    }
}
