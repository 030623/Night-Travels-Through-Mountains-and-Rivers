using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TypeText : MonoBehaviour
{
    public UnityEvent onFinishTyping;
    public Text textComponent;
    public string targetText;
    public string[] poimaryText;
    public float typingSpeed = 0.05f;
    public bool isStartTyping = false;
    public bool isPoimaryText = false;
    private void Start()
    {
        if (isStartTyping)
        {
            StartTyping();
        }
        else if (isPoimaryText)
        {
            TypePoimaryText(poimaryText);
        }
    }
    public void StartTyping()
    {
        StartCoroutine(TypeTextIterator());
    }
    private IEnumerator TypeTextIterator()
    {
        textComponent.text = ""; // Clear existing text
        targetText = targetText.Replace("\\n", "\n"); // Replace \n with newline character
        int charIndex = 0;
        while (charIndex < targetText.Length)
        {
            textComponent.text += targetText[charIndex];
            charIndex++;
            yield return new WaitForSeconds(typingSpeed);
        }
        onFinishTyping.Invoke();
    }
    public void TypePoimaryText(string[] poim)
    {
        StartCoroutine(PoimaryTextTyper(poim));
    }
    private IEnumerator PoimaryTextTyper(string[] poim)
    {
        int i = 0;
        while (i < poim.Length)
        {
            textComponent.text = ""; // Clear existing text

            int charIndex = 0;
            string temp = poim[i].Replace("\\n", "\n");
            while (charIndex < temp.Length)
            {
                textComponent.text += temp[charIndex];
                charIndex++;
                yield return new WaitForSeconds(typingSpeed);
            }
            yield return new WaitForSeconds(2);
            i++;
        }
        onFinishTyping.Invoke();
    }
}
