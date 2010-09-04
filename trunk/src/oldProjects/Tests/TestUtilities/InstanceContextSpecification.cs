namespace Tests.TestUtilities
{
    public abstract class InstanceContextSpecification<SUT> : StaticContextSpecification
    {
        protected SUT sut;

        public override void SetUp()
        {
            Arrange();
            sut = CreateSystemUnderTest();
            Act();
        }

        protected abstract SUT CreateSystemUnderTest();
    }
}