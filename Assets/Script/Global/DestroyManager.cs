using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyManager : MonoBehaviour {

    public static DestroyManager mInstance;


    public static List<GameObject> destroyList=new List<GameObject>();

    void Awake()
    {
        if (mInstance == null)
        {
            mInstance = this;
            DontDestroyOnLoad(mInstance);
        }
        else
        {
            Destroy(this);
        }
    }

    public static void ClearGameObject()
    {
        foreach (GameObject obj in destroyList)
        {
            Debug.Log("destroy name: " + obj.name);
            Destroy(obj);
        
        }
    }
}
