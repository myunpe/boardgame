using System;
using System.Linq;
using Framework.Utility;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Framework
{
    public class MYSceneManager : SingletonBase<MYSceneManager>
    {
        public async UniTask StartSceneAsync(string sceneName)
        {
            Log.D($"start scene async {sceneName}");
            await SceneManager.LoadSceneAsync(sceneName);
            var scene = SceneManager.GetActiveScene();


            var sceneBase = scene.GetRootGameObjects().Select(g => g.GetComponent<SceneBase>()).FirstOrDefault(s => s != null);
            if (sceneBase != null)
            {
                sceneBase.SetActive(false);
                sceneBase.SetupCanvas();
                await sceneBase.BeforeInitializeScene();
                sceneBase.SetActive(true);
                //アニメーションはここかな？
            }
            else
            {
                Log.D($"sceneが見つかりません {sceneName}");
            }

            Log.D($"end scene async {sceneName}");
        }

        public IObservable<AsyncOperation> AddSceneAsync(string sceneName)
        {
            return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive)
                .AsAsyncOperationObservable();
        }

        protected override string InstanceName()
        {
            return "SceneManager";
        }
    }
}