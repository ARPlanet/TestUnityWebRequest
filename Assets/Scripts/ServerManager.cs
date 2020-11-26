using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerManager : MonoBehaviour
{
    public InputField inputField;
    public Button connectButton;
    public Text resultText;
    public RawImage img;

    public void Request()
    {
        string url = inputField.text;
        StartCoroutine(DoRequest(url));        
    }

    public void CheckInput()
    {
        if (string.IsNullOrWhiteSpace(inputField.text))
        {
            connectButton.interactable = false;
        }
        else
        {
            connectButton.interactable = true;
        }
    }

    IEnumerator DoRequest(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.error != null)
        {
            resultText.text = request.error;
        }
        else
        {
            resultText.text = request.downloadHandler.text;
        }        
    }
}
