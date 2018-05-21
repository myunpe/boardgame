using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Framework
{
    public class MYSceneManager : SingletonBase<MYSceneManager>
    {

        public IObservable<AsyncOperation> StartSceneAsync(string sceneName)
        {
            return SceneManager.LoadSceneAsync(sceneName)
                    .AsAsyncOperationObservable();
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
