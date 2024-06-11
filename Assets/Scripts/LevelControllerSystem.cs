using UnityEngine;

public static class LevelControllerSystem
{
    private const string LevelKey = "Level";
    
    public static int GetLevel()
    {
        return PlayerPrefs.GetInt(LevelKey);
    }

    public static void SetCompletedLevel(int lvl)
    {
        PlayerPrefs.SetInt(LevelKey, lvl);
        PlayerPrefs.Save();
    }
}