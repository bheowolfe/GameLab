using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statusTracker : MonoBehaviour
{
	[SerializeField] int score = 0;
	[SerializeField] Text scoreTxt;
	const int DEFAULT_POINTS = 1;
	[SerializeField] int maxBugs = 6;
	[SerializeField] int levelScore = 0;
	[SerializeField] int level;

    // Start is called before the first frame update
    void Start()
	{
		score = PersistentData.Instance.GetScore();
		level = SceneManager.GetActiveScene().buildIndex;
		DisplayScore();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void DisplayScore()
    	{
        	scoreTxt.text = PersistentData.Instance.GetName() + "'s" + "Score: " + score;
    	}

	public void AddPoints(int points)
	{
		score += points;
		levelScore += points;
		Debug.Log("score " + score);
		PersistentData.Instance.SetScore(score);
		DisplayScore();
		maxBugs--;
		if(maxBugs<=0)
			AdvanceLevel();
	}

	public void AddPoints()
    	{
        	AddPoints(DEFAULT_POINTS);
    	}

	public void AdvanceLevel()
    	{
		if(level < 5){
        		SceneManager.LoadScene(level + 1);
		}
		else{
			SceneManager.LoadScene(0);
		}
    	}

	public void Restart(){
		PersistentData.Instance.SetScore(score - levelScore);
		SceneManager.LoadScene(level);
	}

}
