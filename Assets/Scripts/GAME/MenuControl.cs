using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl:MonoBehaviour {
			
	public void onClickPauseButton() {
		Debug.Log ("Practice button clicked");
		SceneManager.LoadScene("MainWorld");
	}

}
