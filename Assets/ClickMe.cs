using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickMe : MonoBehaviour
{
	public Button yourButton;
	[SerializeField] string sceneName;
	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		SceneManager.LoadScene(sceneName);
	}
}
