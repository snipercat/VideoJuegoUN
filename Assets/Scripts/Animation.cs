using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {

	public Sprite[] idleSprites;
	public float idleframesPerSecond;

	public Sprite[] walkSprites;
	public float walkframesPerSecond;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
	
		spriteRenderer = renderer as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Idle(){

		int index = (int)(Time.timeSinceLevelLoad * idleframesPerSecond);
		index = index % idleSprites.Length;
		spriteRenderer.sprite = idleSprites[ index ];
	}

	public void Walk(){
		int index = (int)(Time.timeSinceLevelLoad * walkframesPerSecond);
		index = index % walkSprites.Length;
		spriteRenderer.sprite = walkSprites[ index ];

	}
}
