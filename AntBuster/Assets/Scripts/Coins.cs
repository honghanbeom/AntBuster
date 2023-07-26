using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coins : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        string clickedObjTag = eventData.pointerPress.tag;
        string clickedObjName = eventData.pointerPress.name;

        if (clickedObjTag == "coins")
        {
            if (clickedObjName == "Gold(Clone)")
            {

                Destroy(eventData.pointerPress.gameObject);
                UIManager.instance.userMoney += 50;
            }
            else if (clickedObjName == "Sliver(Clone)")
            {


                Destroy(eventData.pointerPress.gameObject);
                UIManager.instance.userMoney += 30;
            }
            else if (clickedObjName == "Ruby(Clone)")
            {


                Destroy(eventData.pointerPress.gameObject);
                UIManager.instance.userMoney += 100;
            }
        }
    }
}
