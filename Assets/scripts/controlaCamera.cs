using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaCamera : MonoBehaviour {

 	public GameObject Jogador;
	private Vector3 distCompensar;

 	void Start(){
 		distCompensar = transform.position - Jogador.transform.position;
 	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Jogador.transform.position + distCompensar;
		//ja pega a posicao da camera, porque esse codigo ja está na camera (main Camera)
	}

}