using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Judge : MonoBehaviour
{
    private Player _player;
    private Enemy _enemy;
    private ButtonGroup _buttonGroup;


    public void Awake()
    {
        _player = GetComponent<Player>();
        _enemy = GetComponent<Enemy>();
        _buttonGroup = GetComponent<ButtonGroup>();
    }

    public void StartGame()
    {
        StartCoroutine(GameStartTick());
    }

    private IEnumerator GameStartTick()
    {
        yield return new WaitForSeconds(3);
        PrintWinner();
    }

    private void PrintWinner()
    {
        bool playerResult = _player.GetSymbol().Beat(_enemy.GetSymbol());
        bool enemyResult = _enemy.GetSymbol().Beat(_player.GetSymbol());

        if (enemyResult == playerResult)
            Debug.Log("Draw");
        else if (playerResult)
            Debug.Log("Player wins");
        else if (enemyResult)
            Debug.Log("Enemy wins");

        _enemy.ClearSymbol();
    }
}