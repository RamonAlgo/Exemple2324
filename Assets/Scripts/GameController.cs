using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI marcadorText;
    public TextMeshProUGUI escutsText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI puntsText;

    private int monedasTocadas = 0;
    private int escutsJugador = 0;

    void Start()
    {
        ActualizarMarcador();
        ActualizarEscuts();
        gameOverPanel.SetActive(false);
    }

    public void IncrementarContador()
    {
        monedasTocadas++;
        ActualizarMarcador();
    }

    public void IncrementarEscuts()
    {
        escutsJugador++;
        ActualizarEscuts();
    }

    public void DecrementarEscuts()
    {
        escutsJugador--;
        ActualizarEscuts();
        if (escutsJugador < 0)
        {
            GameOver();
        }
    }

    void ActualizarMarcador()
    {
        marcadorText.text = "Monedes tocades: " + monedasTocadas;
    }

    void ActualizarEscuts()
    {
        escutsText.text = "Escuts jugador: " + escutsJugador;
    }
    void GameOver()
    {
        gameOverPanel.SetActive(true);
        puntsText.text = "Punts aconseguits: " + monedasTocadas;
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        monedasTocadas = 0;
        escutsJugador = 0;
        ActualizarMarcador();
        ActualizarEscuts();
    }
}
