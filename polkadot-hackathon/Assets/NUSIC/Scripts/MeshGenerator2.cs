using CrazyMinnow.AmplitudeWebGL;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MeshGenerator2 : MonoBehaviour
{
    public Amplitude amplitude;
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    public Slider eqAvgSlider;
    public Slider eqMaxSlider;

    private Dropdown[] dropdowns;
    private Dropdown sampleSize;
    private Dropdown dataType;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        if (dropdowns != null)
        {
            for (int i = 0; i < dropdowns.Length; i++)
            {
                if (dropdowns[i].gameObject.name == "sampleSize")
                    sampleSize = dropdowns[i];
                if (dropdowns[i].gameObject.name == "dataType")
                    dataType = dropdowns[i];
            }
        }

        if (amplitude)
        {
            if (sampleSize)

                sampleSize.value = System.Array.IndexOf(amplitude.sampleSizeVals, amplitude.sampleSize);

            if (dataType)
                dataType.value = (int)amplitude.dataType;
        }
    }

    private void Update()
    {
        if (amplitude)
        {
            if (eqAvgSlider != null)
                eqAvgSlider.value = amplitude.average;
            else
                Debug.LogError("Eq Avg is null");

            if (eqMaxSlider != null)
                eqMaxSlider.value = amplitude.max;
            else
                Debug.LogError("Eq Max is null");


            /*for (int i = 0; i < amplitude.sample.Length; i++)
            {
                if (eqSliders != null)
                {
                    if (i < eqSliders.Length)
                        eqSliders[i].value = amplitude.sample[i];
                }
                else
                {
                    Debug.LogError("Eq Sliders is null");
                }
            }*/

            vertices = new Vector3[(xSize + 1) * (zSize + 1)];

            for (int a = 0; a < amplitude.sample.Length; a++)
            {
                for (int i = 0, z = 0; z <= zSize; z++)
                {
                    for (int x = 0; x <= xSize; x++)
                    {
                        float y = amplitude.sample[i];
                        vertices[i] = new Vector3(x, y, z);
                        i++;
                        //vertices[i] = new Vector3(x, 0, z);
                        //i++;
                    }
                }
            }
            UpdateMesh();
            
        }
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                //float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;            
                vertices[i] = new Vector3(x, 0, z);
                i++;
                //vertices[i] = new Vector3(x, 0, z);
                //i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
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

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
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

    public void SetBoost(float boost)
    {
        amplitude.boost = boost;
    }

    public void OnValueChangedSampleSize(int sampleSizeIndex)
    {
        if (amplitude)
        {
            amplitude.sampleSize = amplitude.sampleSizeVals[sampleSizeIndex];
        }
    }

    public void OnValueChangedDataType(int dataType)
    {
        if (amplitude)
        {
            amplitude.dataType = (Amplitude.DataType)dataType;
        }
    }

    public void Play()
    {
        if (amplitude)
        {
            amplitude.audioSource.Play();
        }
    }

    public void Stop()
    {
        if (amplitude)
        {
            amplitude.audioSource.Stop();
        }
    }
}
