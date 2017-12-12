using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public int velocidade;
    public int dano;
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * velocidade * Time.deltaTime; // Atribui uma velodidade a bala  
	}


}
