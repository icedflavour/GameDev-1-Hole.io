using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OnChangePosition : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D hole2DCollider;
    [SerializeField] private PolygonCollider2D surface2DCollider;
    [SerializeField] private MeshCollider GeneratedMeshCollider;
    [SerializeField] private float initialScale;

    private Mesh GeneratedMesh;

    private void FixedUpdate()
    {
        if (transform.hasChanged)
        {
            transform.hasChanged = false;
            hole2DCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            hole2DCollider.transform.localScale *= initialScale;
            MakeHole2D();
            Generate3DMeshCollider();
        }
    }

    private void MakeHole2D()
    {
        Vector2[] PointPositions = hole2DCollider.GetPath(0);

        for (int i = 0; i < PointPositions.Length; i++)
        {
            PointPositions[i] = hole2DCollider.transform.TransformPoint(PointPositions[i]);
        }

        surface2DCollider.pathCount = 2;
        surface2DCollider.SetPath(1, PointPositions);
    }

    private void Generate3DMeshCollider()
    {
        if (GeneratedMesh != null) Destroy(GeneratedMesh);
        GeneratedMesh = surface2DCollider.CreateMesh(true, true);
        GeneratedMeshCollider.sharedMesh = GeneratedMesh;
    }
}
