using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel 
{
    public float distancia_a_meta;
    public int numeroNivel;
    public string ref_nivel;
    public Nivel(int numeroNivelp, float distancia_a_metap, string ref_nivelp)
    {
        distancia_a_meta = distancia_a_metap;
        numeroNivel = numeroNivelp;
        ref_nivel = ref_nivelp;
    }



}
