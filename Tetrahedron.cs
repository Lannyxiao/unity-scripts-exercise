using UnityEngine;
using UnityEditor;

public class Tetrahedron : Editor {
	[MenuItem("Xiaolan/ConverttoTetrahedron")]
	public static void ConverttoTetrahedron(){
		// 获取选取的GameObject
		GameObject go = Selection.activeGameObject;
		// 获取Mesh变量
		var mf = go.GetComponent<MeshFilter>();
		if (go.GetComponent<MeshFilter>() == null)
		{
			mf = go.AddComponent<MeshFilter>();
		}
		//定义四面体的mesh
		Mesh mesh = new Mesh();

		Vector3 p0 = new Vector3(0, 0, 0);
		Vector3 p1 = new Vector3(1, 0, 0);
		Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
		Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f)/3);

        mesh.vertices = new Vector3[] { p0, p1, p2, p3 };
        mesh.triangles = new int[] { 
                                    0, 1, 2,
                                    0, 2, 3,
                                    2, 1, 3,
                                    0, 3, 1};
        go.GetComponent<MeshFilter>().sharedMesh = mesh;

		MeshRenderer mr = go.GetComponent<MeshRenderer>();
        if (mr == null)
        {
            mr = go.AddComponent<MeshRenderer>();
        }
	}
}
