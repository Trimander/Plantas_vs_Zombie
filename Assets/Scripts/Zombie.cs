using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {

    Animator anim;

    public int vida;
    public float velocidade;
    public int dano;
    public LayerMask layerPlanta;
    float cooldown = 2f;
    float cooldownNeve = 0f;
    bool parado = false;

    public AudioClip[] sons;
    private float delay = 15;

    private void Start(){
        gameObject.GetComponent<Rigidbody2D>().velocity = -Vector3.right * velocidade;
    }

    void FixedUpdate() {
        if(delay > 0){
            delay -= Time.fixedDeltaTime;
        }
        if(delay < 0){
            Grunir();
            delay = 15;
        }

        if (cooldown > 0) {
            cooldown -= Time.fixedDeltaTime;
        }

        if (cooldownNeve > 0){
            cooldownNeve -= Time.fixedDeltaTime;
            if (parado){
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(84, 94, 255, 255);
            }
            else{
                gameObject.GetComponent<Rigidbody2D>().velocity = -Vector3.right * velocidade * 0.7f;
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(84, 94, 255, 255);
            }
        }
        else {
            if (parado){
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
            else{
                gameObject.GetComponent<Rigidbody2D>().velocity = -Vector3.right * velocidade;
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) { //Função de colisão de objetos com Trigger ativo
        if (col.CompareTag("PlantaExplosiva") && col.gameObject.GetComponent<Mina>().subir){
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Planta") || (col.CompareTag("PlantaExplosiva") && col.gameObject.GetComponent<Mina>().subir == false)) {
            parado = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = -Vector3.right * 0;
            GetComponent<AudioSource>().clip = sons[4];
            GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<Plantas>().Morte(dano);
            cooldown = 2f;
        
        }
        if (col.CompareTag("Bala")) { // Se colidir com algo com a tag Bala, faça
            GetComponent<AudioSource>().clip = sons[3];
            GetComponent<AudioSource>().Play();
            vida -= col.gameObject.GetComponent<Bala>().dano; // Diminui a vida do zombie
            Destroy(col.gameObject); // Destroi a bala

            if (vida <= 0) { // Se a vida do zombie for menor ou igual a 0, faça
                GetComponent<AudioSource>().clip = sons[3];
                GetComponent<AudioSource>().Play();
                Destroy(gameObject); // Destroi o zombie
            }
        }
        if(col.CompareTag("BalaNeve")){
            GetComponent<AudioSource>().clip = sons[3];
            GetComponent<AudioSource>().Play();
            cooldownNeve = 2f;
            vida -= col.gameObject.GetComponent<Bala>().dano;
            Destroy(col.gameObject);

            if (vida <= 0){ // Se a vida do zombie for menor ou igual a 0, faça
                GetComponent<AudioSource>().clip = sons[3];
                GetComponent<AudioSource>().Play();
                Destroy(gameObject); // Destroi o zombie
            }
        }
        
        if (col.CompareTag("PlantaTomate")){
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.CompareTag("Planta") && cooldown < 0) {
            GetComponent<AudioSource>().clip = sons[4];
            GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<Plantas>().Morte(dano);
            cooldown = 2f;

        }
        if (col.CompareTag("PlantaExplosiva") && cooldown < 0){
            GetComponent<AudioSource>().clip = sons[4];
            GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<Plantas>().Morte(dano);
            cooldown = 2f;
        }
        else if (col.CompareTag("BalaNeve")){
            Destroy(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.CompareTag("Planta") || col.gameObject.CompareTag("PlantaExplosiva")){
            GetComponent<AudioSource>().clip = sons[5];
            GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Rigidbody2D>().velocity = -Vector3.right * velocidade;
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            parado = false;
        }
    }

    public void Grunir(){
        GetComponent<AudioSource>().clip = sons[Random.Range(0,2)];
        GetComponent<AudioSource>().Play();
    }
}