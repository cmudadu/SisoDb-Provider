﻿using System.Data;
using System.Data.SqlClient;
using EnsureThat;
using NCore;
using SisoDb.DbSchema;

namespace SisoDb.Dac
{
    public class SqlDbAdoDriver : IAdoDriver
    {
        private const int MaxLenOfStringBeforeEscalating = 4000;

        public virtual IDbConnection CreateConnection(string connectionString)
        {
            Ensure.That(connectionString, "connectionString").IsNotNull();

            return new SqlConnection(connectionString);
        }

        public virtual IDbCommand CreateCommand(IDbConnection connection, string sql, IDbTransaction transaction = null, params IDacParameter[] parameters)
        {
            return CreateCommand(connection, CommandType.Text, sql, transaction, parameters);
        }

        public virtual IDbCommand CreateSpCommand(IDbConnection connection, string spName, IDbTransaction transaction = null, params IDacParameter[] parameters)
        {
            return CreateCommand(connection, CommandType.StoredProcedure, spName, transaction, parameters);
        }

        protected virtual IDbCommand CreateCommand(IDbConnection connection, CommandType commandType, string sql, IDbTransaction transaction = null, IDacParameter[] parameters = null)
        {
            var cmd = connection.CreateCommand();
            if (transaction != null)
                cmd.Transaction = transaction;

            cmd.CommandType = commandType;
            cmd.UpdatedRowSource = UpdateRowSource.None;

            if (!string.IsNullOrWhiteSpace(sql))
                cmd.CommandText = sql;

            AddCommandParametersTo(cmd, parameters);

            return cmd;
        }

        public virtual void AddCommandParametersTo(IDbCommand cmd, params IDacParameter[] parameters)
        {
            foreach (var dacParameter in parameters)
            {
                var parameter = cmd.CreateParameter();
                parameter.ParameterName = dacParameter.Name;

                parameter = OnParameterCreated(parameter, dacParameter);

                parameter.Value = dacParameter.Value; //Yes, value should be set after OnParameterCreated

                cmd.Parameters.Add(parameter);
            }
        }

        protected virtual IDbDataParameter OnParameterCreated(IDbDataParameter parameter, IDacParameter dacParameter)
        {
            var dbParam = (SqlParameter)parameter;

            if (DbSchemas.Parameters.ShouldBeNonUnicodeString(dacParameter))
                dbParam.SqlDbType = SqlDbType.VarChar;
            else if (DbSchemas.Parameters.ShouldBeUnicodeString(dacParameter))
                dbParam.SqlDbType = SqlDbType.NVarChar;

            if(dbParam.SqlDbType == SqlDbType.VarChar || dbParam.SqlDbType == SqlDbType.NVarChar)
            {
                dbParam.Size = (dacParameter.Value.ToStringOrNull() ?? string.Empty).Length;
                if (dbParam.Size > MaxLenOfStringBeforeEscalating)
                    dbParam.Size = -1;

                return dbParam;
            }

            return dbParam;
        }
    }
}