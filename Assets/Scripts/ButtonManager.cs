using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void sceneChangeButton(string newScene) {
        SceneManager.LoadScene(newScene);
    }

    public void exitGame() {
        Application.Quit();
    }
}
