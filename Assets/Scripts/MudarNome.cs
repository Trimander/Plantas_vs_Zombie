using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MudarNome : MonoBehaviour {

    public InputField field;
    public Text camponome;
    public GameObject show;
    public GameObject botoes;

    void Start(){
        if (!PlayerPrefs.HasKey("Nome")){ // Se o campo nome não foi alterado, faça
            PlayerPrefs.SetString("Nome", "PlayerName"); //  Inicia com o nome PlayerName
        }
    }

    public void TrocarNome(){ // Função para trocar nome do jogador
        if (field.text == ""){}
        else
            PlayerPrefs.SetString("Nome", field.text); // Pega o texto digitado pelo jogador e atribui ao campo nome
    }

    public void Mostrar(){ // Função para mostrar o objeto
        botoes.SetActive(false);
        field.text = "";
        show.SetActive(true); // Faz o objeto ficar visivel
    }

    public void Ocultar(){ // Fun~ção para ocultar o objeto
        show.SetActive(false); // Faz o objeto ficar oculto
        botoes.SetActive(true);
    }

    void FixedUpdate(){
        camponome.GetComponent<Text>().text = "" + PlayerPrefs.GetString("Nome"); // Pega a componeente de texto e atribui ao campo nome
    }

    public void CarregarJogo() { // Função para carregar a cena de fases jogo 
        Time.timeScale = 0f; // Pausa o jogo
        SceneManager.LoadScene("Jogo"); // Carrega a cena "Jogo"
    }
}
