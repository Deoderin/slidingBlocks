using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelSystem : MonoBehaviour
{
    public static LoadLevelSystem instance;
    private void Awake()
    {
        instance = this;
        LoadLevel(LevelScene.Game);
        
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(LevelScene level)
    {
        switch(level)
        {
            case LevelScene.Game:
                    SceneManager.LoadScene(level.ToString());
                break;
            case LevelScene.Preloader:
                break;
        }
    }
}

public enum LevelScene
{
    Game,
    Preloader
}