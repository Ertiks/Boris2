using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TestDelegate : MonoBehaviour
{
    public delegate void Test(int a);
    private Test testDelegateFunction;

    private Action TestAction; //Action est une version prefaite du Delegate Void Test(); (void, et aucun parametre)
    private Action<int, float> TestActionBis; //Delegate void qui prend un argu int, et un float.

    private Func<bool> TestFunc; //Version prefaite qui prend 0 parametres, mais qui renvoie un bool.   
    private Func<int, bool> TestFuncBis; //Version prefaite qui prend un int en param, et renvoie un bool. Le dernier est toujours le renvoi

    private void Start()
    {
        testDelegateFunction = MyFirstTest;
        testDelegateFunction += MySecondTest;

        testDelegateFunction(2);
    }

    private void MyFirstTest(int a) //Les fonctions associes au Delegate doivent correspondre a la signature du Delegate (ici, Void, et Int a en parametre)
    {
        Debug.Log("M1 + " + a);
    }

    private void MySecondTest(int a)
    {
        Debug.Log("M2 + " + a);
    }
}
