using UnityEngine;

public class Player : MonoBehaviour
{
    private GameItem _selectedSymbol;

    public void SetSymbol<T>(T symbol) where T : GameItem
    {
        Debug.Log("You Selected " + symbol.name);
        _selectedSymbol = symbol;
    }

    public GameItem GetSymbol()
    {
        return _selectedSymbol;
    }
}