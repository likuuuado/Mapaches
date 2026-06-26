using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ControldeDialogos : MonoBehaviour
{
    [Header("UI")]
    public Text textoNombre;
    public Text textoDialogo;
    public GameObject panelDialogo;

    private Queue<string> colaDialogos;
    private string nombreActual;

    void Start()
    {
        colaDialogos = new Queue<string>();
        panelDialogo.SetActive(false);
    }

    public void IniciarDialogo(string nombre, List<string> lineas)
    {
        nombreActual = nombre;
        textoNombre.text = nombreActual;
        colaDialogos.Clear();

        foreach (string linea in lineas)
        {
            colaDialogos.Enqueue(linea);
        }

        panelDialogo.SetActive(true);
        MostrarSiguienteLinea();
    }

    public void MostrarSiguienteLinea()
    {
        if (colaDialogos.Count == 0)
        {
            TerminarDialogo();
            return;
        }

        string linea = colaDialogos.Dequeue();
        textoDialogo.text = linea;
    }

    void TerminarDialogo()
    {
        panelDialogo.SetActive(false);
        Debug.Log("Diálogo terminado.");
    }

    void Update()
    {
        if (panelDialogo.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            MostrarSiguienteLinea();
        }
    }
}
