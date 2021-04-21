using DG.Tweening;
using Doozy.Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DSPlayerController : HPCharacterController
{
    [SerializeField] float moveDistance = 2f;
    [SerializeField] float hitBackDistance = 2f;
    [SerializeField] float bulletForce = 1000f;
    [SerializeField] float moveTime = 1f;
    [SerializeField] float slowTimeTo = 1f;
    [SerializeField] float rotateSpeed = 0.4f;
    [SerializeField] Ease easeType;
    [SerializeField] GameObject oilEffect;
    float oilEffectTime = -1;
    bool oilEffectIsOn = false;
    [SerializeField] float oilSlowDown = 0.5f;


    [SerializeField] AudioClip outClip;


    [SerializeField] GameObject drunkEffect;
    float drunkEffectTime = -1;
    bool drunkEffectIsOn = false;

    Rigidbody2D rb;
    Sequence sequence;
    Sequence shakeSequence;
    [SerializeField] SpriteRenderer redBloodSprite;
    [SerializeField] SpriteRenderer arrowSprite;
    [SerializeField] SpriteRenderer cellSprite;
    [SerializeField] GameObject dieAnimation;
    [SerializeField] Sprite oilArrow;
    [SerializeField] Sprite drunkArrow;
    [SerializeField] Sprite normalArrow;

    AudioSource audioSource;
    [SerializeField] AudioClip bounceClip;
    [SerializeField] AudioClip shootClip;


    public bool isMirrorPlayer;

    public Transform arrow;

    public bool willShoot = false;

    Vector3 originPosition;
    Vector3 originScale;

    public float actionInvertal = 0.35f;
    float currentActionTime = 100;
    // Start is called before the first frame update
    protected override void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originPosition = transform.position;
        if (!isMirrorPlayer)
        {

            HUD.Instance.player = this;
            GameManager.Instance.player = this;
        }
        Time.timeScale = 0f;
        var player = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager = player;
        collect(0);
        originScale = cellSprite.transform.localScale;
        audioSource = GetComponent<AudioSource>();

    }

    public void addOilEffect(float t)
    {
        oilEffect.SetActive(true);
        oilEffectIsOn = true;
        oilEffectTime = t;
        arrowSprite.sprite = oilArrow;
    }
    public void removeOilEffect()
    {
        oilEffect.SetActive(false);
        oilEffectIsOn = false;
        arrowSprite.sprite = normalArrow;
        audioSource.PlayOneShot(outClip);
    }

    public void addDrunkEffect(float t)
    {
        drunkEffect.SetActive(true);
        drunkEffectIsOn = true;
        drunkEffectTime = t;
        arrowSprite.sprite = drunkArrow;
    }
    public void removeDrunkEffect()
    {
        drunkEffect.SetActive(false);
        drunkEffectIsOn = false;
        arrowSprite.sprite = normalArrow;
        audioSource.PlayOneShot(outClip);
    }
    Color redBloodColor(float ratio)
    {
        float diff1 = 1 - (100f * ratio) / 255;
        float diff2 =  255;
        Color res = new Color(diff1, diff2, diff2);
        return res;
    }
    public void collect(float ratio)
    {
        if (FindObjectOfType<CollectLevelManager>() && redBloodSprite)
        {
            if (!FindObjectOfType<DeliverLevelManager>())
            {
                ratio = 1 - ratio;
            }
            redBloodSprite.color = redBloodColor(ratio);
        }
    }
    protected override void Die()
    {
        currentActionTime = 100;
        if (CheatManager.Instance.infiniteHPInLevel)
        {
            return;
        }

        base.Die();

        foreach(var bulletManager in GetComponent<BulletFury.BulletCollider>().hitByBullets)
        {
            bulletManager.enabled = false;
        }

        Time.timeScale = 0f;
        sequence.Kill();
        shakeSequence.Kill();
        clearVelocity();

        GameManager.Instance.FailedLevel();

        cellSprite.gameObject. SetActive(false);
        dieAnimation.SetActive(true);
        dieAnimation.transform.position = cellSprite.gameObject.transform.position;
        dieAnimation.transform.rotation = cellSprite.transform.rotation;
        dieAnimation.transform.localScale = cellSprite.transform.localScale;


        //GameEventMessage.SendEvent("gameover");
        //Destroy(gameObject);
        //GetComponent<BulletHell.ProjectileEmitterBase>().isStopped = true;
    }

    public void restart()
    {
        //sequence.Kill();
        //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

        transform.position = originPosition;
        Time.timeScale = 1;
        resurrect();

    }

    public void resurrect()
    {
        hp = 1;
        isDead = false;
    }
    public Vector3 getMouseDirection()
    {
        if (isMirrorPlayer)
        {
            return -GameManager.Instance.player.getMouseDirection();
        }
        var target = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(target);
        var dir = (target - transform.position);
        dir = new Vector3(dir.x, dir.y, 0).normalized ;
        return dir;
    }

    void clearVelocity()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.Sleep();
    }

    bool canShoot()
    {
        if (CheatManager.Instance.canShoot || willShoot)
        {
            return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead || GameManager.Instance. finishedLevel)
        {
            return;
        }
        currentActionTime += Time.deltaTime;
        if (oilEffectIsOn)
        {
            oilEffectTime -= Time.deltaTime;
            if (oilEffectTime <= 0)
            {
                removeOilEffect();
            }
        }

        if (drunkEffectIsOn)
        {
            drunkEffectTime -= Time.deltaTime;
            if (drunkEffectTime <= 0)
            {
                removeDrunkEffect();
            }
        }

        arrow.up = getMouseDirection();
        if (currentActionTime <= actionInvertal)
        {
           // return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            currentActionTime = 0;
            if (TutorialManager.Instance.isInTutorial)
            {
                TutorialManager.Instance.leftClick();
            }
            Time.timeScale = 1;
            sequence.Kill();
            shakeSequence.Kill();

            clearVelocity();


            cellSprite.transform.localScale = originScale;

            shakeSequence = DOTween.Sequence();
            shakeSequence.Append(cellSprite.transform.DOShakeScale(0.3f, 0.6f));
            //transform.DOPunchScale(new Vector3(0.2f,0.2f,0.2f), 0.2f);
            var dir = getMouseDirection() * moveDistance * (oilEffectIsOn ? oilSlowDown : 1) * (drunkEffectIsOn ? -1 : 1);

            rb.AddForce(dir, ForceMode2D.Impulse);
            // DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0, moveTime).SetUpdate(true);
            StartCoroutine(slowDown());
            // The shortcuts way
            //﻿﻿﻿﻿﻿﻿﻿﻿transform.DOMove(new Vector3(2,2,2), 1);
            // The generic way
            if (levelManager)
                levelManager.startLevelMove();
            foreach (var bulletManager in GetComponent<BulletFury.BulletCollider>().hitByBullets)
            {
                bulletManager.isStopped = false;
            }
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.DORotateQuaternion(q, rotateSpeed);

        }
        //else if (Input.GetMouseButtonUp(0))
        //{
        //}
        else if (canShoot() && Input.GetMouseButtonDown(1))
        {
            audioSource.PlayOneShot(shootClip);
            currentActionTime = 0;
            if (TutorialManager.Instance.isInTutorial)
            {
                TutorialManager.Instance.rightClick();
            }
            Time.timeScale = 1;
            shakeSequence.Kill();
            sequence.Kill();
            cellSprite.transform.localScale = originScale;
            clearVelocity();

            shakeSequence = DOTween.Sequence();
            shakeSequence.Append(cellSprite.transform.DOShakeScale(0.3f, 0.6f));
            
            //add back force?
            var bullet = PoolsManager.Instance.bulletManager.getItem();
            bullet.SetActive(true);
            bullet.transform.position = transform.position;

            var dir = getMouseDirection() * bulletForce * (oilEffectIsOn? oilSlowDown:1) * (drunkEffectIsOn ? -1 : 1);
            bullet.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);


            var hitdir = -getMouseDirection() * hitBackDistance;

            rb.AddForce(hitdir, ForceMode2D.Impulse);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.DORotateQuaternion(q, rotateSpeed);

            StartCoroutine(slowDown());
            if (levelManager)
                levelManager.startLevelMove(); 
            foreach (var bulletManager in GetComponent<BulletFury.BulletCollider>().hitByBullets)
            {
                bulletManager.isStopped = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            sequence.Kill();
            Time.timeScale = 1;
        }
    }
    IEnumerator slowDown()
    {
        yield return new WaitForSeconds(0.1f);
        sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => Time.timeScale, x => Time.timeScale = x, slowTimeTo, moveTime).SetEase(easeType).SetUpdate(true));
    }
    private void LateUpdate()
    {
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(bounceClip);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Wound" && GameManager.Instance.currentLevel is PairLevelManager)
    //    {
    //        ((PairLevelManager)GameManager.Instance.currentLevel).pair();
    //    }
    //}
}
