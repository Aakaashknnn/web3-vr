using UnityEngine;

public class ChalkTrail : MonoBehaviour
{
    private LineRenderer line;

    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.widthMultiplier = 0.1f;
        line.positionCount = 0;
        line.startColor = Color.white;
        line.endColor = Color.white;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // hold Space to draw
        {
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, transform.position);
        }
    }
}
