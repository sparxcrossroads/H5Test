using UnityEngine;
using UnityEditor;


public class GameDirection : MonoBehaviour {

    [MenuItem("Custom/Build WebPlayerBuild")]
    public static void Build()
    {
        string path = EditorUtility.OpenFolderPanel("choose a folder to save", null, null);

        string[] levels = { "Assets/build1.unity" };

        BuildPipeline.BuildPlayer(levels,path+"/WebPlayerBuild", BuildTarget.WebPlayer,BuildOptions.None);

        Debug.Log("lucky");

    }
}
   