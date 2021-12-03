using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class InputFeedback : MonoBehaviour
{
    [SerializeField] InputField feedback;
    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSca3tN2QRuhR9_4SLJ_93wf62y2kDyJMzdWqZPUeedl8fY73g/formResponse";
    public void Send()
    {
        StartCoroutine(Post(feedback.text));
    }

    IEnumerator Post(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.354682285", s1);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }
}
