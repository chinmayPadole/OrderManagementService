using Autofac;
using Autofac.Integration.WebApi;
using OrderManagementService.Application;
using OrderManagementService.CustomerStore;
using OrderManagementService.DataContract.V1;
using OrderManagementService.Gateways;
using OrderManagementService.OrderStore;
using System.Reflection;
using System.Web.Http;

namespace OrderManagementService
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacWebAPI();
        }
        private static void SetAutofacWebAPI()
        {
            // Create the builder with which components/services are registered.
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder = RegisterServices(builder);

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            //Build the Container
            var container = builder.Build();

            //Create the Dependency Resolver
            var resolver = new AutofacWebApiDependencyResolver(container);

            //Configuring WebApi with Dependency Resolver
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }

        private static ContainerBuilder RegisterServices(ContainerBuilder containerBuilder)
        {

            //Validators
            containerBuilder.RegisterType<ValidatorFactory>().As<IValidatorFactory>().SingleInstance();
            containerBuilder.RegisterType<CreateOrderRequestValidator>().As<FluentValidation.IValidator<OrderManagementService.DataContract.V1.CreateOrderRequest>>().SingleInstance();

            containerBuilder.RegisterType<CreateCustomerRequestValidator>().As<FluentValidation.IValidator<OrderManagementService.DataContract.V1.CreateCustomerRequest>>().SingleInstance();

            //Order store
            containerBuilder.RegisterType<OrderManagementService.OrderStore.OrderStore>().As<IOrderStore>();

            //Order
            containerBuilder.RegisterType<OrderService>().As<IOrderService>();

            //customer store
            containerBuilder.RegisterType<CustomerStore.CustomerStore>().As<ICustomerStore>();
            //customer
            containerBuilder.RegisterType<CustomerService>().As<ICustomerService>();

            return containerBuilder;
        }
    }
}