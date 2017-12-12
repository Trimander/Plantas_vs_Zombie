using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cartas : MonoBehaviour{

    public GameObject[] carta;
    public GameObject[] Pontos;
    public GameObject playAtivo;

    public List<Plantas> prefabsPlantas;
    public List<int> usados;
    public List<float> cooldown;

    public Button[] botoesMenu;
    
    GameMananger game;
    Fluxo estadoJogo;

    int i = 0;
    // int PlantaUsar = 0;

    public void EscolherCarta(int idcarta){
        GameObject gamem = GameObject.Find("GUIPrincipal");
        game = gamem.GetComponent<GameMananger>();

        if (!usados.Contains(idcarta) && i < 6){
            GameObject g = Instantiate(carta[idcarta], Pontos[i].transform.position, Quaternion.identity) as GameObject;
            g.transform.SetParent(Pontos[i].transform);
            g.transform.localScale = Vector3.one;

            Button botao = g.GetComponent<Button>();

            int u = i;
            botao.onClick.AddListener(() => RemoverDaLista(u));
            botao.onClick.AddListener(() => { if (game.cooldownAtual[u] <= 0) { game.PlantaUsar = u; } });
            botao.onClick.AddListener(() => teste(u));

            game.PlantasUsar.Add(prefabsPlantas[idcarta]);
            i++;
           

            usados.Add(idcarta);
            botoesMenu[idcarta].GetComponent<Image>().color = new Color32(150, 150, 150, 255);
        }

        if (i == 6){
            playAtivo.SetActive(true);
        }
    }

    public void RemoverDaLista(int pos){
        GameObject fluxo = GameObject.Find("Fluxo");
        estadoJogo = fluxo.GetComponent<Fluxo>();
        GameObject gamem = GameObject.Find("GUIPrincipal");
        game = gamem.GetComponent<GameMananger>();

        if (!estadoJogo.play && !estadoJogo.fimJogo){
            Destroy(Pontos[pos].transform.GetChild(0).gameObject);
            i--;
            botoesMenu[usados[pos]].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            usados.RemoveAt(pos);
            game.PlantasUsar.RemoveAt(pos);
            playAtivo.SetActive(false);
            for (int j = pos; j < i; j++){
                Vector3 scale;
                GameObject obj = Instantiate(Pontos[j + 1].transform.GetChild(0).gameObject, Pontos[j].transform.position, Quaternion.identity) as GameObject;
                scale = obj.transform.localScale;
                obj.transform.SetParent(Pontos[j].transform);
                obj.transform.localScale = scale;
                Destroy(Pontos[j + 1].transform.GetChild(0).gameObject);

                Button botao = obj.GetComponent<Button>();

                int u = j;
                botao.onClick.AddListener(() => RemoverDaLista(u));
                botao.onClick.AddListener(() => { game.PlantaUsar = u; });
                botao.onClick.AddListener(() => teste(u));
            }
        }
    }

    public void teste(int u)
    {
        if (estadoJogo.play && game.cooldownAtual[u] <= 0 && game.PlantasUsar[u].preco <= game.sol)
        {
            game.cartaSelecionada = true;
            if (GameObject.FindGameObjectsWithTag("marcacao").Length > 0)
            {
                for (int i = 0; i < game.selecionado.Length; i++)
                {
                    game.selecionado[i].SetActive(false);
                }
                game.selecionado[u].SetActive(true);
            }
            else
            {
                game.selecionado[u].SetActive(true);
            }
        }
    }
}
