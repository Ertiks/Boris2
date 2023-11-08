using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Stop", 0.1f);
    }

    private void Stop()
    {
        //Stop = true;
        Destroy(this.gameObject);
    }
}


