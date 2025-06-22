using UnityEngine;

public class SpaceRunnerCameraController : MonoBehaviour
{
    [Header("跟随设置")]
    public Transform target;           // 飞船
    public Vector3 offset = new Vector3(-8, 6, 0); // 右后上，左手系，X-右，Y-上，Z-前
    public float followSmooth = 0.15f;

    [Header("视野设置")]
    public float lookAheadDistance = 10f;   // 视野前探距离
    public Vector3 lookOffset = new Vector3(0, 2, 0); // 视线略上抬

    [Header("轨道弧线（右弯）参数")]
    public float arcRadius = 50f;      // 圆弧半径
    public float arcAnglePerUnit = 3f; // 飞船每前进1单位，轨道弧线右弯多少度

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (!target) return;

        // 1. 计算飞船在圆弧轨道上的切线方向（即前进方向，右弯）
        float traveled = target.position.z; // 假设z是前进距离
        float arcAngle = traveled * arcAnglePerUnit;
        Quaternion arcRot = Quaternion.Euler(0, arcAngle, 0);

        // 2. 计算相机期望位置（始终在飞船右后上方，圆弧方向修正）
        Vector3 cameraOffset = arcRot * offset;
        Vector3 desiredPos = target.position + cameraOffset;

        // 3. 平滑跟随
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref currentVelocity, followSmooth);

        // 4. 相机lookAt目标（飞船前方+lookOffset，圆弧方向修正）
        Vector3 lookAtTarget = target.position + arcRot * (Vector3.forward * lookAheadDistance + lookOffset);

        transform.LookAt(lookAtTarget);

        // 5. 可选：锁定恒星在右侧（如需始终可见恒星，可用屏幕空间固定UI或world space anchor）
        // 这里通过圆弧轨道和相机右后上方保证了右侧开阔
    }
}