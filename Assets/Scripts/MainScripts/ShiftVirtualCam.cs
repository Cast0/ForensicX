using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ShiftVirtualCam : MonoBehaviour
{
    [Header("Inspect Positions Transform")]
    public Transform defaultPos;
    public Transform headPos;
    public Transform lowerPos;
    CinemachineVirtualCamera virtualCamera = null;

    public void ShiftCam_Head()
    {
        virtualCamera.Follow = headPos;
    }
    public void SetupCam(CinemachineVirtualCamera cinemachineVirtualCamera)
    {
        virtualCamera = cinemachineVirtualCamera;
        Default();

    }

    public void Default()
    {
        virtualCamera.Follow = defaultPos;

    }
    public void ShiftCam_Lower()
    {
        virtualCamera.Follow = lowerPos;
    }
}
