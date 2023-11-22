using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class TypewriterEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float typewriterSpeed = 50f;

    public Coroutine Run(string textTotypo, TMP_Text textLabel)
    {
       return StartCoroutine(TypeText(textTotypo, textLabel));
    }

    private IEnumerator TypeText(string textTotype, TMP_Text textLabel)
        
    {
        textLabel.text = string.Empty;
        float t = 0;
        int chartIndex = 0;

        while (chartIndex < textTotype.Length)
        {
            t += Time.deltaTime * typewriterSpeed;
            chartIndex = Mathf.FloorToInt(t);
            chartIndex = Mathf.Clamp(chartIndex, 0, textTotype.Length);
        
            
            textLabel.text = textTotype.Substring(0, chartIndex);

           yield return null;
        }
        textLabel.text = textTotype;
    }
}
