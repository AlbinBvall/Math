using UnityEngine;

public class PrimeNumbers : MonoBehaviour
{
    [SerializeField] int primeIndex = 0;

    int[] numberToCheck = new int[500000000];
    int[] primeNumbers = new int[27000000];

    int n;
    int primeCount = 0;


    void Start()
    {
        primeNumbers[0] = 2;

        for (int i = 1; i < numberToCheck.Length; i++)
        {
             numberToCheck[i] = i;
        }

        Debug.Log("Total prime numbers between 2 and " + numberToCheck[numberToCheck.Length -1] + ": " + PrimeNumber());
        Debug.Log("Value: " + PrimeNumberValue(primeIndex));
    }

    int PrimeNumber()
    {
        
        for (int i = 3; i < numberToCheck.Length; i++)
        {
            n = i;
            IsPrime();
        }
        return primeCount +1;
    }

    void IsPrime()
    {
        int p = 1;
        for (int o = 0; primeNumbers[o] < numberToCheck[n]; o++)
        {
            if (numberToCheck[n] % primeNumbers[o] == 0) // divisible
            {
                return;
            }
            else // not divisible
            {
                p = primeNumbers[o];

                if (primeNumbers[o] >= numberToCheck[n] / p) // not divisible by anything
                {
                    AddToArray();
                    return;
                }
            }
        }
    }

    void AddToArray()
    {
        primeCount++;
        primeNumbers[primeCount] = numberToCheck[n];
    }

    int PrimeNumberValue(int primeIndex)
    {
        if (primeNumbers[primeIndex -1] == 0)
        {
            Debug.Log("unknown");
        }
        return primeNumbers[primeIndex -1];
    }

    
    public void InputTextField(string input)
    {
        Debug.Log(primeNumbers[int.Parse(input) -1]);
    }
}
