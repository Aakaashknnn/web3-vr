using UnityEngine;

public class ChalkWriter : MonoBehaviour
{
    public LineRenderer linePrefab;   // assign a simple LineRenderer prefab
    public Transform tip;             // empty GameObject at chalk tip
    public LayerMask boardLayer;      // only draw on board

    private LineRenderer currentLine;
    private bool isDrawing = false;

    void Update()
    {
        // Start/Stop drawing with Left Mouse Button
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }

        if (isDrawing)
        {
            Draw();
        }
    }

    void StartDrawing()
    {
        // Check if chalk tip is touching the board
        if (Physics.Raycast(tip.position, tip.forward, out RaycastHit hit, 0.1f, boardLayer))
        {
            currentLine = Instantiate(linePrefab);
            currentLine.positionCount = 0;
            isDrawing = true;
        }
    }

    void StopDrawing()
    {
        isDrawing = false;
        currentLine = null;
    }

    void Draw()
    {
        if (currentLine != null)
        {
            // Add a new point at chalk tip
            currentLine.positionCount++;
            currentLine.SetPosition(currentLine.positionCount - 1, tip.position);
        }
    }
}
