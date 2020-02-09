using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Restore : EditorWindow
{
    [MenuItem("Xiaolan/Restore Scenes")]
    public static void RestoreScenes()
    {
        GameObject[] sceneRoots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        for(int i = 0; i<sceneRoots.Length; i++)
        {
            if(sceneRoots[i].name == "Scene Objects")
            {
                UnparentChildren(sceneRoots[i]);
            }
            DestroyImmediate(sceneRoots[i]);
        }
    }
	public static void UnparentChildren(GameObject go)
    {
        List<Transform> childTransforms = new List<Transform>();
        foreach (Transform t in go.transform)
        {
            childTransforms.Add(t);
        }
        foreach(Transform t in childTransforms)
        {
            t.parent = null;
        }
    }
}
