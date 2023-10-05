namespace stringCalculator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
         
        }

        [Test]
        public void isEmpty()
        {
            Assert.That(new stringCalculator().add(""), Is.EqualTo(0));
        }

        [Test]
        public void simpleTest1()
        {
            Assert.That(new stringCalculator().add("1"), Is.EqualTo(1));
        }
        [Test]
        public void simpleTest2()
        {
            Assert.That(new stringCalculator().add("1,2"), Is.EqualTo(3));
        }

        [Test]
        public void unknownAmount()
        {
            Assert.That(new stringCalculator().add("1,2,3,4,5,6,7,8,9"), Is.EqualTo(45));
        }
        

        [Test]
        public void unknownAmount2()
        {
            Assert.That(new stringCalculator().add("1,2,3,4,5"), Is.EqualTo(15));
        }

        [Test]
        public void newLines()
        {
            Assert.That(new stringCalculator().add("1\n2,3,4,5"), Is.EqualTo(15));
        }

        [Test]
        public void newLines2()
        {
            Assert.That(new stringCalculator().add("1,2\n3\n4,5"), Is.EqualTo(15));
        }

        [Test]
        public void differentDelimeter()
        {
            
            Assert.That(new stringCalculator().add("//;\n1\n2;3;4;5"), Is.EqualTo(15));
        }

        [Test]
        public void differentDelimeter2()
        {
            
            Assert.That(new stringCalculator().add("//-\n1\n2-3-4-5"), Is.EqualTo(15));
        }

        [Test]
        public void negativeNumbers1()
        {
            Assert.That(new stringCalculator().add("1\n2,3,4,5"), Is.EqualTo(15));
        }
        [Test]
        public void negativeNumbers2()
        {
            Assert.That(new stringCalculator().add("1\n2,-3,4,-5"), Is.EqualTo(7));
        }

        [Test]
        public void bigNumbers1()
        {
            Assert.That(new stringCalculator().add("1\n2,1003,4,1000"), Is.EqualTo(1007));
        }
        [Test]
        public void bigNumbers2()
        {
            Assert.That(new stringCalculator().add("1\n2,1003,4,999"), Is.EqualTo(1006));
        }



    }
}