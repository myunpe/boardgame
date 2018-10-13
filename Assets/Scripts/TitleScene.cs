using System;
using Framework;
using System.Collections;
using UniRx;
using UniRx.Async;
using UnityEditor.Build.Pipeline;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class TitleScene : SceneBase
{
    [SerializeField] Button gameStartButton;
    [SerializeField] Image sample;

    public override async UniTask BeforeInitializeScene()
    {
//        Log.D($"{GetType().Name} before start");
//        await UniTask.Delay(TimeSpan.FromSeconds(1));
//        Log.D($"{GetType().Name} before end");
//        var load = Addressables.LoadAsset<Sprite>("001010301");
//        await load;
//        sample.sprite = load.Result;
    }


//    void Start()
//    {
//        Addressables.LoadAsset<Sprite>("001010301")
//            .Completed += op => { sample.sprite = op.Result; };
//    }
}