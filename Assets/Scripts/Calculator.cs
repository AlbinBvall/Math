using System;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] Vector3 numbers;
    [SerializeField] Vector4 numbers2;
    void Start()
    {
    }
    void Update()
    {
        //Debug.Log(PythagoreanTheorem(numbers.x, numbers.y, numbers.z));
        Debug.Log(TanSinCos(numbers2.x, numbers2.y, numbers2.z, numbers2.w));
    }

    public float PythagoreanTheorem(float a, float b, float c) // unknown variable is written as 0
    {
        if (a == 0)
        {
            return Mathf.Sqrt(Mathf.Pow(c, 2) - Mathf.Pow(b, 2));
        }
        else if (b == 0)
        {
            return Mathf.Sqrt(Mathf.Pow(c, 2) -  Mathf.Pow(a, 2));
        }
        return Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
    }

    public Vector4 TanSinCos2Var(float a, float b, float c,  float v)
    {
        if (a != 0 && b != 0 && c == 0 && v == 0)
        {
            return new Vector4(a, b, c, Mathf.Atan(a / b));
        }
        else if (v == 0 && a != 0 && c != 0)
        {
            return new Vector4 (Mathf.Asin(a / c), 1, 1, 1);
        }
        else if (v == 0 && b != 0 && c != 0)
        {
            return new Vector4(Mathf.Acos(b / c), 1, 1 ,1);
        }
        else if (a != 0)
        {
           return new Vector4 (a / Mathf.Sin(v), 1, 1, 1);
        }
        else if (b != 0)
        {
            return new Vector4(b / Mathf.Cos(v), 1, 1, 1);
        }

        return new Vector4 (1, 1, 1 ,1);
    }

    public Vector4 TanSinCos(float a, float b, float c, float v)
    {
        if (a == 0 && b == 0 && c != 0 && v != 0)
        {
            float unknownA = Mathf.Sin(v) * c;
            float unknownB = Mathf.Cos(v) * c;

            return new Vector4(unknownA, unknownB, c, v);
        }
        else if (a != 0 && b == 0 && c == 0 && v != 0)
        {
            float unknownB = a / Mathf.Tan(v);
            float unknownC = a / Mathf.Sin(v);

            return new Vector4(a, unknownB, unknownC, v);
        }
        else if (a != 0 && b != 0 && c == 0 && v == 0)
        {
            float unknownC = PythagoreanTheorem(a, b, 0);
            float unknownV = Mathf.Atan(a / b) * Mathf.Rad2Deg;

            return new Vector4(a, b, unknownC, unknownV);
        }
        else if (a == 0 && b != 0 && c != 0 && v == 0)
        {
            float unknownV = Mathf.Acos(b / c) * Mathf.Rad2Deg;
            float unknownA = PythagoreanTheorem(0, b, c);

            return new Vector4(unknownA, b, c, unknownV);
        }
        else if (a == 0 && b != 0 && c == 0 && v != 0)
        {
            float unknownA = b * Mathf.Tan(v);
            float unknownC = b / Mathf.Cos(v);

            return new Vector4(unknownA, b, unknownC, v);
        }
        else if (a != 0 && b == 0 && c != 0 && v == 0)
        {
            float unknownB = PythagoreanTheorem(a, 0, c);
            float unknownV = Mathf.Asin(a / c) * Mathf.Rad2Deg;

            return new Vector4(a, unknownB, c, unknownV);
        }
        else
        {
            return new Vector4(0, 0, 0, 0);
        }

    }
}
