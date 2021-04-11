using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public class ValidatorFactory : IValidatorFactory
    {
        //private readonly IComponentContext _components;

        //public ValidatorFactory(IComponentContext components)
        //{
        //    _components = components;
        //}

        public IValidator<T> GetValidator<T>()
        {
            return null;
           // return _components.Resolve<IValidator<T>>();
        }
    }
}
