using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noz : MonoBehaviour {

    public Sprite Warning;
    public Sprite Danger;

	void FixedUpdate () {
        if (gameObject.GetComponent<Plantas>().vida <= 25){
            gameObject.GetComponent<SpriteRenderer>().sprite = Warning;
        }
        if(gameObject.GetComponent<Plantas>().vida <= 10){
            gameObject.GetComponent<SpriteRenderer>().sprite = Danger;
        }
    }
}
