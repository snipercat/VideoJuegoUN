using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class Scenaries : MonoBehaviour
{
	public int numberOfScenaries = 3;
	public Transform[] scenaries;
	private List<Transform> currentScenaries = new List<Transform>();
	public Transform initialPlataform;
	public Transform finalPlataform;


	private List<Vector3> plataformsPosition = new List<Vector3>();
	private float camheight = 1.63f;
	private float camX = 3.28f;

	/*cax = -6.49348
		platx = -5.953453 - 
*/
	void Start(){
		numberOfScenaries = Parameters.getPlataformsForLevel (PlayerPrefs.GetInt ("Level"));
		// get a random Plataform from the List
		int a;
		a = Random.Range(0, scenaries.Length);

		//Position the initial plataform and get edge Points
		initialPlataform.transform.position = new Vector3 (camX, camheight, 0);
		extractPositions (initialPlataform);

		// Instatiate and move the second plataform
		Transform other = Instantiate (scenaries [a]) as Transform;
		other.transform.position = new Vector2 ( plataformsPosition.ElementAt(1).x +  offsettXSide(other.FindChild ("Left").position.x, other) ,
		                                        camheight);
		extractPositions (other);

		currentScenaries.Add (initialPlataform);
		currentScenaries.Add (other);


	}

	void FixedUpdate(){
				//Debug.Log("message: "+ initialPlataform.FindChild("Left").transform.localPosition );
		if (numberOfScenaries >= 0 && checkinside ()) {
						numberOfScenaries--;			
						createOther ( numberOfScenaries <= 0 );
						
					if(numberOfScenaries  < 0)
						gameObject.GetComponent<CameraFollow>().follow = false;
				}
	}


	bool checkinside(){
		return plataformsPosition.ElementAt (1).x < transform.position.x - camera.orthographicSize - 2.3;

	}

	void createOther( bool final){


		Transform other;

		//Destroy Plataform 
		Destroy (currentScenaries.ElementAt (0).gameObject);
		currentScenaries.RemoveAt (0);
		plataformsPosition.RemoveAt(0);
		plataformsPosition.RemoveAt(0);

		// Instatiate move and add the second plataform
		if (!final) {
				int a;
				a = Random.Range (0, scenaries.Length);
				other = Instantiate (scenaries [a]) as Transform;
		} else {
			 	other = Instantiate (finalPlataform) as Transform;
		}
		other.transform.position = new Vector2 ( plataformsPosition.ElementAt(1).x +  offsettXSide(other.FindChild ("Left").position.x, other) ,
		                                        camheight);
		extractPositions (other);
		currentScenaries.Add (other);
	}

	void extractPositions(Transform t){
		plataformsPosition.Add(t.FindChild ("Left").position);
		plataformsPosition.Add(t.FindChild ("Right").position);
	}

	float offsettXSide(float x, Transform t){

		return t.position.x-x;
	}


}
