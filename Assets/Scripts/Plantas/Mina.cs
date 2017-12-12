using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour {

    Animator explo;
    float delay = 11;
    public bool subir = false;
    public AudioClip[] sons;

    void Start () {
        explo = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
        delay -= Time.fixedDeltaTime;
        if(delay < 0){
            GetComponent<CircleCollider2D>().radius = 0.5f;
            if(subir == false){
                GetComponent<AudioSource>().clip = sons[0];
                GetComponent<AudioSource>().Play();
            }
            subir = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("Zombie") && subir){
            explo.Play("MinaExplosão");
            GetComponent<AudioSource>().clip = sons[1];
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 1);
        }
    }
}
