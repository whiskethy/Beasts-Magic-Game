using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public static MenuManager menuManager;

	void Awake() {
		if (instance == null) {
			instance = this;
			menuManager= GetComponent<MenuManager>();
			InitGame();
		} else if (instance != this) {
			Destroy (gameObject);
		}

	}

	void InitGame() {
		menuManager.LoadScene (GameConstants.LEVELS.StartMenu.ToString ());		
	}
	
}
