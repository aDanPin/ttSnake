using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    void Start()
    {
        GameEventsSystem.current.onSceneReloadTrigger += ReloadScene;
    }

    private void ReloadScene() {
        SceneManager.LoadScene("SampleScene");
    }
}
