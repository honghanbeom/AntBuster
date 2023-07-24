using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private float destroyTime = 7f;
    private float alpha = 1f;
    private Color targetColor;
    private Renderer umaruColor;
    private void Start()
    {
        umaruColor = GetComponent<Renderer>();
        StartCoroutine(ChangeAlpha());
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);       
    }

    private IEnumerator ChangeAlpha()
    {
        yield return new WaitForSeconds(4f); 

        targetColor = umaruColor.material.color;

        float passedTime = 0f;
        float durationTime = 7f;

        while (passedTime < durationTime)
        {
            passedTime += Time.deltaTime;
            alpha -= passedTime / durationTime * 0.005f;
            targetColor = new Color(targetColor.a, targetColor.g, targetColor.b, alpha);
            umaruColor.material.color = targetColor;
            yield return null;  
        }
    }
}
