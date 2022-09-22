using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankSpawner : MonoBehaviour
{
    [SerializeField] private GameObject plank;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform endPos;
    
    private void Start()
    {
        StartCoroutine(SpawnPlank());

    }

    private void Update()
    {
        if (plank.transform.position.z >= endPos.transform.position.z)
        {
            RespawnPlank();
        }
    }

    private IEnumerator SpawnPlank()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        plank = Instantiate(plank, spawnPos.position, Quaternion.identity);
    }

    private void RespawnPlank()
    {
        plank.transform.position = spawnPos.position;
    }
}
