using Castle.DynamicProxy;
using feedback4eTask.Core.CrossCuttingConcerns.Validation;
using feedback4eTask.Core.Utilities.Interceptors;
using FluentValidation;

namespace feedback4eTask.Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {

            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu Bir Doğrulama sınıfı değildir.");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {

            var validator = (IValidator)Activator.CreateInstance(_validatorType);


            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }

    }
}
