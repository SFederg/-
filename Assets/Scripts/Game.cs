using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Hole[] holes;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;
    private System.Random random;

    public void AddScore()
    {
        score++;
        scoreText.text = "—чет: " + score;
    }

    private void Start()
    {
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
            }
        }
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