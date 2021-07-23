using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    private void LoadNextLevel() 
    {
        var AllScenes = (AllScenes[]) Enum.GetValues(typeof(AllScenes));
        foreach (var level in AllScenes) 
        {
            bool isLevelCompleted = Convert.ToBoolean(PlayerPrefs.GetInt(level.ToString()));

            if (isLevelCompleted != true) 
            {
                SceneManager.LoadScene(level.ToString());
                return;
            }
        }

        SceneManager.LoadScene(AllScenes[0].ToString());
    }
}
