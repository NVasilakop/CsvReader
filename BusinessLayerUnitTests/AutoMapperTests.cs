using AutoFixture;
using AutoMapper;
using BusinessModels;
using BusinessModels.Profiles;
using DataModels;

namespace BusinessLayerUnitTests
{
    public class AutoMapperTests
    {
        private readonly IMapper mapper;
        private readonly IFixture _fixture;

        public AutoMapperTests()
        {
          var  mapperConfig = new MapperConfiguration(
          cfg =>
          {
              cfg.AddProfile(new SessionProfiler());
              cfg.AddProfile(new QuoteProfiler());
              cfg.AddProfile(new PolicyProfiler());
          });
            mapper = new Mapper(mapperConfig);
            _fixture = new Fixture();
        }

        [Fact]
        public void SuccessfulSessionProfiler()
        {
           var businessSession =  _fixture.Create<Session>();
           var userSession = mapper.Map<UserSession>(businessSession);
           Assert.NotNull(userSession);
        }

        [Fact]
        public void SuccessfulQuoteProfiler()
        {

            //_fixture.Customize<Quote_Event>(c => c.With(p => p.EndDate,DateTime.Now.ToString())
            //.With(p => p.StartDate,DateTime.Now.ToString)
            //.With(p => p.DateOfBirth,DateTime.Now.ToString)
            //.With(p => p.VehicleRegistrationDate, DateTime.Now.ToString)
            //.With(p => p.TotalPremium, )
            //.With(p => p.SumAssured, 2.3));
            var businessQuoteEvent = _fixture.Create<Quote_Event>();
            var quote = mapper.Map<Quote>(businessQuoteEvent);
            Assert.NotNull(quote);
        }

        [Fact]
        public void SuccessfulPolicyProfiler()
        {
            var businessPolicy = _fixture.Create<BusinessModels.Policy>();
            var policy = mapper.Map<DataModels.Policy>(businessPolicy);
            Assert.NotNull(policy);
        }
    }
}