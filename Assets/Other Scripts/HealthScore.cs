using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


// this is the health score that eventually will be set up to save health and score to the person.
public class HealthScore : MonoBehaviour
{

    private Text health;
    private Text score;

    private float _health;
    private float _score;

    public Text Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
            health.text = "Health = " + _health.ToString();
        }
    }

    public Text Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            score.text = "Score = " + _score.ToString();
        }
    }
}
