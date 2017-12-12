using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limite : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col){ //Função de colisão de objetos com Trigger ativo
        if (col.CompareTag("Bala")){ // Se houver colisão com algum objeto com a tag Zombie, faça
            Destroy(col.gameObject); // Destroy o zombie
        }
    }
}
