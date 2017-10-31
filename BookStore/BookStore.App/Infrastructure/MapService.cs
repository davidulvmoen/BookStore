using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BookStore.App.Infrastructure
{
    static class MapService
	{
        /// <summary>
        /// Mapping a object to another object.
        /// </summary>
		public static Tt MapTo<Tt, Ts>(object source) where Tt : class
		{
            if (source == null)
            {
                return null;
            }

            try
			{
				AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Ts, Tt>());
				var v = AutoMapper.Mapper.Map(source, typeof(Ts), typeof(Tt));
				return (Tt)v;
			}
			catch (Exception e)
			{
				throw new Exception("Could not map...", e);
			}
		}

        /// <summary>
        /// Mapping a collection of objects to another collection of objects.
        /// </summary>
        public static IEnumerable<Tt> MapToList<Tt, Ts>(IEnumerable<Ts> source)
        {
            if (source == null)
            {
                return null;
            }

            try
            {
                AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Ts, Tt>());
                
                List<Tt> tobjs = new List<Tt>();

                foreach (var item in source)
                {
                    var tobj = AutoMapper.Mapper.Map(item, typeof(Ts), typeof(Tt));
                    tobjs.Add((Tt)tobj);
                }

                return tobjs;
            }
            catch (Exception e)
            {
                throw new Exception("Could not map...", e);
            }
        }

        /// <summary>
        /// Mapping raw json to a object.
        /// </summary>
        public static T FromJSON<T>(string raw) where T : class
        {
            if (raw == null)
            {
                return null;
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(raw);
            }
            catch (Exception e)
            {
                throw new Exception("Could not map JSON...", e);
            }
        }
	}
}
