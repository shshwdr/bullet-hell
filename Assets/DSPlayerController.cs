﻿using DG.Tweening;
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


    [SerializeField] GameObject drunkEffect;
    float drunkEffectTime = -1;
    bool drunkEffectIsOn = false;

    Rigidbody2D rb; 
    Sequence sequence;
    [SerializeField] SpriteRenderer redBloodSprite;

    public bool isMirrorPlayer;

    public Transform arrow;

    public bool willShoot = false;

    Vector3 originPosition;
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

    }

    public void addOilEffect(float t)
    {
        oilEffect.SetActive(true);
        oilEffectIsOn = true;
        oilEffectTime = t;
    }
    public void removeOilEffect()
    {
        oilEffect.SetActive(false);
        oilEffectIsOn = false;
    }

    public void addDrunkEffect(float t)
    {
        drunkEffect.SetActive(true);
        drunkEffectIsOn = true;
        drunkEffectTime = t;
    }
    public void removeDrunkEffect()
    {
        drunkEffect.SetActive(false);
        drunkEffectIsOn = false;
    }
    Color redBloodColor(float ratio)
    {
        float diff1 = 1 - (155f * ratio) / 255;
        float diff2 = 1 - (ratio) / 255;
        Color res = new Color(diff1, diff2, diff2);
        return res;
    }
    public void collect(float ratio)
    {
        if (FindObjectOfType<CollectLevelManager>() && redBloodSprite)
        {
            if (FindObjectOfType<DeliverLevelManager>())
            {
                ratio = 1 - ratio;
            }
            redBloodSprite.color = redBloodColor(ratio);
        }
    }
    protected override void Die()
    {

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
        clearVelocity();

        GameManager.Instance.FailedLevel();

        //GameEventMessage.SendEvent("gameover");
        //Destroy(gameObject);
        //GetComponent<BulletHell.ProjectileEmitterBase>().isStopped = true;
    }

    public void restart()
    {
        //sequence.Kill();
        //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

        BulletHell.ProjectileManager.Instance.clearAllProjectiles();
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

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            sequence.Kill();
            clearVelocity();


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
            Time.timeScale = 1;
            sequence.Kill();
            clearVelocity();
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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Wound" && GameManager.Instance.currentLevel is PairLevelManager)
    //    {
    //        ((PairLevelManager)GameManager.Instance.currentLevel).pair();
    //    }
    //}
}
