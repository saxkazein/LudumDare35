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
		audioSource.loop = true;
		audioSource.clip = efectoClick01;
		audioSource.Play();
	}

	public void playClick02(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoClick02;
		audioSource.Play();
	}

	public void playComida01(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoComida01;
		audioSource.Play();
	}
	public void playMejora(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoMejora;
		audioSource.Play();
	}

	public void playRobot01(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoRobot01;
		audioSource.Play();
	}

	public void playRobot02(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoRobot02;
		audioSource.Play();
	}
	public void playRobot03(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoRobot03;
		audioSource.Play();
	}

	public void playRobot04(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoRobot04;
		audioSource.Play();
	}

	public void playRobot05(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoRobot05;
		audioSource.Play();
	}
	public void playSaltoTurno(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoSaltoTurno;
		audioSource.Play();
	}

	public void playSiguiente02(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoSiguiente02;
		audioSource.Play();
	}

	public void playWin01(){
		audioSource.volume = volumenBase;
		audioSource.loop = true;
		audioSource.clip = efectoWin01;
		audioSource.Play();
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
