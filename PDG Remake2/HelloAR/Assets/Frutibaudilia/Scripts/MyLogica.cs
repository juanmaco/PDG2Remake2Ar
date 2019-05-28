using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Sample { 
public class MyLogica : MonoBehaviour {
        public OnClick[] myButtons;
        public List<int> colorList;
        public List<int> colorList2;
        public float showTime = 0.5f;
        public float pauseTime =2f;

        bool maquina = false;
        public bool player = false;
        bool gameO = false;

        private int myRandom;
        public int level = 1;
        private int playerLevel;

        public Text scoreT;
        public Text lifeT;
        public Text cuenta;
        int score = 0;
        int life = 3;
        public GameObject mCanvas;
        public GameObject maquinaU;
        public GameObject rCanvas;
        public GameObject turnoP;
        public GameObject mVictoria;
        bool showUI = false;
        public AudioSource wrong;
        public AudioSource point;
        public GameObject correct;
        public GameObject errado;
        public Animator anim;
        private bool tuto = true; 
        public AudioSource tuto2;
        public AudioSource tuto2v2;
        public AudioSource tuto3;
        public AudioSource tuto4, beep,goS;
        public AudioSource tuto5, tuto6, tuto7, tuto8, tuto9, tuto10, tuto11, tuto12;
        public bool playerFalse = false;
        public bool playerFalse2 = false;
        public bool playerFalse3 = false;
        public bool playerFalse4 = false;
        public int continuar = 0;

        // Use this for initialization
        void Start () {
            anim.SetInteger("Kauca", 0);
            rCanvas.SetActive(false);
            StartCoroutine(Instrucciones());
            playerLevel = 0;
            turnoP.SetActive(false);
            mCanvas.SetActive(false);
            mVictoria.SetActive(false);
            correct.SetActive(false);
            errado.SetActive(false);
            if (tuto == false) {
                maquina = true;
            }
            for (int i=0; i<myButtons.Length; i++)
            {
                myButtons[i].onClick += ButtonClicked;
                myButtons[i].myNumber = i;
            }

	}
        void ButtonClicked(int _number)
        {
            if (player == true)
            {
                if (_number == colorList[playerLevel])
                {
                    playerLevel += 1;
                }
                else
                {
                    myButtons[0].errado = false;
                    life -= 1;
                    StartCoroutine(Wrong());
                    if(life == 0)
                    {
                        FindObjectOfType<GameManager>().GameOver();
                        player = false;
                        maquina = false;
                    }
                }
                if(playerLevel == level)
                {
                    level += 1;
                    playerLevel = 0;
                    maquina = true;
                    StartCoroutine(Wait());
                    if (level == 7)
                    {
                        maquina = false;
                        player = false;
                        FindObjectOfType<GameManager>().Win();
                    }
                }
            }
            if (playerFalse == true)
            {
                if (_number == colorList2[0])
                {
                    tuto5.Play();
                    continuar = 1;
                    playerFalse = false;
                    showUI = false;
                }
                else
                { 
                    StartCoroutine(Wrong());
                }
            }
            if (playerFalse2 == true)
            {
                if (_number == colorList2[1])
                {
                    tuto7.Play();
                    continuar = 2;
                    playerFalse2 = false;
                    showUI = false;
                }
                else
                {
                    StartCoroutine(Wrong());
                }
            }
            if (playerFalse3 == true)
            {
                if (_number == colorList2[2])
                {
                    tuto9.Play();
                    continuar = 3;
                    playerFalse3 = false;
                    showUI = false;
                }
                else
                {
                    StartCoroutine(Wrong());
                }
            }
            if (playerFalse4 == true)
            {
                if (_number == colorList2[3])
                {
                    tuto11.Play();
                    continuar = 4;
                    playerFalse4 = false;
                    showUI = false;
                }
                else
                {
                    StartCoroutine(Wrong());
                }
            }
            if (continuar == 1)
            {
                StartCoroutine(Instrucciones2());
            }
            if (continuar == 2)
            {
                StartCoroutine(Instrucciones3());
            }
            if (continuar == 3)
            {
                StartCoroutine(Instrucciones4());
            }
            if (continuar == 4)
            {
                StartCoroutine(Instrucciones5());
            }
        }
	
	// Update is called once per frame
	void Update () {
            scoreT.text = level.ToString();
            lifeT.text = life.ToString();
            if (maquina)
            {
                player = false;
                maquina = false;
                StartCoroutine(Robot());
            }
            if(showUI == false)
            {
                maquinaU.SetActive(true);
                turnoP.SetActive(false);
            }
            else
            {
                maquinaU.SetActive(false);
                turnoP.SetActive(true);
            }
            if(player == true || playerFalse == true)
            {
                showUI = true;
            }
        }
        IEnumerator Robot()
        {
            showUI = false;
            for(int i =0; i<level; i++)
            {
                if( colorList.Count < level)
                {
                    myRandom = Random.Range(0, myButtons.Length);
                    colorList.Add(myRandom);
                }
                yield return new WaitForSeconds(1f);
                myButtons[colorList[i]].ClickedColor();
                myButtons[colorList[i]].mySound.Play();
                yield return new WaitForSeconds(showTime);
                myButtons[colorList[i]].UnclickedColor();
                yield return new WaitForSeconds(pauseTime);
            }
            player = true;
        }
        IEnumerator Wait()
        {
            scoreT.DOColor(Color.green, 0.5f);
            scoreT.transform.DOScale(1.5f, 1f);
            point.Play();
            correct.SetActive(true);
            yield return new WaitForSeconds(1f);
            scoreT.DOColor(Color.black, 0.5f);
            scoreT.transform.DOScale(1f, 1f);
            correct.SetActive(false);
        }
        IEnumerator Wrong()
        {
            for(int i=0; i< myButtons.Length; i++)
            {
                myButtons[i].errado = false;
            }
            lifeT.DOColor(Color.red, 0.5f);
            lifeT.transform.DOScale(1.5f, 1f);
            wrong.Play();
            anim.SetInteger("Kauca", 5);
            errado.SetActive(true);
            yield return new WaitForSeconds(3f);
            anim.SetInteger("Kauca", 0);
            lifeT.DOColor(Color.black, 0.5f);
            lifeT.transform.DOScale(1f, 1f);
            errado.SetActive(false);
            for (int i = 0; i < myButtons.Length; i++)
            {
                myButtons[i].errado = true;
            }
        }
        IEnumerator Instrucciones()
        {
            maquina = false;
            tuto2.Play();
            StartCoroutine(AnimationManager());
            yield return new WaitForSeconds(18f);
            tuto3.Play();
            yield return new WaitForSeconds(3f);
            tuto4.Play();
            StartCoroutine(AnimationManager3());
            yield return new WaitForSeconds(4f);
            myButtons[0].ClickedColor();
            myButtons[0].mySound.Play();
            colorList2.Add(0);
            yield return new WaitForSeconds(showTime);
            myButtons[0].UnclickedColor();
            yield return new WaitForSeconds(pauseTime);
            playerFalse = true;
        }
        IEnumerator Instrucciones2()
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(AnimationManager4());
            tuto6.Play();
            yield return new WaitForSeconds(3f);
            myButtons[1].ClickedColor();
            myButtons[1].mySound.Play();
            colorList2.Add(1);
            yield return new WaitForSeconds(showTime);
            myButtons[1].UnclickedColor();
            yield return new WaitForSeconds(pauseTime);
            playerFalse2 = true;
        }
        IEnumerator Instrucciones3()
        {
            yield return new WaitForSeconds(1f);
            tuto8.Play();
            yield return new WaitForSeconds(3f);
            myButtons[2].ClickedColor();
            myButtons[2].mySound.Play();
            colorList2.Add(2);
            yield return new WaitForSeconds(showTime);
            myButtons[2].UnclickedColor();
            yield return new WaitForSeconds(pauseTime);
            playerFalse3 = true;
        }
        IEnumerator Instrucciones4()
        {
            yield return new WaitForSeconds(1f);
            tuto10.Play();
            yield return new WaitForSeconds(3f);
            myButtons[3].ClickedColor();
            myButtons[3].mySound.Play();
            colorList2.Add(3);
            yield return new WaitForSeconds(showTime);
            myButtons[3].UnclickedColor();
            yield return new WaitForSeconds(pauseTime);
            playerFalse4 = true;
        }
        IEnumerator Instrucciones5()
        {
            yield return new WaitForSeconds(1f);
            tuto12.Play();
            yield return new WaitForSeconds(23f);
            rCanvas.SetActive(true);
            yield return new WaitForSeconds(1f);
            cuenta.text = "3";
            beep.Play();
            yield return new WaitForSeconds(1f);
            cuenta.text = "2";
            beep.Play();
            yield return new WaitForSeconds(1f);
            cuenta.text = "1";
            beep.Play();
            yield return new WaitForSeconds(1f);
            cuenta.text = "Ya";
            goS.Play();
            cuenta.transform.DOScale(1.5f, 1.5f);
            yield return new WaitForSeconds(1f);
            rCanvas.SetActive(false);
            maquina = true;
            continuar = 6;
        }
        IEnumerator AnimationManager()
        {
            anim.SetInteger("Kauca", 6);
            yield return new WaitForSeconds(10f);
            anim.SetInteger("Kauca", 10);
        }
        IEnumerator AnimationManager2()
        {
            anim.SetInteger("Kauca", 7);
            yield return new WaitForSeconds(1f);
            anim.SetInteger("Kauca", 0);
        }
        IEnumerator AnimationManager3()
        {
            anim.SetInteger("Kauca", 0);
            anim.SetInteger("Kauca", 8);
            yield return new WaitForSeconds(1f);
            anim.SetInteger("Kauca", 0);
        }
        IEnumerator AnimationManager4()
        {
            anim.SetInteger("Kauca", 9);
            yield return new WaitForSeconds(2f);
            anim.SetInteger("Kauca", 0);
        }
    }
}