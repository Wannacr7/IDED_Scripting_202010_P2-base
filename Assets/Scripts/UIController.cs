using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //private Player playerRef;
    [SerializeField]private int livecount = 0;
    private int scoreCount = 0;
    private bool endGame = false;

    [SerializeField]
    private Image[] lifeImages;

    [SerializeField]
    private Text scoreLabel;

    [SerializeField]
    private Button restartBtn;

    [SerializeField]
    private float tickRate = 0.2F;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        Player.OnPlayerHit += CountLive;
        Player.OnPlayerScoreChanged += CountScore;
        Player.OnPlayerDied += SetEndGame;

        ToggleRestartButton(false);
    }

    private void ToggleRestartButton(bool val)
    {
        if (restartBtn != null)
        {
            restartBtn.gameObject.SetActive(val);
        }
    }


    private void OnDisable()
    {
        Player.OnPlayerHit -= CountLive;
        Player.OnPlayerScoreChanged -= CountScore;
        Player.OnPlayerDied -= SetEndGame;
    }
    private void CountLive(int _live)
    {
        livecount += _live;
        if(!endGame)lifeImages[livecount-1].gameObject.SetActive(false);

    }
    private void CountScore(int _score)
    {
        scoreCount += _score;

        if (scoreLabel != null)
        {
            scoreLabel.text = scoreCount.ToString();
        }
    }
    private void SetEndGame(bool _endGame)
    {
        endGame = _endGame;

        //CancelInvoke();

        if (scoreLabel != null)
        {
            scoreLabel.text = "Game Over";
        }

        ToggleRestartButton(true);
    }
}