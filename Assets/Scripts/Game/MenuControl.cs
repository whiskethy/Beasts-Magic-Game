using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl:MonoBehaviour {
			
	public void OnClickPracticeButton() {
		Debug.Log ("Practice button clicked");
		SceneManager.LoadScene(GameConstants.LEVELS.MainWorld.ToString());
	}

	public void OnClickNetworkButton() {
		Debug.Log ("Networked Clicked");
		SceneManager.LoadScene(GameConstants.LEVELS.NetworkLobby.ToString());
	}

	public void OnClickCharacterButton() {
		SceneManager.LoadScene (GameConstants.LEVELS.CharacterLobby.ToString ());
		Debug.Log ("CharacterClicked");
	}

	public void OnClickQuitButton() {
		Debug.Log ("Quit selected");
	}

}
