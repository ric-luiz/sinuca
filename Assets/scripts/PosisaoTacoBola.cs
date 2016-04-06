using UnityEngine;
using System.Collections;

public class PosisaoTacoBola : MonoBehaviour {

	public GameObject taco;
	private Rigidbody rb;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if(rb.velocity.magnitude == 0 && !taco.activeSelf){
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
			for (int i=0; i<=5; i++) {
				Physics.IgnoreCollision (
					GameObject.FindGameObjectsWithTag ("barra")[i].GetComponent<Collider>(),
					taco.transform.Find("colisor").gameObject.GetComponent<Collider>());
			}
		}
	}
}
