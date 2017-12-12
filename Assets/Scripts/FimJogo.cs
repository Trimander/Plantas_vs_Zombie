using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FimJogo : MonoBehaviour {

    public GameObject gameOver;
    public Button bot;

    void OnTriggerEnter2D(Collider2D col){ //Função de colisão de objetos com Trigger ativo
        if (col.CompareTag("Zombie")){ // Se houver colisão com algum objeto com a tag Zombie, faça
            GameObject.Find("BarraFundo").GetComponent<AudioSource>().Stop();
            GameObject.Find("Fundo").GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            Destroy(col.gameObject); // Destroy o zombie
            Time.timeScale = 0f; // Pausa o jogo
            gameOver.SetActive(true); // Faz a mensagem de Fim de Jogo aparecer
            bot.onClick.RemoveAllListeners();
        }
    }
}
