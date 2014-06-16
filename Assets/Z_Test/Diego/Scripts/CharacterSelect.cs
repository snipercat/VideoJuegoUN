using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

//*** Nombres de Ingenieros 
	public string ingeniero1;
	public string ingeniero2;
	public string ingeniero3;

	public int correcto; // Respuesta correcta.

//*** Buttons x position
	private float x1 = 0.33f;
	private float x2 = 0.5f;
	private float x3 = 0.67f;

//*** Button common position Data
	private float y = 0.73f;
	private float w = 0.09f;
	private float h = 0.14f;

//***
	private int sw = Screen.width;
	private int sh = Screen.height;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		//*** Paint Buttons
		if (GUI.Button (new Rect (x1 * sw, y * sh, w * sw, h * sh), "1")) {
						PlayerPrefs.SetString ("ingeniero", ingeniero1); //Asigna el nombre del ingeniero para mostrarlo en pantalla
						PlayerPrefs.SetInt ("correcto", correcto == 1 ? 1: 0); //Evalua si la respuesta es correcta
						PlayerPrefs.SetInt("Returning", 0);	// No se esta regresando, al terminar pasa a EndOfLevel 
						Application.LoadLevel("GamePlay");
				}

		if (GUI.Button (new Rect (x2 * sw, y * sh, w * sw, h * sh), "2")) {
						PlayerPrefs.SetString ("ingeniero", ingeniero2);
						PlayerPrefs.SetInt ("correcto", correcto == 2 ? 1: 0);
						PlayerPrefs.SetInt("Returning", 0);
						Application.LoadLevel("GamePlay");
				}

		if (GUI.Button (new Rect (x3 * sw, y * sh, w * sw, h * sh), "3")) {
						PlayerPrefs.SetString ("ingeniero", ingeniero3);
						PlayerPrefs.SetInt ("correcto", correcto == 3 ? 1: 0);
						PlayerPrefs.SetInt("Returning", 0);
						Application.LoadLevel("GamePlay");
				}






	}
}
