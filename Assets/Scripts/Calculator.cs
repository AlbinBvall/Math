using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] Vector3 numbers;
    void Start()
    {
    }
    void Update()
    {
        Debug.Log(PythagoreanTheorem(numbers.x, numbers.y, numbers.z));

    }

    public float PythagoreanTheorem(float a, float b, float c) // unknown variable is written 0
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

    public float TanSinCos(float a, float b, float c,  float v)
    {
        if (v == 0 && a != 0 && b != 0)
        {
            return Mathf.Atan(a / b);
        }
        else if (v == 0 && a != 0 && c != 0)
        {
            return Mathf.Asin(a / c);
        }
        else if (v == 0 && b != 0 && c != 0)
        {
            return Mathf.Acos(b / c);
        }

        return 1;
    }
}
