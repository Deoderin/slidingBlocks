using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig/ShapeConfig", fileName = "ShapeConfig", order = 0)]
public class ShapeConfig : ScriptableObject
{
    [field: SerializeField]
    public float BaseSpeedShape {get;private set;}
    [field: SerializeField]
    public float WallCollisionSpeedShape {get;private set;}
    [field: SerializeField]
    public float UpSpeedShape {get;private set;}
    [field: SerializeField]
    public float AccelerationTime {get;private set;}
    [field: SerializeField]
    public float FinishStopTime {get;private set;}
    [field: SerializeField]    
    public float TurningTime {get;private set;}
    [field: SerializeField]
    public float AngleRotation {get;private set;}
    [field: SerializeField]
    public Ease RotationAnimationType {get;private set;}
    [field: SerializeField]
    public Ease AccelerationAnimationType {get;private set;}
}