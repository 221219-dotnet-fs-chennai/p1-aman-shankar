using Business_Logic;

namespace Testing
{
    [TestFixture]
    public class MapperTesting
    {
        [Test]
        public void Test1()
        {
            EntityLib.Entities.User user = new EntityLib.Entities.User();
            var actual = Mapper.Map(user);
            Assert.That(actual.GetType() , Is.EqualTo(typeof(Models.User)));
        }
        [Test] public void Test2()
        {
            Models.User user = new Models.User();
            var actual = Mapper.Map(user);
            Assert.That(actual.GetType(),Is.EqualTo(typeof(EntityLib.Entities.User)));
        }
        [Test]
        public void Test3()
        {
            EntityLib.Entities.Skills skill = new EntityLib.Entities.Skills();
            var actual = Mapper.Map(skill);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.Skills)));
        }
        [Test]
        public void Test4()
        {
            Models.Skills skills = new Models.Skills();
            var actual = Mapper.Map(skills);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(EntityLib.Entities.Skills)));
        }
        [Test]
        public void Test5()
        {
            EntityLib.Entities.Company comp = new EntityLib.Entities.Company();
            var actual = Mapper.Map(comp);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.Company)));
        }
        [Test]
        public void Test6()
        {
            Models.Company comp = new Models.Company();
            var actual = Mapper.Map(comp);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(EntityLib.Entities.Company)));
        }
        [Test]
        public void Test7()
        {
            EntityLib.Entities.EducationDetail education = new EntityLib.Entities.EducationDetail();
            var actual = Mapper.Map(education);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.Education)));
        }
        [Test]
        public void Test8()
        {
            Models.Education edu = new Models.Education();
            var actual = Mapper.Map(edu);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(EntityLib.Entities.EducationDetail)));

        }
    }
}
