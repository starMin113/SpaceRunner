using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera TargetCamera;
    public float Angle = 18.0f;
    public float Offset = 44.0f;
    public float PositionSmooth = 10.0f;
    public float RotationSmooth = 5.0f;
    public Vector2 LookAtPointOffset = new Vector2(0.0f, 10.0f);

    private Transform m_cachedCameraTransform;
    private float m_initialCameraFOV;
    private float m_idleCameraDistance;

    void Start()
    {
        m_cachedCameraTransform = TargetCamera ? TargetCamera.transform : Camera.main.transform;
        m_initialCameraFOV = TargetCamera.fieldOfView;
        m_idleCameraDistance = CameraOffsetVector().magnitude;
    }

    public Vector3 CameraOffsetVector()
    {
        return new Vector3(0.0f, Mathf.Sin(Angle * Mathf.Deg2Rad) * Offset, -Offset);
    }

    public void UpdateCamera(SpaceshipMovement movement, SpaceshipInput ginput)
    {
        // 核心逻辑抽取自原SpaceshipController.UpdateCamera()
        Vector3 lookTargetPosition = transform.position + transform.right * LookAtPointOffset.x + transform.up * LookAtPointOffset.y;
        Quaternion targetCameraRotation = Quaternion.LookRotation(lookTargetPosition - m_cachedCameraTransform.position, transform.up);

        m_cachedCameraTransform.rotation = Quaternion.Slerp(m_cachedCameraTransform.rotation,
            targetCameraRotation, RotationSmooth * Time.deltaTime);

        Vector3 cameraOffset = transform.TransformDirection(CameraOffsetVector());
        m_cachedCameraTransform.position = Vector3.Lerp(m_cachedCameraTransform.position,
            transform.position + cameraOffset, PositionSmooth * Time.deltaTime);

        // FOV调整等可根据实际需求补充
    }
}