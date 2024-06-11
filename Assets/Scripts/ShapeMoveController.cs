using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ShapeMoveController : MonoBehaviour
{
    public event Action FinishLevel;
    private const int _speedScore = 10;
    
    [SerializeField]
    private ShapeConfig _shapeConfig;
    [SerializeField]
    private Transform _rootShape;
    [SerializeField]
    private ShapeFinisher _shapeFinisher;
    
    private Vector3 _rotationPosition;
    private GameSteps _step;
    private InputManager _inputManager;
    private TweenerCore<float, float, FloatOptions> _adjustSpeed;
    private float _speed;
    private bool _isFinish;
    
    private void Start()
    {
        Construct();
        SetBaseSpeed();
        Subscribing();
        StartCoroutine(ScoringPointsForSpeed());
        
        _rotationPosition = _rootShape.rotation.eulerAngles;
    }

    private void Construct() => _inputManager = InputManager.instance;

    private void Subscribing()
    {
        _inputManager.SwipeInput += RotateShape;
        _inputManager.PressInput += SpeedUp;
        _inputManager.UnPressInput += SetBaseSpeed;
    }
    
    private void FixedUpdate() => MoveShape();

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish") && _isFinish is false)
        {
            _isFinish = true;
            _step = GameSteps.Finish;
            StopSpeed(0);
            StartCoroutine(_shapeFinisher.Finish());
            FinishLevel?.Invoke();
        }
        
        if(other.CompareTag("Start"))
        {
            _step = GameSteps.Gameplay;
        }

        if(other.CompareTag("Wall"))
        {
            _adjustSpeed.Complete();
            _adjustSpeed.Kill();
            _speed = _shapeConfig.WallCollisionSpeedShape;
            ScoreSystem.ClearMultiplier();
            AdjustSpeed(_shapeConfig.BaseSpeedShape);
        }
    }
    
    private void SpeedUp() => AdjustSpeed(_shapeConfig.UpSpeedShape);
    private void SetBaseSpeed() => AdjustSpeed(_shapeConfig.BaseSpeedShape);
    private void MoveShape() => transform.Translate(Vector3.forward * (_speed * Time.deltaTime), Space.World);

    private IEnumerator ScoringPointsForSpeed()
    {
        float timeUntilUpdate = 0.2f;
        
        while(_step is GameSteps.Gameplay or GameSteps.Start)
        {
            yield return new WaitForSeconds(timeUntilUpdate);
            
            if(_speed > _shapeConfig.BaseSpeedShape)
            {
                ScoreSystem.AddScore(_speedScore);
            } 
        }
    }
    
    private void AdjustSpeed(float targetSpeed)
    {
        if (_step is GameSteps.Gameplay or GameSteps.Start)
        {
            _adjustSpeed = DOTween.To(() => _speed, x => _speed = x, targetSpeed, _shapeConfig.AccelerationTime)
                                  .SetEase(_shapeConfig.AccelerationAnimationType);
        }
    }

    private void StopSpeed(float targetSpeed) =>
        _adjustSpeed = DOTween.To(() => _speed, x => _speed = x, targetSpeed, _shapeConfig.FinishStopTime)
                              .SetEase(_shapeConfig.AccelerationAnimationType);

    private void RotateShape(RotationDirection direction)
    {
        switch(direction)
        {
            case RotationDirection.Right:
                _rotationPosition = new Vector3(_rotationPosition.x, _rotationPosition.y + _shapeConfig.AngleRotation, _rotationPosition.z);
                _rootShape.DORotate(_rotationPosition, _shapeConfig.TurningTime).SetEase(_shapeConfig.RotationAnimationType);
                break;
            case RotationDirection.Left:
                _rotationPosition = new Vector3(_rotationPosition.x, _rotationPosition.y - _shapeConfig.AngleRotation, _rotationPosition.z);
                _rootShape.DORotate(_rotationPosition, _shapeConfig.TurningTime).SetEase(_shapeConfig.RotationAnimationType);
                break;
        }
    }

    private void OnDestroy() => Unsubscribing();

    private void Unsubscribing()
    {
        _inputManager.SwipeInput -= RotateShape;
        _inputManager.PressInput -= SpeedUp;
        _inputManager.UnPressInput -= SetBaseSpeed;
    }
}

public enum GameSteps
{
    Start,
    Gameplay,
    Finish,
}