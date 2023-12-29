using UnityEngine;

public class Hole : MonoBehaviour
{
    public Enemy enemy;

    public void PushEnemy(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, enemy.transform.position.z);
        enemy.isActive = true;
        enemy.gameObject.SetActive(true);
    }

    public Enemy PopEnemy()
    {
        Enemy returnedEnemy = enemy;
        enemy = null;
        return returnedEnemy;
    }
}