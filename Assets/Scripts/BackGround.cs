using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    public Renderer ren;
    private Vector2 tmp;
    public float speed = 0.08f;

	// Use this for initialization
	void Start () {
        ren = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        tmp = ren.material.mainTextureOffset;
        tmp.x += speed * Time.deltaTime;
        tmp.y += speed * Time.deltaTime;
        ren.material.mainTextureOffset = tmp;
    }
}
