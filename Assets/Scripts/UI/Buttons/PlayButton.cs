using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene($"{AllScenes.FirstLevel}"));
    }

}
