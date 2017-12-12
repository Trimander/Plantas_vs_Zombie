using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondVitoria : MonoBehaviour {

    public GameObject telaVitoria;
    Fluxo estadoJogo;
    float tempo;

    void Start(){
        tempo = 0;
    }

    void FixedUpdate() {
        GameObject fluxo = GameObject.Find("Fluxo");
        estadoJogo = fluxo.GetComponent<Fluxo>();

        if (estadoJogo.play) {
            tempo += Time.fixedDeltaTime;
        }

        if (GameObject.FindGameObjectsWithTag("Zombie").Length == 0 && tempo > 156){
            tempo = 0;
            GameObject.Find("BarraFundo").GetComponent<AudioSource>().Stop();
            telaVitoria.SetActive(true);
            estadoJogo.play = false;
            estadoJogo.fimJogo = true;
            Time.timeScale = 0f;
        }
    }
}
