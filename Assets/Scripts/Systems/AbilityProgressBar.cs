using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityProgressBar : MonoBehaviour
{
    public float maximum;
    public float current;
    public Image mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void AddProgress()
    {

    }
    void GetCurrentFill()
    {
        float fillAmount = (current)/(maximum);
        mask.fillAmount = fillAmount;
    }
}
