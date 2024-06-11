using DG.Tweening;
using TMPro;
using UnityEngine;

public class MultiplierGUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _multiplierInfo;
    [SerializeField]
    private Transform _panel;
    [SerializeField]
    private Transform _hidePosition;
    [SerializeField]
    private Transform _showposition;
    [SerializeField]
    private ScoreSystem _scoreSystem;

    private void Start()
    {
        Subscribe();
        UpdateMultiplier();
    }

    private void Subscribe() => _scoreSystem.UpdateMultiplier += UpdateMultiplier;

    private void UpdateMultiplier()
    {
        var currentMultiplier = _scoreSystem.Multiplier;
        
        switch(currentMultiplier)
        {
            case 1:
                _panel.DOMoveX(_hidePosition.position.x, 0.5f);
                break;
            case 2:
                _panel.DOMoveX(_showposition.position.x, 0.5f);
                break;
        }

        _multiplierInfo.text = "X " + currentMultiplier;
    }

    private void OnDestroy() => Unsubscribe();

    private void Unsubscribe() => _scoreSystem.UpdateMultiplier -= UpdateMultiplier;
}
