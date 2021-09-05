using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlaceText : MonoBehaviour
{
    [SerializeField] private string placeName;
    [SerializeField] private GameObject text;
    [SerializeField] private Text placeText;
    [SerializeField] private float secondsText = 4f;
    private bool needText;

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
