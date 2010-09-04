using AutoMapper;

namespace Agendas.Infrastructure
{
    public static class Map
    {
        public static IMappingHandler This<TFrom>(TFrom from)
        {
            return new MappingHandler<TFrom>(from);
        }
    }

    public interface IMappingHandler
    {
        TTo ToA<TTo>();
    }

    internal class MappingHandler<TFrom> : IMappingHandler
    {
        private readonly TFrom from;

        public MappingHandler(TFrom from)
        {
            this.from = from;
        }

        public TTo ToA<TTo>()
        {
            return Mapper.Map<TFrom, TTo>(from);
        }
    }
}