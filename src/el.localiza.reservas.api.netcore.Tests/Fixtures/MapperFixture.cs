using AutoMapper;
using el.localiza.reservas.api.netcore.Application.Mapping;

namespace el.localiza.reservas.api.netcore.Tests.Fixtures
{
    public class MapperFixture
    {
        public IMapper Mapper { get; }

        public MapperFixture()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new ClienteMap());
                opts.AddProfile(new UsuarioMap());
            });

            Mapper = config.CreateMapper();
        }
    }
}
