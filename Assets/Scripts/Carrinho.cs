using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrinho : MonoBehaviour {

    public GameObject Carro;
    public float velocidade;
    public LayerMask layerZombie;
    bool disparou = false;

    // Use this for initialization
    void Start(){
        InvokeRepeating("Mover", 5, 0.1f); // Repete a função Mover em 0.1 em 0.1 segundos, e começa após 5 segundos de jogo
    }

    void Mover(){ // Função para mover o carrinho de cortar grama

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, 0.9f, layerZombie); // Joga um raio a partir da posição do carinho no sentido da direita para verificar se existe zombie

        if (hit.collider != null){ // Se houver colisãp, faça
            if (disparou == false) {
                GetComponent<AudioSource>().Play();
                disparou = true;
            }
            Carro.GetComponent<Rigidbody2D>().velocity = Vector3.right * velocidade; // Pega a componente velocidade do carrinho e lhe atribui velocidade
            Destroy(Carro, 2.9f); // Destroy o carro após 2.9 segundos
        }
    }

    void OnTriggerEnter2D(Collider2D col){ //Função de colisão de objetos com Trigger ativo
        if (col.gameObject.CompareTag("Zombie")){ // Se houver colição com algo com a tag zombie, faça
            Destroy(col.gameObject); // Destroy o objeto com a tag zombie
        }
    }    
}
