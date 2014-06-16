using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	//*** Buttons x position
	private float x1 = 0.45f;

	
	//*** Button y position
	private float y = 0.05f;
	private float wLabel = 0.5f;
	private float h = 0.14f;
	
	//***
	private int sw = Screen.width;
	private int sh = Screen.height;

	private string ingeniero;
	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("ingeniero"))
						ingeniero = PlayerPrefs.GetString ("ingeniero");
				else
						ingeniero = "No seleccionado";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label (new Rect (x1 * sw, y * sh, wLabel * sw, h * sh), ingeniero);


	}

}
