using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GetLodSelection : EditorWindow
{
	[MenuItem("Xiaolan/Get Lod Group")]
	public static void showWindow()
	{
		GetLodSelection window  = (GetLodSelection)EditorWindow.GetWindow(typeof(GetLodSelection));
	}
	void OnGUI()
	{
		if(GUILayout.Button("Select All Without LODGroup!"))
		{
			SelectNoLODGroup();
		}
		if(GUILayout.Button("Select LOD0!"))
		{
			SelectLOD(0);
		}
		if(GUILayout.Button("Select LOD1!"))
		{
			SelectLOD(1);
		}
	}
	public void SelectNoLODGroup()
	{
		GameObject[] gos = UnityEngine.GameObject.FindObjectsOfType<GameObject>();
		List<GameObject> Staticgos = new List<GameObject>();
		for(int k=0;k<gos.Length;k++)
		{
			if (gos[k].isStatic){Staticgos.Add(gos[k]);}
		}
			GameObject[] sgos = Staticgos.ToArray();
			List<GameObject> NoLodgroup = new List<GameObject>();
			for(int i=0;i<sgos.Length;i++)
			{
				LODGroup lodgroup = sgos[i].GetComponent<LODGroup>();
			if(lodgroup == null)
				{
					NoLodgroup.Add(sgos[i]);
				}
			}
			
		Selection.objects = NoLodgroup.ToArray(); 
	}
	public void SelectLOD(int lodIndex)
	{
		GameObject[] gos = UnityEngine.GameObject.FindObjectsOfType<GameObject>();
		List<GameObject> LOD = new List<GameObject>();
		for(int i=0;i<gos.Length;i++)
		{
			LODGroup group = gos[i].GetComponent<LODGroup>();
			if(group == null) continue;
			LOD[] lods = group.GetLODs();
			if(lods.Length < lodIndex) continue;
			Renderer[] renderers = lods[lodIndex].renderers;
			for(int j=0; j<renderers.Length; j++)
			{
				LOD.Add(renderers[j].gameObject);
			}
			Selection.objects= LOD.ToArray();
		}
	}
}
