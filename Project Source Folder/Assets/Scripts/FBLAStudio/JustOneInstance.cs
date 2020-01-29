using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JustOneInstance : MonoBehaviour {
	public string instanceID;
	private static Dictionary<string, GameObject> instance = new Dictionary<string, GameObject >();

	void Awake() {
		if (!instance.ContainsKey(instanceID) || instance[instanceID] == null) {        //not found 
			instance [instanceID] = this.gameObject;                                    //sets to current object
			GameObject.DontDestroyOnLoad(this.gameObject);                              //dont destroy on scene loads
		} else {
			Destroy (this.gameObject);                                                  //found, another instance present, destroy object
		}   
	}

	public static GameObject GetInstance(string name) {
		if (instance.ContainsKey (name)) {                              //if instance found
			return instance [name];                                     //return that instance
		}

		return null;                                                    //else return null
	}
}
