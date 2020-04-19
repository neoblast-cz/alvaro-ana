using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    GameObject virtualCamera;
    Vector3 startPosition;
    Quaternion startRotation;

    bool shouldZoomOut = true;
    bool shouldZoomIn = false;
    CinemachineVirtualCamera cinemachineCamera;
    float cameraStartingSize = 2.5f;
    float cameraFinalSize = 4f;
    float cameraTempSize;

    void Start()
    {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        virtualCamera = GameObject.Find("MainVirtualCamera");

        startPosition = virtualCamera.transform.position;
        startRotation = virtualCamera.transform.rotation;

        cinemachineCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        cameraTempSize = 1f;
    }

    void Update() {
        if (shouldZoomOut)
            ZoomCameraOut();
        if (shouldZoomIn)
            ZoomCameraIn();
    }

    public void RestartCamera() {
        virtualCamera.SetActive(false);
        virtualCamera.transform.SetPositionAndRotation(startPosition, startRotation);
        shouldZoomOut = true;
        cameraTempSize = 1f;
        cinemachineCamera.m_Lens.OrthographicSize = cameraTempSize;
        virtualCamera.SetActive(true);
    }

    public void StartZoomOut(float localStartingSize, float localFinalSize) {
        cameraStartingSize = localStartingSize;
        cameraFinalSize = localFinalSize;
        shouldZoomOut = true;
        shouldZoomIn = false;
    }

    void ZoomCameraOut() {
        shouldZoomIn = false;
        if (cameraTempSize < cameraFinalSize) {
            cameraTempSize += Time.deltaTime;
            cinemachineCamera.m_Lens.OrthographicSize = cameraTempSize;
        }
        else
            shouldZoomOut = false;
    }

    public void StartZoomIn(float localStartingSize, float localFinalSize) {
        cameraStartingSize = localStartingSize;
        cameraFinalSize = localFinalSize;
        shouldZoomIn = true;
        shouldZoomOut = false;
    }

    void ZoomCameraIn() {
        shouldZoomOut = false;
        if (cameraTempSize > cameraStartingSize) {
            cameraTempSize -= Time.deltaTime;
            cinemachineCamera.m_Lens.OrthographicSize = cameraTempSize;
        }
        else
            shouldZoomIn = false;
    }
}