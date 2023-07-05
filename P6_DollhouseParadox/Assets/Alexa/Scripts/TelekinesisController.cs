using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TelekinesisController : MonoBehaviour
{
    public float maxDistance = 10f;
    public InteractionLayerMask interactableLayer;

    private XRController xrController;
    private bool isGrabbing;
    private XRGrabInteractable currentGrabInteractable;
    private Vector3 initialGrabOffset;

    private void Awake()
    {
        xrController = GetComponent<XRController>();
        if (xrController == null)
        {
            Debug.LogError("No XRController component found. Make sure the script is attached to the correct GameObject.");
        }
    }

    private void Update()
    {
        if (xrController.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerPressed))
        {
            if (triggerPressed && !isGrabbing)
            {
                RaycastHit hit;
                if (Physics.Raycast(xrController.transform.position, xrController.transform.forward, out hit, maxDistance, interactableLayer))
                {
                    currentGrabInteractable = hit.collider.GetComponent<XRGrabInteractable>();
                    if (currentGrabInteractable != null)
                    {
                        isGrabbing = true;
                        initialGrabOffset = hit.point - currentGrabInteractable.transform.position;
                        currentGrabInteractable.transform.SetParent(transform);
                        currentGrabInteractable.interactionLayers = interactableLayer;
                    }
                }
            }
            else if (!triggerPressed && isGrabbing)
            {
                isGrabbing = false;
                currentGrabInteractable.transform.SetParent(null);
                currentGrabInteractable.interactionLayers = interactableLayer;
                currentGrabInteractable = null;
            }
        }

        if (isGrabbing && currentGrabInteractable != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(xrController.transform.position, xrController.transform.forward, out hit, maxDistance))
            {
                Vector3 targetPosition = hit.point - initialGrabOffset;
                currentGrabInteractable.transform.position = targetPosition;
            }
        }
    }
}
