using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private float _score = 1;

    public delegate void ScoreChange();
    public event ScoreChange scoreChanged;

    //Increase/Decrease score => change size
    public void ChangeScore(float amount)
    {
        _score += amount;
        ChangeSize();
    }

    //Increase/Decrease size
    private void ChangeSize()
    {
        transform.localScale = Vector3.one * _score;
        scoreChanged?.Invoke();
    }

    public float GetScore()
    {
        return _score;
    }

    //Punch and take damage when touched by strong enemy. Die option
    private void Damage(float scoreDamage, Vector3 punchDirection)
    {
        GetComponent<Rigidbody>().AddForce(punchDirection * 10 + Vector3.up * 5, ForceMode.Impulse);
        ChangeScore(-scoreDamage);
        if (_score < 0.5f)
            Destroy(gameObject);
    }

    //Get cube speed using it score
    public float GetSpeed()
    {
        return _speed / _score;
    }

    //Take damage or get enemy score when touching the cube
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Cube enemyCube = collision.gameObject.GetComponent<Cube>();
            if (GetScore() > enemyCube.GetScore())
            {
                ChangeScore(0.4f);
            }
            else if (GetScore() < enemyCube.GetScore())
            {
                Vector3 punchDirection = (transform.position - collision.gameObject.transform.position).normalized;
                Damage(0.4f, punchDirection);
            }
            else
            {
                Vector3 punchDirection = (transform.position - collision.gameObject.transform.position).normalized;
                Damage(0, punchDirection);
            }
        }
    }
}
