using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PontuacaoBola : MonoBehaviour {
	public Text pontuacao;
	private int pontos;
	public Text winText;
	void Start () {
	
	}

	void Update () {
		foreach (GameObject i in GameObject.FindGameObjectsWithTag ("bola")) {
			if(i.transform.position.y < -1){
				i.gameObject.SetActive(false);				
				pontos++;
				SetPontuacaoBola ();
			}
		}

		if(transform.position.y < -2){
			gameObject.SetActive(false);
			Perdeu();
		}
	}

	void SetPontuacaoBola (){
		pontuacao.text = "Bolas: " + pontos.ToString();
		if (pontos > 15){
			winText.text = "Voce venceu";
		}
	}
	void Perdeu(){
		winText.text = "Voce Perdeu";

		Application.LoadLevel(0);
	}
}
