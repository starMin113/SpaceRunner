using UnityEngine;

public sealed class SpaceshipController : MonoBehaviour
{
    public static SpaceshipController instance;
    public SpaceshipInput input { get; private set; }
    public SpaceshipMovement movement { get; private set; }
    public CameraController cameraController { get; private set; }
    public WeaponController weaponController { get; private set; }

    void Awake()
    {
        if (instance == null) instance = this;
        else Debug.LogError("Singleton pattern violated! Two player controlled spaceships present in the scene");

        input = GetComponent<SpaceshipInput>();
        movement = GetComponent<SpaceshipMovement>();
        cameraController = GetComponent<CameraController>();
        weaponController = GetComponent<WeaponController>();

        if (input == null) input = gameObject.AddComponent<SpaceshipInput>();
        if (movement == null) movement = gameObject.AddComponent<SpaceshipMovement>();
        if (cameraController == null) cameraController = gameObject.AddComponent<CameraController>();
        if (weaponController == null) weaponController = gameObject.AddComponent<WeaponController>();
    }

    void LateUpdate()
    {
        input.UpdateInput();
        movement.UpdateOrientationAndPosition(input);
        cameraController.UpdateCamera(movement, input);
      //  weaponController.UpdateWeapon(input);
    }

    void FixedUpdate()
    {
        // 可根据需求调整职责分配
        movement.PhysicsUpdate();
    }

    public Transform CachedTransform => movement ? movement.transform : transform;
    public float SpeedFactor => movement ? movement.GetSpeedFactor() : 0f;


}