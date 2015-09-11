using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EditDirector : MonoBehaviour {
    public static EditDirector mInstance;


    public GameObject[] editModleNodes;

    public GameObject textEditObj;
    public GameObject imageEditObj;


    public InputField TextEditIF;
    public InputField fontsizeIF;

    #region  data

    Dictionary<string, string> editModleDic = new Dictionary<string, string> { { "Toggle-loading", "loadingNode" },
                                                                                { "Toggle-start", "startNode" },
                                                                                { "Toggle-gaming", "gamingNode" },
                                                                                { "Toggle-gameover", "gameoverNode" }};



    private EditTogglePrefab curEditData;

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

        EditTogglePrefab data = obj.GetComponent<EditTogglePrefab>();

        curEditData = data;

        if(data.type==EditItemType.image)
        {
            imageEditObj.SetActive(true);
            textEditObj.SetActive(false);

            TextEditIF.text = data.transform.GetChild(2).gameObject.GetComponent<Text>().text;
            fontsizeIF.text = data.transform.GetChild(2).gameObject.GetComponent<Text>().fontSize.ToString();
        }
        else
        {
            imageEditObj.SetActive(false);
            textEditObj.SetActive(true);
        }
       
    }


    public void OnTextEditSaveBtnPressed()
    {
        curEditData.des_text.text = TextEditIF.text;
        curEditData.des_text.fontSize = int.Parse(fontsizeIF.text);

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
        Debug.Log("~~~ sads");
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
