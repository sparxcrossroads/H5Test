using UnityEngine;
using System.Collections;

public class LoadDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.LoadLevelAdditive("show");

        Debug.Log("loading show scene");
	}

    private bool active_show = false;

    void Update()
    {
        if (Application.GetStreamProgressForLevel("show") == 1 && active_show==false)
        {
            DestroyLoadingScene();
            active_show = true;
        }
    }


    private void DestroyLoadingScene()
    {
        Debug.Log("loading scene ruining");
        DestroyManager.ClearGameObject();
    }
}
