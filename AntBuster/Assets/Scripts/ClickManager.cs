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

    // Ŭ���� ������Ʈ�� �����ϴ� �޼���
    public void OnObjectClicked(GameObject clickedObject)
    {
        // ���ο� Ŭ���� �߻��ϸ� ������ ����� ������ ����ϴ�.
        if (this.clickedObject != null)
        { 
            Destroy(this.clickedObject);
        }

        this.clickedObject = clickedObject;
    }

    // Ŭ���� ������Ʈ�� ��ȯ�ϴ� �޼���
    public GameObject GetClickedObject()
    {
        return clickedObject;
    }
}
