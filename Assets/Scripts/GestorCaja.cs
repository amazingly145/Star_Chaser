using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This GameMaster has the logic of all the game: winning, losing and restarting 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>

public class GestorCajas : MonoBehaviour
{
    //variables
    //arreglo caja
    public Caja[] cajas;
    //A fuerza debe de haber 3 premios
    public int numPremios = 3;
    public GameObject aliens;
    public GameObject premio;

    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
    void Start()
    {
        AsignarContenido();
    }

    /// <summary>
    /// This method is called to assign content to each box
    /// </summary>
    void AsignarContenido()
    {
        List<int> indices = new List<int>();
        //agrego los indices a la lista
        for (int i = 0; i < cajas.Length; i++) indices.Add(i);
        //asigno las cosas dependiendo de las cajas
        for (int i = 0; i < indices.Count; i++)
        {
            int temp = indices[i];
            //Obtenemos un valor random dependiendo de las cajas
            int rnd = Random.Range(i, indices.Count);
            indices[i] = indices[rnd];
            indices[rnd] = temp;
        }
        //asigno cadauna deoendiendo de los indices y el contenido que debe de a ver
        for (int i = 0; i < cajas.Length; i++)
        {
            //Creamos las cajas dependiendo de lso inidices
            Caja c = cajas[indices[i]];
            c.aliens = aliens;
            c.premio = premio;
            if (i < numPremios){
                c.tipoContenido = TipoContenido.Premio;
            }else{
                c.tipoContenido = TipoContenido.Alien;
            }
        }
    }
}