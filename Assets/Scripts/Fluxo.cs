using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fluxo : MonoBehaviour {

    public GameObject menu;
    public GameObject gameOver;
    public GameObject fundo;
    public GameObject EscolherCarta;
    public GameObject menuPause;
    public GameObject Fundo;
    public bool play = false;
    public bool fimJogo = false;

    public void CarregarJogo() { // Função para carregar a cena de fases jogo 
        Time.timeScale = 0f; // Pausa o jogo
        SceneManager.LoadScene("Jogo"); // Carrega a cena "Jogo"
    }

    public void CarregarMenu() { // Função para carregar a cena do Menu principal
        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene("MenuPrincipal"); // Carrega a cena "MenuPrincipal"
    }

    public void CarregarMenuPause() { // Função para carregar o menu de pause durante o jogo
        Time.timeScale = 0f; // Pausa o jogo
        menu.SetActive(true); // Faz o menu pause aparecer na tela
        GameObject.Find("Barra").GetComponent<AudioSource>().Pause();
        GameObject.Find("BarraFundo").GetComponent<AudioSource>().Pause();
        GameObject.Find("Fundo").GetComponent<AudioSource>().Pause();
    }

    public void VoltarAoJogo() { // Função para voltar ao jogo quando estiver no menu pause
        Time.timeScale = 1f; // Despausa o jogo
        menu.SetActive(false); // Faz o menu pause ficar oculto
        GameObject.Find("Barra").GetComponent<AudioSource>().UnPause();
        GameObject.Find("BarraFundo").GetComponent<AudioSource>().UnPause();
        GameObject.Find("Fundo").GetComponent<AudioSource>().UnPause();
    }

    public void RestartFase() { // Função para restartar a fase ativa
        Time.timeScale = 1f; // Despausa o jogo
        menu.SetActive(false); // Faz o menu pause ficar oculto
        gameOver.SetActive(false); // Faz a mensagem de game over ficar oculta
        SceneManager.LoadScene("Jogo"); // Carrega a cena "Jogo" 
    }

    public void ComecaJogo(){
        play = true;
        Time.timeScale = 1f;
        EscolherCarta.SetActive(false);
        menuPause.GetComponent<Button>().enabled = true;
        Fundo.SetActive(true);
}

    public void Sair(){
        Application.Quit();
    }
}
