using UnityEngine;

public class ChalkInteractor : MonoBehaviour
{
    public Transform holdPoint; // where chalk attaches
    public float interactDistance = 5f;

    private Camera cam;
    private GameObject heldChalk;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Check for interaction key
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldChalk == null)
            {
                TryPickup();
            }
            else
            {
                DropChalk();
            }
        }
    }

    void TryPickup()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // from crosshair
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Chalk"))
            {
                heldChalk = hit.collider.gameObject;

                // Stop physics
                Rigidbody rb = heldChalk.GetComponent<Rigidbody>();
                if (rb != null) rb.isKinematic = true;

                // Attach to player
                heldChalk.transform.SetParent(holdPoint);
                heldChalk.transform.localPosition = Vector3.zero;
            }
        }
    }

    void DropChalk()
    {
        if (heldChalk != null)
        {
            Rigidbody rb = heldChalk.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false;

            heldChalk.transform.SetParent(null);
            heldChalk = null;
        }
    }
}
