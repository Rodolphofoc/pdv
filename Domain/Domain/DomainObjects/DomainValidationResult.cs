using System.Linq.Expressions;
using System.Reflection;

namespace Domain.DomainObjects
{
    public abstract class AbstractDomainValidation
    {
        public bool IsSuccessful { get => !Errors.Any(); }
        public IList<KeyValuePair<string, string>> Errors { get; init; } = new List<KeyValuePair<string, string>>();

        public abstract DomainValidationResult Fail<T>(Expression<Func<T, string>> expression, params object[]? args);
        public abstract DomainValidationResult ValidationResult();
        public abstract Task<DomainValidationResult> ValidationResultAsync();

        public abstract Task<DomainValidationResult> FailAsync<T>(Expression<Func<T, string>> expression, params object[]? args);
    }

    public class DomainValidationResult : AbstractDomainValidation
    {
        public static DomainValidationResult Success = new DomainValidationResult();

        public override DomainValidationResult Fail<T>(Expression<Func<T, string>> expression, params object[]? args)
        {
            Errors.Add(GetMessageInfo(expression?.Body as MemberExpression, args));

            return this;
        }



        public override Task<DomainValidationResult> FailAsync<T>(Expression<Func<T, string>> expression, params object[]? args)
        {
            Errors.Add(GetMessageInfo(expression?.Body as MemberExpression, args));

            return Task.FromResult(this);
        }

        private static KeyValuePair<string, string> GetMessageInfo(MemberExpression memberExpression, params object[]? args)
        {
            PropertyInfo propInfo = memberExpression?.Member as PropertyInfo;

            var key = propInfo?.Name;
            var value = propInfo?.GetValue(null, null).ToString();

            return new KeyValuePair<string, string>(key, String.Format(value, args));
        }

        public override DomainValidationResult ValidationResult()
        {
            return this;
        }

        public override Task<DomainValidationResult> ValidationResultAsync()
        {
            return Task.FromResult(this);
        }
    }
}
