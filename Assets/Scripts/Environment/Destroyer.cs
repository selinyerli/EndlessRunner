using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName;

    private void Update()
    {
        parentName = transform.name;
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(10);
        if (parentName == "Section(Clone)")
        {
            Destroy(gameObject);
        }
    }

}
