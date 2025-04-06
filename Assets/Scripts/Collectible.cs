using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public void Create ()
    {
        gameObject.SetActive(true);
        float angle = Random.Range(0f, 2f * Mathf.PI);
        float x = Mathf.Cos(angle) * 3f;
        float y = Mathf.Sin(angle) * 3f;
        transform.position = new Vector3(x, y + 1, 0);
        transform.SetAsLastSibling();
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
