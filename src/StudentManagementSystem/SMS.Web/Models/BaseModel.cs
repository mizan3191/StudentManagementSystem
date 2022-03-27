using Autofac;

namespace SMS.Web.Models
{
    public class BaseModel
    {
        private ILifetimeScope _scope;

        public BaseModel()
        {
        }

        public virtual void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}