using UnityEngine;
using UnityEditor;


public class GameDirection : MonoBehaviour {

    public void Build()
    {
        string[] levels = { "Assets/bui" };

        BuildPipeline.BuildPlayer(levels,"WebPlayerBuild",
                                BuildTarget.WebPlayer,BuildOptions.None);

        Debug.Log("lucky");

    }
}
   