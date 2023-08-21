using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoScroll : MonoBehaviour
{
    float speed = 100.0f;
    float textBeginPosition = -356.0f;
    float boundaryTextEnd = 1402.0f;

    RectTransform gameObjectTransform;
    [SerializeField]
    TextMeshProUGUI mainText;

    [SerializeField]
    bool isLooping = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObjectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }

    IEnumerator AutoScrollText()
    {
        while (gameObjectTransform.localPosition.y < boundaryTextEnd)
        {
            gameObjectTransform.Translate(Vector3.up * speed * Time.deltaTime);
            if(gameObjectTransform.localPosition.y > boundaryTextEnd)
            {
                if (isLooping)
                    gameObjectTransform.localPosition = Vector3.up * textBeginPosition;
                else
                    break;
            }
            
            yield return null;
        }
    }
}
