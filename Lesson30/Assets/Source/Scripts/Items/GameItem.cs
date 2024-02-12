using UnityEngine;

public class GameItem : MonoBehaviour
{
    public virtual bool Beat(GameItem enemySymbol)
    {
        return false;
    }
}


