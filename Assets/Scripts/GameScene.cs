using System.Collections;
using UniRx.Async;

public class GameScene : SceneBase
{
    public override async UniTask BeforeInitializeScene()
    {
        await UniTask.DelayFrame(10);
    }
}
