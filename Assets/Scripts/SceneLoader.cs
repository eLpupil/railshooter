using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadFirstScene();
        }
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }


}
