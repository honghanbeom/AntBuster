using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static ClickManager instance;

    private GameObject clickedObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != null)
                Destroy(gameObject);
        }
    }

    // 클릭된 오브젝트를 설정하는 메서드
    public void OnObjectClicked(GameObject clickedObject)
    {
        // 새로운 클릭이 발생하면 이전에 저장된 선택을 지웁니다.
        if (this.clickedObject != null)
        { 
            Destroy(this.clickedObject);
        }

        this.clickedObject = clickedObject;
    }

    // 클릭된 오브젝트를 반환하는 메서드
    public GameObject GetClickedObject()
    {
        return clickedObject;
    }
}
