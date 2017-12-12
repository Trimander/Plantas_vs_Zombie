using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSol : MonoBehaviour {

    public float velocidade;
    public GameObject PrefabSol;
    private GameObject go;

    public Transform[] PontosSpawn;
    bool estado = true;

    void Start(){
        
    }

    void Spawn(){ // Função para aparecer Sol
        go = Instantiate(PrefabSol, PontosSpawn[Random.Range(0, PontosSpawn.Length)].position, Quaternion.identity); // Instancia Sol em algum ponto de Spawn
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocidade); // Pega a componente de velocidade do objeto e atribui uma velocidade
        Destroy(go, 9); // Destroy o objeto depois de 9 segundos
    }

    void FixedUpdate(){

        if (GameObject.Find("Fluxo").GetComponent<Fluxo>().play && estado)
        {
            InvokeRepeating("Spawn", 5, 10); // Repete a função Spawn em 10 em 10 segundos, e começa após 5 segundos de jogo
            estado = false;
        }else if(!GameObject.Find("Fluxo").GetComponent<Fluxo>().play && !estado)
        {
            StopCoroutine("Spawn");
            estado = true;
        }
        
        
    }
}
