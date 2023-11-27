using UnityEngine;

public class BirdsFactory : MonoBehaviour
{
    [SerializeField] Bird[] _birds;
    private int _counter = 0;
    public Bird CreateBird(Vector2 position)
    {
        Bird newBird = Instantiate(_birds[_counter], position, Quaternion.identity);
        _counter++;
        if (_counter == _birds.Length)
            _counter = 0;

        return newBird;
    }
}
