using System.Collections.Generic;
using UnityEngine;

public class GestorCajas : MonoBehaviour
{
    public Caja[] cajas;
    public int numPremios = 3;
    public GameObject basuraPrefab;
    public GameObject premioPrefab;

    void Start()
    {
        AsignarContenido();
    }

    void AsignarContenido()
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < cajas.Length; i++) indices.Add(i);

        for (int i = 0; i < indices.Count; i++)
        {
            int temp = indices[i];
            int rnd = Random.Range(i, indices.Count);
            indices[i] = indices[rnd];
            indices[rnd] = temp;
        }

        for (int i = 0; i < cajas.Length; i++)
        {
            Caja c = cajas[indices[i]];
            c.basuraPrefab = basuraPrefab;
            c.premioPrefab = premioPrefab;
            c.tipoContenido = (i < numPremios) ? TipoContenido.Premio : TipoContenido.Basura;
        }
    }
}