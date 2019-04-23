using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
	public void GoToForest()
	{
		this.StartCoroutine(this.LoadSceneCoroutine("Forest"));
	}

	public void GoToDesert()
	{
		this.StartCoroutine(this.LoadSceneCoroutine("Desert"));
	}

	private IEnumerator LoadSceneCoroutine(string name)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

		while(!asyncLoad.isDone) {
			yield return null;
		}
	}

	public void Quit()
	{
		Application.Quit();
	}
}
