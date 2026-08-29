using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameMaster gameMaster;
    public Image[] corazones;
    public Image[] estrellas;
    public GameObject panelPausa;

    private bool pausado = false;
    private int vidasAnteriores = -1;
    private int rescatadasAnteriores = -1;

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

    void ActualizarCorazones()
    {
        for (int i = 0; i < corazones.Length; i++)
            corazones[i].enabled = i < gameMaster.vidas;
    }

    void ActualizarEstrellas()
    {
        for (int i = 0; i < estrellas.Length; i++)
            estrellas[i].enabled = i < gameMaster.rescatadas;
    }

    public void TogglePausa()
    {
        pausado = !pausado;
        Time.timeScale = pausado ? 0f : 1f;

        if (panelPausa != null)
            panelPausa.SetActive(pausado);
    }
}