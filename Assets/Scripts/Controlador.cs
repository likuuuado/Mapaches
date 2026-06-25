using UnityEngine;
using UnityEngine.SceneManagement;
public class Controlador : MonoBehaviour
{
    public static Controlador instance;

    [Header("UI")]
    public GameObject pantallaDerrota;
    public GameObject pantallaVictoria;
    public GameObject pantallaPausa;
    private bool estaPausado = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Pausado();
    }

    public void GameOver()
    {
        Debug.Log("Perdiste");
        if (pantallaDerrota != null)
            pantallaDerrota.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReiniciarPantalla()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void Victory()
    {
        Debug.Log("Victoria");
        if (pantallaVictoria != null)
            pantallaVictoria.SetActive(true);
        Time.timeScale = 0f;
    }

    void Pausado()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado) Reanudar();
            else JuegoPausado();
        }
    }

    public void JuegoPausado()
    {
        estaPausado = true;
        if (pantallaPausa != null)
            pantallaPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        estaPausado = false;
        if (pantallaPausa != null)
            pantallaPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    // Nuevo: carga la escena de pelea
    public void CargarEscenaPelea(bool tieneBate)
    {
        // Guardamos si Richie tiene el bate para que la escena de pelea lo use
        PlayerPrefs.SetInt("RichieTieneBate", tieneBate ? 1 : 0);
        SceneManager.LoadScene("BossFight");
    }
}
