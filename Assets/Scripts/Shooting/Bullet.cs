using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 shootDir;

    public void Setup(Vector3 shootDir) //Est appelle par le script ShootBullet qui lui donne la direction de visee
    {
        this.shootDir = shootDir;

        Destroy(gameObject, 5f);    
    }

    private void Update()
    {
        float moveSpeed = 30f;
        transform.position += shootDir * moveSpeed * Time.deltaTime; //Deplacement

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerCollide = collision.gameObject.layer;
        if (layerCollide >= 8 && layerCollide <= 10) //layers compris entre 8 et 10
        {
            Destroy(gameObject);
            if (layerCollide == 9) //si layer est un "object"
            {
                Destroy(collision.gameObject); //detruit aussi l'object
            }
        }
    }
}
