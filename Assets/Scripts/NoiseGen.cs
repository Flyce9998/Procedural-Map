using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGen : MonoBehaviour
{

    [HideInInspector]
    public enum modes { normal, island, lake };
    public int octaves;
    public float seed;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    public List<Terrain> terrain;
    [HideInInspector]
    public static Texture2D mTexture;
    [HideInInspector]
    public static float multiplier;
    public Vector2 offset;
    public static int scale;
    public static bool heightMap;
    public static modes mode;
    public static int size;

    void Start()
    {
        size = 512;
        mode = modes.normal;
        heightMap = false;
        scale = 5;
        multiplier = 1;
        offset = new Vector2(0, 0);
        mTexture = new Texture2D(size, size);
        mTexture.filterMode = FilterMode.Point;
        mTexture.wrapMode = TextureWrapMode.Clamp;
        GetComponent<MeshRenderer>().material.mainTexture = mTexture;
        seed = Random.Range(-1000000, 1000000);
        GenNoise();
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            GenNoise();
        }
        if (Input.GetKeyDown("g"))
        {
            seed = Random.Range(-10000000, 1000000);
            GenNoise();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            offset.x += size / 10 * Time.deltaTime;
            if (size < 600)
            {
                GenNoise();
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            offset.x -= size / 10 * Time.deltaTime;
            if (size < 600)
            {
                GenNoise();
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            offset.y -= size / 10 * Time.deltaTime;
            if (size < 600)
            {
                GenNoise();
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            offset.y += size / 10 * Time.deltaTime;
            if (size <600)
            {
                GenNoise();
            }
        }
    }

    public void GenNoise()
    {
        mTexture = new Texture2D(size, size);
        mTexture.filterMode = FilterMode.Point;
        mTexture.wrapMode = TextureWrapMode.Clamp;
        int center = size / 2 - 1;
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float v = Mathf.PerlinNoise((x + seed + offset.x) * frequency / scale / (size /20.48f), (y + seed + offset.y) * frequency / scale / (size / 20.48f));
                    v = Mathf.Clamp01(v);
                    noiseHeight += v * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
                noiseHeight = Mathf.Clamp01(noiseHeight);

                float distanceToCenter = 1 - Mathf.Abs(Vector2.Distance(new Vector2 (size/2, size/2), new Vector2(x, y))) / (size/2);

                if (mode == modes.lake)
                {
                    noiseHeight -= distanceToCenter * multiplier;
                } else if (mode == modes.island)
                {
                    noiseHeight *= Mathf.Sin(distanceToCenter * multiplier);
                }
                noiseHeight = Mathf.Clamp01(noiseHeight);

                if (!heightMap)
                {
                    for (int j = 0; j < terrain.Count; j++)
                    {
                        if (noiseHeight <= terrain[j].height)
                        {
                            mTexture.SetPixel(x, y, terrain[j].color);
                            break;
                        }
                    }
                } else
                {
                    mTexture.SetPixel(x, y, new Color (noiseHeight, noiseHeight, noiseHeight));
                }
            }
        }


        mTexture.Apply();
        GetComponent<MeshRenderer>().material.SetTexture("_MainTex", mTexture);
    }

    private void OnValidate()
    {
        size = Mathf.ClosestPowerOfTwo(size);
    }
}
[System.Serializable]
public struct Terrain
{
    public string name;
    public float height;
    public Color color;
}
