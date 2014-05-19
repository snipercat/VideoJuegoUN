using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	void OnGUI () {
		// Make a background box

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,400,80,80), "Saltar")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(500,400,80,80), "Atacar")) {
			Application.LoadLevel(2);
		}
	}

}
