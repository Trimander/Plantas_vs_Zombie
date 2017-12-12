using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaNeve : MonoBehaviour {

    public GameObject PrefabBala;
    public Transform canhao;
    public LayerMask layerZombie;
    public AudioClip som;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 1.5f, 2f); // Repete a função Spawn em 3 em 3 segundos, e começa após 3 segundos de jogo
    }

    void Spawn(){
        RaycastHit2D hit = Physics2D.Raycast(canhao.position, Vector3.right, 8.6f - canhao.transform.position.x, layerZombie); // Joga um raio a partir da posição do canhao no sentido da direita para verificar se existe zombie

        if (hit.collider != null)
        { // Se colidir com um zombie, faça
            Instantiate(PrefabBala, canhao.transform.position, Quaternion.identity); // Instancia a bala a partir do canhao
            GetComponent<AudioSource>().clip = som;
            GetComponent<AudioSource>().Play();
        }
    }
}
