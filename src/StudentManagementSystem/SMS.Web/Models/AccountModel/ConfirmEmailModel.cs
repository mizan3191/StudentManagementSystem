using Autofac;

namespace SMS.Web.Models.AccountModel
{
    public class ConfirmEmailModel : BaseModel
    {
        public string StatusMessage { get; set; }
        public bool IsSuccess { get; set; }

        private ILifetimeScope _scope;

        public ConfirmEmailModel()
        {
        }

        public override void Resolve(ILifetimeScope scope)
        {
            _scope = scope;

            base.Resolve(_scope);
        }
    }
}