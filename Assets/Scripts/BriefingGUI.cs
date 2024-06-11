using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BriefingGUI : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private Button _nexLevelButton;
    [SerializeField]
    private Transform _panel;
    [SerializeField]
    private Transform _showPoint;

    public void ShowPanel()
    {
        _panel.gameObject.SetActive(true);
        _panel.DOMoveX(_showPoint.position.x, 1);
    }
    
    private void Awake()
    {
        _nexLevelButton.onClick.AddListener(_gameManager.NextLevelLoad);
    }
}
