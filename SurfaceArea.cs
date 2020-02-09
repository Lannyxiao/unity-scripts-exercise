using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SfArea : Editor {
	[MenuItem("Xiaolan/SurfaceArea")] 
	public static void SurfaceArea(){
		// 获取所有的GameObject
		GameObject[] gos = UnityEngine.GameObject.FindObjectsOfType<GameObject>();
		List<MeshFilter> mflist = new List<MeshFilter>();
		List<Mesh> mlist = new List<Mesh>();
		float SurfaceArea = 0;
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
			SurfaceArea += CalculateSurfaceArea(mcount);
		}
				
	Debug.Log(SurfaceArea.ToString());	
	}
public static float CalculateSurfaceArea(Mesh mesh) {
    var triangles = mesh.triangles;
    var vertices = mesh.vertices;

    double sum = 0.0;

    for(int i = 0; i < triangles.Length; i += 3) {
        Vector3 corner = vertices[triangles[i]];
        Vector3 a = vertices[triangles[i + 1]] - corner;
        Vector3 b = vertices[triangles[i + 2]] - corner;

        sum += Vector3.Cross(a, b).magnitude;
    }

    return (float)(sum/2.0);
}	
}
