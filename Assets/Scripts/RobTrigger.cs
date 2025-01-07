using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobTrigger : MonoBehaviour
{
    [SerializeField] private Material close;
    [SerializeField] private Material open;
    [SerializeField] private GameObject face;

    private Renderer faceRender;


    private void Start()
    {
        faceRender = face.GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        faceRender.material = open;
    }

    private void OnTriggerExit(Collider other)
    {
        faceRender.material = close;
    }
}
