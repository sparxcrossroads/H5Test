using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EditDirector : MonoBehaviour {
    public static EditDirector mInstance;


    public GameObject[] editModleNodes;



    #region  data

    Dictionary<string, string> editModleDic = new Dictionary<string, string> { { "Toggle-loading", "loadingNode" },
                                                                                { "Toggle-start", "startNode" },
                                                                                { "Toggle-gaming", "gamingNode" },
                                                                                { "Toggle-gameover", "gameoverNode" }};
    #endregion


    #region  replace modle

    public void OnEditModleToggleChanged(Toggle toggle)
    {
        foreach (GameObject obj in editModleNodes)
        {
            if (obj.name == editModleDic[toggle.name])
                obj.SetActive(true);
            else
                obj.SetActive(false);
        }


        if (toggle.isOn)
        {
            switch (toggle.name)
            {
                case "Toggle-loading":
                    break;
                case "Toggle-start":
                    break;
                case "Toggle-gaming":
                    break;
                case "Toggle-gameover":
                    break;
                default:
                    break;
            }

        }
    }


    public void UpdateEditItem(GameObject obj)
    {

    }

    #endregion

    #region  system edit

    #endregion

    #region  general edit


    #endregion

    void Awake()
    {
        mInstance = this;
    }


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

    void OnDestroy()
    {
        mInstance = null;
    }


}
