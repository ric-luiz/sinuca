using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject taco;
	public GameObject bolaJogador;
	private bool Reset = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!taco.activeSelf) {

			//Posiciona os eixos
			transform.position = new Vector3(0,15,0.7f);
			//Rotaciona no eixo x
			transform.eulerAngles = new Vector3(90, 180, 0);

			//pode Resetar
			Reset = true;
		} else {

			//Faz com que a camera retorna para de tras do taco
			if(Reset){
				RetornarPosicaoOriginal();
				Reset = false;
			}

			//Rotaciona o taco em volta da bola;
			if(Input.GetMouseButton(1)){
				transform.RotateAround (bolaJogador.transform.position,Vector3.up,-0.5f);
			} else if(Input.GetMouseButton(0)){
				transform.RotateAround (bolaJogador.transform.position,Vector3.up,0.5f);
			}
		}
	}
	private void RetornarPosicaoOriginal(){
		transform.position = new Vector3 (taco.transform.position.x + 1.64f, 1.7f, taco.transform.position.z + 1.25f + 6.4f);
		transform.eulerAngles = new Vector3(30, 180, 0);
	}
}
