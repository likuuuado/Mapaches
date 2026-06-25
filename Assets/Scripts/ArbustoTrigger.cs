using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ArbustoTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            playerNearby = true;
            Debug.Log("Presiona E para entrar al arbusto.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            playerNearby = false;
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("NivelSigilo");
    }
}
