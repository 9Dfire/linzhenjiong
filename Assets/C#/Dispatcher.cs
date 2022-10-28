using UnityEngine;
using UnityEngine.UI;

public class Dispatcher : MonoBehaviour
{
    private Robot _infantry;
    private Robot _sentry;
    public Scrollbar infantryLife;
    public Scrollbar sentryLife;
    void Start()
    {
        _infantry = new Robot(200, 5);
        _sentry = new Robot(600, 5);
    }

    // Update is called once per frame
    void Update()
    {
        infantryLife.size = _infantry.Life / 200f;
        sentryLife.size = _sentry.Life / 600f;
    }
    public void InHurt()
    {
        _infantry.Life -= _sentry.Power;
    }
    public void SeHurt()
    {
        _sentry.Life -= _infantry.Power;
    }
}
