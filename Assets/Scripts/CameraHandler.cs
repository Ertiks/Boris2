using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] float DistanceScreenX;
    [SerializeField] float DistanceScreenY;

    //[SerializeField] int levelSizeX;
    //[SerializeField] int levelSizeY;

    //private Vector3 transfPosVec;

    private void Update()
    {

        //X
        if (transform.position.x - player.transform.position.x > DistanceScreenX)
        {
            transform.position += new Vector3(-32f, 0, 0);
        }
        else if (transform.position.x - player.transform.position.x < -DistanceScreenX)
        {
            transform.position += new Vector3(32f, 0, 0);
        }

        //Y
        if (transform.position.y - player.transform.position.y > DistanceScreenY)
        {
            transform.position += new Vector3(0, -18f, 0);   
        }
        else if (transform.position.y - player.transform.position.y < -DistanceScreenY)
        {
            transform.position += new Vector3(0, 18f, 0);
        }

        /*Algo de Taku :
        transfPosVec = new Vector3((player.transform.position.x - (player.transform.position.x % levelSizeX)) + (levelSizeX / 2)
            , (player.transform.position.y - (player.transform.position.y % levelSizeY)) + (levelSizeY / 2), 0);
        transform.position = transfPosVec;
        */
    }
}
