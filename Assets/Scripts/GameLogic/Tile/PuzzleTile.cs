using UnityEngine;

public class PuzzleTile : BaseTile
{

    new private void Awake()
    {
        base.Awake();  
    }

    new private void Start()
    {
        base.Start();
        imageCompanent.color = new Color32(194, 255, 131, 255);//green
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("V mene");
    }
}
