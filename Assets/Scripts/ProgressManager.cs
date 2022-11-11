using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public int rows = 3;
    public int monkeyrow = 1;
    private float rowsize;
    public Transform monkeyTransform;
    public Camera sceneCamera;
    private int factor = 10;

    // Start is called before the first frame update
    void Start() {
        rowsize = sceneCamera.orthographicSize / rows;
        // Debug.Log("Screen Size" + Screen.width);
        // Debug.Log("Row Size: " + rowSize);
        // Debug.Log("Rows: " + rows);
        Debug.Log("pixelWidth: " + sceneCamera.pixelWidth);
        Debug.Log("pixelHeight: " + sceneCamera.pixelHeight);
        float camWidth = calculateCameraWidth(sceneCamera);
        Debug.Log("actualCamWidth: " + camWidth);
        monkeyTransform.position = new Vector2(CalculateMonkeyPosition(monkeyrow), 0);
        // sceneCamera.orthographicSize = calculateAppropriateCameraSize(sceneCamera, rows);
        // Debug.Log("niceSize: " + calculateAppropriateCameraSize(sceneCamera, rows));
        setCamera(sceneCamera, rows);
    }

    // Update is called once per frame
    void Update() {
        setCamera(sceneCamera, rows);
        monkeyTransform.position = new Vector2(CalculateMonkeyPosition(monkeyrow), 0);
    }

    float CalculateMonkeyPosition(int row) {
        return (row * factor) - 5;
    }

    void setCamera(Camera cam, int rowsToBeVisible) {
        sceneCamera.orthographicSize = calculateAppropriateCameraSize(sceneCamera, rows);
        cam.transform.position = new Vector2(rowsToBeVisible * factor / 2, 0);
    }

    float calculateCameraWidth(Camera cam) {
        Debug.Log("aspect: " + cam.aspect);
        // Debug.Log("size: " + cam.orthographicSize * 2);
        return (cam.orthographicSize * 2) * cam.aspect;
    }

    float calculateAppropriateCameraSize(Camera cam, int rowsToBeVisible) {
        // float camSize = cam.orthographicSize * 2;
        return ((rowsToBeVisible * factor) / cam.aspect) / 2.0f;
    }

}
