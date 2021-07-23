using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeleteProgressButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(DeleteProgress);
    }

    private void DeleteProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
