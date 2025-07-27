using UnityEngine;

public class SpaceshipInput : MonoBehaviour
{
    public Vector4 RawInput { get; private set; }
    public Vector4 SmoothedInput { get; private set; }
    public bool FireBullet { get; private set; }
    public bool FireRocket { get; private set; }

    [Header("Input Smoothing")]
    public Vector4 Response = new Vector4(6.0f, 6.0f, 6.0f, 0.75f);

    public void UpdateInput()
    {
        Vector4 currentRawInput = Vector4.zero;
        // 你可以根据你的InputMode和m_input配置进一步补全(此处简化)
        currentRawInput.x = Input.GetAxis("Vertical");
        currentRawInput.y = Input.GetAxis("Horizontal");
        currentRawInput.z = Input.GetAxis("Roll");
        currentRawInput.w = Input.GetButton("Throttle") ? 1.0f : 0.0f;

        Vector4 currentSmoothedInput = Vector4.zero;
        for (int i = 0; i < 4; ++i)
        {
            currentSmoothedInput[i] = Mathf.Lerp(SmoothedInput[i], currentRawInput[i], Response[i] * Time.deltaTime);
        }

        RawInput = currentRawInput;
        SmoothedInput = currentSmoothedInput;

        FireBullet = Input.GetMouseButton(0);
        FireRocket = Input.GetMouseButtonDown(1);
    }
}