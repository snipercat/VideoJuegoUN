using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

//*** Nombres de Ingenieros 
	private string Problema;
	private string[] ingenieros  = new string[3];
	public int correcto; // Respuesta correcta.
	private string[] Mensajes = new string[3];




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
	
	private int Level;

	// Use this for initialization
	void Start () {
		if( PlayerPrefs.HasKey ("Level")){
			Level = PlayerPrefs.GetInt("Level");
		}
		else{
			Level = 0;
			PlayerPrefs.SetInt("Level",0);
		}
	
	//***	Asignar las variables del nivel.
		Problema = Parameters.getProblem (Level);

		ingenieros[0] = Parameters.getEngineer (Level,0);
		ingenieros[1] = Parameters.getEngineer (Level,1);
		ingenieros[2] = Parameters.getEngineer (Level,2);

		correcto = Parameters.getCorrectAnswer (Level);

		Mensajes[0] = Parameters.getEngineersMessage (Level,0);
		Mensajes[1] = Parameters.getEngineersMessage (Level,1);
		Mensajes[2] = Parameters.getEngineersMessage (Level,2);

		//*** Asign Sprites
			//Do Stuffs.
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		//***paint problem (Problema)

			// do stuffs

		// ** Pain Engineeers Name ( ingenieros [])
			
			// do stuffs

		//*** Paint Buttons
		if (GUI.Button (new Rect (x1 * sw, y * sh, w * sw, h * sh), "1")) {
						PlayerPrefs.SetString ("ingeniero", ingenieros[0]); //Asigna el nombre del ingeniero para mostrarlo en pantalla
						PlayerPrefs.SetInt ("correcto", correcto == 0 ? 1: 0); //Evalua si la respuesta es correcta
						PlayerPrefs.SetInt("Returning", 0);	// No se esta regresando, al terminar pasa a EndOfLevel 
						PlayerPrefs.SetString("Message",Mensajes[0] ); // asigna el mensaje que le dira el ingeniero al terminar el nivel
						Application.LoadLevel("GamePlay");
				}

		if (GUI.Button (new Rect (x2 * sw, y * sh, w * sw, h * sh), "2")) {
						PlayerPrefs.SetString ("ingeniero", ingenieros[1]);
						PlayerPrefs.SetInt ("correcto", correcto == 1 ? 1: 0);
						PlayerPrefs.SetInt("Returning", 0);
						PlayerPrefs.SetString("Message",Mensajes[0] );
						Application.LoadLevel("GamePlay");
				}

		if (GUI.Button (new Rect (x3 * sw, y * sh, w * sw, h * sh), "3")) {
						PlayerPrefs.SetString ("ingeniero", ingenieros[2]);
						PlayerPrefs.SetInt ("correcto", correcto == 2 ? 1: 0);
						PlayerPrefs.SetInt("Returning", 0);
						PlayerPrefs.SetString("Message",Mensajes[0] );
						Application.LoadLevel("GamePlay");
				}






	}
}
