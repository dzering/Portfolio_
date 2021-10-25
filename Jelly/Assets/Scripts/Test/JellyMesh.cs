using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMesh : MonoBehaviour
{
    public float _intensity = 1f;
    public float mass = 1f;
    public float steefness = 1f;
    public float damping = 0.75f;

    Mesh OriginalMesh, CloneMesh;
    MeshRenderer meshRenderer;
    JellyVertex[] jv;
    Vector3[] vertexArray;

    private void Start()
    {
        OriginalMesh = GetComponent<MeshFilter>().sharedMesh;
        CloneMesh = Instantiate(OriginalMesh);

        GetComponent<MeshFilter>().sharedMesh = CloneMesh;
        meshRenderer = GetComponent<MeshRenderer>();

        jv = new JellyVertex[CloneMesh.vertexCount];
        for (int i = 0; i < jv.Length; i++)
        {
            jv[i] = new JellyVertex(i, transform.TransformPoint(CloneMesh.vertices[i]));
        }
    }

    private void FixedUpdate()
    {
        vertexArray = OriginalMesh.vertices;
        for (int i = 0; i < jv.Length; i++)
        {
            var target = transform.TransformPoint(vertexArray[jv[i].ID]);
            float intensity = (1 - (meshRenderer.bounds.max.y - target.y) / meshRenderer.bounds.size.y) * _intensity; // Разобраться с этой строкой;
            jv[i].Shake(target, mass, steefness, damping);
            target = transform.InverseTransformPoint(jv[i].position);
            vertexArray[jv[i].ID] = Vector3.Lerp(vertexArray[jv[i].ID], target, intensity);
        }
        CloneMesh.vertices = vertexArray;
    }
}


public class JellyVertex
{
    public int ID;
    public Vector3 position;
    public Vector3 velocity, force;

    public JellyVertex(int id, Vector3 pos)
    {
        ID = id;
        position = pos;
    }

    public void Shake(Vector3 target, float m, float s, float d)
    {
        force = (target - position) * s;
        velocity = (velocity + force / m) * d;
        position += velocity;
        if((velocity + force + force / m).magnitude < 0.001f)
        {
            position = target;
        }
    }

}
