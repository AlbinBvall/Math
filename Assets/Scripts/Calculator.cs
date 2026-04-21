using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] Vector3 pythagoreanNumbers;
    [SerializeField] Vector4 tanSinCosAngle;

    void Start()
    {
    }
    void Update()
    {
        //Debug.Log(PythagoreanTheorem(numbers.x, numbers.y, numbers.z));
        Debug.Log(TanSinCos(tanSinCosAngle.x, tanSinCosAngle.y, tanSinCosAngle.z, tanSinCosAngle.w));
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

    public Vector4 TanSinCos(float a, float b, float c, float v) // uses two variables only, if not used, write 0
    {
        if (a == 0 && b == 0 && c != 0 && v != 0) // knows c and v
        {
            float unknownA = Mathf.Sin(Mathf.Deg2Rad * v) * c;
            float unknownB = Mathf.Cos(Mathf.Deg2Rad * v) * c;

            return new Vector4(unknownA, unknownB, c, v);
        }
        else if (a != 0 && b == 0 && c == 0 && v != 0) // knows a and v
        {
            float unknownB = a / Mathf.Tan(Mathf.Deg2Rad * v);
            float unknownC = a / Mathf.Sin(Mathf.Deg2Rad * v);

            return new Vector4(a, unknownB, unknownC, v);
        }
        else if (a != 0 && b != 0 && c == 0 && v == 0) // knows a and b
        {
            float unknownC = PythagoreanTheorem(a, b, 0);
            float unknownV = Mathf.Atan(a / b) * Mathf.Rad2Deg;

            return new Vector4(a, b, unknownC, unknownV);
        }
        else if (a == 0 && b != 0 && c != 0 && v == 0) // knows b and c
        {
            float unknownV = Mathf.Acos(b / c) * Mathf.Rad2Deg;
            float unknownA = PythagoreanTheorem(0, b, c);

            return new Vector4(unknownA, b, c, unknownV);
        }
        else if (a == 0 && b != 0 && c == 0 && v != 0) // knows b and v
        {
            float unknownA = b * Mathf.Tan(Mathf.Deg2Rad * v);
            float unknownC = b / Mathf.Cos(Mathf.Deg2Rad * v);

            return new Vector4(unknownA, b, unknownC, v);
        }
        else if (a != 0 && b == 0 && c != 0 && v == 0) // knows a and c
        {
            float unknownB = PythagoreanTheorem(a, 0, c);
            float unknownV = Mathf.Asin(a / c) * Mathf.Rad2Deg;

            return new Vector4(a, unknownB, c, unknownV);
        }
        else // not enough information
        {
            return new Vector4(0, 0, 0, 0);
        }

    }

    public void InputTextFieldTanSinCos(string input)
    {
        Debug.Log(TanSinCos(
            int.Parse(input.Substring(input.LastIndexOf(';'))),
            4,
            0,
            0));
    }
}
