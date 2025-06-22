using UnityEngine;

public class SpaceRunnerCameraController : MonoBehaviour
{
    [Header("��������")]
    public Transform target;           // �ɴ�
    public Vector3 offset = new Vector3(-8, 6, 0); // �Һ��ϣ�����ϵ��X-�ң�Y-�ϣ�Z-ǰ
    public float followSmooth = 0.15f;

    [Header("��Ұ����")]
    public float lookAheadDistance = 10f;   // ��Ұǰ̽����
    public Vector3 lookOffset = new Vector3(0, 2, 0); // ��������̧

    [Header("������ߣ����䣩����")]
    public float arcRadius = 50f;      // Բ���뾶
    public float arcAnglePerUnit = 3f; // �ɴ�ÿǰ��1��λ���������������ٶ�

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (!target) return;

        // 1. ����ɴ���Բ������ϵ����߷��򣨼�ǰ���������䣩
        float traveled = target.position.z; // ����z��ǰ������
        float arcAngle = traveled * arcAnglePerUnit;
        Quaternion arcRot = Quaternion.Euler(0, arcAngle, 0);

        // 2. �����������λ�ã�ʼ���ڷɴ��Һ��Ϸ���Բ������������
        Vector3 cameraOffset = arcRot * offset;
        Vector3 desiredPos = target.position + cameraOffset;

        // 3. ƽ������
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref currentVelocity, followSmooth);

        // 4. ���lookAtĿ�꣨�ɴ�ǰ��+lookOffset��Բ������������
        Vector3 lookAtTarget = target.position + arcRot * (Vector3.forward * lookAheadDistance + lookOffset);

        transform.LookAt(lookAtTarget);

        // 5. ��ѡ�������������Ҳࣨ����ʼ�տɼ����ǣ�������Ļ�ռ�̶�UI��world space anchor��
        // ����ͨ��Բ�����������Һ��Ϸ���֤���Ҳ࿪��
    }
}