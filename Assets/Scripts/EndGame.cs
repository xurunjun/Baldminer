using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject EndGameCanvas;
    public GameObject StartGameCanvas;

    public Countdown countdown;
    public StopBtn stopBtn;
    public Player player;
    public Score score;
    public Text EndScore;

    public void Start()
    {
        EndGameCanvas.SetActive(false);
    }
    public void HomeBtnOnClick()
    {
        stopBtn.Player.SetActive(true);
        EndGameCanvas.SetActive(false);
        StartGameCanvas.SetActive(true);
        EndGameCanvas.SetActive(false);
        //stopBtn.Player.SetActive(false);
        stopBtn.Generater.SetActive(false);
    }

    public void RestartBtnOnClick()
    {
        EndGameCanvas.SetActive(false);
        StartGameCanvas.SetActive(false);

        stopBtn.Player.SetActive(true);
        stopBtn.Generater.SetActive(true);
        player.gameObject.SetActive(true);

        player.reStart();
        score.setScore(0);
        countdown.time = 120;
        stopBtn.StopWindow.SetActive(false);
    }

    public void Update()
    {
        EndScore.text = score.score.ToString();
    }
}
