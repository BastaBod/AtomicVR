using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeshSplitter : MonoBehaviour
{
    public GameObject originalMeshObject;
    public GameObject voxelPrefab;
    public Vector3 voxelSize;

    void Start()
    {
        // Access the mesh from the original object
        Mesh originalMesh = originalMeshObject.GetComponent<MeshFilter>().mesh;

        // Get the bounds of the original mesh
        Bounds meshBounds = originalMesh.bounds;

        // Calculate the number of voxels along each axis
        int voxelCountX = Mathf.CeilToInt(meshBounds.size.x / voxelSize.x);
        int voxelCountY = Mathf.CeilToInt(meshBounds.size.y / voxelSize.y);
        int voxelCountZ = Mathf.CeilToInt(meshBounds.size.z / voxelSize.z);

        // Loop through each voxel
        for (int x = 0; x < voxelCountX; x++)
        {
            for (int y = 0; y < voxelCountY; y++)
            {
                for (int z = 0; z < voxelCountZ; z++)
                {
                    // Calculate the position of the current voxel
                    Vector3 voxelPosition = meshBounds.min + new Vector3(x * voxelSize.x, y * voxelSize.y, z * voxelSize.z);

                    // Check if the voxel position is inside the mesh bounds
                    if (IsInsideBounds(voxelPosition, meshBounds))
                    {
                        // Instantiate a voxel cube at the current position
                        GameObject voxel = Instantiate(voxelPrefab, voxelPosition, Quaternion.identity);
                        voxel.transform.localScale = voxelSize;
                    }
                }
            }
        }
    }

    bool IsInsideBounds(Vector3 point, Bounds bounds)
    {
        return point.x >= bounds.min.x && point.x <= bounds.max.x &&
               point.y >= bounds.min.y && point.y <= bounds.max.y &&
               point.z >= bounds.min.z && point.z <= bounds.max.z;
    }

}
