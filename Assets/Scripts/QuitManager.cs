using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuitManager : MonoBehaviour
{
    public TextMeshProUGUI endScoreText;

    // Start is called before the first frame update
    void Start()
    {
        endScoreText.text = $"High Score: {GameManager.Instance.curHighUser} : {GameManager.Instance.curHighScore}";
        StartCoroutine(EndItAll());
    }

    IEnumerator EndItAll ()
    {
        yield return new WaitForSeconds(13);
        Debug.Log("application quit");
        Application.Quit();
    }
}
