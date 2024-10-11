using Dapper;
using System.Data;

namespace Bookify.Application.Data
{
    internal sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
    {
        //this method below is for Dapper , it is for our queries since we are using dapper
        //we need to tell dapper what dateonly is, it does not support dateonly
        public override DateOnly Parse(object value)
        {
            return DateOnly.FromDateTime((DateTime)value);
        }

        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            parameter.DbType = DbType.Date;
            parameter.Value = value;
        }
    }
}
