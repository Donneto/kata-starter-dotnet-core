using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_feeding_the_monkey
    {
        static Monkey _systemUnderTest;
        
        Establish context = () => 
            _systemUnderTest = new Monkey();

        Because of = () => 
            _systemUnderTest.Eat("banana");

        It should_have_the_food_in_its_belly = () =>
            _systemUnderTest.Belly.Should().Contain("banana");
    }

    public class when_user_input_is_empty
    {
        private Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_do_something = () => { _result.Should().Be(0); };
        private static int _result;
        private static Calculator _systemUnderTest;
    }
    
    public class when_user_input_a_single_number
    {
        private Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("3"); };

        It should_return_the_same_number= () => { _result.Should().Be(3); };
        private static int _result;
        private static Calculator _systemUnderTest;
    }
    
    public class when_user_input_two_numbers
    {
        private Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2"); };

        It should_return_the_sum_of_numbers= () => { _result.Should().Be(3); };
        private static int _result;
        private static Calculator _systemUnderTest;
    }
    
    public class when_user_input_multiple_numbers
    {
        private Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };

        It should_return_the_sum_of_numbers= () => { _result.Should().Be(6); };
        private static int _result;
        private static Calculator _systemUnderTest;
    }



    internal class Calculator
    {
        public int Add(string num = "")
        {

            if (string.IsNullOrEmpty(num) )
            {
                return 0;
            }

            var number = num.Split(",");

            if (number.Length > 1)
            {
                return int.Parse(number[0]) + int.Parse(number[1]);
            }

            return Int32.Parse(num);
        }
    }

    
    // Given the user input is an unknown amount of numbers when calculating the sum then it should return the sum of all the numbers. (example "1,2,3" should equal 6)
    // Given the user input is multiple numbers with new line and comma delimiters when calculating the sum then it should return the sum of all the numbers. (example "1\n2,3" should equal 6)
    // Given the user input is multiple numbers with a custom single-character delimiter when calculating the sum then it should return the sum of all the numbers. (example “//;\n1;2” should return 3)
    // Given the user input contains one negative number when calculating the sum then it should throw an exception "negatives not allowed: x" (where x is the negative number).
    // Given the user input contains multiple negative numbers mixed with positive numbers when calculating the sum then it should throw an exception "negatives not allowed: x, y, z" (where x, y, z are only the negative numbers).
    // Given the user input contains numbers larger than 1000 when calculating the sum it should only sum the numbers less than 1001. (example 2 + 1001 = 2)
    // Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[]\n12***3” should return 6)
    // Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[][%]\n12%3” should return 6)
}