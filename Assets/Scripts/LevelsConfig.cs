using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig/LevelsConfig", fileName = "LevelsConfig", order = 0)]
public class LevelsConfig : ScriptableObject
{
    [field:SerializeField]
    public List<Level> Levels {get;private set;}
}