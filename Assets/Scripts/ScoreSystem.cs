using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private static ScoreSystem _instance;
    
    private int _multiplier = 1;
    private int _score;

    public event Action UpdateScore;    
    public event Action UpdateMultiplier;

    public int Multiplier
    {
        get => _multiplier;
        set
        {
            _multiplier = value;
            UpdateMultiplier?.Invoke();
        }
    }

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            UpdateScore?.Invoke();
        }
    }
    
    public static void AddScore(int score) => _instance.Score += (score * _instance.Multiplier);
    public static void AddMultiplier() => _instance.Multiplier += 1;
    public static void ClearMultiplier() => _instance.Multiplier = 1;
    
    private void Awake() => _instance = this;
}