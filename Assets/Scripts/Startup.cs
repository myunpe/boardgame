using Framework;
using Framework.Utility;
using UniRx;
using UniRx.Async;
using UnityEngine;

public class Startup : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        MYSceneManager.Instance.StartSceneAsync(DEF.Scene.TITLE).Forget();
    }
}
