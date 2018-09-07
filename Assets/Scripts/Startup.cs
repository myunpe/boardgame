using Framework;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Startup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MYSceneManager.Instance.StartSceneAsync(DEF.Scene.SAMPLESCENE).StartAsCoroutine();
	}

}
