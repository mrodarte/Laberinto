using UnityEngine;
using System.Collections;

public class ControllerCamera : MonoBehaviour {
	public GameObject player;
	private Vector3 posINI;
	// Use this for initialization
	void Start () {
		posINI = this.transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = player.transform.position + posINI;
	}
}
