using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    public Transform camera;

    // Late Update is right after update
    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }
}
