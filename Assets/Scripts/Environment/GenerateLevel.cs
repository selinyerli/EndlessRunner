using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sectionPrefabs; // Farklý section prefablarý için dizi
    public int initialSectionCount = 3; // Baþlangýçta oluþturulacak section sayýsý
    public float sectionLength = 52f;
    public float playerMoveSpeed = 3f;
    public Transform player; // Oyuncu objesi
    private List<GameObject> activeSections = new List<GameObject>();
    private float spawnZ;
    private int sectionIndex = 0;

    void Start()
    {
        spawnZ = 0;
        for (int i = 0; i < initialSectionCount; i++)
        {
            SpawnSection();
        }
    }

    void Update()
    {
        // Oyuncuyu ileri hareket ettir
        player.Translate(Vector3.forward * playerMoveSpeed * Time.deltaTime);

        // Yeni section ekleme kontrolü
        if (player.position.z > spawnZ - (initialSectionCount * sectionLength))
        {
            SpawnSection();
        }
    }

    void SpawnSection()
    {
        GameObject selectedSectionPrefab = sectionPrefabs[Random.Range(0, sectionPrefabs.Length)];
        Debug.Log($"Spawning section: {selectedSectionPrefab}");
        GameObject section = Instantiate(selectedSectionPrefab);
        section.transform.position = Vector3.forward * spawnZ;
        activeSections.Add(section);
        spawnZ += sectionLength;

        // Schedule deletion of this section after 60 seconds
        StartCoroutine(DeleteSectionAfterDelay(section));
    }

    IEnumerator DeleteSectionAfterDelay(GameObject section)
    {
        yield return new WaitForSeconds(120f);
        DeleteSection(section);
    }

    void DeleteSection(GameObject section)
    {
        if (activeSections.Contains(section))
        {
            activeSections.Remove(section);
            Destroy(section);
        }
    }
}