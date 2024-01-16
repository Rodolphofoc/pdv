using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainObjects
{

    public interface IDomainValidationHandler
    { };

    public interface IDomainValidationHandler<TRequest> : IDomainValidationHandler
    {
        Task<DomainValidationResult> Validate(TRequest request);
    }

}