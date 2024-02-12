using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Judge))]
public class ButtonGroup : MonoBehaviour
{
    private Player _player;
    private Judge _judge;

    public void Awake()
    {
        _player = GetComponent<Player>();
        _judge = GetComponent<Judge>();
    }
    
    public void SelectSymbol(GameItem symbol)
    {
        _player.SetSymbol(symbol);
        
        _judge.StartGame();
    }

}
