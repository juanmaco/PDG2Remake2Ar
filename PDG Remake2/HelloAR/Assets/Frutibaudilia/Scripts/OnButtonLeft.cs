using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample { 
public class OnButtonLeft : MonoBehaviour {
        public OnClick click;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            Onpress();
        }
        void Onpress()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
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
