using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeProgresso : MonoBehaviour {

    public StatusBarra statusBarra;

    public GameObject barraProgresso;
    public GameObject waveApproch;
    public GameObject WaveFinal;
    public GameObject ready;
    public GameObject set;
    public GameObject plant;

    public Text txtProgresso;
    public float maxProgresso;
    public float progressoAtual;
    private bool startgame = false;
    private bool finalWave = false;
    private bool parar = false;
    private bool comecou = false;
    private bool set1 = false;
    private bool ready1 = false;

    public AudioClip[] sons;
        
	// Use this for initialization
	void Start () {
        statusBarra = this.gameObject.GetComponent<StatusBarra>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        barraProgresso.transform.localScale = new Vector3(statusBarra.PegarTamanhoBarra(progressoAtual, maxProgresso), barraProgresso.transform.localScale.y, barraProgresso.transform.localScale.z);
        txtProgresso.text = statusBarra.PegarPorcentagemBarra(progressoAtual, maxProgresso, 100) + "%";

        if (progressoAtual <= maxProgresso && progressoAtual > 0){
            progressoAtual -= Time.fixedDeltaTime;
            if(progressoAtual <= 156 && comecou == false){
                ready.SetActive(true);
                Destroy(ready, 0.5f);
                comecou = true;
            }
            
            
            if (progressoAtual <= 155.3 && set1 == false){ 
                set.SetActive(true);
                Destroy(set, 0.5f);
                set1 = true;
            }
            if (progressoAtual <= 154.5 && ready1 == false){
                plant.SetActive(true);
                Destroy(plant, 0.9f);
                ready1 = true;
            }


            if (progressoAtual < 136 && startgame == false){
                GetComponent<AudioSource>().clip = sons[0];
                GetComponent<AudioSource>().Play();
                startgame = true;
            }

            if (progressoAtual < 30 && finalWave == false){
                waveApproch.SetActive(true);
                Destroy(waveApproch, 3);
                GetComponent<AudioSource>().clip = sons[1];
                GetComponent<AudioSource>().Play();
                finalWave = true;
            }

            if(progressoAtual < 23 && parar == false){
                WaveFinal.SetActive(true);
                Destroy(WaveFinal, 3);
                parar = true;
            }
        }
        else{
            progressoAtual = 0;
            txtProgresso.text = 0.ToString() + "%";
        }
	}
}
