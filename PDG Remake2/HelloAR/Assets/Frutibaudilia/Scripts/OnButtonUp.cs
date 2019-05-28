using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample { 
public class OnButtonUp : MonoBehaviour {
    public OnClick click;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            OnPress();
	}
        void OnPress()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                click.OnMouseDown();
            }
            else
            {
                click.OnMouseUp();
            }
        }
}
}