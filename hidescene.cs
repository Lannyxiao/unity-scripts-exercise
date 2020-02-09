using UnityEngine;
using UnityEditor;

public class hidescene : EditorWindow
{
    [MenuItem("Xiaolan/Hide Scenes")]
    public static void HideScenes()
    {
        GameObject[] sceneRoots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        bool ifAlreadyHidden = false;
        for(int i = 0; i<sceneRoots.Length; i++)
        {
            if(sceneRoots[i].name == "Scene Objects")
            {
                ifAlreadyHidden = true;
            }
        }
        if(ifAlreadyHidden == true)
        {
            Debug.Log("Scene already hidden.");
            return;
        }
        else
        {
            GameObject sceneRootsParent = new GameObject("Scene Objects");
            foreach (var t in sceneRoots)
            {
                t.transform.parent = sceneRootsParent.transform;
            }
            sceneRootsParent.SetActive(false);
        }
    }
}