//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class ClickSell : MonoBehaviour, IPointerClickHandler
//{
//    #region IClick
//    // ���� ���� pistol 50, rifle 100, shotgun 100;
//    GameObject ui;
//    GameObject _createButton;
//    GameObject _riffleButton;
//    GameObject _shotGunButton;
//    GameObject _sellButton;



//    #region enable color rgba
//    float r = 82f / 255f;
//    float g = 74f / 255f;
//    float b = 74f / 255f;
//    float a = 0.4f;
//    #endregion

//    #region colors of original
//    private Color originalCreateColor;
//    private Color originalRiffleColor;
//    private Color originalShotGunColor;
//    private Color originalSellColor;
//    #endregion

//    public void Awake()
//    {
//        ui = GFunc.GetRootObject("UI");
//        _createButton = ui.FindChildObject("Pistol_button");
//        _riffleButton = ui.FindChildObject("Rifle_button");
//        _shotGunButton = ui.FindChildObject("ShotGun_button");
//        _sellButton = ui.FindChildObject("Sell_button");
//    }



//    #endregion


//    public void OnPointerClick(PointerEventData eventData)
//    {
//        string clickedObjTag = eventData.pointerPress.tag;
//        string clickedObjName = eventData.pointerPress.name;

//        Button createButton = _createButton.GetComponent<Button>();
//        Button riffleButton = _riffleButton.GetComponent<Button>();
//        Button shotGunButton = _shotGunButton.GetComponent<Button>();
//        Button sellButton = _sellButton.GetComponent<Button>();

//        originalCreateColor = createButton.image.color;
//        originalRiffleColor = riffleButton.image.color;
//        originalShotGunColor = shotGunButton.image.color;
//        originalSellColor = sellButton.image.color;

//        if (clickedObjTag == "Pistol")
//        {
//            riffleButton.interactable = true;
//            shotGunButton.interactable = true;
//            sellButton.interactable = true;
//            createButton.interactable = false;

//            createButton.image.color = new Color(r, g, b, a);
//            sellButton.image.color = originalSellColor;
//            riffleButton.image.color = originalRiffleColor;
//            shotGunButton.image.color = originalShotGunColor;

//            sellButton.onClick.AddListener(SellUnit);

//        }
//        if (clickedObjTag == "Rifle" || clickedObjTag == "ShotGun") // �ٸ� ���̸�
//        {
//            createButton.interactable = false;
//            riffleButton.interactable = false;
//            shotGunButton.interactable = false;
//            sellButton.interactable = true;

//            riffleButton.image.color = new Color(r, g, b, a);
//            shotGunButton.image.color = new Color(r, g, b, a);
//            createButton.image.color = new Color(r, g, b, a);
//            sellButton.image.color = originalSellColor;

//            sellButton.onClick.AddListener(SellUnit);
//        }
//    }// OnPointerClick


//    public void SellUnit()
//    {
//        if (gameObject.CompareTag("Pistol"))
//        {
//            Destroy(gameObject);
//            UIManager.instance.userMoney += 50;
//        }
//        else if (gameObject.CompareTag("Rifle"))
//        {
//            Destroy(gameObject);
//            UIManager.instance.userMoney += 100;
//        }
//        else if (gameObject.CompareTag("ShotGun"))
//        {
//            Destroy(gameObject);
//            UIManager.instance.userMoney += 100;
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickSell : MonoBehaviour, IPointerClickHandler
{
    private ClickManager clickManager;
    private GameObject lastClickedObject;

    // ���� ���� pistol 50, rifle 100, shotgun 100;
    GameObject ui;
    GameObject _createButton;
    GameObject _riffleButton;
    GameObject _shotGunButton;
    GameObject _sellButton;

    #region enable color rgba
    float r = 82f / 255f;
    float g = 74f / 255f;
    float b = 74f / 255f;
    float a = 0.4f;
    #endregion

    #region colors of original
    private Color originalCreateColor { get; set; }
    private Color originalRiffleColor { get; set; }
    private Color originalShotGunColor { get; set; }
    private Color originalSellColor { get; set; }
    #endregion

    public void Awake()
    {
        clickManager = ClickManager.instance; // ClickManager �ν��Ͻ� ��������

        ui = GFunc.GetRootObject("UI");
        _createButton = ui.FindChildObject("Pistol_button");
        _riffleButton = ui.FindChildObject("Rifle_button");
        _shotGunButton = ui.FindChildObject("ShotGun_button");
        _sellButton = ui.FindChildObject("Sell_button");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string clickedObjTag = eventData.pointerPress.tag;
        string clickedObjName = eventData.pointerPress.name;

        Button createButton = _createButton.GetComponent<Button>();
        Button riffleButton = _riffleButton.GetComponent<Button>();
        Button shotGunButton = _shotGunButton.GetComponent<Button>();
        Button sellButton = _sellButton.GetComponent<Button>();

        originalCreateColor = createButton.image.color;
        originalRiffleColor = riffleButton.image.color;
        originalShotGunColor = shotGunButton.image.color;
        originalSellColor = sellButton.image.color;

        if (clickedObjTag == "Pistol")
        {
            riffleButton.interactable = true;
            shotGunButton.interactable = true;
            sellButton.interactable = true;
            createButton.interactable = false;

            createButton.image.color = new Color(r, g, b, a);
            sellButton.image.color = originalSellColor;
            riffleButton.image.color = originalRiffleColor;
            shotGunButton.image.color = originalShotGunColor;

            sellButton.onClick.AddListener(SellUnit);

            // ���������� Ŭ���� ��ü�� ClickManager�� ���� ����
            clickManager.OnObjectClicked(gameObject);
        }
        else if (clickedObjTag == "Rifle" || clickedObjTag == "ShotGun") // �ٸ� ���̸�
        {
            createButton.interactable = false;
            riffleButton.interactable = false;
            shotGunButton.interactable = false;
            sellButton.interactable = true;

            riffleButton.image.color = new Color(r, g, b, a);
            shotGunButton.image.color = new Color(r, g, b, a);
            createButton.image.color = new Color(r, g, b, a);
            sellButton.image.color = originalSellColor;

            sellButton.onClick.AddListener(SellUnit);

            // ���������� Ŭ���� ��ü�� ClickManager�� ���� ����
            clickManager.OnObjectClicked(gameObject);
        }
    }// OnPointerClick

    public void SellUnit()
    {
        if (gameObject.CompareTag("Pistol"))
        {
            Destroy(gameObject);
            UIManager.instance.userMoney += 50;
        }
        else if (gameObject.CompareTag("Rifle"))
        {
            Destroy(gameObject);
            UIManager.instance.userMoney += 100;
        }
        else if (gameObject.CompareTag("ShotGun"))
        {
            Destroy(gameObject);
            UIManager.instance.userMoney += 100;
        }
    }
}

