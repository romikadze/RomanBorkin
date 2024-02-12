namespace Source.Scripts1.Items
{
    public class Rock : GameItem
    {
        public override bool Beat(GameItem enemySymbol)
        {
            return enemySymbol is Shears;
        }
    }
}