using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinematicaVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("NivelExploracion"); // carga la escena de exploración
    }
}
