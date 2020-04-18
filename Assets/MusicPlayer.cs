using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] float loadSceneDelay = 5f;

    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", loadSceneDelay);
    }


    // Update is called once per frame
    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
    
    
}
