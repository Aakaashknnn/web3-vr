using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.green;
    public float rayDistance = 5f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        crosshairImage.color = normalColor;
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // center of screen
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Chalk")) // highlight if looking at chalk
            {
                crosshairImage.color = interactColor;
            }
            else
            {
                crosshairImage.color = normalColor;
            }
        }
        else
        {
            crosshairImage.color = normalColor;
        }
    }
}
