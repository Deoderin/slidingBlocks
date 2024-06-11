using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig/ShapePunchConfig", fileName = "ShapePunchConfig", order = 0)]
internal class ShapePunchConfig : ScriptableObject
{
    [field: SerializeField]
    public float TimePunchAnimation {get; private set;}

    [field: SerializeField]
    public float PunchForce {get;private set;}
    [field: SerializeField]
    public Ease EaseForDestroyPunchingWall {get;private set;}
}