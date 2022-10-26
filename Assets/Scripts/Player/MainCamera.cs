using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainCamera : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerBody;
    public Rigidbody rbody;

    public float rotationSpeed;

    public CinemachineFreeLook thirdPersonCamera;
    public CameraStyle currentStyle;

    public enum CameraStyle
    {
        Normal,
        Aiming
    }

    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();

    private void Start()
    {
        currentStyle = CameraStyle.Normal;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            currentStyle = CameraStyle.Aiming;
        }
        else
        {
            currentStyle = CameraStyle.Normal;
        }

        // Rotate orientation
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        // Player input direction
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Raycast to aim at center of screen
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector3 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            mouseWorldPosition = raycastHit.point;
        }
        else
        {
            mouseWorldPosition = ray.GetPoint(10);
        }


        if (currentStyle == CameraStyle.Normal)
        {
            thirdPersonCamera.m_Lens.FieldOfView = 50;
            if (inputDirection != Vector3.zero)
            {
                playerBody.forward = Vector3.Slerp(playerBody.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
            }

        }
        else if (currentStyle == CameraStyle.Aiming)
        {
            thirdPersonCamera.m_Lens.FieldOfView = 40;

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            playerBody.forward = Vector3.Slerp(playerBody.forward, aimDirection, Time.deltaTime * 20f);
        }
    }
}
