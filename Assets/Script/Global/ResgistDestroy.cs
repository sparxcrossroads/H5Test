using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResgistDestroy : MonoBehaviour {

    void Awake()
    {
        DestroyManager.destroyList.Add(this.gameObject);
        Debug.Log(this.gameObject.name);
    }
}
