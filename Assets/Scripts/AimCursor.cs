using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;


public class AimCursor : MonoBehaviour
{
    private Vector3 PosBullet = new Vector3(1,0,0); //Le vecteur est def en coordonnees locales
    private Vector3 WPosBullet; //Vecteur position en coordonnees globales

    [SerializeField] private Transform aimTransform; //Transform du player qu'on va faire tourner

    public event EventHandler<OnShootEventArgs> OnShootEvent;
    public class OnShootEventArgs : EventArgs //Class lie a l'event pour transmettre la position d'instanciation du projectile
    {
        public Vector3 PosBullet; //Position LOCALE du projectile instancie

        public Vector3 shootDir;

    }


    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        //Partie Aim (c'est des maths et de la geometrie) :
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        //------------//

        //Partie Event Shoot : 

        Vector3 WPosBullet = aimTransform.TransformPoint(PosBullet); //On passe les coord en coord World
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            OnShootEvent?.Invoke(this, new OnShootEventArgs { PosBullet = WPosBullet, shootDir = aimDirection}); //On transmet les coord globales
        }   
        
    }


}
