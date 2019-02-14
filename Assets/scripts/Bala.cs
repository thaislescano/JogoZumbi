using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

public float Velocidade = 20;
private Rigidbody rigidBodyBala;


	void Start () {
		rigidBodyBala = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidBodyBala.MovePosition(rigidBodyBala.position +
			transform.forward * Velocidade * Time.deltaTime);
		//1 * velocidade * tempo
		
	}


	//colisão da bala
	//bala é um trigger
	//quando um trigger bate em um objeto este método é chamado
	void OnTriggerEnter (Collider objetoDeColisao) {

		if (objetoDeColisao.tag == "Inimigo") {
			Destroy(objetoDeColisao.gameObject);
		}

		Destroy(gameObject);
		//o objeto desse script
		
	}
}
