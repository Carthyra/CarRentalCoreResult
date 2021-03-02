using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validaton;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //=> attribute da Type ile vermemiz gerekiyor.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //=> gönderilen validatorType bir IValidator değilse hata ver.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil!"); //=> hata olarak ne dönsün?
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) //=> metod öncesi çalışacak 
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //=> reflection
            //=> Activator.CreateInstance => verdiğimiz validator ın çalışma anında bir instancesını oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //=> _validatorType 'in base typeını bul. onunda Generic Argümanlarından ilkini al.
            //=> ProductValidator => base type ı AbstractValidator<Product> => bununda generic argümanlarının ilki Product classı
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //=> product classının parametlerini bul
            foreach (var entity in entities) //=> parametrelerin her birini tek tek gez
            {
                ValidationTool.Validate(validator, entity); //=> ValidationTool'u kullanarak validate et.
            }
        }
    }
}
