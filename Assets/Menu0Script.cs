using UnityEngine;
using System.Collections;

public class Menu0Script : MonoBehaviour {

	private int relativeX = 709;
	private int relativeY = 399;

	public int x = 95;
	private int y = 235;
	private int width =200;
	private int height =100;
	private int distanceH = 10;



	// Use this for initialization
	void Start () {

		x = NW (x);
		y = NH (y);
		width = NW (width);
		height = NH (height);
		distanceH = NW (distanceH);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		Rect startRect = new Rect (x , y, width, height);
		Rect exitRect = new Rect (x + width + distanceH , y, width, height);

		if (GUI.Button (startRect, "Comenzar"))
						Application.LoadLevel ("walk_test");
		if (GUI.Button (exitRect, "Salir"))
						Application.Quit ();



	}

	int NW( int nx ){
		Debug.Log ((nx + 0f)/relativeX);
		return  Mathf.FloorToInt ((nx + 0f) / relativeX * Screen.width);

	}

	int NH( int ny ){
		return Mathf.FloorToInt ((ny + 0f) /relativeY * Screen.height);
	}
}
