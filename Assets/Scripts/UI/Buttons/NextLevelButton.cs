using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(() => {
            SceneManager.LoadScene(AllScenes.SecondLevel.ToString());
        });
    }
}
