using System.Linq.Expressions;

namespace AzarDataNetTestAPI.Modules.Common.Application.Services.Exp
{
    public class ExpCombine
    {
        public static Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var result = CheckMethodParams(left, right);
            if (result != null)
            {
                return result;
            }
            var parameter = Expression.Parameter(typeof(T), "p");
            var combined = new ParameterReplacer(parameter).Visit(Expression.And(left.Body, right.Body));
            return Expression.Lambda<Func<T, bool>>(combined, parameter);
        }

        public static Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var result = CheckMethodParams(left, right);
            if (result != null)
            {
                return result;
            }
            var parameter = Expression.Parameter(typeof(T), "p");
            var combined = new ParameterReplacer(parameter).Visit(Expression.Or(left.Body, right.Body));
            return Expression.Lambda<Func<T, bool>>(combined, parameter);
        }

        public static Func<Data, Data> CreateNewStatement<Data>(string fields)
        {
            // input parameter "o"
            var xParameter = Expression.Parameter(typeof(Data), "o");

            // new statement "new Data()"
            var xNew = Expression.New(typeof(Data));

            // create initializers
            var bindings = fields.Split(',').Select(o => o.Trim())
                .Select(o =>
                {

                    // property "Field1"
                    var mi = typeof(Data).GetProperty(o);

                    // original value "o.Field1"
                    var xOriginal = Expression.Property(xParameter, mi);

                    // set value "Field1 = o.Field1"
                    return Expression.Bind(mi, xOriginal);
                }
            );

            // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            var xInit = Expression.MemberInit(xNew, bindings);

            // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            var lambda = Expression.Lambda<Func<Data, Data>>(xInit, xParameter);

            // compile to Func<Data, Data>
            return lambda.Compile();
        }

        private static Expression<Func<T, bool>> CheckMethodParams<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null && right == null) throw new ArgumentException("At least one argument must not be null");
            //if (left == null && right == null) return null; 
            if (left == null) return right;
            if (right == null) return left;
            return null;
        }

        class ParameterReplacer : ExpressionVisitor
        {
            readonly ParameterExpression parameter;

            internal ParameterReplacer(ParameterExpression parameter)
            {
                this.parameter = parameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return parameter;
            }
        }
    }
}
