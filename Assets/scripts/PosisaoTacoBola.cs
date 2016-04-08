using UnityEngine;
using System.Collections;

public class PosisaoTacoBola : MonoBehaviour {

	public GameObject taco;
	private Rigidbody rb;
	private bool bolasParadas = false;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if(rb.velocity.magnitude == 0 && !taco.activeSelf && bolasParadas){
			//Mostra o taco
			taco.SetActive(true);
			//O taco volta a sofre acoes da fisica
			taco.GetComponent<Rigidbody>().isKinematic = false;
			taco.transform.Find("colisor").gameObject.GetComponent<Collider>().isTrigger = false;
			//Define os angulos do taco para zero
			taco.transform.rotation = Quaternion.Euler(0,0,0);
			//Seta a nova posicao
			taco.transform.position = new Vector3(transform.position.x - 1.64f, -1.67f, transform.position.z - 1);

			//Refaz o IgnoreCollision, pois o taco foi desativado
			foreach (GameObject i in GameObject.FindGameObjectsWithTag ("barra")) {
				Physics.IgnoreCollision (
					i.GetComponent<Collider>(),
					taco.transform.Find("colisor").gameObject.GetComponent<Collider>());
			}
			foreach (GameObject i in GameObject.FindGameObjectsWithTag ("bola")) {
				Physics.IgnoreCollision (
					i.GetComponent<Collider>(),
					taco.transform.Find("colisor").gameObject.GetComponent<Collider>());
			}
		}

		foreach (GameObject i in GameObject.FindGameObjectsWithTag ("bola")) {
			//Tambem quero saber se todas as bolas estao paradas
			bolasParadas = true;
			if(i.GetComponent<Rigidbody>().velocity.magnitude > 0.2){
				bolasParadas = false;
			}
		}
	}
}
