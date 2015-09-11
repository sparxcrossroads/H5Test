using UnityEngine;
using System.Collections;

public class LoadDirector : MonoBehaviour {

	// Use this for initialization
    private AsyncOperation async;
    int progress = 0;

	void Start () {
       
       Debug.Log("loading show scene");
      


        //Application.LoadLevelAdditive("show");
       StartCoroutine(LoadingNext());
	}

    private IEnumerator LoadingNext()
    {
        yield return new WaitForSeconds(3.0f);
        async = Application.LoadLevelAdditiveAsync("show");
        yield return async;
    }

    private bool active_show = false;

    void Update()
    {
        if (async == null)
            return;
        progress = (int)async.progress*100;

        if (progress == 100 && active_show == false)
        {
            DestroyLoadingScene();
            active_show = true;
        }
    }


    private static void DestroyLoadingScene()
    {
        Debug.Log("loading scene ruining");
        DestroyManager.ClearGameObject();
    }
}
