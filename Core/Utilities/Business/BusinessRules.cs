using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics) //=> logics iş kuralları, logic te iş kurallarından teki.
            {
                if (!logic.Success) //=> iş kuralı başarılı dönmezse(logic.Succes == false) ile aynı daha kısa yazımı
                {
                    return logic; //=> kurala uymayanı döndür
                }
            }
            return null; //=> başarılı olunca bir şey dönmesine gerek yok.yinede return null; diyoruz ki method hata vermesin.
        }
    }
}
