using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Funguju?");
    }
}
