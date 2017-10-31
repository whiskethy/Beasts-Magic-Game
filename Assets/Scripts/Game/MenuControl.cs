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
	}

	public void OnClickCharacterButton() {
		Debug.Log ("CharacterClicked");
	}

}
