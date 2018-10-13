using System.Threading;
using UniRx.Async;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class SceneBase : UIBehaviour
{
    Canvas canvas;
    protected Canvas Canvas => canvas ?? gameObject.GetComponent<Canvas>();
    CanvasScaler canvasScaler;
    protected CanvasScaler CanvasScaler => canvasScaler ?? gameObject.GetComponent<CanvasScaler>();

    protected readonly CancellationTokenSource cts = new CancellationTokenSource();

    public abstract UniTask BeforeInitializeScene();

    protected virtual void OnDestroy()
    {
        cts.Cancel();
        cts.Dispose();
    }

    public void SetupCanvas()
    {
        Canvas.renderMode = RenderMode.ScreenSpaceCamera;
        Canvas.worldCamera = Camera.current;
        CanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        CanvasScaler.referenceResolution = new Vector2(1024, 576);
    }
    
   
}