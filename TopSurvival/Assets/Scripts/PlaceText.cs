using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceText : MonoBehaviour
{
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    public float secondsText = 4f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
            if (needText)
            {
                StartCoroutine(placeNameCoroutine());
            }
    }

    private IEnumerator placeNameCoroutine()
    {
        text.SetActive(true);
        placeText.text = placeName;
        placeText.GetComponent<Text>().CrossFadeAlpha(0, secondsText, false); //Adds fafe to text
        yield return new WaitForSeconds(secondsText);
        text.SetActive(false);
    }
}
