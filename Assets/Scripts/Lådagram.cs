using UnityEngine;
using System.Collections;
using System;

public class Lådagram : MonoBehaviour
{
    [SerializeField] float[] numbers;
    [SerializeField] float scale = 1;
    [SerializeField] Transform medianPos;
    [SerializeField] Transform kvartil;
    [SerializeField] Transform minstaVärde;
    [SerializeField] Transform högstaVärde;

    float medianPosInArray;
    float nedreKvartilPosInArray;
    float övreKvartilPosInArray;
    float timePassed;
    float prevTime;

    void Start()
    {
        DateTime prevTime = DateTime.Now;
        SortArray(numbers);
        DateTime currentTime = DateTime.Now;
        TimeSpan duration = currentTime.Subtract(prevTime);
        Debug.Log("Time Calculating: " + duration.TotalMilliseconds);
    }

    void Update()
    {  


        medianPos.position = new Vector3(GetMedian(numbers), medianPos.position.y, medianPos.position.z) / scale;
        kvartil.position = new Vector3(GetKvartilAvstånd(numbers) / 2 + GetNedreKvartil(numbers), kvartil.position.y, kvartil.position.z) / scale;
        kvartil.localScale = new Vector3(kvartil.localScale.x, GetKvartilAvstånd(numbers), kvartil.localScale.z) / scale;
        minstaVärde.position = new Vector3(numbers[0], minstaVärde.position.y, minstaVärde.position.z) / scale;
        högstaVärde.position = new Vector3(numbers[^1], högstaVärde.position.y, högstaVärde.position.z) / scale;
    }



    public float[] SortArray(float[] numbers)
    {
        for (int last = numbers.Length; last > 0; last--)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[i - 1])
                {
                    (numbers[i - 1], numbers[i]) = (numbers[i], numbers[i - 1]);
                }
            }
        }
        return numbers;
    }

    public bool IsSorted(float[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] > numbers[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    public float GetKvartilAvstånd(float[] numbers)
    {
        return GetÖvreKvartil(numbers) - GetNedreKvartil(numbers);
    }

    public float GetNedreKvartil(float[] numbers)
    {
        nedreKvartilPosInArray = numbers.Length / 4;
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

    public float GetÖvreKvartil(float[] numbers)
    {
        övreKvartilPosInArray = numbers.Length / 2 * 1.5f;
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

    public float GetMedian(float[] numbers)
    {
        medianPosInArray = numbers.Length / 2;
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

    public bool IsInt(float myFloat)
    {
        return myFloat == (int) myFloat;
    }


}
