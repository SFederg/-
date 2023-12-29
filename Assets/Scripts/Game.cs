using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Hole[] holes;
    private System.Random random;

    private void Start()
    {
        random = new System.Random();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < holes.Length; i++)
        {
            if (holes[i].enemy != null)
            {
                if (!holes[i].enemy.isActive)
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