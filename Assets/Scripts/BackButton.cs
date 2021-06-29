using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    void Start()
    {
        backButton.onClick.AddListener(() => SceneManager.LoadScene($"{AllScenes.StartScene}"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
