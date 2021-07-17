using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private Button backButtonCompanent;

    private void Start()
    {
        backButtonCompanent.onClick.AddListener(() => SceneManager.LoadScene($"{AllScenes.Start}"));
    }
}
