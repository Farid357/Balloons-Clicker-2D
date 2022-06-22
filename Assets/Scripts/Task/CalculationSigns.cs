using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Tools
{
    public static class CalculationSigns
    {
        private static string[] _signsStandart = new string[] { "+", "-" };
        private static string _sign;

        public static string GetStandart(Image[] images)
        {
            var index = UnityEngine.Random.Range(0, _signsStandart.Length);
            images[index].gameObject.SetActive(true);
            return _signsStandart[index];
        }
        public static int GetResult(int firstNumber, int secondNumber, Image[] images)
        {
            _sign = GetStandart(images);
            var result = 0;

            if (_sign == "+")
            {
                result = firstNumber + secondNumber;
            }

            else if (_sign == "-")
            {
                result = firstNumber - secondNumber;
            }

            else
                throw new InvalidOperationException("Sign is wrong!");

            return result;
        }
       public static bool CheckResult(int result, string answer)
        {
            if (result.ToString() == answer)
                return true;

            return false;
        }
    }
}
