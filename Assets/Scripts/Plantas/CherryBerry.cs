using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBerry : MonoBehaviour {

    float esperar = 1.6f;
    bool explodiu = false;

    void FixedUpdate () {
        if(esperar > 0){
            esperar -= Time.fixedDeltaTime;
        }

        if (esperar < 0.85f){
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<CircleCollider2D>().radius = 2;
        }
        if(esperar < 0.7f) { 
           gameObject.GetComponent<CircleCollider2D>().radius = 0f;
        }
        if (esperar < 0){
            Destroy(gameObject);
            esperar = 1.6f;
        }

        Explodir();
    }

    public void Explodir(){
        if(esperar < 1f && explodiu == false){
            GetComponent<AudioSource>().Play();
            explodiu = true;
        }
    }
}

