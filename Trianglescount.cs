using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Trianglescount : Editor {
	[MenuItem("Xiaolan/TrianglesCount")] 
	public static void TrianglesCount(){
		// 获取所有的GameObject
		GameObject[] gos = UnityEngine.GameObject.FindObjectsOfType<GameObject>();
		List<MeshFilter> mflist = new List<MeshFilter>();
		List<Mesh> mlist = new List<Mesh>();
		int tris = 0;
		for(int i=0;i<gos.Length;i++)
		{
			MeshFilter mf = gos[i].GetComponent<MeshFilter>();
			if(mf != null)
			{
				mflist.Add(mf);
			}
		}
		// 获取null!=0的meshfilter
		MeshFilter[] mfs = mflist.ToArray();
			
		for(int j=0;j<mfs.Length;j++)
		{
			Mesh m = mfs[j].sharedMesh;
			if(m != null)
			{
				mlist.Add(m);
			}
		}
		// 获取null!=0的mesh
		Mesh[] ms = mlist.ToArray();
		for(int k=0; k<ms.Length;k++)
		{
			Mesh mcount = ms[k];
			tris += mcount.triangles.Length / 3;
		}
				
	Debug.Log(tris.ToString());	
	}
		
}

