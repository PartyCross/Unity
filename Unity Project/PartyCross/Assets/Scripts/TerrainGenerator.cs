using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;

    private List<GameObject> currentTerrains = new List<GameObject>();
    [HideInInspector] public Vector3 currentPosition = new Vector3(0, 0, 0);

    private void Start()
    {
        GameObject firstTerrain = Instantiate(terrainDatas[0].possibleTerrain[Random.Range(0, terrainDatas[0].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
        currentTerrains.Add(firstTerrain);
        currentPosition.x++;
        for (int i = 0; i < maxTerrainCount; ++i)
        {
            SpawnTerrain(true, new Vector3(0,0,0));
        }
        maxTerrainCount = currentTerrains.Count + 1;
        SpawnFieldOfGrass(true, new Vector3(0,0,0));
    }

    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if((currentPosition.x - playerPos.x < minDistanceFromPlayer) || isStart)
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);

            for (int i = 0; i < terrainInSuccession; ++i)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrain[Random.Range(0,terrainDatas[whichTerrain].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                currentPosition.x++;
            }
        }
    }

    public void SpawnFieldOfGrass(bool isStart, Vector3 playerPos) {
        Vector3 thisPos = new Vector3(0,0,0);
        if(playerPos.x == thisPos.x && isStart) {
            for(; thisPos.x >= -20; thisPos.x--) {
                GameObject terrain = Instantiate(terrainDatas[0].possibleTerrain[Random.Range(0, 3)], thisPos, Quaternion.identity, terrainHolder);
            }
        }
    }
}