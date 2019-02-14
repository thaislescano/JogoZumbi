using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour {

	public GameObject Bala;
	public GameObject CanoDaArma;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Fire1 é o nome do input do click no mouse dentro da Unity
		if (Input.GetButtonDown("Fire1")){
			//atirar
			//objeto, posicao, rotacao
			Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
		}
	}
}
