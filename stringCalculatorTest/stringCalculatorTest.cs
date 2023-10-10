using FluentAssertions;

namespace stringCalculator
{
    public class stringCalculatorTest
    {
        private stringCalculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new stringCalculator();
        }



        [Test]
        public void should_return_0_if_values_are_an_empty_string()
        {
            String values = "";
            int result = calculator.add(values);
            result.Should().Be(0);
        }

        [Test]
        public void should_return_1_if_values_are_1()
        {
            String values = "1";
            int result = calculator.add(values);
            result.Should().Be(1);
        }
        [Test]
        public void should_return_3()
        {
            String values = "1,2";
            int result = calculator.add(values);
            result.Should().Be(3);
        }

        [Test]
        public void should_return_45()
        {
            String values = "1,2,3,4,5,6,7,8,9";
            int result = calculator.add(values);
            result.Should().Be(45);
        }
        

        [Test]
        public void should_return_15()
        {
            String values = "1,2,3,4,5";
            int result = calculator.add(values);
            result.Should().Be(15);
        }

        [Test]
        public void should_return_15_with_line_break_delimiter()
        {
            String values = "1\n2,3,4,5";
            int result = calculator.add(values);
            result.Should().Be(15);
        }

        [Test]
        public void should_return_15_with_line_break_delimiter_2()
        {
            String values = "1,2\n3\n4,5";
            int result = calculator.add(values);
            result.Should().Be(15);
        }

        [Test]
        public void should_return_15_with_random_delimiter()
        {
            String values = "//;\n1\n2;3;4;5";
            int result = calculator.add(values);
            result.Should().Be(15);
        }

        [Test]
        public void should_return_15_with_random_delimiter_2()
        {

            String values = "//-\n1\n2-3-4-5";
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
        public void should_be_1007_but_big_numbers_must_be_ignored()
        {
            String values = "1\n2,1003,4,1000";
            int result = calculator.add(values);
            result.Should().Be(1007);
        }
        [Test]
        public void should_be_1006_but_big_numbers_must_be_ignored()
        {
            String values = "1\n2,1003,4,999";
            int result = calculator.add(values);
            result.Should().Be(1006);
        }



    }
}