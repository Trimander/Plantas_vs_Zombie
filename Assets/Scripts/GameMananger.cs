using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMananger : MonoBehaviour {

    public List<Plantas> PlantasUsar; // Cria uma lista para colocar as plantas que serão usadas

    public GameObject Cartas;
    public GameObject PrefabsCartas;
    public GameObject Botaopa;
    public GameObject[] selecionado;
    public float[] cooldownAtual;
    public float[] cooldown;

    public Text Txtsols; //label do texto onde mostra a quantidade de sols.
    public Text[] TxtLabel;

    Fluxo estadoJogo;
    Cartas acessoUsados;
    public AudioClip[] sons;

    public int sol = 0;
    public int solTotal = 0;
    public int PlantaUsar;
    public bool cartaSelecionada;
    public bool pa = false;
    private bool plantou = false;

    // Use this for initialization
    void Start(){
        atualizarSol(-150); // Inicializa a quantidade de sol
        Time.timeScale = 0f;
        solTotal = 0;
    }

    //Função para atualizar a quantidade de Sol
    public void atualizarSol(int add){
        sol += add; //soma a quantidade colocada no parametro a quantidade total de sol
        Txtsols.text = sol.ToString(); // converte e armazena esse valor em um label de texto
    }

    public void decrementarCooldown(){
        for (int i = 0; i < 6; i++){
            if (cooldownAtual[i] > 0 || PlantasUsar[i].preco > sol){
                //cooldownAtual[i] -= Time.fixedDeltaTime;
                acessoUsados.Pontos[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            }
            else{
                acessoUsados.Pontos[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            if (cooldownAtual[i] > 0){
                cooldownAtual[i] -= Time.fixedDeltaTime;
                TxtLabel[i].gameObject.SetActive(true);
                TxtLabel[i].text = cooldownAtual[i].ToString("F2");
            }
            else{
                TxtLabel[i].text = 0.ToString();
                TxtLabel[i].gameObject.SetActive(false);
            }
        }
    }

    void FixedUpdate () {
        GameObject car = GameObject.Find("CartasPontos");
        acessoUsados = car.GetComponent<Cartas>();

        GameObject fluxo = GameObject.Find("Fluxo");
        estadoJogo = fluxo.GetComponent<Fluxo>();

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition); // Captura posição do mouse na tela
        RaycastHit2D hitsol = Physics2D.Raycast(r.origin, r.direction, 1f, 1 << LayerMask.NameToLayer("Sol"));
        RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction, 1f, 1<< LayerMask.NameToLayer("SQMs")); // Joga um "raio" para verificar se tem algo a partir de uma origem, em uma direção

        if (estadoJogo.play){
            decrementarCooldown();
        }

        if (Input.GetMouseButtonDown(0)){ //Quando o mouse esquerdo for pressionado
            if (hitsol.collider != null){
                if (hitsol.collider.CompareTag("Sol")){ // Caso a colisão seja com algo com a tag SOL
                    atualizarSol(25); // Chama a função atualizarSol para acrescentar 25 a quantidade total de sol
                    Destroy(hitsol.collider.gameObject); // Destroy o objeto apos o uso
                    solTotal += 25;
                    GetComponent<AudioSource>().clip = sons[1];
                    GetComponent<AudioSource>().Play();
                }
            }

            else if (hit.collider != null){ //Se colidir com algo, entre no if 
                if (hit.collider.CompareTag("SQMs") && cartaSelecionada == true){ // Se a colisão foi com a tag SQM, entre no if
                    Transform t = hit.collider.transform; // 
                    CriarPlanta(PlantaUsar, t);// Chama a função para criar a planta no sqm escolhido
                    cartaSelecionada = false;
                    if(plantou == true){
                        cooldownAtual[PlantaUsar] = cooldown[acessoUsados.usados[PlantaUsar]];
                        selecionado[PlantaUsar].SetActive(false);
                        GetComponent<AudioSource>().clip = sons[0];
                        GetComponent<AudioSource>().Play();
                        plantou = false;
                    }
                    
                }
                else if(hit.collider.CompareTag("SQMs") && pa == true){
                    if (hit.collider.gameObject.transform.childCount > 0){
                        Destroy(hit.collider.gameObject.transform.GetChild(0).gameObject);
                        pa = false;
                    }
                    else {pa = false; }
                }
                else { pa = false;}

            }
        }
	}

    public void CriarPlanta(int numero, Transform t) { // Função para criar planta nos SQMs
        GameObject fluxo = GameObject.Find("Fluxo");
        estadoJogo = fluxo.GetComponent<Fluxo>();
        if (estadoJogo.play == true) {
            if (PlantasUsar[numero].preco > sol) // Confere se tem sol para comprar a planta
                return;
            if (t.childCount != 0) // Confere se não tem filho para poder inserir
                return;

            GameObject g = Instantiate(PlantasUsar[PlantaUsar].gameObject, t.position, gameObject.transform.rotation) as GameObject; // instancia a planta no sqm escolhido
            g.transform.SetParent(t); //

            atualizarSol(-PlantasUsar[numero].preco); // Atualiza a quantidade de sol apos a compra da planta
            plantou = true;
        }
    }

    public void paEstado(){
        Button botao = Botaopa.GetComponent<Button>();

        botao.onClick.AddListener(() => pa = true);
        pa = true;
    }

    public void selecaoCarta(int i){
        selecionado[i].SetActive(false);
        cartaSelecionada = false;
    }
}
