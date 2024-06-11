using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelSystem : MonoBehaviour
{
    public static LoadLevelSystem instance;
    private void Awake()
    {
        instance ??= this;
    }

    public void LoadLevel(LevelScene level)
    {
        switch(level)
        {
            case LevelScene.Game:
                SceneManager.LoadScene(level.ToString());
                break;
            case LevelScene.Menu:
                break;
        }
    }
}

public enum LevelScene
{
    Game,
    Menu
}