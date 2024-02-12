namespace Source.Scripts1.Items
{
    public class Shears : GameItem
    {
        public override bool Beat(GameItem enemySymbol)
        {
            return enemySymbol is Paper;
        }
    }
}