using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EditDirector : MonoBehaviour {
    public static EditDirector mInstance;


    public GameObject[] editModleNodes;

    public GameObject textEditObj;
    public GameObject imageEditObj;


    // edit text
    //public InputField TextEditIF;
    //public InputField fontsizeIF;

    public Text textEditT;
    public Text fontSizeT;

    public FontStyle font_style = FontStyle.Normal;

    public bool font_bold = false;
    public bool font_italic = false;
    public int font_size = 20; //region
    public Color font_color = new Color(0,0,0,255);

    // drawing board
    public GameObject drawBoardObj;

    public Slider slider_R;
    public Slider slider_G;
    public Slider slider_B;

    public Text sliderRT;
    public Text sliderGT;
    public Text sliderBT;

    public Image image_Mix;

    public float color_R;
    public float color_G;
    public float color_B;
    public Color color_new=new Color(0,0,0,255);

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
        drawBoardObj.SetActive(true);

        EditTogglePrefab data = obj.GetComponent<EditTogglePrefab>();

        curEditData = data;

        if(data.type==EditItemType.image)
        {
            imageEditObj.SetActive(true);
            textEditObj.SetActive(false);

            
        }
        else
        {
            imageEditObj.SetActive(false);
            textEditObj.SetActive(true);

            RefreshEditTextArea();
        }
       
    }


    

    #endregion

    #region  system edit

    #endregion

    #region  general edit

    private void ChangeFontStyle()
    {
        // normal
        if (!font_bold && !font_italic)
        {
            font_style = FontStyle.Normal;
        }

        //bold
        if (font_bold && !font_italic)
        {
            font_style = FontStyle.Bold;
        }

        //italic
        if (!font_bold && font_italic)
        {
            font_style = FontStyle.Italic;
        }

        // bold & italic
        if (font_bold && font_italic)
        {
            font_style = FontStyle.BoldAndItalic;
        }
        
    }
    public void OnTextEdit_BoldBtnPressed()
    {
        font_bold = !font_bold;
        ChangeFontStyle();

        textEditT.fontStyle = font_style;
    }

    public void OnTextEdit_ItalicBtnPressed()
    {
        font_italic = !font_italic;
        ChangeFontStyle();

        textEditT.fontStyle = font_style;
    }

    public void OnTextEdit_FontSizeIFEndEdit()
    {
        font_size = int.Parse(fontSizeT.text);
        textEditT.fontSize = font_size;
    }

    //drawing board

    public void OnTextEdit_ColorBtnPressed()
    {
        textEditT.color=color_new;
    }

    public void OnTextEdit_DrawboardBtnPressd()
    {
        if (drawBoardObj.activeInHierarchy)
            drawBoardObj.SetActive(false);
        else
            drawBoardObj.SetActive(true);
    }


    public void OnTextEdit_SliderRChanged()
    {
        color_R = slider_R.value;
        color_new.r = color_R;
        image_Mix.color = color_new;

        sliderRT.text = ((int)(color_R * 256)).ToString();
    }

    public void OnTextEdit_SliderGChanged()
    {
        color_G = slider_G.value;
        color_new.g = color_G;
        image_Mix.color = color_new;

        sliderGT.text = ((int)(color_G * 256)).ToString();
    }

    public void OnTextEdit_SliderBChanged()
    {
        color_B = slider_B.value;
        color_new.b = color_B;
        image_Mix.color = color_new;

        sliderBT.text = ((int)(color_B * 256)).ToString();
    }


    private void RefreshEditTextArea()
    {
        Text _test = curEditData.transform.GetChild(2).gameObject.GetComponent<Text>();

        font_style = _test.fontStyle;
        switch (font_style)
        {
            case FontStyle.Normal:
                font_bold = false;
                font_italic = false;
                break;
            case FontStyle.Bold:
                font_bold = true;
                font_italic = false;
                break;
            case FontStyle.Italic:
                font_bold = false;
                font_italic = true;
                break;
            case FontStyle.BoldAndItalic:
                font_bold = true;
                font_italic = true;
                break;
        }

        font_size = _test.fontSize;
        font_color = _test.color;

        color_R = _test.color.r;
        color_G = _test.color.g;
        color_B = _test.color.b;

        Debug.Log("color_R: " + color_R);

        textEditT.text = _test.text;
        textEditT.fontStyle = font_style;
        textEditT.fontSize = font_size;
        textEditT.color = font_color;


        fontSizeT.text = font_size.ToString();

        slider_R.value = color_R;
        slider_G.value = color_G;
        slider_B.value = color_B;
        color_new = font_color;

        image_Mix.color = font_color;

    }


    public void OnTextEdit_SaveBtnPressed()
    {
        Text res_text = curEditData.transform.GetChild(2).gameObject.GetComponent<Text>();

        res_text.text = textEditT.text;
        res_text.fontStyle = font_style;
        res_text.fontSize = font_size;
        res_text.color = font_color;

        drawBoardObj.SetActive(false);
    }

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
