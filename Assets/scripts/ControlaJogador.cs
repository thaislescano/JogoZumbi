using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour {

	public float velocidade = 10;
	private Vector3 direcao;
	public LayerMask MascaraChao;
	//essa variavel aparece na unity
	public GameObject TextoGameOver; //ativar quando necessário
	public bool Vivo = true;

	private Rigidbody rigidBodyJogador;
	private Animator animatorJogador;

	void Start (){
		Time.timeScale = 1; //tempo normal
		rigidBodyJogador = GetComponent<Rigidbody>();
		animatorJogador = GetComponent<Animator>();

	}

	void Update () {
		

		float eixoX = Input.GetAxis("Horizontal");
		float eixoZ = Input.GetAxis("Vertical");
		
		direcao = new Vector3(eixoX, 0, eixoZ);

		if (direcao != Vector3.zero){
			animatorJogador.SetBool("movendo", true);
		}
		else {
			animatorJogador.SetBool("movendo", false);
		}

		if (Vivo == false){
			if(Input.GetButton("Fire1")){
				SceneManager.LoadScene("game");
			}
		}
	}

	void FixedUpdate() {
		//movimentar pela fisica
		rigidBodyJogador.MovePosition(rigidBodyJogador.position + 
			(direcao * velocidade * Time.deltaTime));

		//transform.Translate(direcao * velocidade * Time.deltaTime);
		//nao preciso mais
		//mover nessa direcao por segundo - delta

		Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

		RaycastHit impacto; //toque do raio em qualquer coisa

		//Raycast gerar um raio
		// 100 - distancia até onde eu quero testar esse raio
		//out - variável sem valor nenhum, entra no if com nenhum valor, mas encontra lá dentro

		if(Physics.Raycast(raio, out impacto, 150, MascaraChao))
		{
			Vector3 posicaoMiraJogador = impacto.point - transform.position;

			posicaoMiraJogador.y = 0;
			//tirando modificações na posição em y

			Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

			rigidBodyJogador.MoveRotation(novaRotacao);
		}
	}

	

}
