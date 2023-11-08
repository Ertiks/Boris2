using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanon : MonoBehaviour
{
    [SerializeField] private float shootTimerMax;

    private Vector3 shootPosition;
    private Vector3 shootRotation;

    private float shootTimer;

    private void Awake()
    {
        shootPosition = transform.Find("shootPosition").position;

        shootTimer = shootTimerMax;
    }

    private void Start()
    {
        shootRotation = shootPosition - transform.position;
    }


    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            EnemyProjectile.Create(shootPosition, shootRotation, transform.rotation);

            shootTimer += shootTimerMax;

        }




    }
}
