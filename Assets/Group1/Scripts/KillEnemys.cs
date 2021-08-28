using UnityEngine;

public class KillEnemys : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _blackScreen;    
    [SerializeField] private EnemyMover[] _enemies;

    private const float Distance = 0.2f;

    public void ShowBlackScreen()
    {
        _blackScreen.SetActive(true);
    }

    private void Update()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy == null)
                continue;

            if (Vector3.Distance(_player.transform.position, enemy.transform.position) < Distance)
            {
                _player.InitializeCollision(enemy);
            }

        }
    }
}
