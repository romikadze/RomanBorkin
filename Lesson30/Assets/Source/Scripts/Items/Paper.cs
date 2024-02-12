namespace Source.Scripts1.Items
{
    public class Paper : GameItem
    {
        public override bool Beat(GameItem enemySymbol)
        {
            return enemySymbol is Rock;
        }
    }
}