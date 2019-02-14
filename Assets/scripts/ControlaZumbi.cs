using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour {

	public GameObject Jogador;
	public float Velocidade = 5; //mais devagar que o jogador
	private Rigidbody rigidBodyZumbi;
	private Animator animatorZumbi;

	// Use this for initialization
	void Start() {
		Jogador = GameObject.FindWithTag("Jogador");
		int geraTipoZumbi = Random.Range(1, transform.childCount);
		transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);

		rigidBodyZumbi = GetComponent<Rigidbody>();
		animatorZumbi = GetComponent<Animator>();
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		Vector3 direcao  = Jogador.transform.position - transform.position;
		Quaternion novaRotacao = Quaternion.LookRotation(direcao);

		//olhar pro personagem
		rigidBodyZumbi.MoveRotation(novaRotacao);	

		float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

		//se tou perto, me movimento
	if (distancia > 2.5 ){ //2 porque 1 de raio do colisor de cada um - bater colisores 1+1 = 2
		//podemos aumentar um pouquinho
		
		rigidBodyZumbi.MovePosition(rigidBodyZumbi.position + direcao.normalized
		 * Velocidade * Time.deltaTime);

		
		animatorZumbi.SetBool("Atacando", false);

	}

	else {
		animatorZumbi.SetBool("Atacando", true);

	}


}

void AtacaJogador ()
{
	Time.timeScale = 0;
	//pausa o jogo
	Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);

	Jogador.GetComponent<ControlaJogador>().Vivo = false;

}



}
