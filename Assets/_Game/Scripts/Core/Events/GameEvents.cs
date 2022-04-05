using UnityEngine;
using System;

class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    void Awake() => current = this;

    public event Action onGameStart;
    public event Action onGameEnd;
    public event Action onUpdateTask;

    public void GameStart() => onGameStart?.Invoke();
    public void GameEnd() => onGameEnd?.Invoke();
    public void UpdateTask() => onUpdateTask?.Invoke();
}