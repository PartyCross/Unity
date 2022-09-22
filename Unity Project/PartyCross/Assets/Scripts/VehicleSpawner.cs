using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vehicle;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private bool isRightSide;

    private void Start()
    {
        StartCoroutine(SpawnVehicle());
    }

    //private void Update()
    //{
    //    if(vehicle.transform.position.z >= endPos.transform.position.z)
    //    {
    //        RespawnVehicle();
    //    }
    //}

    private IEnumerator SpawnVehicle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));
            vehicle = Instantiate(vehicle, spawnPos.position, Quaternion.identity);
            vehicle.transform.rotation = Quaternion.Euler(0, spawnPos.rotation.y, 0);
            if (!isRightSide)
            {
                vehicle.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }

    //private void RespawnVehicle()
    //{
    //    vehicle.transform.position = spawnPos.position;
    //}
}