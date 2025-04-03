using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class playerFly : MonoBehaviour
{
    public GameObject rightHand;  // Assign in the Inspector
    public float acceleration = 20f;  // Adjust thrust power
    public float maxSpeed = 30f;      // Maximum flying speed

    private Rigidbody rb;
    private InputDevice rightHandDevice;
    public XRNode rightHandNode = XRNode.RightHand;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;  // Enable gravity for natural deceleration
        rb.drag = 0.5f;        // Adjust drag for smoother deceleration
    }

    void Update()
    {
        rightHandDevice = InputDevices.GetDeviceAtXRNode(rightHandNode);

        if (rightHandDevice.isValid && rightHandDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            if (triggerValue > 0.1f) // Apply force when trigger is pressed
            {
                Fly();
            }
        }
    }

    void Fly()
    {
        if (rightHand == null) return;

        Vector3 forceDirection = rightHand.transform.forward; // Move in the direction of the hand
        rb.AddForce(forceDirection * acceleration, ForceMode.Acceleration);

        // Clamp velocity to maxSpeed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
