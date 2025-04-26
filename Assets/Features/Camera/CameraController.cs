using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [Header("References")] public CinemachineVirtualCamera virtualCamera;
    public Transform followTarget;

    [Header("Movement Settings")] public float moveSpeed = 5f;

    [Header("Zoom Settings")] public float zoomSpeed = 5f;
    public float minZoom = 3f;
    public float maxZoom = 10f;

    private void Start()
    {
        if (virtualCamera != null && followTarget != null)
        {
            virtualCamera.Follow = followTarget;
        }
        else
        {
            Debug.LogError("CameraController: Missing Virtual Camera or Follow Target reference.");
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        var input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        if (input != Vector2.zero)
        {
            followTarget.position += (Vector3)(input * (moveSpeed * Time.deltaTime));
        }
    }

    private void HandleZoom()
    {
        var scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput == 0f) return;
        
        var newSize = virtualCamera.m_Lens.OrthographicSize - scrollInput * zoomSpeed;
        newSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        virtualCamera.m_Lens.OrthographicSize = newSize;
    }
}