using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float force;
	public Text txtTime;
	public Button btnRestart;

	private float timeValue;
	private bool gameOver;

	void Start () {
		timeValue = 30;
		btnRestart.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if(gameOver != true){
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");

			Vector3 vector = new Vector3 (h, 0.5f, v);
			Rigidbody rb = GetComponent<Rigidbody> ();
			rb.AddForce (vector * force * Time.deltaTime);

			timeValue -= Time.deltaTime;

			if(timeValue <= 0f){
				timeValue = 0.0f;
				gameOver = true;
				btnRestart.gameObject.SetActive (true);
			}

			txtTime.text = "Tiempo: " + timeValue.ToString ("F2");
		}
	}

	void OnTriggerEnter (Collider obj){
		if (gameOver != true) {
			if (obj.gameObject.tag == "enlace") {
				if (SceneManager.GetActiveScene ().name == "Main") {
					SceneManager.LoadScene ("scene1");
				} else {
					SceneManager.LoadScene ("Main");
				}
			}
		}
	}

	public void resetGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "truco")
		{
			Destroy(col.gameObject);
		}
	}
		
}