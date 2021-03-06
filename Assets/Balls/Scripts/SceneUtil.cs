using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneUtil : MonoBehaviour {

	public GameObject balls;
	public GameObject[] planes;
	public Texture[] tex;
	public Texture GridTex;
	public float speed = 1;
	// Use this for initialization
	void Start () {
		UnityEngine.XR.XRSettings.showDeviceView = false;
		tex = new Texture[planes.Length];
		for (int i = 0; i < tex.Length; i++) {
			tex [i] = planes [i].GetComponent<MeshRenderer> ().material.mainTexture;
			planes [i].GetComponent<MeshRenderer> ().material.mainTexture = GridTex;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.A)) {
			balls.SetActive (true);
			for (int i = 0; i < tex.Length; i++) {
				planes [i].GetComponent<MeshRenderer> ().material.mainTexture = tex[i];
			}
		}
		if (Input.GetKeyUp (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
		if (Input.GetKey (KeyCode.Alpha7)) {
			Transform g = Camera.main.transform;
			g.localEulerAngles = new Vector3 (g.localEulerAngles.x + Input.GetAxis ("Mouse Y") * speed, g.localEulerAngles.y + Input.GetAxis ("Mouse X") * speed, g.localEulerAngles.z);
		}
		if (Input.GetKey (KeyCode.Alpha8)) {
			Camera.main.fieldOfView = Camera.main.fieldOfView + Input.GetAxis ("Mouse Y") * speed;
		}
		if (Input.GetKey (KeyCode.Alpha9)) {
			Transform g = Camera.main.transform;
			g.localPosition = new Vector3 (g.localPosition.x, g.localPosition.y + Input.GetAxis ("Mouse Y") * speed*.1f, g.localPosition.z);
		}
	}
}
