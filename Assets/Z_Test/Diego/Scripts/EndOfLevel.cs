using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour {

	//*** Buttons x position



	
	//*** Button y position
	private float x = 0.5f;
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

		//Pinta un bot'on para continuar
		if (GUI.Button (new Rect (x * sw, y * sh, w * sw, h * sh), "Continuar")) {

			//Si el jugador selecciono la respuesta correcta (==1) pasa a selecionar un jugador
			if( PlayerPrefs.GetInt("correcto") == 1 ){
				Application.LoadLevel("CharacterSelect");
			}
			// Si la respuesta es incorecta, se devuelve corriendo
			else{
				PlayerPrefs.SetInt("Returning", 1); // Indica que al finalizar el nivel, se pasa a seleccionar personaje
				Application.LoadLevel("GamePlay");
			}
		}
	}



}
