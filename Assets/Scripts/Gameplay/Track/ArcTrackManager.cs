using UnityEngine;

public class ArcTrackManager : MonoBehaviour
{
    public Transform[] trackCenters; // 各条轨道的圆心
    public float[] trackRadii;       // 各轨道半径
    public float arcStartDegree = 0; // 起始弧度
    public float arcEndDegree = 180; // 结束弧度
    public int segmentCount = 100;   // 弧段分辨率
    public GameObject trackPrefab;   // Lowpoly圆弧轨道片段预制件

    void Start()
    {
        for (int i = 0; i < trackCenters.Length; i++)
            GenerateArc(trackCenters[i], trackRadii[i]);
    }

    void GenerateArc(Transform center, float radius)
    {
        float angleStep = (arcEndDegree - arcStartDegree) / segmentCount;
        Vector3 prevPos = Vector3.zero;
        for (int seg = 0; seg <= segmentCount; seg++)
        {
            float angle = Mathf.Deg2Rad * (arcStartDegree + seg * angleStep);
            Vector3 pos = center.position + new Vector3(
                Mathf.Cos(angle) * radius,
                0,
                Mathf.Sin(angle) * radius
            );
            if (seg > 0)
            {
                // 实例化轨道片段，连接prevPos和pos
                var trackSeg = Instantiate(trackPrefab);
                trackSeg.transform.position = (pos + prevPos) / 2f;
                trackSeg.transform.LookAt(pos);
                trackSeg.transform.localScale = new Vector3(1, 1, Vector3.Distance(pos, prevPos));
                trackSeg.transform.SetParent(center);
            }
            prevPos = pos;
        }
    }

    // 获取指定轨道上某弧度的世界坐标
    public Vector3 GetPosOnTrack(int trackIdx, float degree)
    {
        float rad = Mathf.Deg2Rad * degree;
        return trackCenters[trackIdx].position + new Vector3(
            Mathf.Cos(rad) * trackRadii[trackIdx],
            0,
            Mathf.Sin(rad) * trackRadii[trackIdx]
        );
    }
}