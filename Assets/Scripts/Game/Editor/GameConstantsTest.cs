using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameConstantsTest {
	
	private static GameConstants.LEVELS[] levels = (GameConstants.LEVELS[])Enum.GetValues (typeof(GameConstants.LEVELS));
	private static Dictionary<string, string> levelMap = GetListToMap (levels);

	[Test]
	public void TestScenesAreInLevelsEnum() {
		
		string level = "NetworkLobby";
		string level1 = "MainWorld";
		string level2 = "MainWorldPractice";

		Assert.AreEqual (level, GameConstants.LEVELS.NetworkLobby.ToString ());
		Assert.AreEqual(level1, GameConstants.LEVELS.MainWorld.ToString());
		Assert.AreEqual (level2, GameConstants.LEVELS.MainWorldPractice.ToString ());
	}

	[Test]
	public void testUtility(){
		Assert.True (Utility.Equals (1.0f, 1.0f));
		Assert.False(Utility.Equals(1.0f, 2.0f));
	}

	[UnityTest]
	public IEnumerator TestAllLevelsAreInBuildSettings() {
		EditorBuildSettingsScene[] scenesInSettings = EditorBuildSettings.scenes;
		Dictionary<string, string> sceneMap = GetListToMap (scenesInSettings);
		foreach(GameConstants.LEVELS level in levels) {
			if(!sceneMap.ContainsKey(level.ToString())){
				Debug.Log("Level not in build settings:" + level.ToString());
				List<string> sceneValues = new List<string>(sceneMap.Keys);
				Debug.Log ("Scenes:");
				foreach(string s in sceneValues){
					Debug.Log (s);
				}
			}
			Assert.True(sceneMap.ContainsKey(level.ToString()));
		}
		yield return null;
	}

	[UnityTest]
	public IEnumerator TestAllScenesAreInLevels(){
		EditorBuildSettingsScene[] scenesInSettings = EditorBuildSettings.scenes;

		foreach (EditorBuildSettingsScene scene in scenesInSettings) {
			string sceneString = scene.path.ToString ().Replace ("Assets/Scenes/", "").Replace (".unity", "").ToString ();
			if (!levelMap.ContainsKey (sceneString)) {
				Debug.Log ("Scene: " + sceneString + ", not in levels");
			 
			}
			Assert.True(levelMap.ContainsKey(sceneString));
		}
		yield return null;
	}

	private static List<T> GetEnumList<T>()
	{
		T[] array = (T[])System.Enum.GetValues(typeof(T));
		List<T> list = new List<T>(array);
		return list;
	}

	private static Dictionary<string, string> GetListToMap(GameConstants.LEVELS[] list)
	{
		Dictionary<string, string> r = new Dictionary<string, string>();
		foreach(GameConstants.LEVELS l in list) {
			if(!r.ContainsKey(l.ToString())) {
				r.Add (l.ToString(), l.ToString());
			}
		}
		return r;
	}

	private static Dictionary<string, string> GetListToMap(EditorBuildSettingsScene[] list)
	{
		Dictionary<string, string> r1 = new Dictionary<string, string>();
		foreach(EditorBuildSettingsScene l in list) {
				r1.Add (l.path.ToString().Replace("Assets/Scenes/","").Replace(".unity","").ToString(), 
					l.path.ToString().Replace("Assets/Scenes/","").Replace(".unity","").ToString());
		}
		return r1;
	}
}
