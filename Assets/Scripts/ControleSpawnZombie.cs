using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSpawnZombie : MonoBehaviour {

    public List<GameObject> Prefabpontos;
    public GameObject[] Pontos;

    // Use this for initialization
    void Start(){
        int teste;

        for (int i = Pontos.Length; i > 0; i--){ // Passa em todos os campos de tempo
            teste = Random.Range(0, i);
            Pontos[i - 1].AddComponent<SpawnZombie>();
            Pontos[i - 1].GetComponent<SpawnZombie>().PrefabZombie = Prefabpontos[teste].GetComponent<SpawnZombie>().PrefabZombie;
            Pontos[i - 1].GetComponent<SpawnZombie>().tempo = Prefabpontos[teste].GetComponent<SpawnZombie>().tempo;
            Prefabpontos.RemoveAt(teste);
        }
    }
}
