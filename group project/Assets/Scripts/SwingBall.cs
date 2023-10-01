using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBall : MonoBehaviour
{
    public float maxSwingAngle;
    public float rotateSpeed;
    public float angle;
    public Transform rotateCenter;
    float currentRotateAngle = 0;
    Vector3 rotateDirction = new Vector3(0,0,1);

    bool firstTime = true;

    // Update is called once per frame
    void Update()
    {
        if (currentRotateAngle < maxSwingAngle)
        {
            currentRotateAngle += rotateSpeed * Time.deltaTime;
        }
        else
        {
            currentRotateAngle = 0;
            rotateDirction = -rotateDirction;
            if (firstTime)
            {
                maxSwingAngle += angle;
                firstTime = false;
            }
        }
        transform.RotateAround(rotateCenter.position, rotateDirction, rotateSpeed * Time.deltaTime);
    }
}
