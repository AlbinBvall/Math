using Unity.VisualScripting;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [Header("PythagoreanThearom")]
    [SerializeField] Vector3 pythagoreanNumbers;
    [Header("TanSinCos")]
    [SerializeField] Vector4 tanSinCosAngle;
    [Header("MomentJämnVikt")]
    [SerializeField] Vector2[] forces;
    [SerializeField] float distanceAToB;
    [Header("Moment")]
    [SerializeField] Vector2[] vector2s;
    [SerializeField] float unknownLengthsForce;
    [Header("Friction")]
    [SerializeField] float weight;
    [SerializeField] float friction;

    void Start()
    {
    }
    void Update()
    {
        //Debug.Log(PythagoreanTheorem(numbers.x, numbers.y, numbers.z));
        Debug.Log(TanSinCos(tanSinCosAngle.x, tanSinCosAngle.y, tanSinCosAngle.z, tanSinCosAngle.w));
        Debug.Log(MomentJämnvikt(forces, distanceAToB));
        Debug.Log("Moment: " + Moment(vector2s, unknownLengthsForce));
        Debug.Log("Friction: " + Friction(weight, friction));
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
            Debug.Log("Not enough information given");
            return new Vector4(0, 0, 0, 0);
        }

    }

    public Vector2 MomentJämnvikt(Vector2[] forces , float distanceToUnknown)
    {
        Vector2 totalForce = Vector2.zero;
        float totalMass = 0;

        foreach (Vector2 v in forces)
        {
            totalForce.y += v.x * v.y;
            totalMass += v.y;
        }

        totalForce.y /= distanceToUnknown;

        totalForce.x = totalMass - totalForce.y;

        return totalForce;
    }

    public float Moment(Vector2[] values, float lengthForce)
    {
        float length = 0;
        float totalForce = 0;
        foreach (Vector2 item in values)
        {
            totalForce += item.x * item.y;
        }

        length = totalForce / lengthForce;

        return length;
    }

    public float Friction(float weight, float friction)
    {
        float u = 0;

        u = friction / weight;

        return u;
    }

    public void InputTextFieldTanSinCos(string input)
    {
        string separator = input.ToSeparatedString(";");
        Debug.Log(TanSinCos(
            int.Parse(input.Substring(0, input[int.Parse(separator)])),
            4,
            0,
            0));
    }
}
