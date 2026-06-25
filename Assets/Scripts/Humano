using UnityEngine;
public class Humano : MonoBehaviour
{
    [Header("Patrulla")]
    public Transform[] patrolPoints;
    public float walkSpeed = 2f;
    private int currentPoint = 0;

    [Header("Detección")]
    public float visionRange = 5f;
    public float visionAngle = 45f;
    public LayerMask playerLayer;
    private Transform richie;

    [Header("Estados de Alerta")]
    public enum AlertState { Oculto, Alerta, Visto }
    public AlertState currentState = AlertState.Oculto;

    void Start()
    {
        richie = GameObject.FindGameObjectWithTag("Jugador").transform;
    }

    void Update()
    {
        Patrol();
        DetectPlayer();
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;
        Transform target = patrolPoints[currentPoint];
        transform.position = Vector2.MoveTowards(transform.position, target.position, walkSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void DetectPlayer()
    {
        Vector2 direction = richie.position - transform.position;
        float angle = Vector2.Angle(direction, transform.right);

        if (direction.magnitude <= visionRange && angle <= visionAngle)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, visionRange, playerLayer);
            if (hit.collider != null)
            {
                currentState = AlertState.Visto;
                richie.GetComponent<Richie>().UpdateAlertUI("Visto");
                Controlador.instance.GameOver();
            }
            else
            {
                currentState = AlertState.Alerta;
                richie.GetComponent<Richie>().UpdateAlertUI("Alerta");
            }
        }
        else
        {
            currentState = AlertState.Oculto;
            richie.GetComponent<Richie>().UpdateAlertUI("Oculto");
        }
    }
}
