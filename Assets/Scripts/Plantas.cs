using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantas : MonoBehaviour {

    public Sprite PlantaEscolhida;
    public int preco;
    public int vida;

    public void Morte(int dano){ // Função para dar dano as plantas
        vida -= dano; // remove a vida da planta
        if(vida <= 0){ // Se a vida for menor ou igual a zero, entra no if
            Destroy(gameObject); // Destroy a planta
        }
    }

}
