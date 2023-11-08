using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventSubscriber : MonoBehaviour
{
    private void Start()
    {   
        //On Reference le script. Comme il est sur le meme Gameobject, on a juste a recuperer le component script.
        TestEvent1 testEvent1 = GetComponent<TestEvent1>(); //(Ne pas oublier les parenthèses a la fin.)

        //On ajoute un nouveau subscriber, mais dans un autre script !
        testEvent1.OnSpacePressed += TestEvent1_OnSpacePressed;
    }

    private void TestEvent1_OnSpacePressed(object sender, TestEvent1.OnSpacePressedEventArgs e) //Penser a mettre les meme arguments que EventHandler.
    {
        Debug.Log("Espace appuye : " + e.spaceCount);


    }
}
