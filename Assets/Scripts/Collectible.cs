using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static float _globalAngle;

    public void Create ()
    {
        float radius = -(KarmaVisualizerLogic.Instance.Cam.transform.position.z / 2f);
        gameObject.SetActive(true);
        float x = Mathf.Cos(_globalAngle) * radius;
        float y = Mathf.Sin(_globalAngle) * radius;
        transform.position = new Vector3(x, y + 1, 0);
        transform.SetAsLastSibling();
        _globalAngle += 0.1f;
    }

    private void Update()
    {
        Vector3 diff = new Vector3(0, 1, 0) - transform.position;
        transform.position += diff * Time.deltaTime * SpritesFX.Instance.GetSpeed();
        if (diff.magnitude < 0.1f)
        {
            gameObject.SetActive(false);
            SpriteBlinker.Instance.TriggerBlink();
        }
    }
}
