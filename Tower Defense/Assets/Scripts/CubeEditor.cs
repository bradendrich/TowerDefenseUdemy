using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [SerializeField] [Range (1f, 20f)] float gridSize = 10f;

    TextMesh textMesh;
    Vector3 snapPos;

    void Update ()
    {
        UpdatenNameAndTextOnCube();

        SnapCubePosition();
    }

    private void SnapCubePosition()
    {
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }

    private void UpdatenNameAndTextOnCube()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelName = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMesh.text = labelName;
        gameObject.name = labelName;
    }
}
