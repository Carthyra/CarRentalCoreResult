using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        int _duration;
        ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) // duration için değer verilmezse, default olarak 60 kullan
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            // ICacheManager'ın kendiside bir aspect olduğundan dolayı bu şekilde injection yapılır.
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            // cache key'i için isim oluşturmaya çalışıyoruz, bu nedenle ilk metod ismini alıyoruz.
            var arguments = invocation.Arguments.ToList();
            // cache için metod ismi aldık, ama metodun argümanları varsa onları listeye çevir.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            // keyimizi oluşturduk

            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
                // oluşturduğumuz key cache'ler içerisinde varsa onun değerini getir.
            }
            invocation.Proceed();
            // yoksa metoda devam et ve veritabanına git, verileri al.
            _cacheManager.Add(key, invocation.ReturnValue,_duration);
            // metodun getirdiği veriyi cache'e ekle.
        }
    }
}
