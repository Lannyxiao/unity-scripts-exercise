using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Boundbox : Editor {

	[MenuItem("Xiaolan/Get Scene Boundbox")] 
	public static void SceneBoundbox(){
		Bounds tempBounds = new Bounds(Vector3.zero, Vector3.zero);
		GameObject[] gos = UnityEngine.GameObject.FindObjectsOfType<GameObject>();
		List<GameObject> Staticgos = new List<GameObject>();
		List<GameObject> mfgoslist = new List<GameObject>();
		List<Renderer> rlist = new List<Renderer>();
		for(int h=0;h<gos.Length;h++)
		{
			if(gos[h].isStatic){Staticgos.Add(gos[h]);}
		}
		GameObject[] sgos = Staticgos.ToArray();
		for(int k=0;k<sgos.Length;k++)
		{
			MeshFilter mf = sgos[k].GetComponent<MeshFilter>();
			if(mf == null) continue;
			Mesh m = mf.sharedMesh;
			if(m != null){mfgoslist.Add(sgos[k]);}
		}
		GameObject[] mfgos = mfgoslist.ToArray();
		for(int j=0;j<mfgos.Length;j++)
		{
			Renderer r = mfgos[j].GetComponent<Renderer>();
			if(r != null)
			{
				rlist.Add(r);
			}
		}
		Renderer[] rs = rlist.ToArray();
		for(int i=0;i<rs.Length;i++)
		{
			tempBounds.Encapsulate(rs[i].bounds);
		}
		Bounds Scenebound = tempBounds;
		Color color = Color.green;
		DrawBoundingbox(Scenebound, color);
		Debug.Log(Scenebound.size);
	}
	public static void DrawBoundingbox(Bounds bounds, Color color)
    {
        Vector3 point000 = new Vector3(bounds.min[0],bounds.min[1],bounds.min[2]);
        Vector3 point001 = new Vector3(bounds.min[0],bounds.min[1],bounds.max[2]); 
        Vector3 point010 = new Vector3(bounds.min[0],bounds.max[1],bounds.min[2]);
        Vector3 point011 = new Vector3(bounds.min[0],bounds.max[1],bounds.max[2]);
        Vector3 point100 = new Vector3(bounds.max[0],bounds.min[1],bounds.min[2]);
        Vector3 point101 = new Vector3(bounds.max[0],bounds.min[1],bounds.max[2]);
        Vector3 point110 = new Vector3(bounds.max[0],bounds.max[1],bounds.min[2]);
        Vector3 point111 = new Vector3(bounds.max[0],bounds.max[1],bounds.max[2]);
        Vector3[] points = {point000, point001, point010, point011,point100,point101,point110,point111};

        Debug.DrawLine(points[0], points[1], color, 10);
        Debug.DrawLine(points[0], points[2], color, 10);
        Debug.DrawLine(points[2], points[3], color, 10);
        Debug.DrawLine(points[3], points[1], color, 10);
        
        Debug.DrawLine(points[4], points[5], color, 10);
        Debug.DrawLine(points[4], points[6], color, 10);
        Debug.DrawLine(points[6], points[7], color, 10);
        Debug.DrawLine(points[5], points[7], color, 10);

        Debug.DrawLine(points[6], points[2], color, 10);
        Debug.DrawLine(points[5], points[1], color, 10);
        Debug.DrawLine(points[4], points[0], color, 10);
        Debug.DrawLine(points[7], points[3], color, 10);
    }
	
}