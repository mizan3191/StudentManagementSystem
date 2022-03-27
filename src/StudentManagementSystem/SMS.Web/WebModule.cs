using Autofac;
using SMS.Web.Models;
using SMS.Web.Models.AccountModel;

namespace SMS.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModel>().AsSelf();
            builder.RegisterType<LoginModel>().AsSelf();
            builder.RegisterType<ConfirmEmailModel>().AsSelf();
            builder.RegisterType<CreateCompanyModel>().AsSelf();
            builder.RegisterType<ForgotPasswordModel>().AsSelf();
            builder.RegisterType<BaseModel>().AsSelf();

            base.Load(builder);
        }
    }
}