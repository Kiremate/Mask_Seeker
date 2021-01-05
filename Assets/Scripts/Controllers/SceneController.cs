using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    public enum EEScenes : int { MAIN_TITLE, COMBAT_SCENE, SELECT_MASK_SCENE };

    [SerializeField]
    private EEScenes currentScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Load Certain Scene and makes some changes be4 that, saves info required etc...
    public void LoadScene(int eScene)
    {
        // TODO 
        SaveData();


        SceneManager.LoadScene(eScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    private void SaveData()
    {

    }

}
