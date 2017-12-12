using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarra : MonoBehaviour {

    public float PegarTamanhoBarra(float minValor, float maxValor) {
        return minValor / maxValor;
    }

    public int PegarPorcentagemBarra(float minValor, float maxValor, int fator){
        return Mathf.RoundToInt(PegarTamanhoBarra(minValor, maxValor) * fator);
    }
}
