using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private KillEnemys _controller;
    [SerializeField] private float _speed;
    [Header("EdgeFrameGame")]
    [SerializeField] private float _edgeX;
    [SerializeField] private float _edgeY;

    private bool _isReady;
    private float _delay;

    private const int Splitter = 2;
    private const int MultiSpeed = 2;
    private const string Enemy = "enemy";
    private const string Speed = "speed";

    public void InitializeCollision(EnemyMover enemy)
    {
        KillEnemy(enemy);
        IncreaseSpeed(enemy);
    }

    private void Update()
    {
        if (_isReady)
        {
            _delay -= Time.deltaTime;

            if(_delay < 0)
            {
                _isReady = false;
                _speed /= Splitter;
            }
        }

        FindActiveEnemies();
        Move();
    }

    private void KillEnemy(EnemyMover enemy)
    {
        if (enemy.name == Enemy)
            Destroy(enemy.gameObject);
    }

    private void IncreaseSpeed(EnemyMover enemy)
    {
        if (enemy.name == Speed)
        {
            _speed *= MultiSpeed;
            _isReady = true;
            _delay = Splitter;
            Destroy(enemy.gameObject);
        }
    }

    private void FindActiveEnemies()
    {
        EnemyMover[] enemies = GameObject.FindObjectsOfType<EnemyMover>();

        if (enemies.Length == 0)
        {
            _controller.ShowBlackScreen();
            enabled = false;
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y <= _edgeY)
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S) && transform.position.y >= -_edgeY)
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A) && transform.position.x >= -_edgeX)
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D) && transform.position.x <= _edgeX)
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
