using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour
{
    public RectTransform rt;
    public bool start;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        SelectStart();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the horizontal axis
        float x = Input.GetAxisRaw("Horizontal");

        // If it was an input to the left
        if (x<0)
        {
            SelectStart();
        }
        // If it was an input to the right
        if (x>0)
        {
            SelectQuit();
        }
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (start)
            {
                StartGame();
            }
            else
            {
                QuitGame();
            }
        }
    }

    void SelectStart()
    {
        rt.anchoredPosition = new Vector3(-346, -160, 0);
        start = true;
    }

    void SelectQuit()
    {
        rt.anchoredPosition = new Vector3(221.6f, -160, 0);
        start = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
