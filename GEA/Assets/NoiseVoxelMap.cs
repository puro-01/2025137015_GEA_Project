using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseVoxelMap : MonoBehaviour
{
    public GameObject grassBlockPrefab;

    public GameObject dirtBlockPrefab;

    public GameObject blockPrefabWater;

    public int width = 20;

    public int depth = 20;

    public int maxHeight = 16;

    public int WaterLevel = 4;

    [SerializeField] float noiseScale = 20f;
    // Start is called before the first frame update
    void Start()
    {
        float offsetX = Random.Range(-9999f, 9999f);
        float offsetZ = Random.Range(-9999f, 9999f);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float nx = (x + offsetX) / noiseScale;
                float nz = (z + offsetZ) / noiseScale;

                float noise = Mathf.PerlinNoise(nz, nx);

                int h = Mathf.FloorToInt(noise * maxHeight);

                if (h <= 0) h = 1;

                for (int y = 0; y <= h; y++)
                {
                    if (y == h)
                    {
                        // 가장 윗부분(y == h)이므로 잔디를 배치합니다.
                        Place(grassBlockPrefab, x, y, z);
                    }
                    else
                    {
                        // 잔디 아래(y < h)는 흙을 배치합니다.
                        Place(dirtBlockPrefab, x, y, z);
                    }
                }
                for (int y = h + 1; y <= WaterLevel; y++)
                {
                    PlaceWater(x, y, z);
                }
            }
        }
    }

    private void Place(GameObject prefabToPlace, int x, int y, int z)
    {
        // 프리팹이 할당되지 않았을 경우를 대비한 방어 코드
        if (prefabToPlace == null)
        {
            Debug.LogWarning($"Prefab for ({x},{y},{z}) is not assigned.");
            return;
        }

        var go = Instantiate(prefabToPlace, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"B_{prefabToPlace.name}_{x}_{y}_{z}"; // 이름도 더 구체적으로 변경
    }

    private void PlaceWater(int x, int y, int z)
    {
        var go = Instantiate(blockPrefabWater, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"Water_{x}_{y}_{z}";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
