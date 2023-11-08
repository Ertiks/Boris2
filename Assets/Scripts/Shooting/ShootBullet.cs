using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ShootBullet : MonoBehaviour
{

    [SerializeField] private Transform pfBullet; //Prefab du projectile
    [SerializeField] private Transform aimTransform; //Le player, pour recuperer la rotation


    private void Start()
    {
        AimCursor aimCursor = GetComponent<AimCursor>();
        aimCursor.OnShootEvent += OnshootSubs; //Subscribe a l'event dans AimCursor

    }

    //Fonction qui se subscribe a l'event shoot dans AimCursor
    private void OnshootSubs(object sender, AimCursor.OnShootEventArgs e)
    {
        CameraShaker.Instance.ShakeCamera(1f, 0.07f);

        Vector3 ShootDir = e.shootDir;
        Transform bulletTransform = Instantiate(pfBullet, e.PosBullet, aimTransform.transform.rotation); //Instancie le projectile
        bulletTransform.GetComponent<Bullet>().Setup(ShootDir); //Appelle la fonction Setup associe au script Bullet que l'on recupere grace au transform.GetComponent<>. 
        //On lui donne la direction de visee


    }
}
