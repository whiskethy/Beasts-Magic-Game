using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager:MonoBehaviour {

    Text PlayerNameText;
    string PlayerName;

	public void OnClickPracticeButton() {
		Debug.Log ("Practice button clicked");
		SceneManager.LoadScene(GameConstants.LEVELS.MainWorldPractice.ToString());
	}

	public void OnClickNetworkButton() {
		Debug.Log ("Networked Clicked");
		SceneManager.LoadScene(GameConstants.LEVELS.LobbyScene.ToString());
	}

	public void OnClickCharacterButton() {
        Debug.Log ("CharacterClicked");
        SceneManager.LoadScene(GameConstants.LEVELS.CharacterScene.ToString());
	}

	public void OnClickQuitButton() {
		Debug.Log ("Quit selected");
		Application.Quit();
	}

	public void LoadScene(string scene) {
		SceneManager.LoadScene (scene);
	}
    void Start()
    {
        //PlayerNameText = GameObject.Find("MenuPlayerText").GetComponent<Text>();
        //PlayerName=PlayerPrefs.GetString("SelectedPlayer");
        //if(PlayerName!="")
        //    PlayerNameText.text = "You selected game player is "+PlayerName+" now.";

        PlayerPrefs.DeleteKey("Player1");
        PlayerPrefs.DeleteKey("Player2");
    }

    private void OnGUI()
    {

 

    }
}
