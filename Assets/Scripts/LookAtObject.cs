using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] private GameObject targetObject = null;
    void LateUpdate()
    {
        transform.LookAt(targetObject.transform);
        transform.Rotate(0, 180, 0);
    }
}
