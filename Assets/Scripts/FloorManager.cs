using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] floorPrefabs; // Array to hold the three floor prefabs
    public int repeatCount = 5;       // Number of times to repeat the floors
    public float floorLength = 58f;   // Length of each floor (to calculate positions)
    public float destructionDelay = 50f; // Time before destroying the old floors

    private void Start()
    {
        StartCoroutine(ManageFloors());
    }

    IEnumerator ManageFloors()
    {
        // Önce mevcut floor nesnelerini yok et
        yield return new WaitForSeconds(destructionDelay);
        DestroyOldFloors();

        // Sonra yeni floor nesnelerini klonlayýp yerleþtir
        GenerateFloors();
    }

    private void DestroyOldFloors()
    {
        GameObject[] oldFloors = GameObject.FindGameObjectsWithTag("Floor"); // Eðer floor nesnelerinin hepsi ayný tag'e sahipse
        foreach (GameObject floor in oldFloors)
        {
            Destroy(floor);
        }
    }

    private void GenerateFloors()
    {
        Debug.Log("floor");
        float zPosition = -50f;
        float floorLength = 58f;

        for (int i = 0; i < repeatCount; i++)
        {
            for (int j = 0; j < floorPrefabs.Length; j++)
            {
                Debug.Log("Cloning");
                Vector3 spawnPosition = new Vector3(0, 0, zPosition);
                Instantiate(floorPrefabs[j], spawnPosition, Quaternion.identity);

                zPosition += floorLength;
            }
        }
    }
}