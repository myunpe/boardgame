using System;
using Framework;
using System.Collections;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

public class TitleScene : SceneBase
{

    [SerializeField] Button gameStartButton;


    public override async  UniTask BeforeInitializeScene()
    {
        Log.D($"{GetType().Name} before start");
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        Log.D($"{GetType().Name} before end");
    }
}
