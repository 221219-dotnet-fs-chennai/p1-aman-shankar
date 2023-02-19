using Business_Logic;

namespace Testing
{
    [TestFixture]
    public class ValidationTesting
    {
        [SetUp]
        public void Setup()
        {}
        [TestCase(null, false)]
        [TestCase("asdfghjkl@gmail.in", true)]
        [TestCase("nothing@gmail.good", true)]
        [TestCase("working@gmail.com", true)]
        [TestCase("goodjob@contact.in", true)]
        [TestCase("xyz.kml05@gmail.com", true)]
        [TestCase("abcdef@yahoo.com", true)]
        [TestCase("abcdef@gmail.com", true)]
        [TestCase("abcdef@outlook.com", true)]
        [TestCase("abcdef123@outlook.com", true)]
        [TestCase("abcdef.123@gmail.com", true)]
        [Test]


        public void Test1(string input, bool expected)
        {
            bool actual = Validation.EmailIsValid(input);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(null, false)]
        [TestCase("Aman123@", true)]
        [TestCase("Venkat33@", true)]
        [TestCase("Arshad765@", true)]
        [Test]


        public void Test2 (string input, bool expected)
        {
            bool actual = Validation.IsValidPassword(input);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("12345", false)]
        [TestCase("123456789", false)]
        [TestCase("0123456789", false)]
        [TestCase("1234567890", false)]
        [TestCase("2234567890", false)]
        [TestCase("3234567890", false)]
        [TestCase("4234567890", false)]
        [TestCase("5234567890", false)]
        [TestCase("523456789a", false)]
        [TestCase("523456789.", false)]
        [TestCase("523456789!", false)]
        [TestCase("6234567890", true)]
        [TestCase("7234567890", true)]
        [TestCase("8234567890", true)]
        [TestCase("9234567890", true)]
        [Test]


        public void Test3(string input, bool expected)
        {
            bool actual = Validation.IsValidMobileNumber(input);
            Assert.AreEqual(expected, actual);
        }
        [TestCase("560001", true)]
        [TestCase("100021", true)]
        [TestCase("200021", true)]
        [TestCase("300021", true)]
        [TestCase("400021", true)]
        [TestCase("500021", true)]
        [TestCase("600021", true)]
        [TestCase("700021", true)]
        [TestCase("800021", true)]
        [TestCase("900021", true)]
        [Test]


        public void Test4(string input, bool expected)
        {
            bool actual = Validation.IsValidPincode(input);
            Assert.AreEqual(expected, actual);
        }
        [TearDown]
        public void CleanUp() { }
    }
}