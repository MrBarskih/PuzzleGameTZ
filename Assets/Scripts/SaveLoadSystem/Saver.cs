using UnityEngine;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{
    [SerializeField] private PuzzleAreaObserver puzzleAreaObserver;

    private void Awake()
    {
        puzzleAreaObserver.LevelIsComplited += SaveProgress;
    }
   
    private void OnDestroy()
    {
        puzzleAreaObserver.LevelIsComplited -= SaveProgress;
    }

    private void SaveProgress()
    {
        string levelName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt(levelName, 1);
    }

}
