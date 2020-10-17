using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class RotateCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;

    Quaternion startRotation;
    Quaternion endRotation;
    float targetRotation;
    float rotationProgress = -1;

    public void CalculateRotation(int direction)
    {
        startRotation = transform.rotation;
        if (direction == 1) // Rotate left
        {
            targetRotation += transform.rotation.y + 90;
        }
        else if (direction == 0) //Rotate Right
        {
            targetRotation -= transform.rotation.y + 90;
        }
        endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRotation, transform.rotation.eulerAngles.z);
        rotationProgress = 0;
    }

    void DoRotate()
    {
        if (rotationProgress < 1 && rotationProgress >= 0)
        {
            rotationProgress += Time.deltaTime * 4;
            cam.transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DoRotate();

        if (Input.GetKeyDown(KeyCode.E))//&& !test)
        {
            CalculateRotation(1);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            CalculateRotation(0);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            //SwitchView();
        }
    }
}
