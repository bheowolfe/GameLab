using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
	GameObject[] pauseMode;
	GameObject[] resumeMode;
	[SerializeField] Text playerNameInput;

    	// Start is called before the first frame update
    	void Start()
    	{
		pauseMode = GameObject.FindGameObjectsWithTag("Stopped");
       	resumeMode = GameObject.FindGameObjectsWithTag("Going");

        	foreach (GameObject g in pauseMode){
			Debug.Log("test Start");
            	g.SetActive(false);
		}
    	}

    // Update is called once per frame
    void Update()
    {
        
    }

    	public void PlayGame()
	{
		string s = playerNameInput.text;
        	PersistentData.Instance.SetName(s);
		Time.timeScale = 1.0f;
        	SceneManager.LoadScene("Level1");
    	}

	public void MainMenu()
	{
		SceneManager.LoadScene("StartScreen");
	}

	public void Instructions()
	{
		SceneManager.LoadScene("Instructions");
	}

	public void Settings()
	{
		SceneManager.LoadScene("Settings");
	}


	public void PauseResume(){
		if(Time.timeScale == 0.0f)
			Resume();
		else if(Time.timeScale == 1.0f)
			Pause();
	}

    	public void Pause()
    	{
        	Time.timeScale = 0.0f;
        	foreach (GameObject g in pauseMode){
            	g.SetActive(true);
			Debug.Log("test Pause");
		}
        	foreach (GameObject g in resumeMode){
            	g.SetActive(false);
		}
    	}

    	public void Resume()
    	{
        	Time.timeScale = 1.0f;
        	foreach (GameObject g in pauseMode){
            	g.SetActive(false);
			Debug.Log("test Resume");
		}
        	foreach (GameObject g in resumeMode){
            	g.SetActive(true);
		}
    	}

}
