using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
   
public GameObject[] section; // Bölüm prefablarý
public Transform player; // Player objesinin transformu
public float zPos = 1500; // Yeni bölümün z pozisyonu
public float sectionLength = 50; // Her bölümün uzunluðu
public float distanceToGenerate = 50; // Yeni bölüm oluþturmak için gereken mesafe
private bool creatingSection = false;

    int xd = 0;


private void Update()
{
    
    if (player.position.z >= zPos - distanceToGenerate && !creatingSection)
    {
            Debug.Log(xd);
            xd++;
        creatingSection = true;
        StartCoroutine(GenerateSection());
    }
}

IEnumerator GenerateSection()
{
    int secNum = Random.Range(0, section.Length);
    GameObject sectionObject = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);


    zPos += sectionLength;
    yield return new WaitForSeconds(0.1f); // Çok kýsa bir bekleme süresi
    creatingSection = false;
}
}
