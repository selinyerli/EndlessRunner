using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
   
public GameObject[] section; // B�l�m prefablar�
public Transform player; // Player objesinin transformu
public float zPos = 1500; // Yeni b�l�m�n z pozisyonu
public float sectionLength = 50; // Her b�l�m�n uzunlu�u
public float distanceToGenerate = 50; // Yeni b�l�m olu�turmak i�in gereken mesafe
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
    yield return new WaitForSeconds(0.1f); // �ok k�sa bir bekleme s�resi
    creatingSection = false;
}
}
