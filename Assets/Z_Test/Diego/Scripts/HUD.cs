using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	//*** Buttons x position
	public  float x1 = 0.02f;
	public  float x2 = 0.45f;
	public  float x3 = 0.8f;

	
	//*** Button y position
	private float y = 0.05f;
	private float wLabel = 0.5f;
	private float h = 0.14f;
	
	//***
	private int sw = Screen.width;
	private int sh = Screen.height;

	private string 	ingeniero;
	private int		level;
	private int		plataformas;
	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("ingeniero"))
						ingeniero = PlayerPrefs.GetString ("ingeniero");
				else
						ingeniero = "No seleccionado";
		level = PlayerPrefs.GetInt ("Level")+1;
	}
	
	// Update is called once per frame
	void Update () {
		plataformas = gameObject.GetComponent<Scenaries>().scenariesLeft() + 1;
	}

	void OnGUI(){
		GUI.Label (new Rect (x1 * sw, y * sh, wLabel * sw, h * sh), "Level "+level);
		GUI.Label (new Rect (x2 * sw, y * sh, wLabel * sw, h * sh), ingeniero);
		GUI.Label (new Rect (x3 * sw, y * sh, wLabel * sw, h * sh), "Plataformas: "+plataformas);


	}

}
