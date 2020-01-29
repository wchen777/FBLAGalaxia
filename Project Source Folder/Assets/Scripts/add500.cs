using UnityEngine;
using System.Collections;

public class add500 : MonoBehaviour {

    // Use this for initialization
    public int amountperquestion = 500;
	void Start () {
        ScoreTracker.GetInstance().ScorePoints(amountperquestion);             //adds some amount to score when question is right             
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
