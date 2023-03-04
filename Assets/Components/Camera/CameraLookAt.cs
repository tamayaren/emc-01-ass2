using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private GameObject cameraSubject;
    [SerializeField] private float cameraSmoothness = 60f;
    [SerializeField] private float cameraZAxis = 15f;

    private void Update()
    {
        if (!cameraSubject) return;
        Vector3 cameraSubjectPosition = cameraSubject.transform.position;

        this.transform.position = Vector3.Lerp(this.transform.position,
            new Vector3(cameraSubjectPosition.x, cameraSubjectPosition.y, -cameraZAxis),
            cameraSmoothness * Time.deltaTime);
    }
}
