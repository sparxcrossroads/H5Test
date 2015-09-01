using UnityEngine;
using System.Collections;

public class LoadDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.LoadLevelAdditive("edit");
        Debug.Log("ss");
	}
	
}
