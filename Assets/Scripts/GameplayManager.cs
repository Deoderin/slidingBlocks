using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    public GameSteps Step {get; set;}

    private void Awake() => instance ??= this;
}
