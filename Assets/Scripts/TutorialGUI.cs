using UnityEngine;
using UnityEngine.UI;

public class TutorialGUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _tutorialPanel;
    [SerializeField]
    private Button _button;
    private void Awake()
    {
        _tutorialPanel.SetActive(false);
        
        if(LevelControllerSystem.GetLevel() == 0)
        {
            _tutorialPanel.SetActive(true);
            Time.timeScale = 0;
            _button.onClick.AddListener(PlayGame);
        }
    }

    private void PlayGame()
    {
        _tutorialPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
