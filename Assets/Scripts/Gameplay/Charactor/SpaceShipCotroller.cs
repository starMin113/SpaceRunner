using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public ArcTrackManager trackMgr;
    public int currentTrackIdx = 1;    // 默认第2条轨道
    public float moveSpeed = 15f;      // 前进速度（度/秒）
    public float currentDegree = 0f;   // 当前在圆弧上的角度

    void Update()
    {
        // 轨道切换输入
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            TryChangeTrack(-1);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            TryChangeTrack(1);

        // 前进
        currentDegree += moveSpeed * Time.deltaTime;
        // 限制弧度范围
        currentDegree = Mathf.Min(currentDegree, trackMgr.arcEndDegree);

        // 更新飞船世界坐标
        transform.position = trackMgr.GetPosOnTrack(currentTrackIdx, currentDegree);

        // 使飞船始终面向运动方向
        Vector3 forwardOnTrack = trackMgr.GetPosOnTrack(currentTrackIdx, currentDegree + 2f) - transform.position;
        transform.forward = forwardOnTrack.normalized;
    }

    void TryChangeTrack(int dir)
    {
        int targetIdx = Mathf.Clamp(currentTrackIdx + dir, 0, trackMgr.trackCenters.Length - 1);
        if (targetIdx != currentTrackIdx)
        {
            currentTrackIdx = targetIdx;
            // 可加切换特效、音效
        }
    }
}