using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraShake : MonoBehaviour
{
    Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.02f;
    public float shakeTime = 0.5f;

    public void ShakeCamera()
    {
        cameraInitialPosition = transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermediatePosition = transform.position;
        cameraIntermediatePosition.x += cameraShakingOffsetX;
        cameraIntermediatePosition.y += cameraShakingOffsetY;
        transform.position = cameraIntermediatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        transform.position = cameraInitialPosition;
    }
}



