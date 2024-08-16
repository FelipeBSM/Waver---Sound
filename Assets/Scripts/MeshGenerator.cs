using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    //Mesh Infos
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    [SerializeField] private float restSmoothTime;

    //Grid Infos
    [SerializeField] private int xSize=20, zSize =20;
    

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        CreateShape();
       
    }

    void Update()
    {
        UpdateMesh();
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    MoveMesh(UnityEngine.Random.Range(1, 10f));
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    ResetMesh();
        //}
    }
    public void CreateShape()
    {
       
        for(int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
              
                vertices[i] = new Vector3(x, 1, z); // aumentar esse valor maybe em y
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;
       


        for (int z = 0; z <zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
       
    }
    public void MoveMesh(float _ammount)
    {
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * 3;
                Vector3 newVec = new Vector3(x, y, z);
                vertices[i] = Vector3.Lerp(vertices[i],newVec,restSmoothTime *Time.deltaTime); // aumentar esse valor maybe em y
                i++;
            }
        }
    }
    public void MoveMesh(float[] samples)
    {
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {

                Vector3 newVec = new Vector3();
                if (z<zSize/2)
                    newVec = new Vector3(x, samples[i]*50, z);
                else
                    newVec = new Vector3(x, samples[i] * 200, z);
                vertices[i] = newVec;
                i++;
            }
        }
    }
    public void ResetMesh()
    {
        
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                Vector3 reset = new Vector3(x, 1, z);
                vertices[i] = Vector3.Lerp(vertices[i], reset, restSmoothTime * Time.deltaTime); // aumentar esse valor maybe em y
                i++;
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }

    // Update is called once per frame


    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
