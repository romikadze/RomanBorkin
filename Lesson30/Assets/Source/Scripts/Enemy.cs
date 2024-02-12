using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameItem[] _avaibleSymbols;
    private GameItem _symbol;

    private void SelectSymbol()
    {
        _symbol = _avaibleSymbols[Random.Range(0, _avaibleSymbols.Length)];
        Debug.Log("Enemy selected " + _symbol.name);
    }
    
    public GameItem GetSymbol()
    {
        if(!_symbol)
            SelectSymbol();
        
        return _symbol;
    }

    public void ClearSymbol()
    {
        _symbol = null;
    }
}