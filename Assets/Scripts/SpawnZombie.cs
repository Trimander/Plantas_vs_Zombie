using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{

    public GameObject[] PrefabZombie;
    public int[] tempo;
    GameMananger acesso;

    // Use this for initialization
    void Start(){
        for (int i = 0; i < tempo.Length; i++) // Passa em todos os campos de tempo
            Invoke("Spawn", tempo[i]); // Chama a função Spawn no tempo i
        
    }

    void Spawn(){ // Função para Spawnar os zombies
        GameObject car = GameObject.Find("GUIPrincipal");
        acesso = car.GetComponent<GameMananger>();

        if (acesso.GetComponent<GameMananger>().solTotal < 300){
            Instantiate(PrefabZombie[0], transform.position, Quaternion.identity);
        }
        else if (acesso.GetComponent<GameMananger>().solTotal < 700){
            Instantiate(PrefabZombie[Random.Range(0, PrefabZombie.Length - 1)], transform.position, Quaternion.identity); // Instancia o zombie
        }
        else{
            Instantiate(PrefabZombie[Random.Range(0, PrefabZombie.Length)], transform.position, Quaternion.identity);
        }
    }
}
