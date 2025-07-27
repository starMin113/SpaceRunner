using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public Transform Avatar;
    public Vector3 Maneuverability = new Vector3(75.0f, 75.0f, -50.0f);
    public float BankAngleSmooth = 2.5f;
    public float MaxBankAngleOnTurnAxis = 45.0f;
    public float MaxBankAngleOnTurnLeftRight = 60f;
    public float MaxBankAngleOnTurnUpDown = 60f;
    public float MaxBankAngleSideways = 30f;
    public float SidewaysSpeed = 25f;
    public Vector2 SpeedRange = new Vector2(30.0f, 600.0f);
    public AnimationCurve AccelerationCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

    private Quaternion m_initialAvatarRotation;

    void Start()
    {
        if (Avatar != null)
            m_initialAvatarRotation = Avatar.localRotation;
    }

    public float SpeedFactor(float throttle) => AccelerationCurve.Evaluate(throttle);

    public float CurrentSpeed(float throttle)
    {
        return Mathf.Lerp(SpeedRange.x, SpeedRange.y, SpeedFactor(throttle));
    }

    public void UpdateOrientationAndPosition(SpaceshipInput input)
    {
        // 旋转
        for (int i = 0; i < 3; ++i)
        {
            transform.localRotation *= Quaternion.AngleAxis(
                input.SmoothedInput[i] * Maneuverability[i] * Time.deltaTime,
                i == 0 ? Vector3.right : i == 1 ? Vector3.up : Vector3.forward
            );
        }

        // 前进
        if (Input.GetAxis("Stop") == 0f)
        {
            transform.localPosition += transform.forward * CurrentSpeed(input.SmoothedInput.w) * Time.deltaTime;
        }

        // 倾斜
        if (Avatar != null)
        {
            Avatar.localRotation = Quaternion.Slerp(
                Avatar.localRotation,
                m_initialAvatarRotation * Quaternion.AngleAxis(input.SmoothedInput.y * MaxBankAngleOnTurnLeftRight, Vector3.up),
                BankAngleSmooth * Time.deltaTime
            );
            Avatar.localRotation = Quaternion.Slerp(
                Avatar.localRotation,
                m_initialAvatarRotation * Quaternion.AngleAxis(-input.SmoothedInput.y * MaxBankAngleOnTurnAxis, Vector3.forward),
                BankAngleSmooth * Time.deltaTime
            );
            Avatar.localRotation = Quaternion.Slerp(
                Avatar.localRotation,
                m_initialAvatarRotation * Quaternion.AngleAxis(input.SmoothedInput.x * MaxBankAngleOnTurnUpDown, Vector3.right),
                BankAngleSmooth * Time.deltaTime
            );
        }
        if (Input.GetAxis("Sideways") != 0f)
        {
            transform.localPosition += transform.right * Input.GetAxis("Sideways") * Time.deltaTime * SidewaysSpeed;
            if (Avatar != null)
            {
                Avatar.localRotation = Quaternion.Slerp(
                    Avatar.localRotation,
                    m_initialAvatarRotation * Quaternion.AngleAxis(-Input.GetAxis("Sideways") * MaxBankAngleSideways, Vector3.forward),
                    BankAngleSmooth * Time.deltaTime
                );
            }
        }
    }

    public void PhysicsUpdate() { /* 如需物理相关可在此实现 */ }

    public float GetSpeedFactor()
    {
        const float currentThrottle = 0;
        return AccelerationCurve.Evaluate(currentThrottle); // currentThrottle由SpaceshipInput传递或本地维护
    }
}