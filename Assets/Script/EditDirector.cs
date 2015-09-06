using UnityEngine;
using System.Collections;

public class EditDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ToLoadingScene());
	}

    IEnumerator ToLoadingScene()
    {
        yield return null;
        Application.LoadLevelAdditive("loading");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
