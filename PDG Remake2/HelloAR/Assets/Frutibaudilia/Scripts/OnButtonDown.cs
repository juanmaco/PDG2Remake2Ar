using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample { 
public class OnButtonDown : MonoBehaviour {
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
            if (Input.GetKeyDown(KeyCode.DownArrow))
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
