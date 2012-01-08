﻿using System;
using System.Collections.Generic;
using System.Linq;
using NCore;
using PineCone.Structures;
using PineCone.Structures.Schemas;
using SisoDb.DbSchema;
using SisoDb.Structures;

namespace SisoDb.Dac.BulkInserts
{
    public class DbStructureInserter : IStructureInserter
    {
    	private static readonly Type TextType;
        private const int MaxStructureBatchSize = 1000;
        private const int MaxIndexesBatchSize = 6000;
        private const int MaxUniquesBatchSize = 6000;

        private readonly IDbClient _dbClient;

		static DbStructureInserter()
		{
			TextType = typeof (Text);
		}

        public DbStructureInserter(IDbClient dbClient)
        {
            _dbClient = dbClient;
        }

        public virtual void Insert(IStructureSchema structureSchema, IStructure[] structures)
        {
            if (structures.Length == 1)
                SingleInsertStructure(structureSchema, structures.Single());
            else
                BulkInsertStructures(structureSchema, structures);

			BulkInsertIndexes(structureSchema, structures);

			BulkInsertUniques(structureSchema, structures);
        }

        protected virtual void SingleInsertStructure(IStructureSchema structureSchema, IStructure structure)
        {
            var sql = "insert into [{0}] ([{1}], [{2}]) values (@{1}, @{2})".Inject(
                structureSchema.GetStructureTableName(),
                StructureStorageSchema.Fields.Id.Name,
                StructureStorageSchema.Fields.Json.Name);

            _dbClient.ExecuteNonQuery(sql,
                new DacParameter(StructureStorageSchema.Fields.Id.Name, structure.Id.Value),
                new DacParameter(StructureStorageSchema.Fields.Json.Name, structure.Data));
        }

        protected virtual void BulkInsertStructures(IStructureSchema structureSchema, IEnumerable<IStructure> structures)
        {
            var structureStorageSchema = new StructureStorageSchema(structureSchema, structureSchema.GetStructureTableName());

            using (var structuresReader = new StructuresReader(structureStorageSchema, structures))
            {
                using (var bulkInserter = _dbClient.GetBulkCopy())
                {
                    bulkInserter.BatchSize = structuresReader.RecordsAffected > MaxStructureBatchSize ? MaxStructureBatchSize : structuresReader.RecordsAffected;
                    bulkInserter.DestinationTableName = structuresReader.StorageSchema.Name;

                    foreach (var field in structuresReader.StorageSchema.GetFieldsOrderedByIndex())
                        bulkInserter.AddColumnMapping(field.Name, field.Name);

                    bulkInserter.Write(structuresReader);
                }
            }
        }

        protected virtual void BulkInsertIndexes(IStructureSchema structureSchema, IEnumerable<IStructure> structures)
        {
			var indexesTableNames = structureSchema.GetIndexesTableNames();
        	var structureIndexes = structures.SelectMany(s => s.Indexes);

			BulkInsertIndexes(structureSchema, indexesTableNames.IntegersTableName, structureIndexes.Where(i => i.DataTypeCode == DataTypeCode.IntegerNumber));
			BulkInsertIndexes(structureSchema, indexesTableNames.FractalsTableName, structureIndexes.Where(i => i.DataTypeCode == DataTypeCode.FractalNumber));
			BulkInsertIndexes(structureSchema, indexesTableNames.BooleansTableName, structureIndexes.Where(i => i.DataTypeCode == DataTypeCode.Bool));
			BulkInsertIndexes(structureSchema, indexesTableNames.DatesTableName, structureIndexes.Where(i => i.DataTypeCode == DataTypeCode.DateTime));
			BulkInsertIndexes(structureSchema, indexesTableNames.GuidsTableName, structureIndexes.Where(i => i.DataTypeCode == DataTypeCode.Guid));
			BulkInsertIndexes(structureSchema, indexesTableNames.StringsTableName, structureIndexes.Where(i => i.DataTypeCode == DataTypeCode.String || i.DataTypeCode == DataTypeCode.Enum), false);
			BulkInsertIndexes(structureSchema, indexesTableNames.TextsTableName, structureIndexes.Where(i => i.DataType == TextType), false);
        }

		protected virtual void BulkInsertIndexes(IStructureSchema structureSchema, string indexesTableName, IEnumerable<IStructureIndex> structureIndexes, bool storeAdditionalStringValue = true)
		{
			var indexesStorageSchema = new IndexStorageSchema(structureSchema, indexesTableName);

			using (var indexesReader = new IndexesReader(indexesStorageSchema, structureIndexes))
			{
				using (var bulkInserter = _dbClient.GetBulkCopy())
				{
					bulkInserter.BatchSize = indexesReader.RecordsAffected > MaxIndexesBatchSize
						? MaxIndexesBatchSize
						: indexesReader.RecordsAffected;
					bulkInserter.DestinationTableName = indexesReader.StorageSchema.Name;

					var fields = indexesReader.StorageSchema.GetFieldsOrderedByIndex();
					foreach (var field in fields)
					{
						if(field.Name == IndexStorageSchema.Fields.StringValue.Name && !storeAdditionalStringValue)
							continue;

						bulkInserter.AddColumnMapping(field.Name, field.Name);
					}
					bulkInserter.Write(indexesReader);
				}
			}
		}

        protected virtual void BulkInsertUniques(IStructureSchema structureSchema, IEnumerable<IStructure> structures)
        {
            var uniques = structures.SelectMany(s => s.Uniques).ToArray();
            if (uniques.Length <= 0)
                return;

            var uniquesStorageSchema = new UniqueStorageSchema(structureSchema, structureSchema.GetUniquesTableName());

            using (var uniquesReader = new UniquesReader(uniquesStorageSchema, uniques))
            {
                using (var bulkInserter = _dbClient.GetBulkCopy())
                {
                    bulkInserter.BatchSize = uniquesReader.RecordsAffected > MaxUniquesBatchSize ? MaxUniquesBatchSize : uniquesReader.RecordsAffected;
                    bulkInserter.DestinationTableName = uniquesReader.StorageSchema.Name;

                    foreach (var field in uniquesReader.StorageSchema.GetFieldsOrderedByIndex())
                        bulkInserter.AddColumnMapping(field.Name, field.Name);

                    bulkInserter.Write(uniquesReader);
                }
            }
        }
    }
}