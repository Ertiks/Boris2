using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent1 : MonoBehaviour
{

    //On defini l'evenement :
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    //On peut passer la classe EventArgs cree juste en dessous pour lui donner plus d'informations lors de l'event.

    public class OnSpacePressedEventArgs : EventArgs
    {
        public int spaceCount;
    }

    private int spaceCount; //Pour compter le nombre de fois qu'on a appuye sur espace  

    private void Start()
    {
        //Permet de dire que Testing_OnSpacePressed est un subscriber a OnSpacePressed.
        OnSpacePressed += Testing_OnSpacePressed;

        spaceCount = 0;
    }

    private void Testing_OnSpacePressed(object sender, EventArgs e) //Les arguments du Subscriber doivent "match" la signature de l'event (Object sender, EventArgs e)
    {   
        //Testing_OnSpacePressed "ecoute" OnSpacePressed, et est appelle quand l'event arrive.
        Debug.Log("Space !");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Touche espace enfoncé --> Event !

            /*
            Le  "?.Invoke" permet de dire qu'on renvoit seulement si l'event n'est pas vide (null)
            EventArgs.Empty permet de ne rien renvoyer, car "EventHandler" demande un "System.EventArgs e"
            */
            spaceCount++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { spaceCount = spaceCount });
        }
    }
}
