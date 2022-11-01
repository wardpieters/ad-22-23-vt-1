using System;
using System.Text.RegularExpressions;

namespace AD
{
    public class BigInt
    {
        public BigIntDigit first;
        public bool isPositive = true;

        public BigInt(string number)
        {
            if (number == null || number.Length == 0)
            {
                first = new BigIntDigit(0);
                isPositive = true;
                return;
            }

            Regex valid_Regex = new Regex(@"^(0|(-?[1-9][0-9]*))$", 0);
            if (!valid_Regex.IsMatch(number))
            {
                throw new BigIntWrongInputException();
            }

            /*
             * From here you can start to build your list of BigIntDigit's.
             */
            // split all characters in numbers
            char[] numbers = number.ToCharArray();
            // var numbers = number.Split("");

            foreach (var character in numbers)
            {
                if (character.ToString().Equals("-"))
                {
                    isPositive = false;
                }
                else
                {
                    int value = Int32.Parse(character.ToString());
                    
                    if (first == null)
                    {
                        first = new BigIntDigit(value);
                    }
                    else
                    {
                        var old = first;
                        first = new BigIntDigit(value);
                        first.next = old;
                    }
                }
            }
        }

        public override string ToString()
        {
            if (first == null || (first.value == 0 && first.next == null))
            {
                return "0";
            }

            var output = String.Empty;

            var currentNode = first;
            while (currentNode != null)
            {
                output += currentNode.value;
                
                currentNode = currentNode.next;
            }

            // Reverse string
            char[] charArray = output.ToCharArray();
            Array.Reverse(charArray);
            output = new string(charArray);
            
            return (isPositive ? "" : "-") + output;
        }

        public int Sum()
        {
            int sum = 0;

            var currentNode = first;
            while (currentNode != null)
            {
                sum += currentNode.value;
                
                currentNode = currentNode.next;
            }

            return sum;
        }

        public void Increment()
        {
            var currentNode = first;
            currentNode.value += 1;
            
            while (currentNode != null && currentNode.value > 9)
            {
                currentNode.value = 0;

                if (currentNode.next == null)
                {
                    currentNode.next = new BigIntDigit(1);
                } else currentNode.next.value += 1;
                
                currentNode = currentNode.next;
            }
        }

        public void IncrementBetter()
        {
            var increment = isPositive ? 1 : -1;
            var currentNode = first;
            currentNode.value += increment;
            
            while (currentNode != null && (currentNode.value > 9 || currentNode.value < 0))
            {
                currentNode.value = isPositive ? 0 : 9;

                if (currentNode.next == null)
                {
                    currentNode.next = new BigIntDigit(increment);
                }
                else
                {
                    currentNode.next.value += increment;

                    if (currentNode.next.value == 0)
                    {
                        currentNode.next = null;
                    }
                }
                
                currentNode = currentNode.next;
            }

            if (first.next == null && first.value == 0)
            {
                isPositive = true;
            }
        }
    }

    public class BigIntWrongInputException : System.Exception
    {
    }
}
