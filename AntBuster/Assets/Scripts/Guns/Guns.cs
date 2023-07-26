using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class Guns : MonoBehaviour, IPointerClickHandler
{
    private ClickManager clickManager;

    public int damage;
    public float range;
    public float attackSpeed;
    private float delayTime;

    public GameObject gun;
    public Transform target;
    public GameObject bulletPrefab;
    public Animator animator;


    #region IClick
    // 유닛 가격 pistol 50, rifle 100, shotgun 100;
    GameObject ui;
    GameObject _createButton;
    GameObject _riffleButton;
    GameObject _shotGunButton;
    GameObject _sellButton;

    public GameObject[] guns;

    Vector2 enemyPosition;
    Collider2D[] colliders;

    #region enable color rgba
    float r = 82f / 255f;
    float g = 74f / 255f;
    float b = 74f / 255f;
    float a = 0.4f;
    #endregion

    #region colors of original
    private Color originalCreateColor;
    private Color originalRiffleColor;
    private Color originalShotGunColor;
    private Color originalSellColor;
    #endregion

    #endregion

    public void Awake()
    {
        clickManager = ClickManager.instance;
        ui = GFunc.GetRootObject("UI");
        _createButton = ui.FindChildObject("Pistol_button");
        _riffleButton = ui.FindChildObject("Rifle_button");
        _shotGunButton = ui.FindChildObject("ShotGun_button");
        _sellButton = ui.FindChildObject("Sell_button");

    }



    public void Start()
    { 
        gun = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        delayTime = 0f;
    }

    public void Update()
    {
        // 적 오브젝트가 사거리 안에 있는지 체크
        colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders)
        {
            // 원형 영역 안에 있는 적 오브젝트의 태그를 확인하고 원하는 태그인 경우 위치를 받아옴
            if (collider.CompareTag("Umaru"))
            {
                enemyPosition = collider.transform.position;
                // 이제 enemyPosition 변수에 적 오브젝트의 위치 정보가 저장됨
                break; // 원하는 적 오브젝트를 찾았으므로 루프를 빠져나옴
            }
        }
        Attack();
    }

    public void Attack()
    {
        delayTime += Time.deltaTime;
        if (VectorDis(enemyPosition) < range && colliders.Length > 0)
        {
            if (delayTime > attackSpeed)
            {
                animator.SetTrigger("isFire");
                GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position,
                    gameObject.transform.rotation);
                delayTime = 0f;
            }
        }
        else
        {
        }
    }

    public float VectorDis(Vector2 position)
    {
        float disVec = Vector2.Distance(position , transform.position);
        return disVec;
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

            riffleButton.image.color = originalRiffleColor;
            shotGunButton.image.color = originalShotGunColor;
            sellButton.image.color = originalCreateColor;

            createButton.interactable = false;
            createButton.image.color = new Color(r, g, b, a);

            sellButton.onClick.AddListener(SellUnit);
            riffleButton.onClick.AddListener(UpgradeRifle);
            shotGunButton.onClick.AddListener(UpgradeShotGun);
            clickManager.OnObjectClicked(gameObject);


        }
        if (clickedObjTag == "Rifle" || clickedObjTag == "ShotGun") // 다른 총이면
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

    public void UpgradeRifle()
    {
        if (gameObject.CompareTag("Pistol"))
        {
            Destroy(gameObject);
            GameObject rifle;
            rifle = Instantiate(guns[0], gameObject.transform.position,
                gameObject.transform.rotation);
            UIManager.instance.userMoney -= 100;
        }

    }

    public void UpgradeShotGun()
    {
        if (gameObject.CompareTag("Pistol"))
        {
            Destroy(gameObject);
            GameObject shotGun;
            shotGun = Instantiate(guns[1], gameObject.transform.position,
                gameObject.transform.rotation);
            UIManager.instance.userMoney -= 100;
        }

    }
}

