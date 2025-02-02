using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed for moving the follow target
    public float zoomSpeed = 4f;  // Speed for zooming in/out
    public float minZoom = 0f;    // Minimum distance for the follow target
    public float maxZoom = 20f;   // Maximum distance for the follow target

    public GameObject followTarget; // The target that the camera follows

    private float _initialHeight;

    public void Start()
    {
        // Store the initial position of the follow target for reference
        _initialHeight = followTarget.transform.position.y;
    }

    public void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var scrollInput = Input.GetAxis("Mouse ScrollWheel");
        
        var targetPosition = followTarget.transform.position;
        
        targetPosition += new Vector3(horizontal, 0, vertical).normalized * (moveSpeed * Time.deltaTime);
        targetPosition.y = Mathf.Clamp(targetPosition.y - scrollInput * zoomSpeed, minZoom - _initialHeight, maxZoom - _initialHeight);

        followTarget.transform.position = targetPosition;
    }
}