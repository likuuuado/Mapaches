using UnityEngine;
using UnityEngine.SceneManagement;

public class Richie : MonoBehaviour
{
    [Header("Movimiento")]
    public float normalSpeed = 5f;
    public float stealthSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Sigilo")]
    public bool isHidden = false;

    [Header("UI Alerta")]
    public GameObject eyeClosed;
    public GameObject eyeYellow;
    public GameObject eyeRed;

    [Header("Progresión")]
    public bool tieneBate = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleStealth();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
                Controlador.instance.Reanudar();
            else
                Controlador.instance.JuegoPausado();
        }
    }

    void HandleMovement()
    {
        float currentSpeed = isHidden ? stealthSpeed : normalSpeed;
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.linearVelocity = moveInput * currentSpeed;
    }

    void HandleStealth()
    {
        isHidden = Input.GetKey(KeyCode.LeftShift);
    }

    public void UpdateAlertUI(string state)
    {
        eyeClosed.SetActive(state == "Oculto");
        eyeYellow.SetActive(state == "Alerta");
        eyeRed.SetActive(state == "Visto");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bate"))
            {
                tieneBate = true;
                PlayerPrefs.SetInt("RichieTieneBate", 1);
                Destroy(other.gameObject);
                Debug.Log("Richie consiguió el bate.");
                SceneManager.LoadScene("NivelExploracion");
            }
        if (other.CompareTag("Tortuga"))
            {
                Debug.Log("Richie se enfrenta a la Tortuga");
                SceneManager.LoadScene("BossFight");
            }
    }
}
