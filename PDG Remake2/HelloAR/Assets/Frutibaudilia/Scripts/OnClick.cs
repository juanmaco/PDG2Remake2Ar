﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Sample { 
public class OnClick : MonoBehaviour {
    public Material lMaterial;
    public Material nMaterial;
    private Renderer mReneder;
    private Vector3 myTp;
    public int myNumber = 99;
    public delegate void ClickEv(int number);
    public MyLogica gameLog;
    public AudioSource mySound;
    public SampleImageTargetBehaviour myTarget;
        bool seeActivo;
        public Animator anim;
        public int numeroAnim;
       public bool errado;


        public event ClickEv onClick;
      
        // Use this for initialization
        void Start () {
            mReneder = GetComponent<Renderer>();
            mReneder.enabled=true;
            myTp = transform.position;
            seeActivo = false;
            //anim.SetInteger("Kauca", 0);
            errado = true;
	}
	
	// Update is called once per frame
	void Update () {
            OnSee();
	}
        public void OnMouseDown()
        {
           if(gameLog.player == true || gameLog.playerFalse == true || gameLog.playerFalse2 == true || gameLog.playerFalse3 == true || gameLog.playerFalse4 == true)
            {
                mReneder.sharedMaterial = lMaterial;
                //transform.DOMoveY(30, 0.5f);
                onClick.Invoke(myNumber);
                StartCoroutine(Sound());
                StartCoroutine(Animacion());
            }
        }
        public void OnMouseUp()
        {
            mReneder.sharedMaterial = nMaterial;
            // transform.DOMoveY(myTp.y, 1);
        }
        public void ClickedColor()
        {
            mReneder.sharedMaterial = lMaterial;
            transform.DOMoveY(30, 0.5f);
        }
        public void UnclickedColor()
        {
            mReneder.sharedMaterial = nMaterial;
            transform.DOMoveY(myTp.y, 0.5f);
        }
        IEnumerator Sound()
        {
            mySound.Play();
            yield return new WaitForSeconds(.5f);
        }
        IEnumerator Animacion()
        {
            if(errado == true)
            {
            anim.SetInteger("Kauca", numeroAnim);
            yield return new WaitForSeconds(1f);
            anim.SetInteger("Kauca", 0);
            yield return new WaitForSeconds(0.1f);
            }
            else
            {
                anim.SetInteger("Kauca", 5);
                yield return new WaitForSeconds(1f);
                anim.SetInteger("Kauca", 0);
                yield return new WaitForSeconds(0.2f);
            }
        }
        void OnSee()
        {
            if(myTarget.ReturnState() && !seeActivo )
            {
                mReneder.sharedMaterial = lMaterial;
                //transform.DOMoveY(30, 0.5f);
                onClick.Invoke(myNumber);
                StartCoroutine(Sound());
                StartCoroutine(Animacion());
                seeActivo = true;
            }else if (!myTarget.ReturnState())
            {
                mReneder.sharedMaterial = nMaterial;
                // transform.DOMoveY(myTp.y, 1);
                seeActivo = false;
               // Debug.LogError("no sè: " + myTarget.ReturnState());
            }
        }
    }
}