using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObjDestr : MonoBehaviour
{

    [SerializeField] private Transform pfBlockSpawned;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform B1 = Instantiate(pfBlockSpawned, new Vector3(1, 0, 0), Quaternion.identity);
        Transform B2 = Instantiate(pfBlockSpawned, new Vector3(0, 1, 0), Quaternion.identity);
        Transform B3 = Instantiate(pfBlockSpawned, new Vector3(-1, 0, 0), Quaternion.identity);
        Transform B4 = Instantiate(pfBlockSpawned, new Vector3(0, -1, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}
