using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Hole[] holes;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finishHeader;
    [SerializeField] private TextMeshProUGUI mainScoreText;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button restartLevelButton;

    private Hammer hummer;
    private Timer timer;
    private int score;
    private System.Random random;

    public void AddScore()
    {
        score++;
        scoreText.text = "—чет: " + score;
    }

    public void FinishLevel()
    {
        timer.StopTimer();
        Cursor.visible = true;
        hummer.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);

        for (int i = 0; i < holes.Length; i++)
            if (holes[i].enemy != null)
                holes[i].enemy.gameObject.SetActive(false);

        finishHeader.gameObject.SetActive(true);
        mainScoreText.gameObject.SetActive(true);
        mainScoreText.text = "—чет: " + score;
        mainMenuButton.gameObject.SetActive(true);
        restartLevelButton.gameObject.SetActive(true);

        mainMenuButton.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(0);
        });

        restartLevelButton.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(1);
        });
    }

    private void Start()
    {
        hummer = FindFirstObjectByType<Hammer>();
        timer = FindFirstObjectByType<Timer>();
        score = 0;
        scoreText.text = "—чет: " + score;
        random = new System.Random();

        for (int i = 0; i < holes.Length; i++)
        {
            Enemy enemy = holes[i].enemy;

            if (enemy != null)
            {
                if (enemy as Mole)
                {
                    enemy.damaged.AddListener(AddScore);
                }
                else if (enemy as Bomb)
                {
                    enemy.damaged.AddListener(FinishLevel);
                }
            }
        }

        timer.finished.AddListener(FinishLevel);
        timer.StartTimer();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < holes.Length; i++)
        {
            if (holes[i].enemy != null)
            {
                if (!holes[i].enemy.IsFirstActive)
                {
                    int holeNumber = random.Next(holes.Length);
                    if (holes[holeNumber].enemy == null)
                    {
                        Enemy enemy = holes[i].PopEnemy();
                        holes[holeNumber].PushEnemy(enemy);
                    }
                }
            }
        }
    }
}