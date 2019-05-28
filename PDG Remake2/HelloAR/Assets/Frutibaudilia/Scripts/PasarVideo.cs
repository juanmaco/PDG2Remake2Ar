using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PasarVideo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Pasar());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Pasar(){
		yield return new WaitForSeconds(111f);
		SceneManager.LoadScene("frutibau");
	}
}
