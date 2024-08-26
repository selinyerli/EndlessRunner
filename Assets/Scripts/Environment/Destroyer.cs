using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string objectNameToDestroy = "Section(Clone)"; // The name to match for destruction
    public float destructionDelay = 50f;                  // Time before destruction

    private void Start()
    {
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(destructionDelay);

        if (transform.name == objectNameToDestroy)
        {
            Destroy(gameObject);
        }
    }
}