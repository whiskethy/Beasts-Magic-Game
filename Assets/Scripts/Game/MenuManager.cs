using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager:MonoBehaviour {
			
	public void OnClickPracticeButton() {
		Debug.Log ("Practice button clicked");
		SceneManager.LoadScene(GameConstants.LEVELS.MainWorldPractice.ToString());
	}

	public void OnClickNetworkButton() {
		Debug.Log ("Networked Clicked");
		SceneManager.LoadScene(GameConstants.LEVELS.NetworkLobby.ToString());
	}

	public void OnClickCharacterButton() {
		Debug.Log ("CharacterClicked");
	}

	public void OnClickQuitButton() {
		Debug.Log ("Quit selected");
		Application.Quit();
	}

	public void LoadScene(string scene) {
		SceneManager.LoadScene (scene);
	}
}
