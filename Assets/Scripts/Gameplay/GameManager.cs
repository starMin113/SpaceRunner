
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState { MainMenu, Playing, Paused, GameOver, Narrative }
    public GameState CurrentState { get; private set; }

    void Awake() { Instance = this; }
    void Start() { CurrentState = GameState.MainMenu; }
    public void StartGame() { /* ��ʼ���ؿ�����������ɫ */ }
    public void PauseGame() { /* ... */ }
    public void GameOver() { /* ... */ }
}
