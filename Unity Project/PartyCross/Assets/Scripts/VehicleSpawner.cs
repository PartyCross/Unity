using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vehicle;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform endPos;

    private void Start()
    {
        StartCoroutine(SpawnVehicle());
    }

    private void Update()
    {
        if(vehicle.transform.position.z >= endPos.transform.position.z)
        {
            RespawnVehicle();
        }
    }

    private IEnumerator SpawnVehicle()
    {
        yield return new WaitForSeconds(Random.Range(1,5));
        vehicle = Instantiate(vehicle, spawnPos.position, Quaternion.identity);
    }

    private void DespawnVehicle()
    {

    }

    private void RespawnVehicle()
    {
        vehicle.transform.position = spawnPos.position;
    }
}