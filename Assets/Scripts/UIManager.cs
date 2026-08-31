using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This UIManager is a class to assign the canvases of play, pause, faliure, etc
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class UIManager : MonoBehaviour
{
    //variables
    public GameMaster gameMaster;
    public Image[] corazones;
    public Image[] estrellas;
    public GameObject panelPausa;

    private bool pausado = false;
    private int vidasAnteriores = -1;
    private int rescatadasAnteriores = -1;

    /// <summary>
    /// Update se actualiza cada frame
    /// </summary>
    void Update()
    {
        if (gameMaster == null) return;

        if (gameMaster.vidas != vidasAnteriores)
        {
            ActualizarCorazones();
            vidasAnteriores = gameMaster.vidas;
        }

        if (gameMaster.rescatadas != rescatadasAnteriores)
        {
            ActualizarEstrellas();
            rescatadasAnteriores = gameMaster.rescatadas;
        }
    }

    /// <summary>
    /// Actualiza los corazones dependiedno del GameMaster
    /// </summary>
    void ActualizarCorazones()
    {
        for (int i = 0; i < corazones.Length; i++)
        //Mandamos a llamar las vidas en gameMaster, y las actualizamos
            corazones[i].enabled = i < gameMaster.vidas;
    }

    /// <summary>
    /// Actualiza las estrellas
    /// </summary>
    void ActualizarEstrellas()
    {
        for (int i = 0; i < estrellas.Length; i++)
            estrellas[i].enabled = i < gameMaster.rescatadas;
    }

/// <summary>
    /// Toogle Pausa abre el panel de pausa y lo deja congelado
    /// </summary>
    public void TogglePausa()
    {
        pausado = !pausado;
        if (pausado){
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
        if (panelPausa != null)
            panelPausa.SetActive(pausado);
    }
}