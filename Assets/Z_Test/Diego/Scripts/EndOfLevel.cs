using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour {

	//fontsize variables
	float _oldWidth;
	float _oldHeight;
	float _fontSize = 14f;
	float Ratio = 20f; 
	float buttonW;
	float buttonH;

	
	//*** Button y position
	private float x = 0.5f;
	private float y = 0.73f;
	private float w = 0.09f;
	private float h = 0.14f;

	//***
	private int sw = Screen.width;
	private int sh = Screen.height;

	private string message;
	// Use this for initialization
	void Start () {
		message = PlayerPrefs.GetString ("Message");
	}
	
	// Update is called once per frame
	void Update () {
		//changing font proportions
		if (_oldWidth != Screen.width || _oldHeight != Screen.height) {
			_oldWidth = Screen.width;
			_oldHeight = Screen.height;
			_fontSize = Mathf.Min(Screen.width, Screen.height) / Ratio;
			buttonW = Screen.width/5;
			buttonH = Screen.height/8;
		}
	}

	void OnGUI(){
		//Proportion of font size
		GUI.skin.button.fontSize = (int) _fontSize;
		GUI.skin.label.fontSize = (int) _fontSize;
		GUI.skin.button.fixedWidth = buttonW;
		GUI.skin.button.fixedHeight=buttonH;


		// Paing Enginer Message ( message)
		GUI.Label (new Rect (sw/4 ,sh/4 , sw/2, sw/2), message);	
			// Do Stuffs

		//Pinta un bot'on para continuar
		if (GUI.Button (new Rect (x * sw, y * sh, buttonW, buttonH), "Continuar")) {

			//Si el jugador selecciono la respuesta correcta (==1) pasa a selecionar un jugador
			if( PlayerPrefs.GetInt("correcto") == 1 ){

				int Level = PlayerPrefs.GetInt("Level")+1;
				if( Level <=1){
					PlayerPrefs.SetInt("Level",Level);
					Application.LoadLevel("CharacterSelect");
				}
				else{// Load Final Level
					// temporal Reset Level
						PlayerPrefs.SetInt("Level",0);
						Application.LoadLevel("CharacterSelect");
					//

				}




			}
			// Si la respuesta es incorecta, se devuelve corriendo
			else{
				PlayerPrefs.SetInt("Returning", 1); // Indica que al finalizar el nivel, se pasa a seleccionar personaje
				Application.LoadLevel("GamePlay");
			}
		}
	}



}
