using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] float loadSceneDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", loadSceneDelay);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
