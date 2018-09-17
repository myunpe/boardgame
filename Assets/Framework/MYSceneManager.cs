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
            await SceneManager.LoadSceneAsync(sceneName);
            Scene scene = SceneManager.GetActiveScene();
            Log.D("scene name : " + scene.name + ", isloaded " + scene.isLoaded + ", path " + scene.path);

            var sceneBase = scene.GetRootGameObjects().Select(g => g.GetComponent<SceneBase>()).FirstOrDefault(s => s != null);
            if(sceneBase != null)
            await sceneBase.BeforeInitializeScene();
            else
            {
                Log.D($"sceneが見つかりません {sceneName}");
            }
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
