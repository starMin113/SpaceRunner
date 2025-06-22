using System.Collections.Generic;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    public FractalGalaxyMap GalaxyMap;          // 星系结构数据
    public GameObject TrackPrefab;
    public List<Track> Tracks;                  // 圆弧形轨道对象
    public void GenerateLevel(int starSystemID)
    {
        // 1. 读取当前星系的地图分形结构
        // 2. 动态实例化轨道与障碍/补给点
        // 3. 初始化TrackSystem
    }
}