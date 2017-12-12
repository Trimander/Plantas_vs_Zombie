using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girassol : MonoBehaviour {

    public GameObject PrefabSol;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 10, 24); // Repete a função Spawn em 5 em 5 segundos, e começa após 5 segundos de jogo
    }
	
	void Spawn(){ 
        GameObject go = Instantiate(PrefabSol, transform.position, Quaternion.identity); // Instancia um sol
        Destroy(go, 4); // Destroy o objeto em 4 segundos
    }
}
