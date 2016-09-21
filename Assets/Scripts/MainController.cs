using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {
    public bool testing = true;
    int[] sceneScore;
    int _currentSceneIndex = -1;

    // Use this for initialization
    void OnEnable () {
#if UNITY_EDITOR
        if (!testing || GameObject.FindObjectsOfType<MainController>().Length > 1) Destroy(gameObject);
#else
        if(SceneManager.GetActiveScene().name != "Preload") Destroy(gameObject);
#endif
        DontDestroyOnLoad(gameObject);
    }

    void LaunchScene(int index) {
        _currentSceneIndex = index;
        SceneManager.LoadScene("Minigame" + index);
    }
    void SaveScore(int score) {  }
    void Load() { }
    void Save() { }
    void EraseMemory() { }
    void ExitGame() { }
    void ShowInstructions() { }
    void Pause(bool pause) { }

    // Update is called once per frame
    void Update () {
	
	}
}
