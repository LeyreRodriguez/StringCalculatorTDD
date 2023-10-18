using FluentAssertions;

namespace stringCalculator
{
    public class Tests
    {
        private stringCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new stringCalculator();
        }

        [Test]
        public void return_0_if_values_are_an_empty_String()
        {
            String values = "";
            int result = calculator.add(values);
            result.Should().Be(0);
        }

        [Test]
        public void check_add_with_1_value()
        {
            String values = "1";
            int result = calculator.add(values);
            result.Should().Be(1);
        }

        [Test]
        public void check_add_with_2_values()
        {
            String values = "1,2";
            int result = calculator.add(values);
            result.Should().Be(3);
        }

        [Test]
        public void check_add_with_an_unknown_amount_of_numbers()
        {
            String values = "1,2,3,4,5";
            int result = calculator.add(values);
            result.Should().Be(15);
        }


        [Test]
        public void check_line_break_as_delimiter()
        {
            String values = "1\n2,3,4\n5";
            int result = calculator.add(values);
            result.Should().Be(15);
        }

        [Test]
        public void check_custom_delimiter()
        {
            String values = "//;\n1;2;3;4;5";
            int result = calculator.add(values);
            result.Should().Be(15);
        }


        [Test]
        public void should_fail_and_throw_an_exception()
        {
            String values = "1\n2,-3,4,-5";
            int result = calculator.add(values);
            result.Should().Be(-2);
        }

        [Test]
        public void check_numbers_less_than_one_thousand()
        {
            String values = "1100";
            int result = calculator.add(values);
            result.Should().Be(0);
        }
        [Test]
        public void check_numbers_less_than_one_thousand_2()
        {
            String values = "1\n2,1003,4,999";
            int result = calculator.add(values);
            result.Should().Be(1006);
        }


    }
}