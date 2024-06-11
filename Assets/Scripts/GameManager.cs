using System;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private LevelsConfig _levelsConfig;
    [SerializeField]
    private CinemachineVirtualCamera _camera;
    [SerializeField]
    private BriefingGUI _briefingGUI;
    //[SerializeField]
    
    private ShapeMoveController _shape;

    private void Awake()
    {
        StartGame();
        Subscribe();
        
    }

    private void OpenBriefingUi()
    {
        _briefingGUI.ShowPanel();
    }

    private void StartGame()
    {
        var indexLevel = LevelControllerSystem.GetLevel();
        var level = Instantiate(indexLevel < _levelsConfig.Levels.Count ? _levelsConfig.Levels[indexLevel] : _levelsConfig.Levels[Random.Range(1, _levelsConfig.Levels.Count - 1)]);
        
        _shape = level.ShapeTransform;
        SetTargetForCamera(_shape.transform);
    }

    private void Subscribe() => _shape.FinishLevel += Finish;

    private void Finish() => OpenBriefingUi();

    private void SetTargetForCamera(Transform levelShapeTransform)
    {
        _camera.Follow = levelShapeTransform;
        _camera.LookAt = levelShapeTransform;
    }

    public void NextLevelLoad()
    {
        LevelControllerSystem.SetCompletedLevel(LevelControllerSystem.GetLevel() + 1);
        LoadLevelSystem.instance.LoadLevel(LevelScene.Game);
    }

    private void OnDestroy() => Unsubscribe();

    private void Unsubscribe() => _shape.FinishLevel -= Finish;
}