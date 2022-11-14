using AutoMapper;
using System;
using System.Linq;

namespace Github.Mobile.Services
{
    /// <summary>
    /// Object mapper to convert one object to another
    /// </summary>
    public interface IObjectMapperService
    {
        /// <summary>
        /// Convert object from source to destination
        /// </summary>
        TDestination Map<TDestination>(object source);

        /// <summary>
        /// Convert object from source to destination
        /// </summary>
        TDestination Map<TSource, TDestination>(TSource value);
    }

    public class ObjectMapperService : IObjectMapperService
    {
        private readonly Mapper _mapper;

        public ObjectMapperService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                var baseType = typeof(Profile);
                var allTypes = typeof(App).Assembly
                    .GetTypes()
                    .Where(x => baseType.IsAssignableFrom(x))
                    .Where(x => x != baseType);

                foreach (var profile in allTypes)
                    cfg.AddProfile(profile);
            });

            _mapper = new Mapper(config);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            if (source == null)
                throw new ArgumentNullException($"{nameof(Map)} : {nameof(source)}");

            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TDestination>(object source)
        {
            if (source == null)
                throw new ArgumentNullException($"{nameof(Map)} : {nameof(source)}");

            return _mapper.Map<TDestination>(source);
        }
    }
}
