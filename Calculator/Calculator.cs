using ArrayBasedStack;
using LinkedListBasedStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Calculator
    {
        private static readonly Dictionary<char, int> _operationPriority = new Dictionary<char, int>
        {
            {')', 5 },
            {'^', 4 },
            {'*', 3 },
            {'/', 3 },
            {'+', 2 },
            {'-', 2 },
            {'(', 1 }
        };

        public static string PostfixConverter(string infixExpression)
        {
            var operatorStack = new ArrayBasedStack<char>();
            var postfixExpression = string.Empty;

            for (int i = 0; i < infixExpression.Length; i++)
            {
                if (infixExpression[i] == '(')
                {
                    operatorStack.Push(infixExpression[i]);
                }
                else if (infixExpression[i] == ')')
                {
                    while (!operatorStack.Empty() && operatorStack.Top() != '(')
                    {
                        postfixExpression += operatorStack.Pop();
                    }

                    operatorStack.Pop();
                }
                else if (infixExpression[i] < '0' || infixExpression[i] > '9')
                {
                    while (!operatorStack.Empty() &&
                        _operationPriority[infixExpression[i]] <= _operationPriority[operatorStack.Top()])
                    {
                        postfixExpression += operatorStack.Pop();
                    }

                    operatorStack.Push(infixExpression[i]);
                }
                else
                {
                    while (i < infixExpression.Length && infixExpression[i] >= '0' && infixExpression[i] <= '9')
                    {
                        postfixExpression += infixExpression[i++];
                    }
                    postfixExpression += ' ';
                    --i;
                }
            }

            while (!operatorStack.Empty())
            {
                postfixExpression += operatorStack.Pop();
            }

            return postfixExpression;
        }
        //"5 1 1 +^10 -2 *"
        public static double PostfixExpressionEvaluator(string postfixExpression)
        {
            var numStack = new Stack<double>();
            double num = 0;

            for (int i = 0; i < postfixExpression.Length; ++i)
            {
                if (postfixExpression[i] < '0' || postfixExpression[i] > '9')
                {
                    var result = DoOperation(postfixExpression[i], numStack.Pop(), numStack.Pop());
                    numStack.Push(result);
                }
                else
                {
                    while (i < postfixExpression.Length &&
                       postfixExpression[i] >= '0' && postfixExpression[i] <= '9')
                    {
                        num = num * 10 + postfixExpression[i] - '0';
                        ++i;
                    }

                    numStack.Push(num);
                    num = 0;
                }
            }

            return numStack.Pop();
        }

        public static double InfixExpressionEvaluator(string infixExpression)
        {
            return PostfixExpressionEvaluator(PostfixConverter(infixExpression));
        }

        private static double DoOperation(char operation, double num1, double num2)
        {
            switch (operation)
            {
                case '^':
                    return Math.Pow(num2, num1);
                case '*':
                    return num1 * num2;
                case '/':
                    return num2 / num1;
                case '+':
                    return num1 + num2;
                case '-':
                    return num2 - num1;
                default: return 0;
            }
        }
    }
}
