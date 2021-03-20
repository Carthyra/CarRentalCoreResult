using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
            // memoryCache için oluşan instace'ı al.
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(60));
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            // hocanın github'ından aldık.
                var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                // git belleğe bak EntriesCollection'ı (microsuft buraya attığını söylüyor) bul.
                var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
                // EntriesCollection içerisinde definition'ı memorycache olanları bul.
                List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
            // ICacheEntry türünde cacheCollectionValues yeni liste, aşağıda içerisinde değer ekleyeceğiz.

            foreach (var cacheItem in cacheEntriesCollection)
            {
                // bütün listdeki her bir cache elemanını gez.
                    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            // her bir cache elemanında alttaki kurallar uyanlar.
                var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
                // burada pattern oluşturuyoruz.
                var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
                // cache datası içerisindeki keylerden benim gönderdiğim değere uygun olanları keysToRemove içerisine at.

            foreach (var key in keysToRemove)
            {
                // keysToRemove içerisindeki bütün keyleri bellekten siliyoruz.(uçuruyoruz.)
                _memoryCache.Remove(key);
            }
        }
    }
    
}
