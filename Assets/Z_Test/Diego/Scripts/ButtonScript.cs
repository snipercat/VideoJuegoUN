using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	//*** fontsize variables
	float _oldWidth;
	float _oldHeight;
	float _fontSize = 14f;
	float Ratio = 20f; 
	float buttonW;
	float buttonH;



	void Update () {
		//changing font proportions
		if (_oldWidth != Screen.width || _oldHeight != Screen.height) {
			_oldWidth = Screen.width;
			_oldHeight = Screen.height;
			_fontSize = Mathf.Min(Screen.width, Screen.height) / Ratio;

		}
		
	}

	void OnGUI () {
		buttonW = Screen.width/5;
		buttonH = Screen.height/5;

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(0.1f*Screen.width,0.8f*Screen.height,buttonW,buttonH), "Saltar")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(0.6f*Screen.width,0.8f*Screen.height,buttonW,buttonH), "Atacar")) {
			Application.LoadLevel(2);
		}
	}

}
