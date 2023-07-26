//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class CreatePistol : MonoBehaviour, IPointerClickHandler
//{
//    GameObject ui;
//    GameObject _createButton;
//    GameObject _riffleButton;
//    GameObject _shotGunButton;
//    GameObject _sellButton;

//    float r = 82f / 255f;
//    float g = 74f / 255f;
//    float b = 74f / 255f;
//    float a = 0.4f;

//    private Color originalCreateColor;
//    private Color originalRiffleColor;
//    private Color originalShotGunColor;
//    private Color originalSellColor;


//    private void Awake()
//    {
//        ui = GFunc.GetRootObject("UI");
//        _createButton = ui.FindChildObject("Pistol_button");
//        _riffleButton = ui.FindChildObject("Rifle_button");
//        _shotGunButton = ui.FindChildObject("ShotGun_button");
//        _sellButton = ui.FindChildObject("Sell_button");

//        originalCreateColor = _createButton.GetComponent<Button>().image.color;
//        originalRiffleColor = _riffleButton.GetComponent<Button>().image.color;
//        originalShotGunColor = _shotGunButton.GetComponent<Button>().image.color;
//        originalSellColor = _sellButton.GetComponent<Button>().image.color; 
//    }

//    public void OnPointerClick(PointerEventData eventData)
//    {
//        string clickedObjTag = eventData.pointerPress.tag;

//        Button createButton = _createButton.GetComponent<Button>();
//        Button riffleButton = _riffleButton.GetComponent<Button>();
//        Button shotGunButton = _shotGunButton.GetComponent<Button>();
//        Button sellButton = _sellButton.GetComponent<Button>();

//        originalCreateColor = createButton.image.color;
//        originalRiffleColor = riffleButton.image.color;
//        originalShotGunColor = shotGunButton.image.color;
//        originalSellColor = sellButton.image.color;

//        if (clickedObjTag == "NullCheck")
//        {
//            createButton.interactable = true;
//            sellButton.interactable = false;
//            shotGunButton.interactable = false;
//            riffleButton.interactable = false;

//            createButton.image.color = originalCreateColor;
//            sellButton.image.color = new Color(r, g, b, a);
//            shotGunButton.image.color = new Color(r, g, b, a);
//            riffleButton.image.color = new Color(r, g, b, a);
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreatePistol : MonoBehaviour, IPointerClickHandler
{

    public GameObject pistolPrefab;
    public LayerMask towerSpaceLayer;
    private int towerSpaceCount = 0;

    GameObject ui;
    GameObject _createButton;
    GameObject _riffleButton;
    GameObject _shotGunButton;
    GameObject _sellButton;

    float r = 82f / 255f;
    float g = 74f / 255f;
    float b = 74f / 255f;
    float a = 0.4f;

    private Color originalCreateColor;
    private Color originalRiffleColor;
    private Color originalShotGunColor;
    private Color originalSellColor;


    private void Awake()
    {

        ui = GFunc.GetRootObject("UI");
        _createButton = ui.FindChildObject("Pistol_button");
        _riffleButton = ui.FindChildObject("Rifle_button");
        _shotGunButton = ui.FindChildObject("ShotGun_button");
        _sellButton = ui.FindChildObject("Sell_button");

        originalCreateColor = _createButton.GetComponent<Button>().image.color;
        originalRiffleColor = _riffleButton.GetComponent<Button>().image.color;
        originalShotGunColor = _shotGunButton.GetComponent<Button>().image.color;
        originalSellColor = _sellButton.GetComponent<Button>().image.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string clickedObjTag = eventData.pointerPress.tag;

        Button createButton = _createButton.GetComponent<Button>();
        Button riffleButton = _riffleButton.GetComponent<Button>();
        Button shotGunButton = _shotGunButton.GetComponent<Button>();
        Button sellButton = _sellButton.GetComponent<Button>();

        originalCreateColor = createButton.image.color;
        originalRiffleColor = riffleButton.image.color;
        originalShotGunColor = shotGunButton.image.color;
        originalSellColor = sellButton.image.color;

        if (clickedObjTag == "NullCheck")
        {
            createButton.interactable = true;
            sellButton.interactable = false;
            shotGunButton.interactable = false;
            riffleButton.interactable = false;

            createButton.image.color = originalCreateColor;
            sellButton.image.color = new Color(r, g, b, a);
            shotGunButton.image.color = new Color(r, g, b, a);
            riffleButton.image.color = new Color(r, g, b, a);


            createButton.onClick.AddListener(CreateTower);
        }
    }


    void CreateTower()
    {
        if (UIManager.instance.userMoney >= 50 && towerSpaceCount < 4)
        {
            //UIManager.instance.userMoney -= 50;
            //// 2.2f , 0.8f, -0.6f, -2f;
            //Vector3 position = new Vector3(0f, -0.6f, 0f);
            //GameObject pistol;
            //pistol = Instantiate(pistolPrefab, position, Quaternion.identity);
            //towerSpaceCount++;
            float[] positions = new float[] { 2.2f, 0.8f, -0.6f, -2f };
            Vector3 position = new Vector3(0f, positions[towerSpaceCount], 0f);
            GameObject pistol = Instantiate(pistolPrefab, position, Quaternion.identity);
            towerSpaceCount++;













        }
    }
}

