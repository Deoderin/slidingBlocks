using TMPro;
using UnityEngine;

public class ScoreGUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _score;
    [SerializeField]
    private TextMeshProUGUI _level;
    [SerializeField]
    private ScoreSystem _scoreSystem;

    private void Start()
    {
        Subscribe();
        
        _level.text = LevelControllerSystem.GetLevel().ToString();
    }

    private void Subscribe() => _scoreSystem.UpdateScore += UpdateScore;

    public void UpdateScore() => _score.text = _scoreSystem.Score.ToString();

    private void OnDestroy() => Unsubscribe();

    private void Unsubscribe() => _scoreSystem.UpdateScore -= UpdateScore;
}