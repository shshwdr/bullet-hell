using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilManager : MonoBehaviour
{
    [SerializeField] float oilEffectTime = 2f;
    [SerializeField] int effectType = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
