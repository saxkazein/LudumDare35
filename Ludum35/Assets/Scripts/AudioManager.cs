using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {


	// EFECTOS
	public AudioClip efectoClick01;
	public AudioClip efectoClick02;
	public AudioClip efectoComida01;
	public AudioClip efectoMejora;
	public AudioClip efectoRobot01;
	public AudioClip efectoRobot02;
	public AudioClip efectoRobot03;
	public AudioClip efectoRobot04;
	public AudioClip efectoRobot05;
	public AudioClip efectoSaltoTurno;
	public AudioClip efectoSiguiente02;
	public AudioClip efectoWin01;


	// TRACKS
	public AudioClip trackIntro;
	public AudioClip trackGameOver;
	public AudioClip trackLoop1;


	public float volumenBase;


	public AudioSource audioSource;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	void Awake(){
	}


	// EFECTOS
	public void playClick01(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoClick01);
	}

	public void playClick02(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoClick02);
	}

	public void playComida01(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoComida01);
	}
	public void playMejora(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoMejora);
	}

	public void playRobot01(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoRobot01);
	}

	public void playRobot02(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoRobot02);
	}
	public void playRobot03(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoRobot03);
	}

	public void playRobot04(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoRobot04);
	}

	public void playRobot05(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoRobot05);
	}
	public void playSaltoTurno(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoSaltoTurno);
	}

	public void playSiguiente02(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoSiguiente02);
	}

	public void playWin01(){
		audioSource.volume = volumenBase;
		audioSource.PlayOneShot (efectoWin01);
	}

	// TRACKS
	public void playIntro(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = trackIntro;
		audioSource.Play();
	}

	public void playGameOver(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = trackGameOver;
		audioSource.Play();
	}

	public void playLoop1(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = trackLoop1;
		audioSource.Play();
	}





}
