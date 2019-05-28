using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sample {
    public class ButtonClick : MonoBehaviour {
        public SampleImageTargetBehaviour[] frutas;
        bool seeActivo;

	// Use this for initialization
	void Start () {
            seeActivo = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void OnClick()
    {
        SceneManager.LoadScene("video");
    }
        public void onSees()
        {
            for(int i = 0; i<frutas.Length; i++)
            {
                if (frutas[i].ReturnState() && !seeActivo)
                {
                    SceneManager.LoadScene("video");
                    seeActivo = true;
                }
            }
        }
}
}
