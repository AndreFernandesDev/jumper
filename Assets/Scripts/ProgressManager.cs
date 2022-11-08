using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public int rows = 3;
    private float rowsize;
    public float rowSize {
        get { return rowsize; }
    }
    public Transform monkeyTransform;
    public Camera sceneCamera;

    // Start is called before the first frame update
    void Start() {
        rowsize = sceneCamera.orthographicSize / rows;
        Debug.Log("Screen Size" + Screen.width);
        Debug.Log("Row Size: " + rowSize);
        Debug.Log("Rows: " + rows);
        Debug.Log("Calculated Position" + CalculateMonkeyPosition(1));

        monkeyTransform.position = new Vector2(CalculateMonkeyPosition(1), 0);

    }

    // Update is called once per frame
    void Update() {
        
    }

    float CalculateMonkeyPosition(int row) {
        float negativeDiscount = (sceneCamera.orthographicSize / 2) * -1;
        return (rowSize * row) - (rowSize / 2) + negativeDiscount;
    }
}
