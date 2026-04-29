using Unity.Mathematics;
using UnityEngine;

public class Lådagram : MonoBehaviour
{
    [SerializeField] float[] numbers;
    [SerializeField] Transform medianPos;
    [SerializeField] Transform kvartil;

    float medianPosInArray;
    float nedreKvartilPosInArray;
    float övreKvartilPosInArray;

    void Start()
    {
        medianPosInArray = numbers.Length / 2;
        nedreKvartilPosInArray = medianPosInArray / 2;
        övreKvartilPosInArray = medianPosInArray * 1.5f;


        medianPos.position = new Vector3(GetMedian(numbers), medianPos.position.y, medianPos.position.z);
        kvartil.position = new Vector3(GetKvartilAvstånd(), kvartil.position.y, kvartil.position.z);
        kvartil.localScale = new Vector3(kvartil.localScale.x, GetKvartilAvstånd(), kvartil.localScale.z);
    }

    void Update()
    {
        
    }

    float GetKvartilAvstånd()
    {
        return GetÖvreKvartil() - GetNedreKvartil();
    }

    float GetNedreKvartil()
    {
        float nedreKvartil = 0;

        if (IsInt(nedreKvartilPosInArray))
        {
            nedreKvartil = numbers[(int)nedreKvartilPosInArray];
        }
        else
        {
            int middleNumber1 = (int)(nedreKvartilPosInArray + 0.5f);
            int middleNumber2 = (int)(nedreKvartilPosInArray - 0.5f);

            nedreKvartil = numbers[middleNumber1 + middleNumber2 / 2];
        }

        return nedreKvartil;
    }

    float GetÖvreKvartil()
    {
        float övreKvartil = 0;

        if (IsInt(nedreKvartilPosInArray))
        {
            övreKvartil = numbers[(int)övreKvartilPosInArray];
        }
        else
        {
            int middleNumber1 = (int)(övreKvartilPosInArray + 0.5f);
            int middleNumber2 = (int)(övreKvartilPosInArray - 0.5f);

            övreKvartil = numbers[middleNumber1 + middleNumber2 / 2];
        }

        return övreKvartil;
    }

    float GetMedian(float[] numbers)
    {
        float median;

        if (IsInt(medianPosInArray))
        {
            median = numbers[(int) medianPosInArray];
        }
        else
        {
            int middleNumber1 = (int) (medianPosInArray + 0.5f);
            int middleNumber2 = (int) (medianPosInArray - 0.5f);

            median = numbers[middleNumber1 +  middleNumber2 / 2];
        }

        return median;
    }

    bool IsInt(float myFloat)
    {
        return Mathf.Approximately(myFloat, Mathf.RoundToInt(myFloat));
    }


}
