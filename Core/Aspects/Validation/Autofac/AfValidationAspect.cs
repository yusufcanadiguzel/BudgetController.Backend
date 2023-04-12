using Castle.DynamicProxy;
using Core.Constants.Messages;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors.Autofac.Abstract;
using FluentValidation;

namespace Core.Aspects.Validation.Autofac
{
    public class AfValidationAspect : AfMethodInterception
    {
        private readonly Type _validatorType;

        public AfValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception(AspectMessages.WrongValidationType);

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach ( var entity in entities )
            {
                FvValidationTool.Validate(validator, entity);
            }
        }
    }
}
