using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilManager : MonoBehaviour
{
    [SerializeField] float oilEffectTime = 2f;
    [SerializeField] int effectType = 0;


    [SerializeField] List<Sprite> oilSprites;
    [SerializeField] List<Sprite> drunkSprites;
    SpriteRenderer spriteRenderer;



    AudioSource audioSource;

    [SerializeField] List<AudioClip> clips;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(effectType == 0)
        {
            spriteRenderer.sprite = oilSprites[Random.Range(0, oilSprites.Count)];
        }
        else
        {
            spriteRenderer.sprite = drunkSprites[Random.Range(0, drunkSprites.Count)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<DSPlayerController>())
        {
            audioSource.PlayOneShot(clips[effectType]);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.GetComponent<DSPlayerController>())
        {
            if(effectType == 0)
            {

                collision.GetComponent<DSPlayerController>().addOilEffect(oilEffectTime);
            }
            else
            {

                collision.GetComponent<DSPlayerController>().addDrunkEffect(oilEffectTime);
            }
        }
    }
}
