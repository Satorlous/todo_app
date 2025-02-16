﻿#pragma warning disable 1591

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;

using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Data;
using LinqToDB.Mapping;

using NpgsqlTypes;

namespace DataModels
{
	/// <summary>
	/// Database       : todo_db
	/// Data Source    : tcp://localhost:5432
	/// Server Version : 11.7
	/// </summary>
	public partial class TodoDbDB : LinqToDB.Data.DataConnection
	{
		public ITable<Contact>    Contacts    { get { return this.GetTable<Contact>(); } }
		public ITable<Importance> Importances { get { return this.GetTable<Importance>(); } }
		public ITable<Task>       Tasks       { get { return this.GetTable<Task>(); } }
		public ITable<TaskUser>   TaskUsers   { get { return this.GetTable<TaskUser>(); } }
		public ITable<User>       Users       { get { return this.GetTable<User>(); } }

		partial void InitMappingSchema()
		{
			MappingSchema.SetConvertExpression<object[], pg_control_checkpointResult>(tuple => new pg_control_checkpointResult() { checkpoint_lsn = (object)tuple[0], redo_lsn = (object)tuple[1], redo_wal_file = (string)tuple[2], timeline_id = (int?)tuple[3], prev_timeline_id = (int?)tuple[4], full_page_writes = (bool?)tuple[5], next_xid = (string)tuple[6], next_oid = (int?)tuple[7], next_multixact_id = (int?)tuple[8], next_multi_offset = (int?)tuple[9], oldest_xid = (int?)tuple[10], oldest_xid_dbid = (int?)tuple[11], oldest_active_xid = (int?)tuple[12], oldest_multi_xid = (int?)tuple[13], oldest_multi_dbid = (int?)tuple[14], oldest_commit_ts_xid = (int?)tuple[15], newest_commit_ts_xid = (int?)tuple[16], checkpoint_time = (DateTimeOffset?)tuple[17] });
			MappingSchema.SetConvertExpression<object[], pg_control_initResult>(tuple => new pg_control_initResult() { max_data_alignment = (int?)tuple[0], database_block_size = (int?)tuple[1], blocks_per_segment = (int?)tuple[2], wal_block_size = (int?)tuple[3], bytes_per_wal_segment = (int?)tuple[4], max_identifier_length = (int?)tuple[5], max_index_columns = (int?)tuple[6], max_toast_chunk_size = (int?)tuple[7], large_object_chunk_size = (int?)tuple[8], float4_pass_by_value = (bool?)tuple[9], float8_pass_by_value = (bool?)tuple[10], data_page_checksum_version = (int?)tuple[11] });
			MappingSchema.SetConvertExpression<object[], pg_control_recoveryResult>(tuple => new pg_control_recoveryResult() { min_recovery_end_lsn = (object)tuple[0], min_recovery_end_timeline = (int?)tuple[1], backup_start_lsn = (object)tuple[2], backup_end_lsn = (object)tuple[3], end_of_backup_record_required = (bool?)tuple[4] });
			MappingSchema.SetConvertExpression<object[], pg_control_systemResult>(tuple => new pg_control_systemResult() { pg_control_version = (int?)tuple[0], catalog_version_no = (int?)tuple[1], system_identifier = (long?)tuple[2], pg_control_last_modified = (DateTimeOffset?)tuple[3] });
			MappingSchema.SetConvertExpression<object[], pg_create_logical_replication_slotResult>(tuple => new pg_create_logical_replication_slotResult() { slot_name = (string)tuple[0], lsn = (object)tuple[1] });
			MappingSchema.SetConvertExpression<object[], pg_create_physical_replication_slotResult>(tuple => new pg_create_physical_replication_slotResult() { slot_name = (string)tuple[0], lsn = (object)tuple[1] });
			MappingSchema.SetConvertExpression<object[], pg_get_object_addressResult>(tuple => new pg_get_object_addressResult() { classid = (int?)tuple[0], objid = (int?)tuple[1], objsubid = (int?)tuple[2] });
			MappingSchema.SetConvertExpression<object[], pg_identify_objectResult>(tuple => new pg_identify_objectResult() { type = (string)tuple[0], schema = (string)tuple[1], name = (string)tuple[2], identity = (string)tuple[3] });
			MappingSchema.SetConvertExpression<object[], pg_identify_object_as_addressResult>(tuple => new pg_identify_object_as_addressResult() { type = (string)tuple[0], object_names = (object)tuple[1], object_args = (object)tuple[2] });
			MappingSchema.SetConvertExpression<object[], pg_last_committed_xactResult>(tuple => new pg_last_committed_xactResult() { xid = (int?)tuple[0], timestamp = (DateTimeOffset?)tuple[1] });
			MappingSchema.SetConvertExpression<object[], pg_replication_slot_advanceResult>(tuple => new pg_replication_slot_advanceResult() { slot_name = (string)tuple[0], end_lsn = (object)tuple[1] });
			MappingSchema.SetConvertExpression<object[], pg_sequence_parametersResult>(tuple => new pg_sequence_parametersResult() { start_value = (long?)tuple[0], minimum_value = (long?)tuple[1], maximum_value = (long?)tuple[2], increment = (long?)tuple[3], cycle_option = (bool?)tuple[4], cache_size = (long?)tuple[5], data_type = (int?)tuple[6] });
			MappingSchema.SetConvertExpression<object[], pg_stat_fileResult>(tuple => new pg_stat_fileResult() { size = (long?)tuple[0], access = (DateTimeOffset?)tuple[1], modification = (DateTimeOffset?)tuple[2], change = (DateTimeOffset?)tuple[3], creation = (DateTimeOffset?)tuple[4], isdir = (bool?)tuple[5] });
			MappingSchema.SetConvertExpression<object[], pg_stat_get_archiverResult>(tuple => new pg_stat_get_archiverResult() { archived_count = (long?)tuple[0], last_archived_wal = (string)tuple[1], last_archived_time = (DateTimeOffset?)tuple[2], failed_count = (long?)tuple[3], last_failed_wal = (string)tuple[4], last_failed_time = (DateTimeOffset?)tuple[5], stats_reset = (DateTimeOffset?)tuple[6] });
			MappingSchema.SetConvertExpression<object[], pg_stat_get_subscriptionResult>(tuple => new pg_stat_get_subscriptionResult() { subid = (int?)tuple[0], relid = (int?)tuple[1], pid = (int?)tuple[2], received_lsn = (object)tuple[3], last_msg_send_time = (DateTimeOffset?)tuple[4], last_msg_receipt_time = (DateTimeOffset?)tuple[5], latest_end_lsn = (object)tuple[6], latest_end_time = (DateTimeOffset?)tuple[7] });
			MappingSchema.SetConvertExpression<object[], pg_stat_get_wal_receiverResult>(tuple => new pg_stat_get_wal_receiverResult() { pid = (int?)tuple[0], status = (string)tuple[1], receive_start_lsn = (object)tuple[2], receive_start_tli = (int?)tuple[3], received_lsn = (object)tuple[4], received_tli = (int?)tuple[5], last_msg_send_time = (DateTimeOffset?)tuple[6], last_msg_receipt_time = (DateTimeOffset?)tuple[7], latest_end_lsn = (object)tuple[8], latest_end_time = (DateTimeOffset?)tuple[9], slot_name = (string)tuple[10], sender_host = (string)tuple[11], sender_port = (int?)tuple[12], conninfo = (string)tuple[13] });
			MappingSchema.SetConvertExpression<object[], pg_walfile_name_offsetResult>(tuple => new pg_walfile_name_offsetResult() { file_name = (string)tuple[0], file_offset = (int?)tuple[1] });
		}

		public TodoDbDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public TodoDbDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();

		#region Table Functions

		#region PgExpandarray

		[Sql.TableFunction(Schema="information_schema", Name="_pg_expandarray")]
		public ITable<PgExpandarrayResult> PgExpandarray(object par4)
		{
			return this.GetTable<PgExpandarrayResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par4);
		}

		public partial class PgExpandarrayResult
		{
			public int? x { get; set; }
			public int? n { get; set; }
		}

		#endregion

		#region Aclexplode

		[Sql.TableFunction(Schema="pg_catalog", Name="aclexplode")]
		public ITable<AclexplodeResult> Aclexplode(object acl)
		{
			return this.GetTable<AclexplodeResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				acl);
		}

		public partial class AclexplodeResult
		{
			public int?   grantor        { get; set; }
			public int?   grantee        { get; set; }
			public string privilege_type { get; set; }
			public bool?  is_grantable   { get; set; }
		}

		#endregion

		#region GenerateSeries

		[Sql.TableFunction(Schema="pg_catalog", Name="generate_series")]
		public ITable<GenerateSeriesResult> GenerateSeries(DateTimeOffset? par1916, DateTimeOffset? par1917, NpgsqlTimeSpan? par1918)
		{
			return this.GetTable<GenerateSeriesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par1916,
				par1917,
				par1918);
		}

		public partial class GenerateSeriesResult
		{
			public DateTimeOffset? generate_series { get; set; }
		}

		#endregion

		#region GenerateSubscripts

		[Sql.TableFunction(Schema="pg_catalog", Name="generate_subscripts")]
		public ITable<GenerateSubscriptsResult> GenerateSubscripts(object par1922, int? par1923)
		{
			return this.GetTable<GenerateSubscriptsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par1922,
				par1923);
		}

		public partial class GenerateSubscriptsResult
		{
			public int? generate_subscripts { get; set; }
		}

		#endregion

		#region JsonArrayElements

		[Sql.TableFunction(Schema="pg_catalog", Name="json_array_elements")]
		public ITable<JsonArrayElementsResult> JsonArrayElements(string from_json)
		{
			return this.GetTable<JsonArrayElementsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				from_json);
		}

		public partial class JsonArrayElementsResult
		{
			public string value { get; set; }
		}

		#endregion

		#region JsonArrayElementsText

		[Sql.TableFunction(Schema="pg_catalog", Name="json_array_elements_text")]
		public ITable<JsonArrayElementsTextResult> JsonArrayElementsText(string from_json)
		{
			return this.GetTable<JsonArrayElementsTextResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				from_json);
		}

		public partial class JsonArrayElementsTextResult
		{
			public string value { get; set; }
		}

		#endregion

		#region JsonEach

		[Sql.TableFunction(Schema="pg_catalog", Name="json_each")]
		public ITable<JsonEachResult> JsonEach(string from_json)
		{
			return this.GetTable<JsonEachResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				from_json);
		}

		public partial class JsonEachResult
		{
			public string key   { get; set; }
			public string value { get; set; }
		}

		#endregion

		#region JsonEachText

		[Sql.TableFunction(Schema="pg_catalog", Name="json_each_text")]
		public ITable<JsonEachTextResult> JsonEachText(string from_json)
		{
			return this.GetTable<JsonEachTextResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				from_json);
		}

		public partial class JsonEachTextResult
		{
			public string key   { get; set; }
			public string value { get; set; }
		}

		#endregion

		#region JsonObjectKeys

		[Sql.TableFunction(Schema="pg_catalog", Name="json_object_keys")]
		public ITable<JsonObjectKeysResult> JsonObjectKeys(string par3639)
		{
			return this.GetTable<JsonObjectKeysResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par3639);
		}

		public partial class JsonObjectKeysResult
		{
			public string json_object_keys { get; set; }
		}

		#endregion

		#region JsonPopulateRecordset

		[Sql.TableFunction(Schema="pg_catalog", Name="json_populate_recordset")]
		public ITable<JsonPopulateRecordsetResult> JsonPopulateRecordset(object @base, string from_json, bool? use_json_as_text)
		{
			return this.GetTable<JsonPopulateRecordsetResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				@base,
				from_json,
				use_json_as_text);
		}

		public partial class JsonPopulateRecordsetResult
		{
			public int? json_populate_recordset { get; set; }
		}

		#endregion

		#region JsonbArrayElements

		[Sql.TableFunction(Schema="pg_catalog", Name="jsonb_array_elements")]
		public ITable<JsonbArrayElementsResult> JsonbArrayElements(string from_json)
		{
			return this.GetTable<JsonbArrayElementsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				from_json);
		}

		public partial class JsonbArrayElementsResult
		{
			public string value { get; set; }
		}

		#endregion

		#region JsonbArrayElementsText

		[Sql.TableFunction(Schema="pg_catalog", Name="jsonb_array_elements_text")]
		public ITable<JsonbArrayElementsTextResult> JsonbArrayElementsText(string from_json)
		{
			return this.GetTable<JsonbArrayElementsTextResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				from_json);
		}

		public partial class JsonbArrayElementsTextResult
		{
			public string value { get; set; }
		}

		#endregion

		#region JsonbEach

		[Sql.TableFunction(Schema="pg_catalog", Name="jsonb_each")]
		public ITable<JsonbEachResult> JsonbEach(string from_json)
		{
			return this.GetTable<JsonbEachResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				from_json);
		}

		public partial class JsonbEachResult
		{
			public string key   { get; set; }
			public string value { get; set; }
		}

		#endregion

		#region JsonbEachText

		[Sql.TableFunction(Schema="pg_catalog", Name="jsonb_each_text")]
		public ITable<JsonbEachTextResult> JsonbEachText(string from_json)
		{
			return this.GetTable<JsonbEachTextResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				from_json);
		}

		public partial class JsonbEachTextResult
		{
			public string key   { get; set; }
			public string value { get; set; }
		}

		#endregion

		#region JsonbObjectKeys

		[Sql.TableFunction(Schema="pg_catalog", Name="jsonb_object_keys")]
		public ITable<JsonbObjectKeysResult> JsonbObjectKeys(string par3752)
		{
			return this.GetTable<JsonbObjectKeysResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par3752);
		}

		public partial class JsonbObjectKeysResult
		{
			public string jsonb_object_keys { get; set; }
		}

		#endregion

		#region JsonbPopulateRecordset

		[Sql.TableFunction(Schema="pg_catalog", Name="jsonb_populate_recordset")]
		public ITable<JsonbPopulateRecordsetResult> JsonbPopulateRecordset(object par3758, string par3759)
		{
			return this.GetTable<JsonbPopulateRecordsetResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par3758,
				par3759);
		}

		public partial class JsonbPopulateRecordsetResult
		{
			public int? jsonb_populate_recordset { get; set; }
		}

		#endregion

		#region PgAvailableExtensionVersions

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_available_extension_versions")]
		public ITable<PgAvailableExtensionVersionsResult> PgAvailableExtensionVersions()
		{
			return this.GetTable<PgAvailableExtensionVersionsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgAvailableExtensionVersionsResult
		{
			public string name        { get; set; }
			public string version     { get; set; }
			public bool?  superuser   { get; set; }
			public bool?  relocatable { get; set; }
			public string schema      { get; set; }
			public Array  requires    { get; set; }
			public string comment     { get; set; }
		}

		#endregion

		#region PgAvailableExtensions

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_available_extensions")]
		public ITable<PgAvailableExtensionsResult> PgAvailableExtensions()
		{
			return this.GetTable<PgAvailableExtensionsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgAvailableExtensionsResult
		{
			public string name            { get; set; }
			public string default_version { get; set; }
			public string comment         { get; set; }
		}

		#endregion

		#region PgConfig

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_config")]
		public ITable<PgConfigResult> PgConfig()
		{
			return this.GetTable<PgConfigResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgConfigResult
		{
			public string name    { get; set; }
			public string setting { get; set; }
		}

		#endregion

		#region PgCursor

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_cursor")]
		public ITable<PgCursorResult> PgCursor()
		{
			return this.GetTable<PgCursorResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgCursorResult
		{
			public string          name          { get; set; }
			public string          statement     { get; set; }
			public bool?           is_holdable   { get; set; }
			public bool?           is_binary     { get; set; }
			public bool?           is_scrollable { get; set; }
			public DateTimeOffset? creation_time { get; set; }
		}

		#endregion

		#region PgEventTriggerDdlCommands

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_event_trigger_ddl_commands")]
		public ITable<PgEventTriggerDdlCommandsResult> PgEventTriggerDdlCommands()
		{
			return this.GetTable<PgEventTriggerDdlCommandsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgEventTriggerDdlCommandsResult
		{
			public int?   classid         { get; set; }
			public int?   objid           { get; set; }
			public int?   objsubid        { get; set; }
			public string command_tag     { get; set; }
			public string object_type     { get; set; }
			public string schema_name     { get; set; }
			public string object_identity { get; set; }
			public bool?  in_extension    { get; set; }
			public object command         { get; set; }
		}

		#endregion

		#region PgEventTriggerDroppedObjects

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_event_trigger_dropped_objects")]
		public ITable<PgEventTriggerDroppedObjectsResult> PgEventTriggerDroppedObjects()
		{
			return this.GetTable<PgEventTriggerDroppedObjectsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgEventTriggerDroppedObjectsResult
		{
			public int?   classid         { get; set; }
			public int?   objid           { get; set; }
			public int?   objsubid        { get; set; }
			public bool?  original        { get; set; }
			public bool?  normal          { get; set; }
			public bool?  is_temporary    { get; set; }
			public string object_type     { get; set; }
			public string schema_name     { get; set; }
			public string object_name     { get; set; }
			public string object_identity { get; set; }
			public Array  address_names   { get; set; }
			public Array  address_args    { get; set; }
		}

		#endregion

		#region PgExtensionUpdatePaths

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_extension_update_paths")]
		public ITable<PgExtensionUpdatePathsResult> PgExtensionUpdatePaths(string name)
		{
			return this.GetTable<PgExtensionUpdatePathsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				name);
		}

		public partial class PgExtensionUpdatePathsResult
		{
			public string source { get; set; }
			public string target { get; set; }
			public string path   { get; set; }
		}

		#endregion

		#region PgGetKeywords

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_get_keywords")]
		public ITable<PgGetKeywordsResult> PgGetKeywords()
		{
			return this.GetTable<PgGetKeywordsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgGetKeywordsResult
		{
			public string word    { get; set; }
			public char?  catcode { get; set; }
			public string catdesc { get; set; }
		}

		#endregion

		#region PgGetMultixactMembers

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_get_multixact_members")]
		public ITable<PgGetMultixactMembersResult> PgGetMultixactMembers(int? multixid)
		{
			return this.GetTable<PgGetMultixactMembersResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				multixid);
		}

		public partial class PgGetMultixactMembersResult
		{
			public int?   xid  { get; set; }
			public string mode { get; set; }
		}

		#endregion

		#region PgGetPublicationTables

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_get_publication_tables")]
		public ITable<PgGetPublicationTablesResult> PgGetPublicationTables(string pubname)
		{
			return this.GetTable<PgGetPublicationTablesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				pubname);
		}

		public partial class PgGetPublicationTablesResult
		{
			public int? relid { get; set; }
		}

		#endregion

		#region PgGetReplicationSlots

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_get_replication_slots")]
		public ITable<PgGetReplicationSlotsResult> PgGetReplicationSlots()
		{
			return this.GetTable<PgGetReplicationSlotsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgGetReplicationSlotsResult
		{
			public string slot_name           { get; set; }
			public string plugin              { get; set; }
			public string slot_type           { get; set; }
			public int?   datoid              { get; set; }
			public bool?  temporary           { get; set; }
			public bool?  active              { get; set; }
			public int?   active_pid          { get; set; }
			public int?   xmin                { get; set; }
			public int?   catalog_xmin        { get; set; }
			public string restart_lsn         { get; set; }
			public string confirmed_flush_lsn { get; set; }
		}

		#endregion

		#region PgHbaFileRules

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_hba_file_rules")]
		public ITable<PgHbaFileRulesResult> PgHbaFileRules()
		{
			return this.GetTable<PgHbaFileRulesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgHbaFileRulesResult
		{
			public int?   line_number { get; set; }
			public string type        { get; set; }
			public Array  database    { get; set; }
			public Array  user_name   { get; set; }
			public string address     { get; set; }
			public string netmask     { get; set; }
			public string auth_method { get; set; }
			public Array  options     { get; set; }
			public string error       { get; set; }
		}

		#endregion

		#region PgListeningChannels

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_listening_channels")]
		public ITable<PgListeningChannelsResult> PgListeningChannels()
		{
			return this.GetTable<PgListeningChannelsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgListeningChannelsResult
		{
			public string pg_listening_channels { get; set; }
		}

		#endregion

		#region PgLockStatus

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_lock_status")]
		public ITable<PgLockStatusResult> PgLockStatus()
		{
			return this.GetTable<PgLockStatusResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgLockStatusResult
		{
			public string locktype           { get; set; }
			public int?   database           { get; set; }
			public int?   relation           { get; set; }
			public int?   page               { get; set; }
			public short? tuple              { get; set; }
			public string virtualxid         { get; set; }
			public int?   transactionid      { get; set; }
			public int?   classid            { get; set; }
			public int?   objid              { get; set; }
			public short? objsubid           { get; set; }
			public string virtualtransaction { get; set; }
			public int?   pid                { get; set; }
			public string mode               { get; set; }
			public bool?  granted            { get; set; }
			public bool?  fastpath           { get; set; }
		}

		#endregion

		#region PgLogicalSlotGetBinaryChanges

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_logical_slot_get_binary_changes")]
		public ITable<PgLogicalSlotGetBinaryChangesResult> PgLogicalSlotGetBinaryChanges(string slot_name, object upto_lsn, int? upto_nchanges, object options)
		{
			return this.GetTable<PgLogicalSlotGetBinaryChangesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				slot_name,
				upto_lsn,
				upto_nchanges,
				options);
		}

		public partial class PgLogicalSlotGetBinaryChangesResult
		{
			public string lsn  { get; set; }
			public int?   xid  { get; set; }
			public byte[] data { get; set; }
		}

		#endregion

		#region PgLogicalSlotGetChanges

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_logical_slot_get_changes")]
		public ITable<PgLogicalSlotGetChangesResult> PgLogicalSlotGetChanges(string slot_name, object upto_lsn, int? upto_nchanges, object options)
		{
			return this.GetTable<PgLogicalSlotGetChangesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				slot_name,
				upto_lsn,
				upto_nchanges,
				options);
		}

		public partial class PgLogicalSlotGetChangesResult
		{
			public string lsn  { get; set; }
			public int?   xid  { get; set; }
			public string data { get; set; }
		}

		#endregion

		#region PgLogicalSlotPeekBinaryChanges

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_logical_slot_peek_binary_changes")]
		public ITable<PgLogicalSlotPeekBinaryChangesResult> PgLogicalSlotPeekBinaryChanges(string slot_name, object upto_lsn, int? upto_nchanges, object options)
		{
			return this.GetTable<PgLogicalSlotPeekBinaryChangesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				slot_name,
				upto_lsn,
				upto_nchanges,
				options);
		}

		public partial class PgLogicalSlotPeekBinaryChangesResult
		{
			public string lsn  { get; set; }
			public int?   xid  { get; set; }
			public byte[] data { get; set; }
		}

		#endregion

		#region PgLogicalSlotPeekChanges

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_logical_slot_peek_changes")]
		public ITable<PgLogicalSlotPeekChangesResult> PgLogicalSlotPeekChanges(string slot_name, object upto_lsn, int? upto_nchanges, object options)
		{
			return this.GetTable<PgLogicalSlotPeekChangesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				slot_name,
				upto_lsn,
				upto_nchanges,
				options);
		}

		public partial class PgLogicalSlotPeekChangesResult
		{
			public string lsn  { get; set; }
			public int?   xid  { get; set; }
			public string data { get; set; }
		}

		#endregion

		#region PgLsDir

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_ls_dir")]
		public ITable<PgLsDirResult> PgLsDir(string par5221, bool? par5222, bool? par5223)
		{
			return this.GetTable<PgLsDirResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par5221,
				par5222,
				par5223);
		}

		public partial class PgLsDirResult
		{
			public string pg_ls_dir { get; set; }
		}

		#endregion

		#region PgLsLogdir

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_ls_logdir")]
		public ITable<PgLsLogdirResult> PgLsLogdir()
		{
			return this.GetTable<PgLsLogdirResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgLsLogdirResult
		{
			public string          name         { get; set; }
			public long?           size         { get; set; }
			public DateTimeOffset? modification { get; set; }
		}

		#endregion

		#region PgLsWaldir

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_ls_waldir")]
		public ITable<PgLsWaldirResult> PgLsWaldir()
		{
			return this.GetTable<PgLsWaldirResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgLsWaldirResult
		{
			public string          name         { get; set; }
			public long?           size         { get; set; }
			public DateTimeOffset? modification { get; set; }
		}

		#endregion

		#region PgOptionsToTable

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_options_to_table")]
		public ITable<PgOptionsToTableResult> PgOptionsToTable(object options_array)
		{
			return this.GetTable<PgOptionsToTableResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				options_array);
		}

		public partial class PgOptionsToTableResult
		{
			public string option_name  { get; set; }
			public string option_value { get; set; }
		}

		#endregion

		#region PgPreparedStatement

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_prepared_statement")]
		public ITable<PgPreparedStatementResult> PgPreparedStatement()
		{
			return this.GetTable<PgPreparedStatementResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgPreparedStatementResult
		{
			public string          name            { get; set; }
			public string          statement       { get; set; }
			public DateTimeOffset? prepare_time    { get; set; }
			public Array           parameter_types { get; set; }
			public bool?           from_sql        { get; set; }
		}

		#endregion

		#region PgPreparedXact

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_prepared_xact")]
		public ITable<PgPreparedXactResult> PgPreparedXact()
		{
			return this.GetTable<PgPreparedXactResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgPreparedXactResult
		{
			public int?            transaction { get; set; }
			public string          gid         { get; set; }
			public DateTimeOffset? prepared    { get; set; }
			public int?            ownerid     { get; set; }
			public int?            dbid        { get; set; }
		}

		#endregion

		#region PgShowAllFileSettings

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_show_all_file_settings")]
		public ITable<PgShowAllFileSettingsResult> PgShowAllFileSettings()
		{
			return this.GetTable<PgShowAllFileSettingsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgShowAllFileSettingsResult
		{
			public string sourcefile { get; set; }
			public int?   sourceline { get; set; }
			public int?   seqno      { get; set; }
			public string name       { get; set; }
			public string setting    { get; set; }
			public bool?  applied    { get; set; }
			public string error      { get; set; }
		}

		#endregion

		#region PgShowAllSettings

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_show_all_settings")]
		public ITable<PgShowAllSettingsResult> PgShowAllSettings()
		{
			return this.GetTable<PgShowAllSettingsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgShowAllSettingsResult
		{
			public string name            { get; set; }
			public string setting         { get; set; }
			public string unit            { get; set; }
			public string category        { get; set; }
			public string short_desc      { get; set; }
			public string extra_desc      { get; set; }
			public string context         { get; set; }
			public string vartype         { get; set; }
			public string source          { get; set; }
			public string min_val         { get; set; }
			public string max_val         { get; set; }
			public Array  enumvals        { get; set; }
			public string boot_val        { get; set; }
			public string reset_val       { get; set; }
			public string sourcefile      { get; set; }
			public int?   sourceline      { get; set; }
			public bool?  pending_restart { get; set; }
		}

		#endregion

		#region PgShowReplicationOriginStatus

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_show_replication_origin_status")]
		public ITable<PgShowReplicationOriginStatusResult> PgShowReplicationOriginStatus()
		{
			return this.GetTable<PgShowReplicationOriginStatusResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgShowReplicationOriginStatusResult
		{
			public int?   local_id    { get; set; }
			public string external_id { get; set; }
			public string remote_lsn  { get; set; }
			public string local_lsn   { get; set; }
		}

		#endregion

		#region PgStatGetActivity

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_stat_get_activity")]
		public ITable<PgStatGetActivityResult> PgStatGetActivity(int? pid)
		{
			return this.GetTable<PgStatGetActivityResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				pid);
		}

		public partial class PgStatGetActivityResult
		{
			public int?            datid            { get; set; }
			public int?            pid              { get; set; }
			public int?            usesysid         { get; set; }
			public string          application_name { get; set; }
			public string          state            { get; set; }
			public string          query            { get; set; }
			public string          wait_event_type  { get; set; }
			public string          wait_event       { get; set; }
			public DateTimeOffset? xact_start       { get; set; }
			public DateTimeOffset? query_start      { get; set; }
			public DateTimeOffset? backend_start    { get; set; }
			public DateTimeOffset? state_change     { get; set; }
			public NpgsqlInet?     client_addr      { get; set; }
			public string          client_hostname  { get; set; }
			public int?            client_port      { get; set; }
			public int?            backend_xid      { get; set; }
			public int?            backend_xmin     { get; set; }
			public string          backend_type     { get; set; }
			public bool?           ssl              { get; set; }
			public string          sslversion       { get; set; }
			public string          sslcipher        { get; set; }
			public int?            sslbits          { get; set; }
			public bool?           sslcompression   { get; set; }
			public string          sslclientdn      { get; set; }
		}

		#endregion

		#region PgStatGetBackendIdset

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_stat_get_backend_idset")]
		public ITable<PgStatGetBackendIdsetResult> PgStatGetBackendIdset()
		{
			return this.GetTable<PgStatGetBackendIdsetResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgStatGetBackendIdsetResult
		{
			public int? pg_stat_get_backend_idset { get; set; }
		}

		#endregion

		#region PgStatGetProgressInfo

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_stat_get_progress_info")]
		public ITable<PgStatGetProgressInfoResult> PgStatGetProgressInfo(string cmdtype)
		{
			return this.GetTable<PgStatGetProgressInfoResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				cmdtype);
		}

		public partial class PgStatGetProgressInfoResult
		{
			public int?  pid     { get; set; }
			public int?  datid   { get; set; }
			public int?  relid   { get; set; }
			public long? param1  { get; set; }
			public long? param2  { get; set; }
			public long? param3  { get; set; }
			public long? param4  { get; set; }
			public long? param5  { get; set; }
			public long? param6  { get; set; }
			public long? param7  { get; set; }
			public long? param8  { get; set; }
			public long? param9  { get; set; }
			public long? param10 { get; set; }
		}

		#endregion

		#region PgStatGetWalSenders

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_stat_get_wal_senders")]
		public ITable<PgStatGetWalSendersResult> PgStatGetWalSenders()
		{
			return this.GetTable<PgStatGetWalSendersResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgStatGetWalSendersResult
		{
			public int?            pid           { get; set; }
			public string          state         { get; set; }
			public string          sent_lsn      { get; set; }
			public string          write_lsn     { get; set; }
			public string          flush_lsn     { get; set; }
			public string          replay_lsn    { get; set; }
			public NpgsqlTimeSpan? write_lag     { get; set; }
			public NpgsqlTimeSpan? flush_lag     { get; set; }
			public NpgsqlTimeSpan? replay_lag    { get; set; }
			public int?            sync_priority { get; set; }
			public string          sync_state    { get; set; }
		}

		#endregion

		#region PgStopBackup

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_stop_backup")]
		public ITable<PgStopBackupResult> PgStopBackup(bool? exclusive, bool? wait_for_archive)
		{
			return this.GetTable<PgStopBackupResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				exclusive,
				wait_for_archive);
		}

		public partial class PgStopBackupResult
		{
			public string lsn        { get; set; }
			public string labelfile  { get; set; }
			public string spcmapfile { get; set; }
		}

		#endregion

		#region PgTablespaceDatabases

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_tablespace_databases")]
		public ITable<PgTablespaceDatabasesResult> PgTablespaceDatabases(int? par5520)
		{
			return this.GetTable<PgTablespaceDatabasesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par5520);
		}

		public partial class PgTablespaceDatabasesResult
		{
			public int? pg_tablespace_databases { get; set; }
		}

		#endregion

		#region PgTimezoneAbbrevs

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_timezone_abbrevs")]
		public ITable<PgTimezoneAbbrevsResult> PgTimezoneAbbrevs()
		{
			return this.GetTable<PgTimezoneAbbrevsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgTimezoneAbbrevsResult
		{
			public string          abbrev     { get; set; }
			public NpgsqlTimeSpan? utc_offset { get; set; }
			public bool?           is_dst     { get; set; }
		}

		#endregion

		#region PgTimezoneNames

		[Sql.TableFunction(Schema="pg_catalog", Name="pg_timezone_names")]
		public ITable<PgTimezoneNamesResult> PgTimezoneNames()
		{
			return this.GetTable<PgTimezoneNamesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
		}

		public partial class PgTimezoneNamesResult
		{
			public string          name       { get; set; }
			public string          abbrev     { get; set; }
			public NpgsqlTimeSpan? utc_offset { get; set; }
			public bool?           is_dst     { get; set; }
		}

		#endregion

		#region RegexpMatches

		[Sql.TableFunction(Schema="pg_catalog", Name="regexp_matches")]
		public ITable<RegexpMatchesResult> RegexpMatches(string par6004, string par6005, string par6006)
		{
			return this.GetTable<RegexpMatchesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par6004,
				par6005,
				par6006);
		}

		public partial class RegexpMatchesResult
		{
			public Array regexp_matches { get; set; }
		}

		#endregion

		#region RegexpSplitToTable

		[Sql.TableFunction(Schema="pg_catalog", Name="regexp_split_to_table")]
		public ITable<RegexpSplitToTableResult> RegexpSplitToTable(string par6025, string par6026, string par6027)
		{
			return this.GetTable<RegexpSplitToTableResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par6025,
				par6026,
				par6027);
		}

		public partial class RegexpSplitToTableResult
		{
			public string regexp_split_to_table { get; set; }
		}

		#endregion

		#region TsDebug

		[Sql.TableFunction(Schema="pg_catalog", Name="ts_debug")]
		public ITable<TsDebugResult> TsDebug(string document)
		{
			return this.GetTable<TsDebugResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				document);
		}

		public partial class TsDebugResult
		{
			public string alias        { get; set; }
			public string description  { get; set; }
			public string token        { get; set; }
			public Array  dictionaries { get; set; }
			public string dictionary   { get; set; }
			public Array  lexemes      { get; set; }
		}

		#endregion

		#region TsParse

		[Sql.TableFunction(Schema="pg_catalog", Name="ts_parse")]
		public ITable<TsParseResult> TsParse(string parser_name, string txt)
		{
			return this.GetTable<TsParseResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				parser_name,
				txt);
		}

		public partial class TsParseResult
		{
			public int?   tokid { get; set; }
			public string token { get; set; }
		}

		#endregion

		#region TsStat

		[Sql.TableFunction(Schema="pg_catalog", Name="ts_stat")]
		public ITable<TsStatResult> TsStat(string query, string weights)
		{
			return this.GetTable<TsStatResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				query,
				weights);
		}

		public partial class TsStatResult
		{
			public string word   { get; set; }
			public int?   ndoc   { get; set; }
			public int?   nentry { get; set; }
		}

		#endregion

		#region TsTokenType

		[Sql.TableFunction(Schema="pg_catalog", Name="ts_token_type")]
		public ITable<TsTokenTypeResult> TsTokenType(string parser_name)
		{
			return this.GetTable<TsTokenTypeResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				parser_name);
		}

		public partial class TsTokenTypeResult
		{
			public int?   tokid       { get; set; }
			public string alias       { get; set; }
			public string description { get; set; }
		}

		#endregion

		#region TxidSnapshotXip

		[Sql.TableFunction(Schema="pg_catalog", Name="txid_snapshot_xip")]
		public ITable<TxidSnapshotXipResult> TxidSnapshotXip(object par7479)
		{
			return this.GetTable<TxidSnapshotXipResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				par7479);
		}

		public partial class TxidSnapshotXipResult
		{
			public long? txid_snapshot_xip { get; set; }
		}

		#endregion

		#region Unnest

		[Sql.TableFunction(Schema="pg_catalog", Name="unnest")]
		public ITable<UnnestResult> Unnest(object tsvector)
		{
			return this.GetTable<UnnestResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
				tsvector);
		}

		public partial class UnnestResult
		{
			public string lexeme    { get; set; }
			public Array  positions { get; set; }
			public Array  weights   { get; set; }
		}

		#endregion

		#endregion
	}

	public partial class pg_control_checkpointResult
	{
		public object checkpoint_lsn { get; set; }

		public object redo_lsn { get; set; }

		public string redo_wal_file { get; set; }

		public int? timeline_id { get; set; }

		public int? prev_timeline_id { get; set; }

		public bool? full_page_writes { get; set; }

		public string next_xid { get; set; }

		public int? next_oid { get; set; }

		public int? next_multixact_id { get; set; }

		public int? next_multi_offset { get; set; }

		public int? oldest_xid { get; set; }

		public int? oldest_xid_dbid { get; set; }

		public int? oldest_active_xid { get; set; }

		public int? oldest_multi_xid { get; set; }

		public int? oldest_multi_dbid { get; set; }

		public int? oldest_commit_ts_xid { get; set; }

		public int? newest_commit_ts_xid { get; set; }

		public DateTimeOffset? checkpoint_time { get; set; }
	}

	public partial class pg_control_initResult
	{
		public int? max_data_alignment { get; set; }

		public int? database_block_size { get; set; }

		public int? blocks_per_segment { get; set; }

		public int? wal_block_size { get; set; }

		public int? bytes_per_wal_segment { get; set; }

		public int? max_identifier_length { get; set; }

		public int? max_index_columns { get; set; }

		public int? max_toast_chunk_size { get; set; }

		public int? large_object_chunk_size { get; set; }

		public bool? float4_pass_by_value { get; set; }

		public bool? float8_pass_by_value { get; set; }

		public int? data_page_checksum_version { get; set; }
	}

	public partial class pg_control_recoveryResult
	{
		public object min_recovery_end_lsn { get; set; }

		public int? min_recovery_end_timeline { get; set; }

		public object backup_start_lsn { get; set; }

		public object backup_end_lsn { get; set; }

		public bool? end_of_backup_record_required { get; set; }
	}

	public partial class pg_control_systemResult
	{
		public int? pg_control_version { get; set; }

		public int? catalog_version_no { get; set; }

		public long? system_identifier { get; set; }

		public DateTimeOffset? pg_control_last_modified { get; set; }
	}

	public partial class pg_create_logical_replication_slotResult
	{
		public string slot_name { get; set; }

		public object lsn { get; set; }
	}

	public partial class pg_create_physical_replication_slotResult
	{
		public string slot_name { get; set; }

		public object lsn { get; set; }
	}

	public partial class pg_get_object_addressResult
	{
		public int? classid { get; set; }

		public int? objid { get; set; }

		public int? objsubid { get; set; }
	}

	public partial class pg_identify_objectResult
	{
		public string type { get; set; }

		public string schema { get; set; }

		public string name { get; set; }

		public string identity { get; set; }
	}

	public partial class pg_identify_object_as_addressResult
	{
		public string type { get; set; }

		public object object_names { get; set; }

		public object object_args { get; set; }
	}

	public partial class pg_last_committed_xactResult
	{
		public int? xid { get; set; }

		public DateTimeOffset? timestamp { get; set; }
	}

	public partial class pg_replication_slot_advanceResult
	{
		public string slot_name { get; set; }

		public object end_lsn { get; set; }
	}

	public partial class pg_sequence_parametersResult
	{
		public long? start_value { get; set; }

		public long? minimum_value { get; set; }

		public long? maximum_value { get; set; }

		public long? increment { get; set; }

		public bool? cycle_option { get; set; }

		public long? cache_size { get; set; }

		public int? data_type { get; set; }
	}

	public partial class pg_stat_fileResult
	{
		public long? size { get; set; }

		public DateTimeOffset? access { get; set; }

		public DateTimeOffset? modification { get; set; }

		public DateTimeOffset? change { get; set; }

		public DateTimeOffset? creation { get; set; }

		public bool? isdir { get; set; }
	}

	public partial class pg_stat_get_archiverResult
	{
		public long? archived_count { get; set; }

		public string last_archived_wal { get; set; }

		public DateTimeOffset? last_archived_time { get; set; }

		public long? failed_count { get; set; }

		public string last_failed_wal { get; set; }

		public DateTimeOffset? last_failed_time { get; set; }

		public DateTimeOffset? stats_reset { get; set; }
	}

	public partial class pg_stat_get_subscriptionResult
	{
		public int? subid { get; set; }

		public int? relid { get; set; }

		public int? pid { get; set; }

		public object received_lsn { get; set; }

		public DateTimeOffset? last_msg_send_time { get; set; }

		public DateTimeOffset? last_msg_receipt_time { get; set; }

		public object latest_end_lsn { get; set; }

		public DateTimeOffset? latest_end_time { get; set; }
	}

	public partial class pg_stat_get_wal_receiverResult
	{
		public int? pid { get; set; }

		public string status { get; set; }

		public object receive_start_lsn { get; set; }

		public int? receive_start_tli { get; set; }

		public object received_lsn { get; set; }

		public int? received_tli { get; set; }

		public DateTimeOffset? last_msg_send_time { get; set; }

		public DateTimeOffset? last_msg_receipt_time { get; set; }

		public object latest_end_lsn { get; set; }

		public DateTimeOffset? latest_end_time { get; set; }

		public string slot_name { get; set; }

		public string sender_host { get; set; }

		public int? sender_port { get; set; }

		public string conninfo { get; set; }
	}

	public partial class pg_walfile_name_offsetResult
	{
		public string file_name { get; set; }

		public int? file_offset { get; set; }
	}

	[Table(Schema="public", Name="contacts")]
	public partial class Contact
	{
		[Column("id"),    PrimaryKey, Identity] public long   Id    { get; set; } // bigint
		[Column("name"),  NotNull             ] public string Name  { get; set; } // character varying(255)
		[Column("value"), NotNull             ] public string Value { get; set; } // character varying(255)
	}

	[Table(Schema="public", Name="importances")]
	public partial class Importance
	{
		[Column("id"),   PrimaryKey, Identity] public long   Id   { get; set; } // bigint
		[Column("name"), NotNull             ] public string Name { get; set; } // character varying(255)

		#region Associations

		/// <summary>
		/// tasks_importance_id_foreign_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="ImportanceId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Task> Tasks { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="tasks")]
	public partial class Task
	{
		[Column("id"),            PrimaryKey,  Identity] public long      Id           { get; set; } // bigint
		[Column("header"),        NotNull              ] public string    Header       { get; set; } // character varying(255)
		[Column("description"),   NotNull              ] public string    Description  { get; set; } // character varying(255)
		[Column("extra"),            Nullable          ] public string    Extra        { get; set; } // character varying(255)
		[Column("owner_id"),      NotNull              ] public int       OwnerId      { get; set; } // integer
		[Column("importance_id"), NotNull              ] public int       ImportanceId { get; set; } // integer
		[Column("created_at"),       Nullable          ] public DateTime? CreatedAt    { get; set; } // timestamp (0) without time zone
		[Column("updated_at"),       Nullable          ] public DateTime? UpdatedAt    { get; set; } // timestamp (0) without time zone
		[Column("image"),            Nullable          ] public string    Image        { get; set; } // character varying(255)

		#region Associations

		/// <summary>
		/// tasks_importance_id_foreign
		/// </summary>
		[Association(ThisKey="ImportanceId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="tasks_importance_id_foreign", BackReferenceName="Tasksimportanceidforeigns")]
		public Importance Importance { get; set; }

		/// <summary>
		/// tasks_owner_id_foreign
		/// </summary>
		[Association(ThisKey="OwnerId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="tasks_owner_id_foreign", BackReferenceName="Tasksowneridforeigns")]
		public User Owner { get; set; }

		/// <summary>
		/// task_user_task_id_foreign_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TaskId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<TaskUser> Users { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="task_user")]
	public partial class TaskUser
	{
		[Column("id"),      PrimaryKey, Identity] public long Id     { get; set; } // bigint
		[Column("task_id"), NotNull             ] public int  TaskId { get; set; } // integer
		[Column("user_id"), NotNull             ] public int  UserId { get; set; } // integer

		#region Associations

		/// <summary>
		/// task_user_task_id_foreign
		/// </summary>
		[Association(ThisKey="TaskId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="task_user_task_id_foreign", BackReferenceName="Taskusertaskidforeigns")]
		public Task Task { get; set; }

		/// <summary>
		/// task_user_user_id_foreign
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="task_user_user_id_foreign", BackReferenceName="Taskuseruseridforeigns")]
		public User User { get; set; }

		#endregion
	}

	[Table(Schema="public", Name="users")]
	public partial class User
	{
		[Column("id"),       PrimaryKey, Identity] public long   Id       { get; set; } // bigint
		[Column("name"),     NotNull             ] public string Name     { get; set; } // character varying(255)
		[Column("email"),    NotNull             ] public string Email    { get; set; } // character varying(255)
		[Column("password"), NotNull             ] public string Password { get; set; } // character varying(255)

		#region Associations

		/// <summary>
		/// tasks_owner_id_foreign_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="OwnerId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Task> OwnedTasks { get; set; }

		/// <summary>
		/// task_user_user_id_foreign_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="UserId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<TaskUser> Tasks { get; set; }

		#endregion
	}

	public static partial class SqlFunctions
	{
		#region PgCharMaxLength

		[Sql.Function(Name="information_schema._pg_char_max_length", ServerSideOnly=true)]
		public static int? PgCharMaxLength(int? typid, int? typmod)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCharOctetLength

		[Sql.Function(Name="information_schema._pg_char_octet_length", ServerSideOnly=true)]
		public static int? PgCharOctetLength(int? typid, int? typmod)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDatetimePrecision

		[Sql.Function(Name="information_schema._pg_datetime_precision", ServerSideOnly=true)]
		public static int? PgDatetimePrecision(int? typid, int? typmod)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIndexPosition

		[Sql.Function(Name="information_schema._pg_index_position", ServerSideOnly=true)]
		public static int? PgIndexPosition(int? par6, short? par7)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIntervalType

		[Sql.Function(Name="information_schema._pg_interval_type", ServerSideOnly=true)]
		public static string PgIntervalType(int? typid, int? mod)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgKeysequal

		[Sql.Function(Name="information_schema._pg_keysequal", ServerSideOnly=true)]
		public static bool? PgKeysequal(object par10, object par11)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNumericPrecision

		[Sql.Function(Name="information_schema._pg_numeric_precision", ServerSideOnly=true)]
		public static int? PgNumericPrecision(int? typid, int? typmod)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNumericPrecisionRadix

		[Sql.Function(Name="information_schema._pg_numeric_precision_radix", ServerSideOnly=true)]
		public static int? PgNumericPrecisionRadix(int? typid, int? typmod)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNumericScale

		[Sql.Function(Name="information_schema._pg_numeric_scale", ServerSideOnly=true)]
		public static int? PgNumericScale(int? typid, int? typmod)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTruetypid

		[Sql.Function(Name="information_schema._pg_truetypid", ServerSideOnly=true)]
		public static int? PgTruetypid(object par16, object par17)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTruetypmod

		[Sql.Function(Name="information_schema._pg_truetypmod", ServerSideOnly=true)]
		public static int? PgTruetypmod(object par19, object par20)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abbrev

		[Sql.Function(Name="pg_catalog.abbrev", ServerSideOnly=true)]
		public static string Abbrev(NpgsqlInet? par24)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abs

		[Sql.Function(Name="pg_catalog.abs", ServerSideOnly=true)]
		public static decimal? Abs(decimal? par36)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstime

		[Sql.Function(Name="pg_catalog.abstime", ServerSideOnly=true)]
		public static object Abstime(DateTime? par40)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimeeq

		[Sql.Function(Name="pg_catalog.abstimeeq", ServerSideOnly=true)]
		public static bool? Abstimeeq(object par42, object par43)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimege

		[Sql.Function(Name="pg_catalog.abstimege", ServerSideOnly=true)]
		public static bool? Abstimege(object par45, object par46)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimegt

		[Sql.Function(Name="pg_catalog.abstimegt", ServerSideOnly=true)]
		public static bool? Abstimegt(object par48, object par49)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimein

		[Sql.Function(Name="pg_catalog.abstimein", ServerSideOnly=true)]
		public static object Abstimein(object par51)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimele

		[Sql.Function(Name="pg_catalog.abstimele", ServerSideOnly=true)]
		public static bool? Abstimele(object par53, object par54)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimelt

		[Sql.Function(Name="pg_catalog.abstimelt", ServerSideOnly=true)]
		public static bool? Abstimelt(object par56, object par57)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimene

		[Sql.Function(Name="pg_catalog.abstimene", ServerSideOnly=true)]
		public static bool? Abstimene(object par59, object par60)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimeout

		[Sql.Function(Name="pg_catalog.abstimeout", ServerSideOnly=true)]
		public static object Abstimeout(object par62)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimerecv

		[Sql.Function(Name="pg_catalog.abstimerecv", ServerSideOnly=true)]
		public static object Abstimerecv(object par64)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Abstimesend

		[Sql.Function(Name="pg_catalog.abstimesend", ServerSideOnly=true)]
		public static byte[] Abstimesend(object par66)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Aclcontains

		[Sql.Function(Name="pg_catalog.aclcontains", ServerSideOnly=true)]
		public static bool? Aclcontains(object par68, object par69)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Acldefault

		[Sql.Function(Name="pg_catalog.acldefault", ServerSideOnly=true)]
		public static object Acldefault(object par71, int? par72)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Aclinsert

		[Sql.Function(Name="pg_catalog.aclinsert", ServerSideOnly=true)]
		public static object Aclinsert(object par74, object par75)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Aclitemeq

		[Sql.Function(Name="pg_catalog.aclitemeq", ServerSideOnly=true)]
		public static bool? Aclitemeq(object par77, object par78)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Aclitemin

		[Sql.Function(Name="pg_catalog.aclitemin", ServerSideOnly=true)]
		public static object Aclitemin(object par80)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Aclitemout

		[Sql.Function(Name="pg_catalog.aclitemout", ServerSideOnly=true)]
		public static object Aclitemout(object par82)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Aclremove

		[Sql.Function(Name="pg_catalog.aclremove", ServerSideOnly=true)]
		public static object Aclremove(object par84, object par85)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Acos

		[Sql.Function(Name="pg_catalog.acos", ServerSideOnly=true)]
		public static double? Acos(double? par87)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Acosd

		[Sql.Function(Name="pg_catalog.acosd", ServerSideOnly=true)]
		public static double? Acosd(double? par89)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Age

		[Sql.Function(Name="pg_catalog.age", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? Age(DateTime? par101)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Amvalidate

		[Sql.Function(Name="pg_catalog.amvalidate", ServerSideOnly=true)]
		public static bool? Amvalidate(int? par103)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyIn

		[Sql.Function(Name="pg_catalog.any_in", ServerSideOnly=true)]
		public static object AnyIn(object par105)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyOut

		[Sql.Function(Name="pg_catalog.any_out", ServerSideOnly=true)]
		public static object AnyOut(object par107)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyarrayIn

		[Sql.Function(Name="pg_catalog.anyarray_in", ServerSideOnly=true)]
		public static object AnyarrayIn(object par109)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyarrayOut

		[Sql.Function(Name="pg_catalog.anyarray_out", ServerSideOnly=true)]
		public static object AnyarrayOut(object par111)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyarrayRecv

		[Sql.Function(Name="pg_catalog.anyarray_recv", ServerSideOnly=true)]
		public static object AnyarrayRecv(object par113)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyarraySend

		[Sql.Function(Name="pg_catalog.anyarray_send", ServerSideOnly=true)]
		public static byte[] AnyarraySend(object par115)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyelementIn

		[Sql.Function(Name="pg_catalog.anyelement_in", ServerSideOnly=true)]
		public static object AnyelementIn(object par117)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyelementOut

		[Sql.Function(Name="pg_catalog.anyelement_out", ServerSideOnly=true)]
		public static object AnyelementOut(object par119)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyenumIn

		[Sql.Function(Name="pg_catalog.anyenum_in", ServerSideOnly=true)]
		public static object AnyenumIn(object par121)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyenumOut

		[Sql.Function(Name="pg_catalog.anyenum_out", ServerSideOnly=true)]
		public static object AnyenumOut(object par123)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnynonarrayIn

		[Sql.Function(Name="pg_catalog.anynonarray_in", ServerSideOnly=true)]
		public static object AnynonarrayIn(object par125)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnynonarrayOut

		[Sql.Function(Name="pg_catalog.anynonarray_out", ServerSideOnly=true)]
		public static object AnynonarrayOut(object par127)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyrangeIn

		[Sql.Function(Name="pg_catalog.anyrange_in", ServerSideOnly=true)]
		public static object AnyrangeIn(object par129, int? par130, int? par131)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AnyrangeOut

		[Sql.Function(Name="pg_catalog.anyrange_out", ServerSideOnly=true)]
		public static object AnyrangeOut(object par133)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Anytextcat

		[Sql.Function(Name="pg_catalog.anytextcat", ServerSideOnly=true)]
		public static string Anytextcat(object par135, string par136)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Area

		[Sql.Function(Name="pg_catalog.area", ServerSideOnly=true)]
		public static double? Area(NpgsqlPath? par142)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Areajoinsel

		[Sql.Function(Name="pg_catalog.areajoinsel", ServerSideOnly=true)]
		public static double? Areajoinsel(object par144, int? par145, object par146, short? par147, object par148)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Areasel

		[Sql.Function(Name="pg_catalog.areasel", ServerSideOnly=true)]
		public static double? Areasel(object par150, int? par151, object par152, int? par153)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayAgg

		[Sql.Function(Name="pg_catalog.array_agg", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static object ArrayAgg<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par157)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayAggArrayFinalfn

		[Sql.Function(Name="pg_catalog.array_agg_array_finalfn", ServerSideOnly=true)]
		public static object ArrayAggArrayFinalfn(object par159, object par160)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayAggArrayTransfn

		[Sql.Function(Name="pg_catalog.array_agg_array_transfn", ServerSideOnly=true)]
		public static object ArrayAggArrayTransfn(object par162, object par163)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayAggFinalfn

		[Sql.Function(Name="pg_catalog.array_agg_finalfn", ServerSideOnly=true)]
		public static object ArrayAggFinalfn(object par165, object par166)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayAggTransfn

		[Sql.Function(Name="pg_catalog.array_agg_transfn", ServerSideOnly=true)]
		public static object ArrayAggTransfn(object par168, object par169)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayAppend

		[Sql.Function(Name="pg_catalog.array_append", ServerSideOnly=true)]
		public static object ArrayAppend(object par171, object par172)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayCat

		[Sql.Function(Name="pg_catalog.array_cat", ServerSideOnly=true)]
		public static object ArrayCat(object par174, object par175)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayDims

		[Sql.Function(Name="pg_catalog.array_dims", ServerSideOnly=true)]
		public static string ArrayDims(object par177)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayEq

		[Sql.Function(Name="pg_catalog.array_eq", ServerSideOnly=true)]
		public static bool? ArrayEq(object par179, object par180)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayFill

		[Sql.Function(Name="pg_catalog.array_fill", ServerSideOnly=true)]
		public static object ArrayFill(object par185, object par186, object par187)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayGe

		[Sql.Function(Name="pg_catalog.array_ge", ServerSideOnly=true)]
		public static bool? ArrayGe(object par189, object par190)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayGt

		[Sql.Function(Name="pg_catalog.array_gt", ServerSideOnly=true)]
		public static bool? ArrayGt(object par192, object par193)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayIn

		[Sql.Function(Name="pg_catalog.array_in", ServerSideOnly=true)]
		public static object ArrayIn(object par195, int? par196, int? par197)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayLarger

		[Sql.Function(Name="pg_catalog.array_larger", ServerSideOnly=true)]
		public static object ArrayLarger(object par199, object par200)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayLe

		[Sql.Function(Name="pg_catalog.array_le", ServerSideOnly=true)]
		public static bool? ArrayLe(object par202, object par203)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayLength

		[Sql.Function(Name="pg_catalog.array_length", ServerSideOnly=true)]
		public static int? ArrayLength(object par205, int? par206)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayLower

		[Sql.Function(Name="pg_catalog.array_lower", ServerSideOnly=true)]
		public static int? ArrayLower(object par208, int? par209)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayLt

		[Sql.Function(Name="pg_catalog.array_lt", ServerSideOnly=true)]
		public static bool? ArrayLt(object par211, object par212)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayNdims

		[Sql.Function(Name="pg_catalog.array_ndims", ServerSideOnly=true)]
		public static int? ArrayNdims(object par214)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayNe

		[Sql.Function(Name="pg_catalog.array_ne", ServerSideOnly=true)]
		public static bool? ArrayNe(object par216, object par217)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayOut

		[Sql.Function(Name="pg_catalog.array_out", ServerSideOnly=true)]
		public static object ArrayOut(object par219)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayPosition

		[Sql.Function(Name="pg_catalog.array_position", ServerSideOnly=true)]
		public static int? ArrayPosition(object par224, object par225, int? par226)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayPositions

		[Sql.Function(Name="pg_catalog.array_positions", ServerSideOnly=true)]
		public static object ArrayPositions(object par228, object par229)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayPrepend

		[Sql.Function(Name="pg_catalog.array_prepend", ServerSideOnly=true)]
		public static object ArrayPrepend(object par231, object par232)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayRecv

		[Sql.Function(Name="pg_catalog.array_recv", ServerSideOnly=true)]
		public static object ArrayRecv(object par234, int? par235, int? par236)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayRemove

		[Sql.Function(Name="pg_catalog.array_remove", ServerSideOnly=true)]
		public static object ArrayRemove(object par238, object par239)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayReplace

		[Sql.Function(Name="pg_catalog.array_replace", ServerSideOnly=true)]
		public static object ArrayReplace(object par241, object par242, object par243)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArraySend

		[Sql.Function(Name="pg_catalog.array_send", ServerSideOnly=true)]
		public static byte[] ArraySend(object par245)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArraySmaller

		[Sql.Function(Name="pg_catalog.array_smaller", ServerSideOnly=true)]
		public static object ArraySmaller(object par247, object par248)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayToJson

		[Sql.Function(Name="pg_catalog.array_to_json", ServerSideOnly=true)]
		public static string ArrayToJson(object par252, bool? par253)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayToString

		[Sql.Function(Name="pg_catalog.array_to_string", ServerSideOnly=true)]
		public static string ArrayToString(object par259, string par260)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayToTsvector

		[Sql.Function(Name="pg_catalog.array_to_tsvector", ServerSideOnly=true)]
		public static object ArrayToTsvector(object par262)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayTypanalyze

		[Sql.Function(Name="pg_catalog.array_typanalyze", ServerSideOnly=true)]
		public static bool? ArrayTypanalyze(object par264)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ArrayUpper

		[Sql.Function(Name="pg_catalog.array_upper", ServerSideOnly=true)]
		public static int? ArrayUpper(object par266, int? par267)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Arraycontained

		[Sql.Function(Name="pg_catalog.arraycontained", ServerSideOnly=true)]
		public static bool? Arraycontained(object par269, object par270)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Arraycontains

		[Sql.Function(Name="pg_catalog.arraycontains", ServerSideOnly=true)]
		public static bool? Arraycontains(object par272, object par273)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Arraycontjoinsel

		[Sql.Function(Name="pg_catalog.arraycontjoinsel", ServerSideOnly=true)]
		public static double? Arraycontjoinsel(object par275, int? par276, object par277, short? par278, object par279)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Arraycontsel

		[Sql.Function(Name="pg_catalog.arraycontsel", ServerSideOnly=true)]
		public static double? Arraycontsel(object par281, int? par282, object par283, int? par284)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Arrayoverlap

		[Sql.Function(Name="pg_catalog.arrayoverlap", ServerSideOnly=true)]
		public static bool? Arrayoverlap(object par286, object par287)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ascii

		[Sql.Function(Name="pg_catalog.ascii", ServerSideOnly=true)]
		public static int? Ascii(string par289)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AsciiToMic

		[Sql.Function(Name="pg_catalog.ascii_to_mic", ServerSideOnly=true)]
		public static object AsciiToMic(int? par290, int? par291, object par292, object par293, int? par294)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region AsciiToUtf8

		[Sql.Function(Name="pg_catalog.ascii_to_utf8", ServerSideOnly=true)]
		public static object AsciiToUtf8(int? par295, int? par296, object par297, object par298, int? par299)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Asin

		[Sql.Function(Name="pg_catalog.asin", ServerSideOnly=true)]
		public static double? Asin(double? par301)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Asind

		[Sql.Function(Name="pg_catalog.asind", ServerSideOnly=true)]
		public static double? Asind(double? par303)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Atan

		[Sql.Function(Name="pg_catalog.atan", ServerSideOnly=true)]
		public static double? Atan(double? par305)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Atan2

		[Sql.Function(Name="pg_catalog.atan2", ServerSideOnly=true)]
		public static double? Atan2(double? par307, double? par308)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Atan2d

		[Sql.Function(Name="pg_catalog.atan2d", ServerSideOnly=true)]
		public static double? Atan2d(double? par310, double? par311)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Atand

		[Sql.Function(Name="pg_catalog.atand", ServerSideOnly=true)]
		public static double? Atand(double? par313)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Avg

		[Sql.Function(Name="pg_catalog.avg", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static NpgsqlTimeSpan? Avg<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, NpgsqlTimeSpan?>> par327)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bernoulli

		[Sql.Function(Name="pg_catalog.bernoulli", ServerSideOnly=true)]
		public static object Bernoulli(object par329)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Big5ToEucTw

		[Sql.Function(Name="pg_catalog.big5_to_euc_tw", ServerSideOnly=true)]
		public static object Big5ToEucTw(int? par330, int? par331, object par332, object par333, int? par334)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Big5ToMic

		[Sql.Function(Name="pg_catalog.big5_to_mic", ServerSideOnly=true)]
		public static object Big5ToMic(int? par335, int? par336, object par337, object par338, int? par339)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Big5ToUtf8

		[Sql.Function(Name="pg_catalog.big5_to_utf8", ServerSideOnly=true)]
		public static object Big5ToUtf8(int? par340, int? par341, object par342, object par343, int? par344)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeCreateEmptyExtension

		[Sql.Function(Name="pg_catalog.binary_upgrade_create_empty_extension", ServerSideOnly=true)]
		public static object BinaryUpgradeCreateEmptyExtension(string par345, string par346, bool? par347, string par348, object par349, object par350, object par351)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetMissingValue

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_missing_value", ServerSideOnly=true)]
		public static object BinaryUpgradeSetMissingValue(int? par352, string par353, string par354)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetNextArrayPgTypeOid

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_next_array_pg_type_oid", ServerSideOnly=true)]
		public static object BinaryUpgradeSetNextArrayPgTypeOid(int? par355)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetNextHeapPgClassOid

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_next_heap_pg_class_oid", ServerSideOnly=true)]
		public static object BinaryUpgradeSetNextHeapPgClassOid(int? par356)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetNextIndexPgClassOid

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_next_index_pg_class_oid", ServerSideOnly=true)]
		public static object BinaryUpgradeSetNextIndexPgClassOid(int? par357)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetNextPgAuthidOid

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_next_pg_authid_oid", ServerSideOnly=true)]
		public static object BinaryUpgradeSetNextPgAuthidOid(int? par358)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetNextPgEnumOid

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_next_pg_enum_oid", ServerSideOnly=true)]
		public static object BinaryUpgradeSetNextPgEnumOid(int? par359)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetNextPgTypeOid

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_next_pg_type_oid", ServerSideOnly=true)]
		public static object BinaryUpgradeSetNextPgTypeOid(int? par360)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetNextToastPgClassOid

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_next_toast_pg_class_oid", ServerSideOnly=true)]
		public static object BinaryUpgradeSetNextToastPgClassOid(int? par361)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetNextToastPgTypeOid

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_next_toast_pg_type_oid", ServerSideOnly=true)]
		public static object BinaryUpgradeSetNextToastPgTypeOid(int? par362)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BinaryUpgradeSetRecordInitPrivs

		[Sql.Function(Name="pg_catalog.binary_upgrade_set_record_init_privs", ServerSideOnly=true)]
		public static object BinaryUpgradeSetRecordInitPrivs(bool? par363)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bit

		[Sql.Function(Name="pg_catalog.bit", ServerSideOnly=true)]
		public static BitArray Bit(long? par372, int? par373)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BitAnd

		[Sql.Function(Name="pg_catalog.bit_and", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static BitArray BitAnd<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, BitArray>> par381)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BitIn

		[Sql.Function(Name="pg_catalog.bit_in", ServerSideOnly=true)]
		public static BitArray BitIn(object par383, int? par384, int? par385)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BitLength

		[Sql.Function(Name="pg_catalog.bit_length", ServerSideOnly=true)]
		public static int? BitLength(BitArray par391)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BitOr

		[Sql.Function(Name="pg_catalog.bit_or", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static BitArray BitOr<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, BitArray>> par399)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BitOut

		[Sql.Function(Name="pg_catalog.bit_out", ServerSideOnly=true)]
		public static object BitOut(BitArray par401)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BitRecv

		[Sql.Function(Name="pg_catalog.bit_recv", ServerSideOnly=true)]
		public static BitArray BitRecv(object par403, int? par404, int? par405)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BitSend

		[Sql.Function(Name="pg_catalog.bit_send", ServerSideOnly=true)]
		public static byte[] BitSend(BitArray par407)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitand

		[Sql.Function(Name="pg_catalog.bitand", ServerSideOnly=true)]
		public static BitArray Bitand(BitArray par409, BitArray par410)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitcat

		[Sql.Function(Name="pg_catalog.bitcat", ServerSideOnly=true)]
		public static BitArray Bitcat(BitArray par412, BitArray par413)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitcmp

		[Sql.Function(Name="pg_catalog.bitcmp", ServerSideOnly=true)]
		public static int? Bitcmp(BitArray par415, BitArray par416)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Biteq

		[Sql.Function(Name="pg_catalog.biteq", ServerSideOnly=true)]
		public static bool? Biteq(BitArray par418, BitArray par419)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitge

		[Sql.Function(Name="pg_catalog.bitge", ServerSideOnly=true)]
		public static bool? Bitge(BitArray par421, BitArray par422)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitgt

		[Sql.Function(Name="pg_catalog.bitgt", ServerSideOnly=true)]
		public static bool? Bitgt(BitArray par424, BitArray par425)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitle

		[Sql.Function(Name="pg_catalog.bitle", ServerSideOnly=true)]
		public static bool? Bitle(BitArray par427, BitArray par428)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitlt

		[Sql.Function(Name="pg_catalog.bitlt", ServerSideOnly=true)]
		public static bool? Bitlt(BitArray par430, BitArray par431)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitne

		[Sql.Function(Name="pg_catalog.bitne", ServerSideOnly=true)]
		public static bool? Bitne(BitArray par433, BitArray par434)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitnot

		[Sql.Function(Name="pg_catalog.bitnot", ServerSideOnly=true)]
		public static BitArray Bitnot(BitArray par436)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitor

		[Sql.Function(Name="pg_catalog.bitor", ServerSideOnly=true)]
		public static BitArray Bitor(BitArray par438, BitArray par439)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitshiftleft

		[Sql.Function(Name="pg_catalog.bitshiftleft", ServerSideOnly=true)]
		public static BitArray Bitshiftleft(BitArray par441, int? par442)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitshiftright

		[Sql.Function(Name="pg_catalog.bitshiftright", ServerSideOnly=true)]
		public static BitArray Bitshiftright(BitArray par444, int? par445)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bittypmodin

		[Sql.Function(Name="pg_catalog.bittypmodin", ServerSideOnly=true)]
		public static int? Bittypmodin(object par447)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bittypmodout

		[Sql.Function(Name="pg_catalog.bittypmodout", ServerSideOnly=true)]
		public static object Bittypmodout(int? par449)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bitxor

		[Sql.Function(Name="pg_catalog.bitxor", ServerSideOnly=true)]
		public static BitArray Bitxor(BitArray par451, BitArray par452)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bool

		[Sql.Function(Name="pg_catalog.bool", ServerSideOnly=true)]
		public static bool? Bool(string par456)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoolAccum

		[Sql.Function(Name="pg_catalog.bool_accum", ServerSideOnly=true)]
		public static object BoolAccum(object par458, bool? par459)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoolAccumInv

		[Sql.Function(Name="pg_catalog.bool_accum_inv", ServerSideOnly=true)]
		public static object BoolAccumInv(object par461, bool? par462)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoolAlltrue

		[Sql.Function(Name="pg_catalog.bool_alltrue", ServerSideOnly=true)]
		public static bool? BoolAlltrue(object par464)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoolAnd

		[Sql.Function(Name="pg_catalog.bool_and", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static bool? BoolAnd<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, bool?>> par466)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoolAnytrue

		[Sql.Function(Name="pg_catalog.bool_anytrue", ServerSideOnly=true)]
		public static bool? BoolAnytrue(object par468)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoolOr

		[Sql.Function(Name="pg_catalog.bool_or", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static bool? BoolOr<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, bool?>> par470)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoolandStatefunc

		[Sql.Function(Name="pg_catalog.booland_statefunc", ServerSideOnly=true)]
		public static bool? BoolandStatefunc(bool? par472, bool? par473)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Booleq

		[Sql.Function(Name="pg_catalog.booleq", ServerSideOnly=true)]
		public static bool? Booleq(bool? par475, bool? par476)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Boolge

		[Sql.Function(Name="pg_catalog.boolge", ServerSideOnly=true)]
		public static bool? Boolge(bool? par478, bool? par479)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Boolgt

		[Sql.Function(Name="pg_catalog.boolgt", ServerSideOnly=true)]
		public static bool? Boolgt(bool? par481, bool? par482)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Boolin

		[Sql.Function(Name="pg_catalog.boolin", ServerSideOnly=true)]
		public static bool? Boolin(object par484)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Boolle

		[Sql.Function(Name="pg_catalog.boolle", ServerSideOnly=true)]
		public static bool? Boolle(bool? par486, bool? par487)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Boollt

		[Sql.Function(Name="pg_catalog.boollt", ServerSideOnly=true)]
		public static bool? Boollt(bool? par489, bool? par490)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Boolne

		[Sql.Function(Name="pg_catalog.boolne", ServerSideOnly=true)]
		public static bool? Boolne(bool? par492, bool? par493)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoolorStatefunc

		[Sql.Function(Name="pg_catalog.boolor_statefunc", ServerSideOnly=true)]
		public static bool? BoolorStatefunc(bool? par495, bool? par496)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Boolout

		[Sql.Function(Name="pg_catalog.boolout", ServerSideOnly=true)]
		public static object Boolout(bool? par498)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Boolrecv

		[Sql.Function(Name="pg_catalog.boolrecv", ServerSideOnly=true)]
		public static bool? Boolrecv(object par500)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Boolsend

		[Sql.Function(Name="pg_catalog.boolsend", ServerSideOnly=true)]
		public static byte[] Boolsend(bool? par502)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoundBox

		[Sql.Function(Name="pg_catalog.bound_box", ServerSideOnly=true)]
		public static NpgsqlBox? BoundBox(NpgsqlBox? par504, NpgsqlBox? par505)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Box

		[Sql.Function(Name="pg_catalog.box", ServerSideOnly=true)]
		public static NpgsqlBox? Box(NpgsqlPoint? par514)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxAbove

		[Sql.Function(Name="pg_catalog.box_above", ServerSideOnly=true)]
		public static bool? BoxAbove(NpgsqlBox? par516, NpgsqlBox? par517)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxAboveEq

		[Sql.Function(Name="pg_catalog.box_above_eq", ServerSideOnly=true)]
		public static bool? BoxAboveEq(NpgsqlBox? par519, NpgsqlBox? par520)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxAdd

		[Sql.Function(Name="pg_catalog.box_add", ServerSideOnly=true)]
		public static NpgsqlBox? BoxAdd(NpgsqlBox? par522, NpgsqlPoint? par523)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxBelow

		[Sql.Function(Name="pg_catalog.box_below", ServerSideOnly=true)]
		public static bool? BoxBelow(NpgsqlBox? par525, NpgsqlBox? par526)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxBelowEq

		[Sql.Function(Name="pg_catalog.box_below_eq", ServerSideOnly=true)]
		public static bool? BoxBelowEq(NpgsqlBox? par528, NpgsqlBox? par529)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxCenter

		[Sql.Function(Name="pg_catalog.box_center", ServerSideOnly=true)]
		public static NpgsqlPoint? BoxCenter(NpgsqlBox? par531)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxContain

		[Sql.Function(Name="pg_catalog.box_contain", ServerSideOnly=true)]
		public static bool? BoxContain(NpgsqlBox? par533, NpgsqlBox? par534)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxContainPt

		[Sql.Function(Name="pg_catalog.box_contain_pt", ServerSideOnly=true)]
		public static bool? BoxContainPt(NpgsqlBox? par536, NpgsqlPoint? par537)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxContained

		[Sql.Function(Name="pg_catalog.box_contained", ServerSideOnly=true)]
		public static bool? BoxContained(NpgsqlBox? par539, NpgsqlBox? par540)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxDistance

		[Sql.Function(Name="pg_catalog.box_distance", ServerSideOnly=true)]
		public static double? BoxDistance(NpgsqlBox? par542, NpgsqlBox? par543)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxDiv

		[Sql.Function(Name="pg_catalog.box_div", ServerSideOnly=true)]
		public static NpgsqlBox? BoxDiv(NpgsqlBox? par545, NpgsqlPoint? par546)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxEq

		[Sql.Function(Name="pg_catalog.box_eq", ServerSideOnly=true)]
		public static bool? BoxEq(NpgsqlBox? par548, NpgsqlBox? par549)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxGe

		[Sql.Function(Name="pg_catalog.box_ge", ServerSideOnly=true)]
		public static bool? BoxGe(NpgsqlBox? par551, NpgsqlBox? par552)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxGt

		[Sql.Function(Name="pg_catalog.box_gt", ServerSideOnly=true)]
		public static bool? BoxGt(NpgsqlBox? par554, NpgsqlBox? par555)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxIn

		[Sql.Function(Name="pg_catalog.box_in", ServerSideOnly=true)]
		public static NpgsqlBox? BoxIn(object par557)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxIntersect

		[Sql.Function(Name="pg_catalog.box_intersect", ServerSideOnly=true)]
		public static NpgsqlBox? BoxIntersect(NpgsqlBox? par559, NpgsqlBox? par560)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxLe

		[Sql.Function(Name="pg_catalog.box_le", ServerSideOnly=true)]
		public static bool? BoxLe(NpgsqlBox? par562, NpgsqlBox? par563)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxLeft

		[Sql.Function(Name="pg_catalog.box_left", ServerSideOnly=true)]
		public static bool? BoxLeft(NpgsqlBox? par565, NpgsqlBox? par566)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxLt

		[Sql.Function(Name="pg_catalog.box_lt", ServerSideOnly=true)]
		public static bool? BoxLt(NpgsqlBox? par568, NpgsqlBox? par569)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxMul

		[Sql.Function(Name="pg_catalog.box_mul", ServerSideOnly=true)]
		public static NpgsqlBox? BoxMul(NpgsqlBox? par571, NpgsqlPoint? par572)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxOut

		[Sql.Function(Name="pg_catalog.box_out", ServerSideOnly=true)]
		public static object BoxOut(NpgsqlBox? par574)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxOverabove

		[Sql.Function(Name="pg_catalog.box_overabove", ServerSideOnly=true)]
		public static bool? BoxOverabove(NpgsqlBox? par576, NpgsqlBox? par577)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxOverbelow

		[Sql.Function(Name="pg_catalog.box_overbelow", ServerSideOnly=true)]
		public static bool? BoxOverbelow(NpgsqlBox? par579, NpgsqlBox? par580)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxOverlap

		[Sql.Function(Name="pg_catalog.box_overlap", ServerSideOnly=true)]
		public static bool? BoxOverlap(NpgsqlBox? par582, NpgsqlBox? par583)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxOverleft

		[Sql.Function(Name="pg_catalog.box_overleft", ServerSideOnly=true)]
		public static bool? BoxOverleft(NpgsqlBox? par585, NpgsqlBox? par586)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxOverright

		[Sql.Function(Name="pg_catalog.box_overright", ServerSideOnly=true)]
		public static bool? BoxOverright(NpgsqlBox? par588, NpgsqlBox? par589)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxRecv

		[Sql.Function(Name="pg_catalog.box_recv", ServerSideOnly=true)]
		public static NpgsqlBox? BoxRecv(object par591)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxRight

		[Sql.Function(Name="pg_catalog.box_right", ServerSideOnly=true)]
		public static bool? BoxRight(NpgsqlBox? par593, NpgsqlBox? par594)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxSame

		[Sql.Function(Name="pg_catalog.box_same", ServerSideOnly=true)]
		public static bool? BoxSame(NpgsqlBox? par596, NpgsqlBox? par597)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxSend

		[Sql.Function(Name="pg_catalog.box_send", ServerSideOnly=true)]
		public static byte[] BoxSend(NpgsqlBox? par599)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BoxSub

		[Sql.Function(Name="pg_catalog.box_sub", ServerSideOnly=true)]
		public static NpgsqlBox? BoxSub(NpgsqlBox? par601, NpgsqlPoint? par602)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpchar

		[Sql.Function(Name="pg_catalog.bpchar", ServerSideOnly=true)]
		public static string Bpchar(object par610)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BpcharLarger

		[Sql.Function(Name="pg_catalog.bpchar_larger", ServerSideOnly=true)]
		public static string BpcharLarger(string par612, string par613)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BpcharPatternGe

		[Sql.Function(Name="pg_catalog.bpchar_pattern_ge", ServerSideOnly=true)]
		public static bool? BpcharPatternGe(string par615, string par616)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BpcharPatternGt

		[Sql.Function(Name="pg_catalog.bpchar_pattern_gt", ServerSideOnly=true)]
		public static bool? BpcharPatternGt(string par618, string par619)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BpcharPatternLe

		[Sql.Function(Name="pg_catalog.bpchar_pattern_le", ServerSideOnly=true)]
		public static bool? BpcharPatternLe(string par621, string par622)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BpcharPatternLt

		[Sql.Function(Name="pg_catalog.bpchar_pattern_lt", ServerSideOnly=true)]
		public static bool? BpcharPatternLt(string par624, string par625)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BpcharSmaller

		[Sql.Function(Name="pg_catalog.bpchar_smaller", ServerSideOnly=true)]
		public static string BpcharSmaller(string par627, string par628)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BpcharSortsupport

		[Sql.Function(Name="pg_catalog.bpchar_sortsupport", ServerSideOnly=true)]
		public static object BpcharSortsupport(object par629)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharcmp

		[Sql.Function(Name="pg_catalog.bpcharcmp", ServerSideOnly=true)]
		public static int? Bpcharcmp(string par631, string par632)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpchareq

		[Sql.Function(Name="pg_catalog.bpchareq", ServerSideOnly=true)]
		public static bool? Bpchareq(string par634, string par635)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharge

		[Sql.Function(Name="pg_catalog.bpcharge", ServerSideOnly=true)]
		public static bool? Bpcharge(string par637, string par638)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpchargt

		[Sql.Function(Name="pg_catalog.bpchargt", ServerSideOnly=true)]
		public static bool? Bpchargt(string par640, string par641)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpchariclike

		[Sql.Function(Name="pg_catalog.bpchariclike", ServerSideOnly=true)]
		public static bool? Bpchariclike(string par643, string par644)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharicnlike

		[Sql.Function(Name="pg_catalog.bpcharicnlike", ServerSideOnly=true)]
		public static bool? Bpcharicnlike(string par646, string par647)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharicregexeq

		[Sql.Function(Name="pg_catalog.bpcharicregexeq", ServerSideOnly=true)]
		public static bool? Bpcharicregexeq(string par649, string par650)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharicregexne

		[Sql.Function(Name="pg_catalog.bpcharicregexne", ServerSideOnly=true)]
		public static bool? Bpcharicregexne(string par652, string par653)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharin

		[Sql.Function(Name="pg_catalog.bpcharin", ServerSideOnly=true)]
		public static string Bpcharin(object par655, int? par656, int? par657)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharle

		[Sql.Function(Name="pg_catalog.bpcharle", ServerSideOnly=true)]
		public static bool? Bpcharle(string par659, string par660)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharlike

		[Sql.Function(Name="pg_catalog.bpcharlike", ServerSideOnly=true)]
		public static bool? Bpcharlike(string par662, string par663)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharlt

		[Sql.Function(Name="pg_catalog.bpcharlt", ServerSideOnly=true)]
		public static bool? Bpcharlt(string par665, string par666)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharne

		[Sql.Function(Name="pg_catalog.bpcharne", ServerSideOnly=true)]
		public static bool? Bpcharne(string par668, string par669)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharnlike

		[Sql.Function(Name="pg_catalog.bpcharnlike", ServerSideOnly=true)]
		public static bool? Bpcharnlike(string par671, string par672)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharout

		[Sql.Function(Name="pg_catalog.bpcharout", ServerSideOnly=true)]
		public static object Bpcharout(string par674)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharrecv

		[Sql.Function(Name="pg_catalog.bpcharrecv", ServerSideOnly=true)]
		public static string Bpcharrecv(object par676, int? par677, int? par678)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharregexeq

		[Sql.Function(Name="pg_catalog.bpcharregexeq", ServerSideOnly=true)]
		public static bool? Bpcharregexeq(string par680, string par681)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharregexne

		[Sql.Function(Name="pg_catalog.bpcharregexne", ServerSideOnly=true)]
		public static bool? Bpcharregexne(string par683, string par684)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpcharsend

		[Sql.Function(Name="pg_catalog.bpcharsend", ServerSideOnly=true)]
		public static byte[] Bpcharsend(string par686)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpchartypmodin

		[Sql.Function(Name="pg_catalog.bpchartypmodin", ServerSideOnly=true)]
		public static int? Bpchartypmodin(object par688)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bpchartypmodout

		[Sql.Function(Name="pg_catalog.bpchartypmodout", ServerSideOnly=true)]
		public static object Bpchartypmodout(int? par690)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinDesummarizeRange

		[Sql.Function(Name="pg_catalog.brin_desummarize_range", ServerSideOnly=true)]
		public static object BrinDesummarizeRange(object par691, long? par692)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinInclusionAddValue

		[Sql.Function(Name="pg_catalog.brin_inclusion_add_value", ServerSideOnly=true)]
		public static bool? BrinInclusionAddValue(object par694, object par695, object par696, object par697)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinInclusionConsistent

		[Sql.Function(Name="pg_catalog.brin_inclusion_consistent", ServerSideOnly=true)]
		public static bool? BrinInclusionConsistent(object par699, object par700, object par701)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinInclusionOpcinfo

		[Sql.Function(Name="pg_catalog.brin_inclusion_opcinfo", ServerSideOnly=true)]
		public static object BrinInclusionOpcinfo(object par703)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinInclusionUnion

		[Sql.Function(Name="pg_catalog.brin_inclusion_union", ServerSideOnly=true)]
		public static bool? BrinInclusionUnion(object par705, object par706, object par707)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinMinmaxAddValue

		[Sql.Function(Name="pg_catalog.brin_minmax_add_value", ServerSideOnly=true)]
		public static bool? BrinMinmaxAddValue(object par709, object par710, object par711, object par712)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinMinmaxConsistent

		[Sql.Function(Name="pg_catalog.brin_minmax_consistent", ServerSideOnly=true)]
		public static bool? BrinMinmaxConsistent(object par714, object par715, object par716)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinMinmaxOpcinfo

		[Sql.Function(Name="pg_catalog.brin_minmax_opcinfo", ServerSideOnly=true)]
		public static object BrinMinmaxOpcinfo(object par718)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinMinmaxUnion

		[Sql.Function(Name="pg_catalog.brin_minmax_union", ServerSideOnly=true)]
		public static bool? BrinMinmaxUnion(object par720, object par721, object par722)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinSummarizeNewValues

		[Sql.Function(Name="pg_catalog.brin_summarize_new_values", ServerSideOnly=true)]
		public static int? BrinSummarizeNewValues(object par724)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BrinSummarizeRange

		[Sql.Function(Name="pg_catalog.brin_summarize_range", ServerSideOnly=true)]
		public static int? BrinSummarizeRange(object par726, long? par727)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Brinhandler

		[Sql.Function(Name="pg_catalog.brinhandler", ServerSideOnly=true)]
		public static object Brinhandler(object par729)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Broadcast

		[Sql.Function(Name="pg_catalog.broadcast", ServerSideOnly=true)]
		public static NpgsqlInet? Broadcast(NpgsqlInet? par731)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btabstimecmp

		[Sql.Function(Name="pg_catalog.btabstimecmp", ServerSideOnly=true)]
		public static int? Btabstimecmp(object par733, object par734)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btarraycmp

		[Sql.Function(Name="pg_catalog.btarraycmp", ServerSideOnly=true)]
		public static int? Btarraycmp(object par736, object par737)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btboolcmp

		[Sql.Function(Name="pg_catalog.btboolcmp", ServerSideOnly=true)]
		public static int? Btboolcmp(bool? par739, bool? par740)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BtbpcharPatternCmp

		[Sql.Function(Name="pg_catalog.btbpchar_pattern_cmp", ServerSideOnly=true)]
		public static int? BtbpcharPatternCmp(string par742, string par743)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BtbpcharPatternSortsupport

		[Sql.Function(Name="pg_catalog.btbpchar_pattern_sortsupport", ServerSideOnly=true)]
		public static object BtbpcharPatternSortsupport(object par744)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btcharcmp

		[Sql.Function(Name="pg_catalog.btcharcmp", ServerSideOnly=true)]
		public static int? Btcharcmp(object par746, object par747)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btfloat48cmp

		[Sql.Function(Name="pg_catalog.btfloat48cmp", ServerSideOnly=true)]
		public static int? Btfloat48cmp(float? par749, double? par750)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btfloat4cmp

		[Sql.Function(Name="pg_catalog.btfloat4cmp", ServerSideOnly=true)]
		public static int? Btfloat4cmp(float? par752, float? par753)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btfloat4sortsupport

		[Sql.Function(Name="pg_catalog.btfloat4sortsupport", ServerSideOnly=true)]
		public static object Btfloat4sortsupport(object par754)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btfloat84cmp

		[Sql.Function(Name="pg_catalog.btfloat84cmp", ServerSideOnly=true)]
		public static int? Btfloat84cmp(double? par756, float? par757)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btfloat8cmp

		[Sql.Function(Name="pg_catalog.btfloat8cmp", ServerSideOnly=true)]
		public static int? Btfloat8cmp(double? par759, double? par760)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btfloat8sortsupport

		[Sql.Function(Name="pg_catalog.btfloat8sortsupport", ServerSideOnly=true)]
		public static object Btfloat8sortsupport(object par761)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bthandler

		[Sql.Function(Name="pg_catalog.bthandler", ServerSideOnly=true)]
		public static object Bthandler(object par763)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint24cmp

		[Sql.Function(Name="pg_catalog.btint24cmp", ServerSideOnly=true)]
		public static int? Btint24cmp(short? par765, int? par766)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint28cmp

		[Sql.Function(Name="pg_catalog.btint28cmp", ServerSideOnly=true)]
		public static int? Btint28cmp(short? par768, long? par769)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint2cmp

		[Sql.Function(Name="pg_catalog.btint2cmp", ServerSideOnly=true)]
		public static int? Btint2cmp(short? par771, short? par772)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint2sortsupport

		[Sql.Function(Name="pg_catalog.btint2sortsupport", ServerSideOnly=true)]
		public static object Btint2sortsupport(object par773)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint42cmp

		[Sql.Function(Name="pg_catalog.btint42cmp", ServerSideOnly=true)]
		public static int? Btint42cmp(int? par775, short? par776)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint48cmp

		[Sql.Function(Name="pg_catalog.btint48cmp", ServerSideOnly=true)]
		public static int? Btint48cmp(int? par778, long? par779)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint4cmp

		[Sql.Function(Name="pg_catalog.btint4cmp", ServerSideOnly=true)]
		public static int? Btint4cmp(int? par781, int? par782)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint4sortsupport

		[Sql.Function(Name="pg_catalog.btint4sortsupport", ServerSideOnly=true)]
		public static object Btint4sortsupport(object par783)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint82cmp

		[Sql.Function(Name="pg_catalog.btint82cmp", ServerSideOnly=true)]
		public static int? Btint82cmp(long? par785, short? par786)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint84cmp

		[Sql.Function(Name="pg_catalog.btint84cmp", ServerSideOnly=true)]
		public static int? Btint84cmp(long? par788, int? par789)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint8cmp

		[Sql.Function(Name="pg_catalog.btint8cmp", ServerSideOnly=true)]
		public static int? Btint8cmp(long? par791, long? par792)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btint8sortsupport

		[Sql.Function(Name="pg_catalog.btint8sortsupport", ServerSideOnly=true)]
		public static object Btint8sortsupport(object par793)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btnamecmp

		[Sql.Function(Name="pg_catalog.btnamecmp", ServerSideOnly=true)]
		public static int? Btnamecmp(string par795, string par796)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btnamesortsupport

		[Sql.Function(Name="pg_catalog.btnamesortsupport", ServerSideOnly=true)]
		public static object Btnamesortsupport(object par797)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btoidcmp

		[Sql.Function(Name="pg_catalog.btoidcmp", ServerSideOnly=true)]
		public static int? Btoidcmp(int? par799, int? par800)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btoidsortsupport

		[Sql.Function(Name="pg_catalog.btoidsortsupport", ServerSideOnly=true)]
		public static object Btoidsortsupport(object par801)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btoidvectorcmp

		[Sql.Function(Name="pg_catalog.btoidvectorcmp", ServerSideOnly=true)]
		public static int? Btoidvectorcmp(object par803, object par804)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btrecordcmp

		[Sql.Function(Name="pg_catalog.btrecordcmp", ServerSideOnly=true)]
		public static int? Btrecordcmp(object par806, object par807)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btrecordimagecmp

		[Sql.Function(Name="pg_catalog.btrecordimagecmp", ServerSideOnly=true)]
		public static int? Btrecordimagecmp(object par809, object par810)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btreltimecmp

		[Sql.Function(Name="pg_catalog.btreltimecmp", ServerSideOnly=true)]
		public static int? Btreltimecmp(object par812, object par813)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Btrim

		[Sql.Function(Name="pg_catalog.btrim", ServerSideOnly=true)]
		public static string Btrim(string par821)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BttextPatternCmp

		[Sql.Function(Name="pg_catalog.bttext_pattern_cmp", ServerSideOnly=true)]
		public static int? BttextPatternCmp(string par823, string par824)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region BttextPatternSortsupport

		[Sql.Function(Name="pg_catalog.bttext_pattern_sortsupport", ServerSideOnly=true)]
		public static object BttextPatternSortsupport(object par825)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bttextcmp

		[Sql.Function(Name="pg_catalog.bttextcmp", ServerSideOnly=true)]
		public static int? Bttextcmp(string par827, string par828)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bttextsortsupport

		[Sql.Function(Name="pg_catalog.bttextsortsupport", ServerSideOnly=true)]
		public static object Bttextsortsupport(object par829)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bttidcmp

		[Sql.Function(Name="pg_catalog.bttidcmp", ServerSideOnly=true)]
		public static int? Bttidcmp(object par831, object par832)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bttintervalcmp

		[Sql.Function(Name="pg_catalog.bttintervalcmp", ServerSideOnly=true)]
		public static int? Bttintervalcmp(object par834, object par835)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ByteaSortsupport

		[Sql.Function(Name="pg_catalog.bytea_sortsupport", ServerSideOnly=true)]
		public static object ByteaSortsupport(object par836)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ByteaStringAggFinalfn

		[Sql.Function(Name="pg_catalog.bytea_string_agg_finalfn", ServerSideOnly=true)]
		public static byte[] ByteaStringAggFinalfn(object par838)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ByteaStringAggTransfn

		[Sql.Function(Name="pg_catalog.bytea_string_agg_transfn", ServerSideOnly=true)]
		public static object ByteaStringAggTransfn(object par840, byte[] par841, byte[] par842)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteacat

		[Sql.Function(Name="pg_catalog.byteacat", ServerSideOnly=true)]
		public static byte[] Byteacat(byte[] par844, byte[] par845)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteacmp

		[Sql.Function(Name="pg_catalog.byteacmp", ServerSideOnly=true)]
		public static int? Byteacmp(byte[] par847, byte[] par848)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteaeq

		[Sql.Function(Name="pg_catalog.byteaeq", ServerSideOnly=true)]
		public static bool? Byteaeq(byte[] par850, byte[] par851)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteage

		[Sql.Function(Name="pg_catalog.byteage", ServerSideOnly=true)]
		public static bool? Byteage(byte[] par853, byte[] par854)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteagt

		[Sql.Function(Name="pg_catalog.byteagt", ServerSideOnly=true)]
		public static bool? Byteagt(byte[] par856, byte[] par857)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteain

		[Sql.Function(Name="pg_catalog.byteain", ServerSideOnly=true)]
		public static byte[] Byteain(object par859)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteale

		[Sql.Function(Name="pg_catalog.byteale", ServerSideOnly=true)]
		public static bool? Byteale(byte[] par861, byte[] par862)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bytealike

		[Sql.Function(Name="pg_catalog.bytealike", ServerSideOnly=true)]
		public static bool? Bytealike(byte[] par864, byte[] par865)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bytealt

		[Sql.Function(Name="pg_catalog.bytealt", ServerSideOnly=true)]
		public static bool? Bytealt(byte[] par867, byte[] par868)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteane

		[Sql.Function(Name="pg_catalog.byteane", ServerSideOnly=true)]
		public static bool? Byteane(byte[] par870, byte[] par871)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteanlike

		[Sql.Function(Name="pg_catalog.byteanlike", ServerSideOnly=true)]
		public static bool? Byteanlike(byte[] par873, byte[] par874)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteaout

		[Sql.Function(Name="pg_catalog.byteaout", ServerSideOnly=true)]
		public static object Byteaout(byte[] par876)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Bytearecv

		[Sql.Function(Name="pg_catalog.bytearecv", ServerSideOnly=true)]
		public static byte[] Bytearecv(object par878)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Byteasend

		[Sql.Function(Name="pg_catalog.byteasend", ServerSideOnly=true)]
		public static byte[] Byteasend(byte[] par880)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cardinality

		[Sql.Function(Name="pg_catalog.cardinality", ServerSideOnly=true)]
		public static int? Cardinality(object par882)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashCmp

		[Sql.Function(Name="pg_catalog.cash_cmp", ServerSideOnly=true)]
		public static int? CashCmp(decimal? par884, decimal? par885)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashDivCash

		[Sql.Function(Name="pg_catalog.cash_div_cash", ServerSideOnly=true)]
		public static double? CashDivCash(decimal? par887, decimal? par888)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashDivFlt4

		[Sql.Function(Name="pg_catalog.cash_div_flt4", ServerSideOnly=true)]
		public static decimal? CashDivFlt4(decimal? par890, float? par891)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashDivFlt8

		[Sql.Function(Name="pg_catalog.cash_div_flt8", ServerSideOnly=true)]
		public static decimal? CashDivFlt8(decimal? par893, double? par894)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashDivInt2

		[Sql.Function(Name="pg_catalog.cash_div_int2", ServerSideOnly=true)]
		public static decimal? CashDivInt2(decimal? par896, short? par897)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashDivInt4

		[Sql.Function(Name="pg_catalog.cash_div_int4", ServerSideOnly=true)]
		public static decimal? CashDivInt4(decimal? par899, int? par900)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashDivInt8

		[Sql.Function(Name="pg_catalog.cash_div_int8", ServerSideOnly=true)]
		public static decimal? CashDivInt8(decimal? par902, long? par903)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashEq

		[Sql.Function(Name="pg_catalog.cash_eq", ServerSideOnly=true)]
		public static bool? CashEq(decimal? par905, decimal? par906)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashGe

		[Sql.Function(Name="pg_catalog.cash_ge", ServerSideOnly=true)]
		public static bool? CashGe(decimal? par908, decimal? par909)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashGt

		[Sql.Function(Name="pg_catalog.cash_gt", ServerSideOnly=true)]
		public static bool? CashGt(decimal? par911, decimal? par912)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashIn

		[Sql.Function(Name="pg_catalog.cash_in", ServerSideOnly=true)]
		public static decimal? CashIn(object par914)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashLe

		[Sql.Function(Name="pg_catalog.cash_le", ServerSideOnly=true)]
		public static bool? CashLe(decimal? par916, decimal? par917)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashLt

		[Sql.Function(Name="pg_catalog.cash_lt", ServerSideOnly=true)]
		public static bool? CashLt(decimal? par919, decimal? par920)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashMi

		[Sql.Function(Name="pg_catalog.cash_mi", ServerSideOnly=true)]
		public static decimal? CashMi(decimal? par922, decimal? par923)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashMulFlt4

		[Sql.Function(Name="pg_catalog.cash_mul_flt4", ServerSideOnly=true)]
		public static decimal? CashMulFlt4(decimal? par925, float? par926)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashMulFlt8

		[Sql.Function(Name="pg_catalog.cash_mul_flt8", ServerSideOnly=true)]
		public static decimal? CashMulFlt8(decimal? par928, double? par929)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashMulInt2

		[Sql.Function(Name="pg_catalog.cash_mul_int2", ServerSideOnly=true)]
		public static decimal? CashMulInt2(decimal? par931, short? par932)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashMulInt4

		[Sql.Function(Name="pg_catalog.cash_mul_int4", ServerSideOnly=true)]
		public static decimal? CashMulInt4(decimal? par934, int? par935)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashMulInt8

		[Sql.Function(Name="pg_catalog.cash_mul_int8", ServerSideOnly=true)]
		public static decimal? CashMulInt8(decimal? par937, long? par938)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashNe

		[Sql.Function(Name="pg_catalog.cash_ne", ServerSideOnly=true)]
		public static bool? CashNe(decimal? par940, decimal? par941)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashOut

		[Sql.Function(Name="pg_catalog.cash_out", ServerSideOnly=true)]
		public static object CashOut(decimal? par943)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashPl

		[Sql.Function(Name="pg_catalog.cash_pl", ServerSideOnly=true)]
		public static decimal? CashPl(decimal? par945, decimal? par946)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashRecv

		[Sql.Function(Name="pg_catalog.cash_recv", ServerSideOnly=true)]
		public static decimal? CashRecv(object par948)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashSend

		[Sql.Function(Name="pg_catalog.cash_send", ServerSideOnly=true)]
		public static byte[] CashSend(decimal? par950)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CashWords

		[Sql.Function(Name="pg_catalog.cash_words", ServerSideOnly=true)]
		public static string CashWords(decimal? par952)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cashlarger

		[Sql.Function(Name="pg_catalog.cashlarger", ServerSideOnly=true)]
		public static decimal? Cashlarger(decimal? par954, decimal? par955)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cashsmaller

		[Sql.Function(Name="pg_catalog.cashsmaller", ServerSideOnly=true)]
		public static decimal? Cashsmaller(decimal? par957, decimal? par958)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cbrt

		[Sql.Function(Name="pg_catalog.cbrt", ServerSideOnly=true)]
		public static double? Cbrt(double? par960)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ceil

		[Sql.Function(Name="pg_catalog.ceil", ServerSideOnly=true)]
		public static double? Ceil(double? par964)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ceiling

		[Sql.Function(Name="pg_catalog.ceiling", ServerSideOnly=true)]
		public static double? Ceiling(double? par968)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Center

		[Sql.Function(Name="pg_catalog.center", ServerSideOnly=true)]
		public static NpgsqlPoint? Center(NpgsqlCircle? par972)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Char

		[Sql.Function(Name="pg_catalog.char", ServerSideOnly=true)]
		public static object Char(string par976)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CharLength

		[Sql.Function(Name="pg_catalog.char_length", ServerSideOnly=true)]
		public static int? CharLength(string par980)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CharacterLength

		[Sql.Function(Name="pg_catalog.character_length", ServerSideOnly=true)]
		public static int? CharacterLength(string par984)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Chareq

		[Sql.Function(Name="pg_catalog.chareq", ServerSideOnly=true)]
		public static bool? Chareq(object par986, object par987)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Charge

		[Sql.Function(Name="pg_catalog.charge", ServerSideOnly=true)]
		public static bool? Charge(object par989, object par990)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Chargt

		[Sql.Function(Name="pg_catalog.chargt", ServerSideOnly=true)]
		public static bool? Chargt(object par992, object par993)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Charin

		[Sql.Function(Name="pg_catalog.charin", ServerSideOnly=true)]
		public static object Charin(object par995)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Charle

		[Sql.Function(Name="pg_catalog.charle", ServerSideOnly=true)]
		public static bool? Charle(object par997, object par998)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Charlt

		[Sql.Function(Name="pg_catalog.charlt", ServerSideOnly=true)]
		public static bool? Charlt(object par1000, object par1001)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Charne

		[Sql.Function(Name="pg_catalog.charne", ServerSideOnly=true)]
		public static bool? Charne(object par1003, object par1004)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Charout

		[Sql.Function(Name="pg_catalog.charout", ServerSideOnly=true)]
		public static object Charout(object par1006)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Charrecv

		[Sql.Function(Name="pg_catalog.charrecv", ServerSideOnly=true)]
		public static object Charrecv(object par1008)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Charsend

		[Sql.Function(Name="pg_catalog.charsend", ServerSideOnly=true)]
		public static byte[] Charsend(object par1010)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Chr

		[Sql.Function(Name="pg_catalog.chr", ServerSideOnly=true)]
		public static string Chr(int? par1012)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cideq

		[Sql.Function(Name="pg_catalog.cideq", ServerSideOnly=true)]
		public static bool? Cideq(object par1014, object par1015)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cidin

		[Sql.Function(Name="pg_catalog.cidin", ServerSideOnly=true)]
		public static object Cidin(object par1017)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cidout

		[Sql.Function(Name="pg_catalog.cidout", ServerSideOnly=true)]
		public static object Cidout(object par1019)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cidr

		[Sql.Function(Name="pg_catalog.cidr", ServerSideOnly=true)]
		public static NpgsqlInet? Cidr(NpgsqlInet? par1021)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CidrIn

		[Sql.Function(Name="pg_catalog.cidr_in", ServerSideOnly=true)]
		public static NpgsqlInet? CidrIn(object par1023)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CidrOut

		[Sql.Function(Name="pg_catalog.cidr_out", ServerSideOnly=true)]
		public static object CidrOut(NpgsqlInet? par1025)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CidrRecv

		[Sql.Function(Name="pg_catalog.cidr_recv", ServerSideOnly=true)]
		public static NpgsqlInet? CidrRecv(object par1027)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CidrSend

		[Sql.Function(Name="pg_catalog.cidr_send", ServerSideOnly=true)]
		public static byte[] CidrSend(NpgsqlInet? par1029)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cidrecv

		[Sql.Function(Name="pg_catalog.cidrecv", ServerSideOnly=true)]
		public static object Cidrecv(object par1031)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cidsend

		[Sql.Function(Name="pg_catalog.cidsend", ServerSideOnly=true)]
		public static byte[] Cidsend(object par1033)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Circle

		[Sql.Function(Name="pg_catalog.circle", ServerSideOnly=true)]
		public static NpgsqlCircle? Circle(NpgsqlBox? par1040)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleAbove

		[Sql.Function(Name="pg_catalog.circle_above", ServerSideOnly=true)]
		public static bool? CircleAbove(NpgsqlCircle? par1042, NpgsqlCircle? par1043)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleAddPt

		[Sql.Function(Name="pg_catalog.circle_add_pt", ServerSideOnly=true)]
		public static NpgsqlCircle? CircleAddPt(NpgsqlCircle? par1045, NpgsqlPoint? par1046)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleBelow

		[Sql.Function(Name="pg_catalog.circle_below", ServerSideOnly=true)]
		public static bool? CircleBelow(NpgsqlCircle? par1048, NpgsqlCircle? par1049)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleCenter

		[Sql.Function(Name="pg_catalog.circle_center", ServerSideOnly=true)]
		public static NpgsqlPoint? CircleCenter(NpgsqlCircle? par1051)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleContain

		[Sql.Function(Name="pg_catalog.circle_contain", ServerSideOnly=true)]
		public static bool? CircleContain(NpgsqlCircle? par1053, NpgsqlCircle? par1054)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleContainPt

		[Sql.Function(Name="pg_catalog.circle_contain_pt", ServerSideOnly=true)]
		public static bool? CircleContainPt(NpgsqlCircle? par1056, NpgsqlPoint? par1057)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleContained

		[Sql.Function(Name="pg_catalog.circle_contained", ServerSideOnly=true)]
		public static bool? CircleContained(NpgsqlCircle? par1059, NpgsqlCircle? par1060)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleDistance

		[Sql.Function(Name="pg_catalog.circle_distance", ServerSideOnly=true)]
		public static double? CircleDistance(NpgsqlCircle? par1062, NpgsqlCircle? par1063)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleDivPt

		[Sql.Function(Name="pg_catalog.circle_div_pt", ServerSideOnly=true)]
		public static NpgsqlCircle? CircleDivPt(NpgsqlCircle? par1065, NpgsqlPoint? par1066)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleEq

		[Sql.Function(Name="pg_catalog.circle_eq", ServerSideOnly=true)]
		public static bool? CircleEq(NpgsqlCircle? par1068, NpgsqlCircle? par1069)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleGe

		[Sql.Function(Name="pg_catalog.circle_ge", ServerSideOnly=true)]
		public static bool? CircleGe(NpgsqlCircle? par1071, NpgsqlCircle? par1072)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleGt

		[Sql.Function(Name="pg_catalog.circle_gt", ServerSideOnly=true)]
		public static bool? CircleGt(NpgsqlCircle? par1074, NpgsqlCircle? par1075)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleIn

		[Sql.Function(Name="pg_catalog.circle_in", ServerSideOnly=true)]
		public static NpgsqlCircle? CircleIn(object par1077)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleLe

		[Sql.Function(Name="pg_catalog.circle_le", ServerSideOnly=true)]
		public static bool? CircleLe(NpgsqlCircle? par1079, NpgsqlCircle? par1080)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleLeft

		[Sql.Function(Name="pg_catalog.circle_left", ServerSideOnly=true)]
		public static bool? CircleLeft(NpgsqlCircle? par1082, NpgsqlCircle? par1083)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleLt

		[Sql.Function(Name="pg_catalog.circle_lt", ServerSideOnly=true)]
		public static bool? CircleLt(NpgsqlCircle? par1085, NpgsqlCircle? par1086)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleMulPt

		[Sql.Function(Name="pg_catalog.circle_mul_pt", ServerSideOnly=true)]
		public static NpgsqlCircle? CircleMulPt(NpgsqlCircle? par1088, NpgsqlPoint? par1089)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleNe

		[Sql.Function(Name="pg_catalog.circle_ne", ServerSideOnly=true)]
		public static bool? CircleNe(NpgsqlCircle? par1091, NpgsqlCircle? par1092)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleOut

		[Sql.Function(Name="pg_catalog.circle_out", ServerSideOnly=true)]
		public static object CircleOut(NpgsqlCircle? par1094)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleOverabove

		[Sql.Function(Name="pg_catalog.circle_overabove", ServerSideOnly=true)]
		public static bool? CircleOverabove(NpgsqlCircle? par1096, NpgsqlCircle? par1097)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleOverbelow

		[Sql.Function(Name="pg_catalog.circle_overbelow", ServerSideOnly=true)]
		public static bool? CircleOverbelow(NpgsqlCircle? par1099, NpgsqlCircle? par1100)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleOverlap

		[Sql.Function(Name="pg_catalog.circle_overlap", ServerSideOnly=true)]
		public static bool? CircleOverlap(NpgsqlCircle? par1102, NpgsqlCircle? par1103)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleOverleft

		[Sql.Function(Name="pg_catalog.circle_overleft", ServerSideOnly=true)]
		public static bool? CircleOverleft(NpgsqlCircle? par1105, NpgsqlCircle? par1106)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleOverright

		[Sql.Function(Name="pg_catalog.circle_overright", ServerSideOnly=true)]
		public static bool? CircleOverright(NpgsqlCircle? par1108, NpgsqlCircle? par1109)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleRecv

		[Sql.Function(Name="pg_catalog.circle_recv", ServerSideOnly=true)]
		public static NpgsqlCircle? CircleRecv(object par1111)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleRight

		[Sql.Function(Name="pg_catalog.circle_right", ServerSideOnly=true)]
		public static bool? CircleRight(NpgsqlCircle? par1113, NpgsqlCircle? par1114)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleSame

		[Sql.Function(Name="pg_catalog.circle_same", ServerSideOnly=true)]
		public static bool? CircleSame(NpgsqlCircle? par1116, NpgsqlCircle? par1117)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleSend

		[Sql.Function(Name="pg_catalog.circle_send", ServerSideOnly=true)]
		public static byte[] CircleSend(NpgsqlCircle? par1119)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CircleSubPt

		[Sql.Function(Name="pg_catalog.circle_sub_pt", ServerSideOnly=true)]
		public static NpgsqlCircle? CircleSubPt(NpgsqlCircle? par1121, NpgsqlPoint? par1122)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ClockTimestamp

		[Sql.Function(Name="pg_catalog.clock_timestamp", ServerSideOnly=true)]
		public static DateTimeOffset? ClockTimestamp()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CloseLb

		[Sql.Function(Name="pg_catalog.close_lb", ServerSideOnly=true)]
		public static NpgsqlPoint? CloseLb(NpgsqlLine? par1125, NpgsqlBox? par1126)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CloseLs

		[Sql.Function(Name="pg_catalog.close_ls", ServerSideOnly=true)]
		public static NpgsqlPoint? CloseLs(NpgsqlLine? par1128, NpgsqlLSeg? par1129)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CloseLseg

		[Sql.Function(Name="pg_catalog.close_lseg", ServerSideOnly=true)]
		public static NpgsqlPoint? CloseLseg(NpgsqlLSeg? par1131, NpgsqlLSeg? par1132)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ClosePb

		[Sql.Function(Name="pg_catalog.close_pb", ServerSideOnly=true)]
		public static NpgsqlPoint? ClosePb(NpgsqlPoint? par1134, NpgsqlBox? par1135)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ClosePl

		[Sql.Function(Name="pg_catalog.close_pl", ServerSideOnly=true)]
		public static NpgsqlPoint? ClosePl(NpgsqlPoint? par1137, NpgsqlLine? par1138)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ClosePs

		[Sql.Function(Name="pg_catalog.close_ps", ServerSideOnly=true)]
		public static NpgsqlPoint? ClosePs(NpgsqlPoint? par1140, NpgsqlLSeg? par1141)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CloseSb

		[Sql.Function(Name="pg_catalog.close_sb", ServerSideOnly=true)]
		public static NpgsqlPoint? CloseSb(NpgsqlLSeg? par1143, NpgsqlBox? par1144)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CloseSl

		[Sql.Function(Name="pg_catalog.close_sl", ServerSideOnly=true)]
		public static NpgsqlPoint? CloseSl(NpgsqlLSeg? par1146, NpgsqlLine? par1147)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ColDescription

		[Sql.Function(Name="pg_catalog.col_description", ServerSideOnly=true)]
		public static string ColDescription(int? par1149, int? par1150)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Concat

		[Sql.Function(Name="pg_catalog.concat", ServerSideOnly=true)]
		public static string Concat(object par1152)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ConcatWs

		[Sql.Function(Name="pg_catalog.concat_ws", ServerSideOnly=true)]
		public static string ConcatWs(string par1154, object par1155)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Contjoinsel

		[Sql.Function(Name="pg_catalog.contjoinsel", ServerSideOnly=true)]
		public static double? Contjoinsel(object par1157, int? par1158, object par1159, short? par1160, object par1161)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Contsel

		[Sql.Function(Name="pg_catalog.contsel", ServerSideOnly=true)]
		public static double? Contsel(object par1163, int? par1164, object par1165, int? par1166)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Convert

		[Sql.Function(Name="pg_catalog.convert", ServerSideOnly=true)]
		public static byte[] Convert(byte[] par1168, string par1169, string par1170)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ConvertFrom

		[Sql.Function(Name="pg_catalog.convert_from", ServerSideOnly=true)]
		public static string ConvertFrom(byte[] par1172, string par1173)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ConvertTo

		[Sql.Function(Name="pg_catalog.convert_to", ServerSideOnly=true)]
		public static byte[] ConvertTo(string par1175, string par1176)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Corr

		[Sql.Function(Name="pg_catalog.corr", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? Corr<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par1178, Expression<Func<TSource, double?>> par1179)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cos

		[Sql.Function(Name="pg_catalog.cos", ServerSideOnly=true)]
		public static double? Cos(double? par1181)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cosd

		[Sql.Function(Name="pg_catalog.cosd", ServerSideOnly=true)]
		public static double? Cosd(double? par1183)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cot

		[Sql.Function(Name="pg_catalog.cot", ServerSideOnly=true)]
		public static double? Cot(double? par1185)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Cotd

		[Sql.Function(Name="pg_catalog.cotd", ServerSideOnly=true)]
		public static double? Cotd(double? par1187)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Count

		[Sql.Function(Name="pg_catalog.count", ServerSideOnly=true, IsAggregate = true)]
		public static long? Count<TSource>(this IEnumerable<TSource> src)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CovarPop

		[Sql.Function(Name="pg_catalog.covar_pop", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? CovarPop<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par1192, Expression<Func<TSource, double?>> par1193)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CovarSamp

		[Sql.Function(Name="pg_catalog.covar_samp", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? CovarSamp<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par1195, Expression<Func<TSource, double?>> par1196)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CstringIn

		[Sql.Function(Name="pg_catalog.cstring_in", ServerSideOnly=true)]
		public static object CstringIn(object par1198)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CstringOut

		[Sql.Function(Name="pg_catalog.cstring_out", ServerSideOnly=true)]
		public static object CstringOut(object par1200)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CstringRecv

		[Sql.Function(Name="pg_catalog.cstring_recv", ServerSideOnly=true)]
		public static object CstringRecv(object par1202)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CstringSend

		[Sql.Function(Name="pg_catalog.cstring_send", ServerSideOnly=true)]
		public static byte[] CstringSend(object par1204)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CumeDist

		[Sql.Function(Name="pg_catalog.cume_dist", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static double? CumeDist<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par1207)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CumeDistFinal

		[Sql.Function(Name="pg_catalog.cume_dist_final", ServerSideOnly=true)]
		public static double? CumeDistFinal(object par1209, object par1210)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CurrentDatabase

		[Sql.Function(Name="pg_catalog.current_database", ServerSideOnly=true)]
		public static string CurrentDatabase()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CurrentQuery

		[Sql.Function(Name="pg_catalog.current_query", ServerSideOnly=true)]
		public static string CurrentQuery()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CurrentSchema

		[Sql.Function(Name="pg_catalog.current_schema", ServerSideOnly=true)]
		public static string CurrentSchema()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CurrentSchemas

		[Sql.Function(Name="pg_catalog.current_schemas", ServerSideOnly=true)]
		public static object CurrentSchemas(bool? par1215)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CurrentSetting

		[Sql.Function(Name="pg_catalog.current_setting", ServerSideOnly=true)]
		public static string CurrentSetting(string par1219, bool? par1220)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CurrentUser

		[Sql.Function(Name="pg_catalog.current_user", ServerSideOnly=true)]
		public static string CurrentUser()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Currtid

		[Sql.Function(Name="pg_catalog.currtid", ServerSideOnly=true)]
		public static object Currtid(int? par1223, object par1224)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Currtid2

		[Sql.Function(Name="pg_catalog.currtid2", ServerSideOnly=true)]
		public static object Currtid2(string par1226, object par1227)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Currval

		[Sql.Function(Name="pg_catalog.currval", ServerSideOnly=true)]
		public static long? Currval(object par1229)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CursorToXml

		[Sql.Function(Name="pg_catalog.cursor_to_xml", ServerSideOnly=true)]
		public static string CursorToXml(object cursor, int? count, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region CursorToXmlschema

		[Sql.Function(Name="pg_catalog.cursor_to_xmlschema", ServerSideOnly=true)]
		public static string CursorToXmlschema(object cursor, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DatabaseToXml

		[Sql.Function(Name="pg_catalog.database_to_xml", ServerSideOnly=true)]
		public static string DatabaseToXml(bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DatabaseToXmlAndXmlschema

		[Sql.Function(Name="pg_catalog.database_to_xml_and_xmlschema", ServerSideOnly=true)]
		public static string DatabaseToXmlAndXmlschema(bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DatabaseToXmlschema

		[Sql.Function(Name="pg_catalog.database_to_xmlschema", ServerSideOnly=true)]
		public static string DatabaseToXmlschema(bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Date

		[Sql.Function(Name="pg_catalog.date", ServerSideOnly=true)]
		public static NpgsqlDate? Date(DateTime? par1240)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateCmp

		[Sql.Function(Name="pg_catalog.date_cmp", ServerSideOnly=true)]
		public static int? DateCmp(NpgsqlDate? par1242, NpgsqlDate? par1243)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateCmpTimestamp

		[Sql.Function(Name="pg_catalog.date_cmp_timestamp", ServerSideOnly=true)]
		public static int? DateCmpTimestamp(NpgsqlDate? par1245, DateTime? par1246)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateCmpTimestamptz

		[Sql.Function(Name="pg_catalog.date_cmp_timestamptz", ServerSideOnly=true)]
		public static int? DateCmpTimestamptz(NpgsqlDate? par1248, DateTimeOffset? par1249)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateEq

		[Sql.Function(Name="pg_catalog.date_eq", ServerSideOnly=true)]
		public static bool? DateEq(NpgsqlDate? par1251, NpgsqlDate? par1252)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateEqTimestamp

		[Sql.Function(Name="pg_catalog.date_eq_timestamp", ServerSideOnly=true)]
		public static bool? DateEqTimestamp(NpgsqlDate? par1254, DateTime? par1255)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateEqTimestamptz

		[Sql.Function(Name="pg_catalog.date_eq_timestamptz", ServerSideOnly=true)]
		public static bool? DateEqTimestamptz(NpgsqlDate? par1257, DateTimeOffset? par1258)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateGe

		[Sql.Function(Name="pg_catalog.date_ge", ServerSideOnly=true)]
		public static bool? DateGe(NpgsqlDate? par1260, NpgsqlDate? par1261)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateGeTimestamp

		[Sql.Function(Name="pg_catalog.date_ge_timestamp", ServerSideOnly=true)]
		public static bool? DateGeTimestamp(NpgsqlDate? par1263, DateTime? par1264)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateGeTimestamptz

		[Sql.Function(Name="pg_catalog.date_ge_timestamptz", ServerSideOnly=true)]
		public static bool? DateGeTimestamptz(NpgsqlDate? par1266, DateTimeOffset? par1267)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateGt

		[Sql.Function(Name="pg_catalog.date_gt", ServerSideOnly=true)]
		public static bool? DateGt(NpgsqlDate? par1269, NpgsqlDate? par1270)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateGtTimestamp

		[Sql.Function(Name="pg_catalog.date_gt_timestamp", ServerSideOnly=true)]
		public static bool? DateGtTimestamp(NpgsqlDate? par1272, DateTime? par1273)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateGtTimestamptz

		[Sql.Function(Name="pg_catalog.date_gt_timestamptz", ServerSideOnly=true)]
		public static bool? DateGtTimestamptz(NpgsqlDate? par1275, DateTimeOffset? par1276)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateIn

		[Sql.Function(Name="pg_catalog.date_in", ServerSideOnly=true)]
		public static NpgsqlDate? DateIn(object par1278)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateLarger

		[Sql.Function(Name="pg_catalog.date_larger", ServerSideOnly=true)]
		public static NpgsqlDate? DateLarger(NpgsqlDate? par1280, NpgsqlDate? par1281)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateLe

		[Sql.Function(Name="pg_catalog.date_le", ServerSideOnly=true)]
		public static bool? DateLe(NpgsqlDate? par1283, NpgsqlDate? par1284)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateLeTimestamp

		[Sql.Function(Name="pg_catalog.date_le_timestamp", ServerSideOnly=true)]
		public static bool? DateLeTimestamp(NpgsqlDate? par1286, DateTime? par1287)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateLeTimestamptz

		[Sql.Function(Name="pg_catalog.date_le_timestamptz", ServerSideOnly=true)]
		public static bool? DateLeTimestamptz(NpgsqlDate? par1289, DateTimeOffset? par1290)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateLt

		[Sql.Function(Name="pg_catalog.date_lt", ServerSideOnly=true)]
		public static bool? DateLt(NpgsqlDate? par1292, NpgsqlDate? par1293)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateLtTimestamp

		[Sql.Function(Name="pg_catalog.date_lt_timestamp", ServerSideOnly=true)]
		public static bool? DateLtTimestamp(NpgsqlDate? par1295, DateTime? par1296)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateLtTimestamptz

		[Sql.Function(Name="pg_catalog.date_lt_timestamptz", ServerSideOnly=true)]
		public static bool? DateLtTimestamptz(NpgsqlDate? par1298, DateTimeOffset? par1299)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateMi

		[Sql.Function(Name="pg_catalog.date_mi", ServerSideOnly=true)]
		public static int? DateMi(NpgsqlDate? par1301, NpgsqlDate? par1302)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateMiInterval

		[Sql.Function(Name="pg_catalog.date_mi_interval", ServerSideOnly=true)]
		public static DateTime? DateMiInterval(NpgsqlDate? par1304, NpgsqlTimeSpan? par1305)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateMii

		[Sql.Function(Name="pg_catalog.date_mii", ServerSideOnly=true)]
		public static NpgsqlDate? DateMii(NpgsqlDate? par1307, int? par1308)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateNe

		[Sql.Function(Name="pg_catalog.date_ne", ServerSideOnly=true)]
		public static bool? DateNe(NpgsqlDate? par1310, NpgsqlDate? par1311)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateNeTimestamp

		[Sql.Function(Name="pg_catalog.date_ne_timestamp", ServerSideOnly=true)]
		public static bool? DateNeTimestamp(NpgsqlDate? par1313, DateTime? par1314)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateNeTimestamptz

		[Sql.Function(Name="pg_catalog.date_ne_timestamptz", ServerSideOnly=true)]
		public static bool? DateNeTimestamptz(NpgsqlDate? par1316, DateTimeOffset? par1317)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateOut

		[Sql.Function(Name="pg_catalog.date_out", ServerSideOnly=true)]
		public static object DateOut(NpgsqlDate? par1319)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DatePart

		[Sql.Function(Name="pg_catalog.date_part", ServerSideOnly=true)]
		public static double? DatePart(string par1342, DateTime? par1343)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DatePlInterval

		[Sql.Function(Name="pg_catalog.date_pl_interval", ServerSideOnly=true)]
		public static DateTime? DatePlInterval(NpgsqlDate? par1345, NpgsqlTimeSpan? par1346)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DatePli

		[Sql.Function(Name="pg_catalog.date_pli", ServerSideOnly=true)]
		public static NpgsqlDate? DatePli(NpgsqlDate? par1348, int? par1349)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateRecv

		[Sql.Function(Name="pg_catalog.date_recv", ServerSideOnly=true)]
		public static NpgsqlDate? DateRecv(object par1351)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateSend

		[Sql.Function(Name="pg_catalog.date_send", ServerSideOnly=true)]
		public static byte[] DateSend(NpgsqlDate? par1353)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateSmaller

		[Sql.Function(Name="pg_catalog.date_smaller", ServerSideOnly=true)]
		public static NpgsqlDate? DateSmaller(NpgsqlDate? par1355, NpgsqlDate? par1356)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateSortsupport

		[Sql.Function(Name="pg_catalog.date_sortsupport", ServerSideOnly=true)]
		public static object DateSortsupport(object par1357)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DateTrunc

		[Sql.Function(Name="pg_catalog.date_trunc", ServerSideOnly=true)]
		public static DateTime? DateTrunc(string par1365, DateTime? par1366)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Daterange

		[Sql.Function(Name="pg_catalog.daterange", ServerSideOnly=true)]
		public static object Daterange(NpgsqlDate? par1371, NpgsqlDate? par1372, string par1373)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DaterangeCanonical

		[Sql.Function(Name="pg_catalog.daterange_canonical", ServerSideOnly=true)]
		public static object DaterangeCanonical(object par1375)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DaterangeSubdiff

		[Sql.Function(Name="pg_catalog.daterange_subdiff", ServerSideOnly=true)]
		public static double? DaterangeSubdiff(NpgsqlDate? par1377, NpgsqlDate? par1378)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DatetimePl

		[Sql.Function(Name="pg_catalog.datetime_pl", ServerSideOnly=true)]
		public static DateTime? DatetimePl(NpgsqlDate? par1380, TimeSpan? par1381)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DatetimetzPl

		[Sql.Function(Name="pg_catalog.datetimetz_pl", ServerSideOnly=true)]
		public static DateTimeOffset? DatetimetzPl(NpgsqlDate? par1383, DateTimeOffset? par1384)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Dcbrt

		[Sql.Function(Name="pg_catalog.dcbrt", ServerSideOnly=true)]
		public static double? Dcbrt(double? par1386)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Decode

		[Sql.Function(Name="pg_catalog.decode", ServerSideOnly=true)]
		public static byte[] Decode(string par1388, string par1389)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Degrees

		[Sql.Function(Name="pg_catalog.degrees", ServerSideOnly=true)]
		public static double? Degrees(double? par1391)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DenseRank

		[Sql.Function(Name="pg_catalog.dense_rank", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static long? DenseRank<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par1394)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DenseRankFinal

		[Sql.Function(Name="pg_catalog.dense_rank_final", ServerSideOnly=true)]
		public static long? DenseRankFinal(object par1396, object par1397)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Dexp

		[Sql.Function(Name="pg_catalog.dexp", ServerSideOnly=true)]
		public static double? Dexp(double? par1399)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Diagonal

		[Sql.Function(Name="pg_catalog.diagonal", ServerSideOnly=true)]
		public static NpgsqlLSeg? Diagonal(NpgsqlBox? par1401)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Diameter

		[Sql.Function(Name="pg_catalog.diameter", ServerSideOnly=true)]
		public static double? Diameter(NpgsqlCircle? par1403)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DispellInit

		[Sql.Function(Name="pg_catalog.dispell_init", ServerSideOnly=true)]
		public static object DispellInit(object par1405)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DispellLexize

		[Sql.Function(Name="pg_catalog.dispell_lexize", ServerSideOnly=true)]
		public static object DispellLexize(object par1407, object par1408, object par1409, object par1410)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistCpoint

		[Sql.Function(Name="pg_catalog.dist_cpoint", ServerSideOnly=true)]
		public static double? DistCpoint(NpgsqlCircle? par1412, NpgsqlPoint? par1413)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistCpoly

		[Sql.Function(Name="pg_catalog.dist_cpoly", ServerSideOnly=true)]
		public static double? DistCpoly(NpgsqlCircle? par1415, NpgsqlPolygon? par1416)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistLb

		[Sql.Function(Name="pg_catalog.dist_lb", ServerSideOnly=true)]
		public static double? DistLb(NpgsqlLine? par1418, NpgsqlBox? par1419)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistPb

		[Sql.Function(Name="pg_catalog.dist_pb", ServerSideOnly=true)]
		public static double? DistPb(NpgsqlPoint? par1421, NpgsqlBox? par1422)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistPc

		[Sql.Function(Name="pg_catalog.dist_pc", ServerSideOnly=true)]
		public static double? DistPc(NpgsqlPoint? par1424, NpgsqlCircle? par1425)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistPl

		[Sql.Function(Name="pg_catalog.dist_pl", ServerSideOnly=true)]
		public static double? DistPl(NpgsqlPoint? par1427, NpgsqlLine? par1428)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistPolyp

		[Sql.Function(Name="pg_catalog.dist_polyp", ServerSideOnly=true)]
		public static double? DistPolyp(NpgsqlPolygon? par1430, NpgsqlPoint? par1431)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistPpath

		[Sql.Function(Name="pg_catalog.dist_ppath", ServerSideOnly=true)]
		public static double? DistPpath(NpgsqlPoint? par1433, NpgsqlPath? par1434)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistPpoly

		[Sql.Function(Name="pg_catalog.dist_ppoly", ServerSideOnly=true)]
		public static double? DistPpoly(NpgsqlPoint? par1436, NpgsqlPolygon? par1437)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistPs

		[Sql.Function(Name="pg_catalog.dist_ps", ServerSideOnly=true)]
		public static double? DistPs(NpgsqlPoint? par1439, NpgsqlLSeg? par1440)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistSb

		[Sql.Function(Name="pg_catalog.dist_sb", ServerSideOnly=true)]
		public static double? DistSb(NpgsqlLSeg? par1442, NpgsqlBox? par1443)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DistSl

		[Sql.Function(Name="pg_catalog.dist_sl", ServerSideOnly=true)]
		public static double? DistSl(NpgsqlLSeg? par1445, NpgsqlLine? par1446)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Div

		[Sql.Function(Name="pg_catalog.div", ServerSideOnly=true)]
		public static decimal? Div(decimal? par1448, decimal? par1449)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Dlog1

		[Sql.Function(Name="pg_catalog.dlog1", ServerSideOnly=true)]
		public static double? Dlog1(double? par1451)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Dlog10

		[Sql.Function(Name="pg_catalog.dlog10", ServerSideOnly=true)]
		public static double? Dlog10(double? par1453)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DomainIn

		[Sql.Function(Name="pg_catalog.domain_in", ServerSideOnly=true)]
		public static object DomainIn(object par1455, int? par1456, int? par1457)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DomainRecv

		[Sql.Function(Name="pg_catalog.domain_recv", ServerSideOnly=true)]
		public static object DomainRecv(object par1459, int? par1460, int? par1461)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Dpow

		[Sql.Function(Name="pg_catalog.dpow", ServerSideOnly=true)]
		public static double? Dpow(double? par1463, double? par1464)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Dround

		[Sql.Function(Name="pg_catalog.dround", ServerSideOnly=true)]
		public static double? Dround(double? par1466)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DsimpleInit

		[Sql.Function(Name="pg_catalog.dsimple_init", ServerSideOnly=true)]
		public static object DsimpleInit(object par1468)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DsimpleLexize

		[Sql.Function(Name="pg_catalog.dsimple_lexize", ServerSideOnly=true)]
		public static object DsimpleLexize(object par1470, object par1471, object par1472, object par1473)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DsnowballInit

		[Sql.Function(Name="pg_catalog.dsnowball_init", ServerSideOnly=true)]
		public static object DsnowballInit(object par1475)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DsnowballLexize

		[Sql.Function(Name="pg_catalog.dsnowball_lexize", ServerSideOnly=true)]
		public static object DsnowballLexize(object par1477, object par1478, object par1479, object par1480)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Dsqrt

		[Sql.Function(Name="pg_catalog.dsqrt", ServerSideOnly=true)]
		public static double? Dsqrt(double? par1482)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DsynonymInit

		[Sql.Function(Name="pg_catalog.dsynonym_init", ServerSideOnly=true)]
		public static object DsynonymInit(object par1484)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region DsynonymLexize

		[Sql.Function(Name="pg_catalog.dsynonym_lexize", ServerSideOnly=true)]
		public static object DsynonymLexize(object par1486, object par1487, object par1488, object par1489)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Dtrunc

		[Sql.Function(Name="pg_catalog.dtrunc", ServerSideOnly=true)]
		public static double? Dtrunc(double? par1491)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ElemContainedByRange

		[Sql.Function(Name="pg_catalog.elem_contained_by_range", ServerSideOnly=true)]
		public static bool? ElemContainedByRange(object par1493, object par1494)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Encode

		[Sql.Function(Name="pg_catalog.encode", ServerSideOnly=true)]
		public static string Encode(byte[] par1496, string par1497)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumCmp

		[Sql.Function(Name="pg_catalog.enum_cmp", ServerSideOnly=true)]
		public static int? EnumCmp(object par1499, object par1500)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumEq

		[Sql.Function(Name="pg_catalog.enum_eq", ServerSideOnly=true)]
		public static bool? EnumEq(object par1502, object par1503)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumFirst

		[Sql.Function(Name="pg_catalog.enum_first", ServerSideOnly=true)]
		public static object EnumFirst(object par1505)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumGe

		[Sql.Function(Name="pg_catalog.enum_ge", ServerSideOnly=true)]
		public static bool? EnumGe(object par1507, object par1508)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumGt

		[Sql.Function(Name="pg_catalog.enum_gt", ServerSideOnly=true)]
		public static bool? EnumGt(object par1510, object par1511)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumIn

		[Sql.Function(Name="pg_catalog.enum_in", ServerSideOnly=true)]
		public static object EnumIn(object par1513, int? par1514)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumLarger

		[Sql.Function(Name="pg_catalog.enum_larger", ServerSideOnly=true)]
		public static object EnumLarger(object par1516, object par1517)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumLast

		[Sql.Function(Name="pg_catalog.enum_last", ServerSideOnly=true)]
		public static object EnumLast(object par1519)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumLe

		[Sql.Function(Name="pg_catalog.enum_le", ServerSideOnly=true)]
		public static bool? EnumLe(object par1521, object par1522)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumLt

		[Sql.Function(Name="pg_catalog.enum_lt", ServerSideOnly=true)]
		public static bool? EnumLt(object par1524, object par1525)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumNe

		[Sql.Function(Name="pg_catalog.enum_ne", ServerSideOnly=true)]
		public static bool? EnumNe(object par1527, object par1528)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumOut

		[Sql.Function(Name="pg_catalog.enum_out", ServerSideOnly=true)]
		public static object EnumOut(object par1530)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumRange

		[Sql.Function(Name="pg_catalog.enum_range", ServerSideOnly=true)]
		public static object EnumRange(object par1535)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumRecv

		[Sql.Function(Name="pg_catalog.enum_recv", ServerSideOnly=true)]
		public static object EnumRecv(object par1537, int? par1538)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumSend

		[Sql.Function(Name="pg_catalog.enum_send", ServerSideOnly=true)]
		public static byte[] EnumSend(object par1540)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EnumSmaller

		[Sql.Function(Name="pg_catalog.enum_smaller", ServerSideOnly=true)]
		public static object EnumSmaller(object par1542, object par1543)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Eqjoinsel

		[Sql.Function(Name="pg_catalog.eqjoinsel", ServerSideOnly=true)]
		public static double? Eqjoinsel(object par1545, int? par1546, object par1547, short? par1548, object par1549)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Eqsel

		[Sql.Function(Name="pg_catalog.eqsel", ServerSideOnly=true)]
		public static double? Eqsel(object par1551, int? par1552, object par1553, int? par1554)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucCnToMic

		[Sql.Function(Name="pg_catalog.euc_cn_to_mic", ServerSideOnly=true)]
		public static object EucCnToMic(int? par1555, int? par1556, object par1557, object par1558, int? par1559)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucCnToUtf8

		[Sql.Function(Name="pg_catalog.euc_cn_to_utf8", ServerSideOnly=true)]
		public static object EucCnToUtf8(int? par1560, int? par1561, object par1562, object par1563, int? par1564)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucJis2004ToShiftJis2004

		[Sql.Function(Name="pg_catalog.euc_jis_2004_to_shift_jis_2004", ServerSideOnly=true)]
		public static object EucJis2004ToShiftJis2004(int? par1565, int? par1566, object par1567, object par1568, int? par1569)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucJis2004ToUtf8

		[Sql.Function(Name="pg_catalog.euc_jis_2004_to_utf8", ServerSideOnly=true)]
		public static object EucJis2004ToUtf8(int? par1570, int? par1571, object par1572, object par1573, int? par1574)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucJpToMic

		[Sql.Function(Name="pg_catalog.euc_jp_to_mic", ServerSideOnly=true)]
		public static object EucJpToMic(int? par1575, int? par1576, object par1577, object par1578, int? par1579)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucJpToSjis

		[Sql.Function(Name="pg_catalog.euc_jp_to_sjis", ServerSideOnly=true)]
		public static object EucJpToSjis(int? par1580, int? par1581, object par1582, object par1583, int? par1584)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucJpToUtf8

		[Sql.Function(Name="pg_catalog.euc_jp_to_utf8", ServerSideOnly=true)]
		public static object EucJpToUtf8(int? par1585, int? par1586, object par1587, object par1588, int? par1589)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucKrToMic

		[Sql.Function(Name="pg_catalog.euc_kr_to_mic", ServerSideOnly=true)]
		public static object EucKrToMic(int? par1590, int? par1591, object par1592, object par1593, int? par1594)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucKrToUtf8

		[Sql.Function(Name="pg_catalog.euc_kr_to_utf8", ServerSideOnly=true)]
		public static object EucKrToUtf8(int? par1595, int? par1596, object par1597, object par1598, int? par1599)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucTwToBig5

		[Sql.Function(Name="pg_catalog.euc_tw_to_big5", ServerSideOnly=true)]
		public static object EucTwToBig5(int? par1600, int? par1601, object par1602, object par1603, int? par1604)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucTwToMic

		[Sql.Function(Name="pg_catalog.euc_tw_to_mic", ServerSideOnly=true)]
		public static object EucTwToMic(int? par1605, int? par1606, object par1607, object par1608, int? par1609)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EucTwToUtf8

		[Sql.Function(Name="pg_catalog.euc_tw_to_utf8", ServerSideOnly=true)]
		public static object EucTwToUtf8(int? par1610, int? par1611, object par1612, object par1613, int? par1614)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EventTriggerIn

		[Sql.Function(Name="pg_catalog.event_trigger_in", ServerSideOnly=true)]
		public static object EventTriggerIn(object par1616)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region EventTriggerOut

		[Sql.Function(Name="pg_catalog.event_trigger_out", ServerSideOnly=true)]
		public static object EventTriggerOut(object par1618)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Every

		[Sql.Function(Name="pg_catalog.every", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static bool? Every<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, bool?>> par1620)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Exp

		[Sql.Function(Name="pg_catalog.exp", ServerSideOnly=true)]
		public static decimal? Exp(decimal? par1624)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Factorial

		[Sql.Function(Name="pg_catalog.factorial", ServerSideOnly=true)]
		public static decimal? Factorial(long? par1626)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Family

		[Sql.Function(Name="pg_catalog.family", ServerSideOnly=true)]
		public static int? Family(NpgsqlInet? par1628)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region FdwHandlerIn

		[Sql.Function(Name="pg_catalog.fdw_handler_in", ServerSideOnly=true)]
		public static object FdwHandlerIn(object par1630)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region FdwHandlerOut

		[Sql.Function(Name="pg_catalog.fdw_handler_out", ServerSideOnly=true)]
		public static object FdwHandlerOut(object par1632)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region FirstValue

		[Sql.Function(Name="pg_catalog.first_value", ServerSideOnly=true)]
		public static object FirstValue(object par1634)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4

		[Sql.Function(Name="pg_catalog.float4", ServerSideOnly=true)]
		public static float? Float4(long? par1646)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4Accum

		[Sql.Function(Name="pg_catalog.float4_accum", ServerSideOnly=true)]
		public static object Float4Accum(object par1648, float? par1649)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48div

		[Sql.Function(Name="pg_catalog.float48div", ServerSideOnly=true)]
		public static double? Float48div(float? par1651, double? par1652)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48eq

		[Sql.Function(Name="pg_catalog.float48eq", ServerSideOnly=true)]
		public static bool? Float48eq(float? par1654, double? par1655)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48ge

		[Sql.Function(Name="pg_catalog.float48ge", ServerSideOnly=true)]
		public static bool? Float48ge(float? par1657, double? par1658)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48gt

		[Sql.Function(Name="pg_catalog.float48gt", ServerSideOnly=true)]
		public static bool? Float48gt(float? par1660, double? par1661)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48le

		[Sql.Function(Name="pg_catalog.float48le", ServerSideOnly=true)]
		public static bool? Float48le(float? par1663, double? par1664)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48lt

		[Sql.Function(Name="pg_catalog.float48lt", ServerSideOnly=true)]
		public static bool? Float48lt(float? par1666, double? par1667)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48mi

		[Sql.Function(Name="pg_catalog.float48mi", ServerSideOnly=true)]
		public static double? Float48mi(float? par1669, double? par1670)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48mul

		[Sql.Function(Name="pg_catalog.float48mul", ServerSideOnly=true)]
		public static double? Float48mul(float? par1672, double? par1673)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48ne

		[Sql.Function(Name="pg_catalog.float48ne", ServerSideOnly=true)]
		public static bool? Float48ne(float? par1675, double? par1676)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float48pl

		[Sql.Function(Name="pg_catalog.float48pl", ServerSideOnly=true)]
		public static double? Float48pl(float? par1678, double? par1679)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4abs

		[Sql.Function(Name="pg_catalog.float4abs", ServerSideOnly=true)]
		public static float? Float4abs(float? par1681)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4div

		[Sql.Function(Name="pg_catalog.float4div", ServerSideOnly=true)]
		public static float? Float4div(float? par1683, float? par1684)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4eq

		[Sql.Function(Name="pg_catalog.float4eq", ServerSideOnly=true)]
		public static bool? Float4eq(float? par1686, float? par1687)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4ge

		[Sql.Function(Name="pg_catalog.float4ge", ServerSideOnly=true)]
		public static bool? Float4ge(float? par1689, float? par1690)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4gt

		[Sql.Function(Name="pg_catalog.float4gt", ServerSideOnly=true)]
		public static bool? Float4gt(float? par1692, float? par1693)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4in

		[Sql.Function(Name="pg_catalog.float4in", ServerSideOnly=true)]
		public static float? Float4in(object par1695)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4larger

		[Sql.Function(Name="pg_catalog.float4larger", ServerSideOnly=true)]
		public static float? Float4larger(float? par1697, float? par1698)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4le

		[Sql.Function(Name="pg_catalog.float4le", ServerSideOnly=true)]
		public static bool? Float4le(float? par1700, float? par1701)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4lt

		[Sql.Function(Name="pg_catalog.float4lt", ServerSideOnly=true)]
		public static bool? Float4lt(float? par1703, float? par1704)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4mi

		[Sql.Function(Name="pg_catalog.float4mi", ServerSideOnly=true)]
		public static float? Float4mi(float? par1706, float? par1707)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4mul

		[Sql.Function(Name="pg_catalog.float4mul", ServerSideOnly=true)]
		public static float? Float4mul(float? par1709, float? par1710)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4ne

		[Sql.Function(Name="pg_catalog.float4ne", ServerSideOnly=true)]
		public static bool? Float4ne(float? par1712, float? par1713)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4out

		[Sql.Function(Name="pg_catalog.float4out", ServerSideOnly=true)]
		public static object Float4out(float? par1715)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4pl

		[Sql.Function(Name="pg_catalog.float4pl", ServerSideOnly=true)]
		public static float? Float4pl(float? par1717, float? par1718)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4recv

		[Sql.Function(Name="pg_catalog.float4recv", ServerSideOnly=true)]
		public static float? Float4recv(object par1720)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4send

		[Sql.Function(Name="pg_catalog.float4send", ServerSideOnly=true)]
		public static byte[] Float4send(float? par1722)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4smaller

		[Sql.Function(Name="pg_catalog.float4smaller", ServerSideOnly=true)]
		public static float? Float4smaller(float? par1724, float? par1725)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4um

		[Sql.Function(Name="pg_catalog.float4um", ServerSideOnly=true)]
		public static float? Float4um(float? par1727)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float4up

		[Sql.Function(Name="pg_catalog.float4up", ServerSideOnly=true)]
		public static float? Float4up(float? par1729)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8

		[Sql.Function(Name="pg_catalog.float8", ServerSideOnly=true)]
		public static double? Float8(long? par1741)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8Accum

		[Sql.Function(Name="pg_catalog.float8_accum", ServerSideOnly=true)]
		public static object Float8Accum(object par1743, double? par1744)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8Avg

		[Sql.Function(Name="pg_catalog.float8_avg", ServerSideOnly=true)]
		public static double? Float8Avg(object par1746)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8Combine

		[Sql.Function(Name="pg_catalog.float8_combine", ServerSideOnly=true)]
		public static object Float8Combine(object par1748, object par1749)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8Corr

		[Sql.Function(Name="pg_catalog.float8_corr", ServerSideOnly=true)]
		public static double? Float8Corr(object par1751)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8CovarPop

		[Sql.Function(Name="pg_catalog.float8_covar_pop", ServerSideOnly=true)]
		public static double? Float8CovarPop(object par1753)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8CovarSamp

		[Sql.Function(Name="pg_catalog.float8_covar_samp", ServerSideOnly=true)]
		public static double? Float8CovarSamp(object par1755)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrAccum

		[Sql.Function(Name="pg_catalog.float8_regr_accum", ServerSideOnly=true)]
		public static object Float8RegrAccum(object par1757, double? par1758, double? par1759)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrAvgx

		[Sql.Function(Name="pg_catalog.float8_regr_avgx", ServerSideOnly=true)]
		public static double? Float8RegrAvgx(object par1761)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrAvgy

		[Sql.Function(Name="pg_catalog.float8_regr_avgy", ServerSideOnly=true)]
		public static double? Float8RegrAvgy(object par1763)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrCombine

		[Sql.Function(Name="pg_catalog.float8_regr_combine", ServerSideOnly=true)]
		public static object Float8RegrCombine(object par1765, object par1766)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrIntercept

		[Sql.Function(Name="pg_catalog.float8_regr_intercept", ServerSideOnly=true)]
		public static double? Float8RegrIntercept(object par1768)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrR2

		[Sql.Function(Name="pg_catalog.float8_regr_r2", ServerSideOnly=true)]
		public static double? Float8RegrR2(object par1770)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrSlope

		[Sql.Function(Name="pg_catalog.float8_regr_slope", ServerSideOnly=true)]
		public static double? Float8RegrSlope(object par1772)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrSxx

		[Sql.Function(Name="pg_catalog.float8_regr_sxx", ServerSideOnly=true)]
		public static double? Float8RegrSxx(object par1774)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrSxy

		[Sql.Function(Name="pg_catalog.float8_regr_sxy", ServerSideOnly=true)]
		public static double? Float8RegrSxy(object par1776)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8RegrSyy

		[Sql.Function(Name="pg_catalog.float8_regr_syy", ServerSideOnly=true)]
		public static double? Float8RegrSyy(object par1778)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8StddevPop

		[Sql.Function(Name="pg_catalog.float8_stddev_pop", ServerSideOnly=true)]
		public static double? Float8StddevPop(object par1780)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8StddevSamp

		[Sql.Function(Name="pg_catalog.float8_stddev_samp", ServerSideOnly=true)]
		public static double? Float8StddevSamp(object par1782)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8VarPop

		[Sql.Function(Name="pg_catalog.float8_var_pop", ServerSideOnly=true)]
		public static double? Float8VarPop(object par1784)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8VarSamp

		[Sql.Function(Name="pg_catalog.float8_var_samp", ServerSideOnly=true)]
		public static double? Float8VarSamp(object par1786)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84div

		[Sql.Function(Name="pg_catalog.float84div", ServerSideOnly=true)]
		public static double? Float84div(double? par1788, float? par1789)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84eq

		[Sql.Function(Name="pg_catalog.float84eq", ServerSideOnly=true)]
		public static bool? Float84eq(double? par1791, float? par1792)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84ge

		[Sql.Function(Name="pg_catalog.float84ge", ServerSideOnly=true)]
		public static bool? Float84ge(double? par1794, float? par1795)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84gt

		[Sql.Function(Name="pg_catalog.float84gt", ServerSideOnly=true)]
		public static bool? Float84gt(double? par1797, float? par1798)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84le

		[Sql.Function(Name="pg_catalog.float84le", ServerSideOnly=true)]
		public static bool? Float84le(double? par1800, float? par1801)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84lt

		[Sql.Function(Name="pg_catalog.float84lt", ServerSideOnly=true)]
		public static bool? Float84lt(double? par1803, float? par1804)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84mi

		[Sql.Function(Name="pg_catalog.float84mi", ServerSideOnly=true)]
		public static double? Float84mi(double? par1806, float? par1807)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84mul

		[Sql.Function(Name="pg_catalog.float84mul", ServerSideOnly=true)]
		public static double? Float84mul(double? par1809, float? par1810)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84ne

		[Sql.Function(Name="pg_catalog.float84ne", ServerSideOnly=true)]
		public static bool? Float84ne(double? par1812, float? par1813)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float84pl

		[Sql.Function(Name="pg_catalog.float84pl", ServerSideOnly=true)]
		public static double? Float84pl(double? par1815, float? par1816)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8abs

		[Sql.Function(Name="pg_catalog.float8abs", ServerSideOnly=true)]
		public static double? Float8abs(double? par1818)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8div

		[Sql.Function(Name="pg_catalog.float8div", ServerSideOnly=true)]
		public static double? Float8div(double? par1820, double? par1821)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8eq

		[Sql.Function(Name="pg_catalog.float8eq", ServerSideOnly=true)]
		public static bool? Float8eq(double? par1823, double? par1824)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8ge

		[Sql.Function(Name="pg_catalog.float8ge", ServerSideOnly=true)]
		public static bool? Float8ge(double? par1826, double? par1827)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8gt

		[Sql.Function(Name="pg_catalog.float8gt", ServerSideOnly=true)]
		public static bool? Float8gt(double? par1829, double? par1830)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8in

		[Sql.Function(Name="pg_catalog.float8in", ServerSideOnly=true)]
		public static double? Float8in(object par1832)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8larger

		[Sql.Function(Name="pg_catalog.float8larger", ServerSideOnly=true)]
		public static double? Float8larger(double? par1834, double? par1835)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8le

		[Sql.Function(Name="pg_catalog.float8le", ServerSideOnly=true)]
		public static bool? Float8le(double? par1837, double? par1838)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8lt

		[Sql.Function(Name="pg_catalog.float8lt", ServerSideOnly=true)]
		public static bool? Float8lt(double? par1840, double? par1841)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8mi

		[Sql.Function(Name="pg_catalog.float8mi", ServerSideOnly=true)]
		public static double? Float8mi(double? par1843, double? par1844)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8mul

		[Sql.Function(Name="pg_catalog.float8mul", ServerSideOnly=true)]
		public static double? Float8mul(double? par1846, double? par1847)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8ne

		[Sql.Function(Name="pg_catalog.float8ne", ServerSideOnly=true)]
		public static bool? Float8ne(double? par1849, double? par1850)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8out

		[Sql.Function(Name="pg_catalog.float8out", ServerSideOnly=true)]
		public static object Float8out(double? par1852)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8pl

		[Sql.Function(Name="pg_catalog.float8pl", ServerSideOnly=true)]
		public static double? Float8pl(double? par1854, double? par1855)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8recv

		[Sql.Function(Name="pg_catalog.float8recv", ServerSideOnly=true)]
		public static double? Float8recv(object par1857)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8send

		[Sql.Function(Name="pg_catalog.float8send", ServerSideOnly=true)]
		public static byte[] Float8send(double? par1859)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8smaller

		[Sql.Function(Name="pg_catalog.float8smaller", ServerSideOnly=true)]
		public static double? Float8smaller(double? par1861, double? par1862)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8um

		[Sql.Function(Name="pg_catalog.float8um", ServerSideOnly=true)]
		public static double? Float8um(double? par1864)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Float8up

		[Sql.Function(Name="pg_catalog.float8up", ServerSideOnly=true)]
		public static double? Float8up(double? par1866)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Floor

		[Sql.Function(Name="pg_catalog.floor", ServerSideOnly=true)]
		public static double? Floor(double? par1870)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Flt4MulCash

		[Sql.Function(Name="pg_catalog.flt4_mul_cash", ServerSideOnly=true)]
		public static decimal? Flt4MulCash(float? par1872, decimal? par1873)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Flt8MulCash

		[Sql.Function(Name="pg_catalog.flt8_mul_cash", ServerSideOnly=true)]
		public static decimal? Flt8MulCash(double? par1875, decimal? par1876)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region FmgrCValidator

		[Sql.Function(Name="pg_catalog.fmgr_c_validator", ServerSideOnly=true)]
		public static object FmgrCValidator(int? par1877)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region FmgrInternalValidator

		[Sql.Function(Name="pg_catalog.fmgr_internal_validator", ServerSideOnly=true)]
		public static object FmgrInternalValidator(int? par1878)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region FmgrSqlValidator

		[Sql.Function(Name="pg_catalog.fmgr_sql_validator", ServerSideOnly=true)]
		public static object FmgrSqlValidator(int? par1879)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Format

		[Sql.Function(Name="pg_catalog.format", ServerSideOnly=true)]
		public static string Format(string par1884)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region FormatType

		[Sql.Function(Name="pg_catalog.format_type", ServerSideOnly=true)]
		public static string FormatType(int? par1886, int? par1887)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Gb18030ToUtf8

		[Sql.Function(Name="pg_catalog.gb18030_to_utf8", ServerSideOnly=true)]
		public static object Gb18030ToUtf8(int? par1888, int? par1889, object par1890, object par1891, int? par1892)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GbkToUtf8

		[Sql.Function(Name="pg_catalog.gbk_to_utf8", ServerSideOnly=true)]
		public static object GbkToUtf8(int? par1893, int? par1894, object par1895, object par1896, int? par1897)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GetBit

		[Sql.Function(Name="pg_catalog.get_bit", ServerSideOnly=true)]
		public static int? GetBit(byte[] par1928, int? par1929)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GetByte

		[Sql.Function(Name="pg_catalog.get_byte", ServerSideOnly=true)]
		public static int? GetByte(byte[] par1931, int? par1932)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GetCurrentTsConfig

		[Sql.Function(Name="pg_catalog.get_current_ts_config", ServerSideOnly=true)]
		public static object GetCurrentTsConfig()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Getdatabaseencoding

		[Sql.Function(Name="pg_catalog.getdatabaseencoding", ServerSideOnly=true)]
		public static string Getdatabaseencoding()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Getpgusername

		[Sql.Function(Name="pg_catalog.getpgusername", ServerSideOnly=true)]
		public static string Getpgusername()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinCleanPendingList

		[Sql.Function(Name="pg_catalog.gin_clean_pending_list", ServerSideOnly=true)]
		public static long? GinCleanPendingList(object par1937)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinCmpPrefix

		[Sql.Function(Name="pg_catalog.gin_cmp_prefix", ServerSideOnly=true)]
		public static int? GinCmpPrefix(string par1939, string par1940, short? par1941, object par1942)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinCmpTslexeme

		[Sql.Function(Name="pg_catalog.gin_cmp_tslexeme", ServerSideOnly=true)]
		public static int? GinCmpTslexeme(string par1944, string par1945)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinCompareJsonb

		[Sql.Function(Name="pg_catalog.gin_compare_jsonb", ServerSideOnly=true)]
		public static int? GinCompareJsonb(string par1947, string par1948)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinConsistentJsonb

		[Sql.Function(Name="pg_catalog.gin_consistent_jsonb", ServerSideOnly=true)]
		public static bool? GinConsistentJsonb(object par1950, short? par1951, string par1952, int? par1953, object par1954, object par1955, object par1956, object par1957)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinConsistentJsonbPath

		[Sql.Function(Name="pg_catalog.gin_consistent_jsonb_path", ServerSideOnly=true)]
		public static bool? GinConsistentJsonbPath(object par1959, short? par1960, string par1961, int? par1962, object par1963, object par1964, object par1965, object par1966)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinExtractJsonb

		[Sql.Function(Name="pg_catalog.gin_extract_jsonb", ServerSideOnly=true)]
		public static object GinExtractJsonb(string par1968, object par1969, object par1970)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinExtractJsonbPath

		[Sql.Function(Name="pg_catalog.gin_extract_jsonb_path", ServerSideOnly=true)]
		public static object GinExtractJsonbPath(string par1972, object par1973, object par1974)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinExtractJsonbQuery

		[Sql.Function(Name="pg_catalog.gin_extract_jsonb_query", ServerSideOnly=true)]
		public static object GinExtractJsonbQuery(string par1976, object par1977, short? par1978, object par1979, object par1980, object par1981, object par1982)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinExtractJsonbQueryPath

		[Sql.Function(Name="pg_catalog.gin_extract_jsonb_query_path", ServerSideOnly=true)]
		public static object GinExtractJsonbQueryPath(string par1984, object par1985, short? par1986, object par1987, object par1988, object par1989, object par1990)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinExtractTsquery

		[Sql.Function(Name="pg_catalog.gin_extract_tsquery", ServerSideOnly=true)]
		public static object GinExtractTsquery(object par2006, object par2007, short? par2008, object par2009, object par2010, object par2011, object par2012)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinExtractTsvector

		[Sql.Function(Name="pg_catalog.gin_extract_tsvector", ServerSideOnly=true)]
		public static object GinExtractTsvector(object par2017, object par2018, object par2019)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinTriconsistentJsonb

		[Sql.Function(Name="pg_catalog.gin_triconsistent_jsonb", ServerSideOnly=true)]
		public static object GinTriconsistentJsonb(object par2021, short? par2022, string par2023, int? par2024, object par2025, object par2026, object par2027)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinTriconsistentJsonbPath

		[Sql.Function(Name="pg_catalog.gin_triconsistent_jsonb_path", ServerSideOnly=true)]
		public static object GinTriconsistentJsonbPath(object par2029, short? par2030, string par2031, int? par2032, object par2033, object par2034, object par2035)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinTsqueryConsistent

		[Sql.Function(Name="pg_catalog.gin_tsquery_consistent", ServerSideOnly=true)]
		public static bool? GinTsqueryConsistent(object par2053, short? par2054, object par2055, int? par2056, object par2057, object par2058, object par2059, object par2060)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GinTsqueryTriconsistent

		[Sql.Function(Name="pg_catalog.gin_tsquery_triconsistent", ServerSideOnly=true)]
		public static object GinTsqueryTriconsistent(object par2062, short? par2063, object par2064, int? par2065, object par2066, object par2067, object par2068)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ginarrayconsistent

		[Sql.Function(Name="pg_catalog.ginarrayconsistent", ServerSideOnly=true)]
		public static bool? Ginarrayconsistent(object par2070, short? par2071, object par2072, int? par2073, object par2074, object par2075, object par2076, object par2077)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ginarrayextract

		[Sql.Function(Name="pg_catalog.ginarrayextract", ServerSideOnly=true)]
		public static object Ginarrayextract(object par2083, object par2084)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ginarraytriconsistent

		[Sql.Function(Name="pg_catalog.ginarraytriconsistent", ServerSideOnly=true)]
		public static object Ginarraytriconsistent(object par2086, short? par2087, object par2088, int? par2089, object par2090, object par2091, object par2092)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ginhandler

		[Sql.Function(Name="pg_catalog.ginhandler", ServerSideOnly=true)]
		public static object Ginhandler(object par2094)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ginqueryarrayextract

		[Sql.Function(Name="pg_catalog.ginqueryarrayextract", ServerSideOnly=true)]
		public static object Ginqueryarrayextract(object par2096, object par2097, short? par2098, object par2099, object par2100, object par2101, object par2102)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistBoxConsistent

		[Sql.Function(Name="pg_catalog.gist_box_consistent", ServerSideOnly=true)]
		public static bool? GistBoxConsistent(object par2104, NpgsqlBox? par2105, short? par2106, int? par2107, object par2108)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistBoxPenalty

		[Sql.Function(Name="pg_catalog.gist_box_penalty", ServerSideOnly=true)]
		public static object GistBoxPenalty(object par2110, object par2111, object par2112)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistBoxPicksplit

		[Sql.Function(Name="pg_catalog.gist_box_picksplit", ServerSideOnly=true)]
		public static object GistBoxPicksplit(object par2114, object par2115)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistBoxSame

		[Sql.Function(Name="pg_catalog.gist_box_same", ServerSideOnly=true)]
		public static object GistBoxSame(NpgsqlBox? par2117, NpgsqlBox? par2118, object par2119)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistBoxUnion

		[Sql.Function(Name="pg_catalog.gist_box_union", ServerSideOnly=true)]
		public static NpgsqlBox? GistBoxUnion(object par2121, object par2122)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistCircleCompress

		[Sql.Function(Name="pg_catalog.gist_circle_compress", ServerSideOnly=true)]
		public static object GistCircleCompress(object par2124)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistCircleConsistent

		[Sql.Function(Name="pg_catalog.gist_circle_consistent", ServerSideOnly=true)]
		public static bool? GistCircleConsistent(object par2126, NpgsqlCircle? par2127, short? par2128, int? par2129, object par2130)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistCircleDistance

		[Sql.Function(Name="pg_catalog.gist_circle_distance", ServerSideOnly=true)]
		public static double? GistCircleDistance(object par2132, NpgsqlCircle? par2133, short? par2134, int? par2135, object par2136)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistPointCompress

		[Sql.Function(Name="pg_catalog.gist_point_compress", ServerSideOnly=true)]
		public static object GistPointCompress(object par2138)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistPointConsistent

		[Sql.Function(Name="pg_catalog.gist_point_consistent", ServerSideOnly=true)]
		public static bool? GistPointConsistent(object par2140, NpgsqlPoint? par2141, short? par2142, int? par2143, object par2144)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistPointDistance

		[Sql.Function(Name="pg_catalog.gist_point_distance", ServerSideOnly=true)]
		public static double? GistPointDistance(object par2146, NpgsqlPoint? par2147, short? par2148, int? par2149, object par2150)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistPointFetch

		[Sql.Function(Name="pg_catalog.gist_point_fetch", ServerSideOnly=true)]
		public static object GistPointFetch(object par2152)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistPolyCompress

		[Sql.Function(Name="pg_catalog.gist_poly_compress", ServerSideOnly=true)]
		public static object GistPolyCompress(object par2154)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistPolyConsistent

		[Sql.Function(Name="pg_catalog.gist_poly_consistent", ServerSideOnly=true)]
		public static bool? GistPolyConsistent(object par2156, NpgsqlPolygon? par2157, short? par2158, int? par2159, object par2160)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GistPolyDistance

		[Sql.Function(Name="pg_catalog.gist_poly_distance", ServerSideOnly=true)]
		public static double? GistPolyDistance(object par2162, NpgsqlPolygon? par2163, short? par2164, int? par2165, object par2166)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Gisthandler

		[Sql.Function(Name="pg_catalog.gisthandler", ServerSideOnly=true)]
		public static object Gisthandler(object par2168)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsqueryCompress

		[Sql.Function(Name="pg_catalog.gtsquery_compress", ServerSideOnly=true)]
		public static object GtsqueryCompress(object par2170)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsqueryConsistent

		[Sql.Function(Name="pg_catalog.gtsquery_consistent", ServerSideOnly=true)]
		public static bool? GtsqueryConsistent(object par2178, object par2179, int? par2180, int? par2181, object par2182)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsqueryPenalty

		[Sql.Function(Name="pg_catalog.gtsquery_penalty", ServerSideOnly=true)]
		public static object GtsqueryPenalty(object par2184, object par2185, object par2186)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsqueryPicksplit

		[Sql.Function(Name="pg_catalog.gtsquery_picksplit", ServerSideOnly=true)]
		public static object GtsqueryPicksplit(object par2188, object par2189)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsquerySame

		[Sql.Function(Name="pg_catalog.gtsquery_same", ServerSideOnly=true)]
		public static object GtsquerySame(long? par2191, long? par2192, object par2193)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsqueryUnion

		[Sql.Function(Name="pg_catalog.gtsquery_union", ServerSideOnly=true)]
		public static long? GtsqueryUnion(object par2195, object par2196)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsvectorCompress

		[Sql.Function(Name="pg_catalog.gtsvector_compress", ServerSideOnly=true)]
		public static object GtsvectorCompress(object par2198)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsvectorConsistent

		[Sql.Function(Name="pg_catalog.gtsvector_consistent", ServerSideOnly=true)]
		public static bool? GtsvectorConsistent(object par2206, object par2207, int? par2208, int? par2209, object par2210)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsvectorDecompress

		[Sql.Function(Name="pg_catalog.gtsvector_decompress", ServerSideOnly=true)]
		public static object GtsvectorDecompress(object par2212)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsvectorPenalty

		[Sql.Function(Name="pg_catalog.gtsvector_penalty", ServerSideOnly=true)]
		public static object GtsvectorPenalty(object par2214, object par2215, object par2216)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsvectorPicksplit

		[Sql.Function(Name="pg_catalog.gtsvector_picksplit", ServerSideOnly=true)]
		public static object GtsvectorPicksplit(object par2218, object par2219)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsvectorSame

		[Sql.Function(Name="pg_catalog.gtsvector_same", ServerSideOnly=true)]
		public static object GtsvectorSame(object par2221, object par2222, object par2223)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region GtsvectorUnion

		[Sql.Function(Name="pg_catalog.gtsvector_union", ServerSideOnly=true)]
		public static object GtsvectorUnion(object par2225, object par2226)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Gtsvectorin

		[Sql.Function(Name="pg_catalog.gtsvectorin", ServerSideOnly=true)]
		public static object Gtsvectorin(object par2228)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Gtsvectorout

		[Sql.Function(Name="pg_catalog.gtsvectorout", ServerSideOnly=true)]
		public static object Gtsvectorout(object par2230)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasAnyColumnPrivilege

		[Sql.Function(Name="pg_catalog.has_any_column_privilege", ServerSideOnly=true)]
		public static bool? HasAnyColumnPrivilege(int? par2251, string par2252)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasColumnPrivilege

		[Sql.Function(Name="pg_catalog.has_column_privilege", ServerSideOnly=true)]
		public static bool? HasColumnPrivilege(int? par2306, short? par2307, string par2308)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasDatabasePrivilege

		[Sql.Function(Name="pg_catalog.has_database_privilege", ServerSideOnly=true)]
		public static bool? HasDatabasePrivilege(int? par2329, string par2330)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasForeignDataWrapperPrivilege

		[Sql.Function(Name="pg_catalog.has_foreign_data_wrapper_privilege", ServerSideOnly=true)]
		public static bool? HasForeignDataWrapperPrivilege(int? par2351, string par2352)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasFunctionPrivilege

		[Sql.Function(Name="pg_catalog.has_function_privilege", ServerSideOnly=true)]
		public static bool? HasFunctionPrivilege(int? par2373, string par2374)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasLanguagePrivilege

		[Sql.Function(Name="pg_catalog.has_language_privilege", ServerSideOnly=true)]
		public static bool? HasLanguagePrivilege(int? par2395, string par2396)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasSchemaPrivilege

		[Sql.Function(Name="pg_catalog.has_schema_privilege", ServerSideOnly=true)]
		public static bool? HasSchemaPrivilege(int? par2417, string par2418)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasSequencePrivilege

		[Sql.Function(Name="pg_catalog.has_sequence_privilege", ServerSideOnly=true)]
		public static bool? HasSequencePrivilege(int? par2439, string par2440)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasServerPrivilege

		[Sql.Function(Name="pg_catalog.has_server_privilege", ServerSideOnly=true)]
		public static bool? HasServerPrivilege(int? par2461, string par2462)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasTablePrivilege

		[Sql.Function(Name="pg_catalog.has_table_privilege", ServerSideOnly=true)]
		public static bool? HasTablePrivilege(int? par2483, string par2484)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasTablespacePrivilege

		[Sql.Function(Name="pg_catalog.has_tablespace_privilege", ServerSideOnly=true)]
		public static bool? HasTablespacePrivilege(int? par2505, string par2506)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HasTypePrivilege

		[Sql.Function(Name="pg_catalog.has_type_privilege", ServerSideOnly=true)]
		public static bool? HasTypePrivilege(int? par2527, string par2528)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HashAclitem

		[Sql.Function(Name="pg_catalog.hash_aclitem", ServerSideOnly=true)]
		public static int? HashAclitem(object par2530)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HashAclitemExtended

		[Sql.Function(Name="pg_catalog.hash_aclitem_extended", ServerSideOnly=true)]
		public static long? HashAclitemExtended(object par2532, long? par2533)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HashArray

		[Sql.Function(Name="pg_catalog.hash_array", ServerSideOnly=true)]
		public static int? HashArray(object par2535)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HashArrayExtended

		[Sql.Function(Name="pg_catalog.hash_array_extended", ServerSideOnly=true)]
		public static long? HashArrayExtended(object par2537, long? par2538)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HashNumeric

		[Sql.Function(Name="pg_catalog.hash_numeric", ServerSideOnly=true)]
		public static int? HashNumeric(decimal? par2540)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HashNumericExtended

		[Sql.Function(Name="pg_catalog.hash_numeric_extended", ServerSideOnly=true)]
		public static long? HashNumericExtended(decimal? par2542, long? par2543)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HashRange

		[Sql.Function(Name="pg_catalog.hash_range", ServerSideOnly=true)]
		public static int? HashRange(object par2545)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region HashRangeExtended

		[Sql.Function(Name="pg_catalog.hash_range_extended", ServerSideOnly=true)]
		public static long? HashRangeExtended(object par2547, long? par2548)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashbpchar

		[Sql.Function(Name="pg_catalog.hashbpchar", ServerSideOnly=true)]
		public static int? Hashbpchar(string par2550)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashbpcharextended

		[Sql.Function(Name="pg_catalog.hashbpcharextended", ServerSideOnly=true)]
		public static long? Hashbpcharextended(string par2552, long? par2553)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashchar

		[Sql.Function(Name="pg_catalog.hashchar", ServerSideOnly=true)]
		public static int? Hashchar(object par2555)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashcharextended

		[Sql.Function(Name="pg_catalog.hashcharextended", ServerSideOnly=true)]
		public static long? Hashcharextended(object par2557, long? par2558)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashenum

		[Sql.Function(Name="pg_catalog.hashenum", ServerSideOnly=true)]
		public static int? Hashenum(object par2560)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashenumextended

		[Sql.Function(Name="pg_catalog.hashenumextended", ServerSideOnly=true)]
		public static long? Hashenumextended(object par2562, long? par2563)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashfloat4

		[Sql.Function(Name="pg_catalog.hashfloat4", ServerSideOnly=true)]
		public static int? Hashfloat4(float? par2565)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashfloat4extended

		[Sql.Function(Name="pg_catalog.hashfloat4extended", ServerSideOnly=true)]
		public static long? Hashfloat4extended(float? par2567, long? par2568)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashfloat8

		[Sql.Function(Name="pg_catalog.hashfloat8", ServerSideOnly=true)]
		public static int? Hashfloat8(double? par2570)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashfloat8extended

		[Sql.Function(Name="pg_catalog.hashfloat8extended", ServerSideOnly=true)]
		public static long? Hashfloat8extended(double? par2572, long? par2573)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashhandler

		[Sql.Function(Name="pg_catalog.hashhandler", ServerSideOnly=true)]
		public static object Hashhandler(object par2575)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashinet

		[Sql.Function(Name="pg_catalog.hashinet", ServerSideOnly=true)]
		public static int? Hashinet(NpgsqlInet? par2577)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashinetextended

		[Sql.Function(Name="pg_catalog.hashinetextended", ServerSideOnly=true)]
		public static long? Hashinetextended(NpgsqlInet? par2579, long? par2580)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashint2

		[Sql.Function(Name="pg_catalog.hashint2", ServerSideOnly=true)]
		public static int? Hashint2(short? par2582)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashint2extended

		[Sql.Function(Name="pg_catalog.hashint2extended", ServerSideOnly=true)]
		public static long? Hashint2extended(short? par2584, long? par2585)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashint4

		[Sql.Function(Name="pg_catalog.hashint4", ServerSideOnly=true)]
		public static int? Hashint4(int? par2587)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashint4extended

		[Sql.Function(Name="pg_catalog.hashint4extended", ServerSideOnly=true)]
		public static long? Hashint4extended(int? par2589, long? par2590)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashint8

		[Sql.Function(Name="pg_catalog.hashint8", ServerSideOnly=true)]
		public static int? Hashint8(long? par2592)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashint8extended

		[Sql.Function(Name="pg_catalog.hashint8extended", ServerSideOnly=true)]
		public static long? Hashint8extended(long? par2594, long? par2595)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashmacaddr

		[Sql.Function(Name="pg_catalog.hashmacaddr", ServerSideOnly=true)]
		public static int? Hashmacaddr(PhysicalAddress par2597)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashmacaddr8

		[Sql.Function(Name="pg_catalog.hashmacaddr8", ServerSideOnly=true)]
		public static int? Hashmacaddr8(PhysicalAddress par2599)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashmacaddr8extended

		[Sql.Function(Name="pg_catalog.hashmacaddr8extended", ServerSideOnly=true)]
		public static long? Hashmacaddr8extended(PhysicalAddress par2601, long? par2602)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashmacaddrextended

		[Sql.Function(Name="pg_catalog.hashmacaddrextended", ServerSideOnly=true)]
		public static long? Hashmacaddrextended(PhysicalAddress par2604, long? par2605)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashname

		[Sql.Function(Name="pg_catalog.hashname", ServerSideOnly=true)]
		public static int? Hashname(string par2607)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashnameextended

		[Sql.Function(Name="pg_catalog.hashnameextended", ServerSideOnly=true)]
		public static long? Hashnameextended(string par2609, long? par2610)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashoid

		[Sql.Function(Name="pg_catalog.hashoid", ServerSideOnly=true)]
		public static int? Hashoid(int? par2612)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashoidextended

		[Sql.Function(Name="pg_catalog.hashoidextended", ServerSideOnly=true)]
		public static long? Hashoidextended(int? par2614, long? par2615)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashoidvector

		[Sql.Function(Name="pg_catalog.hashoidvector", ServerSideOnly=true)]
		public static int? Hashoidvector(object par2617)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashoidvectorextended

		[Sql.Function(Name="pg_catalog.hashoidvectorextended", ServerSideOnly=true)]
		public static long? Hashoidvectorextended(object par2619, long? par2620)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashtext

		[Sql.Function(Name="pg_catalog.hashtext", ServerSideOnly=true)]
		public static int? Hashtext(string par2622)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashtextextended

		[Sql.Function(Name="pg_catalog.hashtextextended", ServerSideOnly=true)]
		public static long? Hashtextextended(string par2624, long? par2625)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashvarlena

		[Sql.Function(Name="pg_catalog.hashvarlena", ServerSideOnly=true)]
		public static int? Hashvarlena(object par2627)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hashvarlenaextended

		[Sql.Function(Name="pg_catalog.hashvarlenaextended", ServerSideOnly=true)]
		public static long? Hashvarlenaextended(object par2629, long? par2630)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Height

		[Sql.Function(Name="pg_catalog.height", ServerSideOnly=true)]
		public static double? Height(NpgsqlBox? par2632)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Host

		[Sql.Function(Name="pg_catalog.host", ServerSideOnly=true)]
		public static string Host(NpgsqlInet? par2634)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Hostmask

		[Sql.Function(Name="pg_catalog.hostmask", ServerSideOnly=true)]
		public static NpgsqlInet? Hostmask(NpgsqlInet? par2636)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Iclikejoinsel

		[Sql.Function(Name="pg_catalog.iclikejoinsel", ServerSideOnly=true)]
		public static double? Iclikejoinsel(object par2638, int? par2639, object par2640, short? par2641, object par2642)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Iclikesel

		[Sql.Function(Name="pg_catalog.iclikesel", ServerSideOnly=true)]
		public static double? Iclikesel(object par2644, int? par2645, object par2646, int? par2647)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Icnlikejoinsel

		[Sql.Function(Name="pg_catalog.icnlikejoinsel", ServerSideOnly=true)]
		public static double? Icnlikejoinsel(object par2649, int? par2650, object par2651, short? par2652, object par2653)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Icnlikesel

		[Sql.Function(Name="pg_catalog.icnlikesel", ServerSideOnly=true)]
		public static double? Icnlikesel(object par2655, int? par2656, object par2657, int? par2658)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Icregexeqjoinsel

		[Sql.Function(Name="pg_catalog.icregexeqjoinsel", ServerSideOnly=true)]
		public static double? Icregexeqjoinsel(object par2660, int? par2661, object par2662, short? par2663, object par2664)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Icregexeqsel

		[Sql.Function(Name="pg_catalog.icregexeqsel", ServerSideOnly=true)]
		public static double? Icregexeqsel(object par2666, int? par2667, object par2668, int? par2669)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Icregexnejoinsel

		[Sql.Function(Name="pg_catalog.icregexnejoinsel", ServerSideOnly=true)]
		public static double? Icregexnejoinsel(object par2671, int? par2672, object par2673, short? par2674, object par2675)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Icregexnesel

		[Sql.Function(Name="pg_catalog.icregexnesel", ServerSideOnly=true)]
		public static double? Icregexnesel(object par2677, int? par2678, object par2679, int? par2680)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InRange

		[Sql.Function(Name="pg_catalog.in_range", ServerSideOnly=true)]
		public static bool? InRange(decimal? par2772, decimal? par2773, decimal? par2774, bool? par2775, bool? par2776)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IndexAmHandlerIn

		[Sql.Function(Name="pg_catalog.index_am_handler_in", ServerSideOnly=true)]
		public static object IndexAmHandlerIn(object par2778)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IndexAmHandlerOut

		[Sql.Function(Name="pg_catalog.index_am_handler_out", ServerSideOnly=true)]
		public static object IndexAmHandlerOut(object par2780)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetClientAddr

		[Sql.Function(Name="pg_catalog.inet_client_addr", ServerSideOnly=true)]
		public static NpgsqlInet? InetClientAddr()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetClientPort

		[Sql.Function(Name="pg_catalog.inet_client_port", ServerSideOnly=true)]
		public static int? InetClientPort()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetGistCompress

		[Sql.Function(Name="pg_catalog.inet_gist_compress", ServerSideOnly=true)]
		public static object InetGistCompress(object par2784)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetGistConsistent

		[Sql.Function(Name="pg_catalog.inet_gist_consistent", ServerSideOnly=true)]
		public static bool? InetGistConsistent(object par2786, NpgsqlInet? par2787, short? par2788, int? par2789, object par2790)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetGistFetch

		[Sql.Function(Name="pg_catalog.inet_gist_fetch", ServerSideOnly=true)]
		public static object InetGistFetch(object par2792)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetGistPenalty

		[Sql.Function(Name="pg_catalog.inet_gist_penalty", ServerSideOnly=true)]
		public static object InetGistPenalty(object par2794, object par2795, object par2796)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetGistPicksplit

		[Sql.Function(Name="pg_catalog.inet_gist_picksplit", ServerSideOnly=true)]
		public static object InetGistPicksplit(object par2798, object par2799)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetGistSame

		[Sql.Function(Name="pg_catalog.inet_gist_same", ServerSideOnly=true)]
		public static object InetGistSame(NpgsqlInet? par2801, NpgsqlInet? par2802, object par2803)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetGistUnion

		[Sql.Function(Name="pg_catalog.inet_gist_union", ServerSideOnly=true)]
		public static NpgsqlInet? InetGistUnion(object par2805, object par2806)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetIn

		[Sql.Function(Name="pg_catalog.inet_in", ServerSideOnly=true)]
		public static NpgsqlInet? InetIn(object par2808)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetMerge

		[Sql.Function(Name="pg_catalog.inet_merge", ServerSideOnly=true)]
		public static NpgsqlInet? InetMerge(NpgsqlInet? par2810, NpgsqlInet? par2811)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetOut

		[Sql.Function(Name="pg_catalog.inet_out", ServerSideOnly=true)]
		public static object InetOut(NpgsqlInet? par2813)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetRecv

		[Sql.Function(Name="pg_catalog.inet_recv", ServerSideOnly=true)]
		public static NpgsqlInet? InetRecv(object par2815)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetSameFamily

		[Sql.Function(Name="pg_catalog.inet_same_family", ServerSideOnly=true)]
		public static bool? InetSameFamily(NpgsqlInet? par2817, NpgsqlInet? par2818)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetSend

		[Sql.Function(Name="pg_catalog.inet_send", ServerSideOnly=true)]
		public static byte[] InetSend(NpgsqlInet? par2820)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetServerAddr

		[Sql.Function(Name="pg_catalog.inet_server_addr", ServerSideOnly=true)]
		public static NpgsqlInet? InetServerAddr()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetServerPort

		[Sql.Function(Name="pg_catalog.inet_server_port", ServerSideOnly=true)]
		public static int? InetServerPort()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetSpgChoose

		[Sql.Function(Name="pg_catalog.inet_spg_choose", ServerSideOnly=true)]
		public static object InetSpgChoose(object par2823, object par2824)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetSpgConfig

		[Sql.Function(Name="pg_catalog.inet_spg_config", ServerSideOnly=true)]
		public static object InetSpgConfig(object par2825, object par2826)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetSpgInnerConsistent

		[Sql.Function(Name="pg_catalog.inet_spg_inner_consistent", ServerSideOnly=true)]
		public static object InetSpgInnerConsistent(object par2827, object par2828)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetSpgLeafConsistent

		[Sql.Function(Name="pg_catalog.inet_spg_leaf_consistent", ServerSideOnly=true)]
		public static bool? InetSpgLeafConsistent(object par2830, object par2831)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetSpgPicksplit

		[Sql.Function(Name="pg_catalog.inet_spg_picksplit", ServerSideOnly=true)]
		public static object InetSpgPicksplit(object par2832, object par2833)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Inetand

		[Sql.Function(Name="pg_catalog.inetand", ServerSideOnly=true)]
		public static NpgsqlInet? Inetand(NpgsqlInet? par2835, NpgsqlInet? par2836)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Inetmi

		[Sql.Function(Name="pg_catalog.inetmi", ServerSideOnly=true)]
		public static long? Inetmi(NpgsqlInet? par2838, NpgsqlInet? par2839)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InetmiInt8

		[Sql.Function(Name="pg_catalog.inetmi_int8", ServerSideOnly=true)]
		public static NpgsqlInet? InetmiInt8(NpgsqlInet? par2841, long? par2842)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Inetnot

		[Sql.Function(Name="pg_catalog.inetnot", ServerSideOnly=true)]
		public static NpgsqlInet? Inetnot(NpgsqlInet? par2844)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Inetor

		[Sql.Function(Name="pg_catalog.inetor", ServerSideOnly=true)]
		public static NpgsqlInet? Inetor(NpgsqlInet? par2846, NpgsqlInet? par2847)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Inetpl

		[Sql.Function(Name="pg_catalog.inetpl", ServerSideOnly=true)]
		public static NpgsqlInet? Inetpl(NpgsqlInet? par2849, long? par2850)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Initcap

		[Sql.Function(Name="pg_catalog.initcap", ServerSideOnly=true)]
		public static string Initcap(string par2852)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2

		[Sql.Function(Name="pg_catalog.int2", ServerSideOnly=true)]
		public static short? Int2(long? par2864)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2Accum

		[Sql.Function(Name="pg_catalog.int2_accum", ServerSideOnly=true)]
		public static object Int2Accum(object par2866, short? par2867)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2AccumInv

		[Sql.Function(Name="pg_catalog.int2_accum_inv", ServerSideOnly=true)]
		public static object Int2AccumInv(object par2869, short? par2870)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2AvgAccum

		[Sql.Function(Name="pg_catalog.int2_avg_accum", ServerSideOnly=true)]
		public static object Int2AvgAccum(object par2872, short? par2873)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2AvgAccumInv

		[Sql.Function(Name="pg_catalog.int2_avg_accum_inv", ServerSideOnly=true)]
		public static object Int2AvgAccumInv(object par2875, short? par2876)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2MulCash

		[Sql.Function(Name="pg_catalog.int2_mul_cash", ServerSideOnly=true)]
		public static decimal? Int2MulCash(short? par2878, decimal? par2879)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2Sum

		[Sql.Function(Name="pg_catalog.int2_sum", ServerSideOnly=true)]
		public static long? Int2Sum(long? par2881, short? par2882)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24div

		[Sql.Function(Name="pg_catalog.int24div", ServerSideOnly=true)]
		public static int? Int24div(short? par2884, int? par2885)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24eq

		[Sql.Function(Name="pg_catalog.int24eq", ServerSideOnly=true)]
		public static bool? Int24eq(short? par2887, int? par2888)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24ge

		[Sql.Function(Name="pg_catalog.int24ge", ServerSideOnly=true)]
		public static bool? Int24ge(short? par2890, int? par2891)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24gt

		[Sql.Function(Name="pg_catalog.int24gt", ServerSideOnly=true)]
		public static bool? Int24gt(short? par2893, int? par2894)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24le

		[Sql.Function(Name="pg_catalog.int24le", ServerSideOnly=true)]
		public static bool? Int24le(short? par2896, int? par2897)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24lt

		[Sql.Function(Name="pg_catalog.int24lt", ServerSideOnly=true)]
		public static bool? Int24lt(short? par2899, int? par2900)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24mi

		[Sql.Function(Name="pg_catalog.int24mi", ServerSideOnly=true)]
		public static int? Int24mi(short? par2902, int? par2903)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24mul

		[Sql.Function(Name="pg_catalog.int24mul", ServerSideOnly=true)]
		public static int? Int24mul(short? par2905, int? par2906)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24ne

		[Sql.Function(Name="pg_catalog.int24ne", ServerSideOnly=true)]
		public static bool? Int24ne(short? par2908, int? par2909)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int24pl

		[Sql.Function(Name="pg_catalog.int24pl", ServerSideOnly=true)]
		public static int? Int24pl(short? par2911, int? par2912)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28div

		[Sql.Function(Name="pg_catalog.int28div", ServerSideOnly=true)]
		public static long? Int28div(short? par2914, long? par2915)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28eq

		[Sql.Function(Name="pg_catalog.int28eq", ServerSideOnly=true)]
		public static bool? Int28eq(short? par2917, long? par2918)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28ge

		[Sql.Function(Name="pg_catalog.int28ge", ServerSideOnly=true)]
		public static bool? Int28ge(short? par2920, long? par2921)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28gt

		[Sql.Function(Name="pg_catalog.int28gt", ServerSideOnly=true)]
		public static bool? Int28gt(short? par2923, long? par2924)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28le

		[Sql.Function(Name="pg_catalog.int28le", ServerSideOnly=true)]
		public static bool? Int28le(short? par2926, long? par2927)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28lt

		[Sql.Function(Name="pg_catalog.int28lt", ServerSideOnly=true)]
		public static bool? Int28lt(short? par2929, long? par2930)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28mi

		[Sql.Function(Name="pg_catalog.int28mi", ServerSideOnly=true)]
		public static long? Int28mi(short? par2932, long? par2933)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28mul

		[Sql.Function(Name="pg_catalog.int28mul", ServerSideOnly=true)]
		public static long? Int28mul(short? par2935, long? par2936)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28ne

		[Sql.Function(Name="pg_catalog.int28ne", ServerSideOnly=true)]
		public static bool? Int28ne(short? par2938, long? par2939)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int28pl

		[Sql.Function(Name="pg_catalog.int28pl", ServerSideOnly=true)]
		public static long? Int28pl(short? par2941, long? par2942)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2abs

		[Sql.Function(Name="pg_catalog.int2abs", ServerSideOnly=true)]
		public static short? Int2abs(short? par2944)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2and

		[Sql.Function(Name="pg_catalog.int2and", ServerSideOnly=true)]
		public static short? Int2and(short? par2946, short? par2947)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2div

		[Sql.Function(Name="pg_catalog.int2div", ServerSideOnly=true)]
		public static short? Int2div(short? par2949, short? par2950)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2eq

		[Sql.Function(Name="pg_catalog.int2eq", ServerSideOnly=true)]
		public static bool? Int2eq(short? par2952, short? par2953)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2ge

		[Sql.Function(Name="pg_catalog.int2ge", ServerSideOnly=true)]
		public static bool? Int2ge(short? par2955, short? par2956)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2gt

		[Sql.Function(Name="pg_catalog.int2gt", ServerSideOnly=true)]
		public static bool? Int2gt(short? par2958, short? par2959)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2in

		[Sql.Function(Name="pg_catalog.int2in", ServerSideOnly=true)]
		public static short? Int2in(object par2961)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2int4Sum

		[Sql.Function(Name="pg_catalog.int2int4_sum", ServerSideOnly=true)]
		public static long? Int2int4Sum(object par2963)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2larger

		[Sql.Function(Name="pg_catalog.int2larger", ServerSideOnly=true)]
		public static short? Int2larger(short? par2965, short? par2966)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2le

		[Sql.Function(Name="pg_catalog.int2le", ServerSideOnly=true)]
		public static bool? Int2le(short? par2968, short? par2969)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2lt

		[Sql.Function(Name="pg_catalog.int2lt", ServerSideOnly=true)]
		public static bool? Int2lt(short? par2971, short? par2972)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2mi

		[Sql.Function(Name="pg_catalog.int2mi", ServerSideOnly=true)]
		public static short? Int2mi(short? par2974, short? par2975)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2mod

		[Sql.Function(Name="pg_catalog.int2mod", ServerSideOnly=true)]
		public static short? Int2mod(short? par2977, short? par2978)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2mul

		[Sql.Function(Name="pg_catalog.int2mul", ServerSideOnly=true)]
		public static short? Int2mul(short? par2980, short? par2981)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2ne

		[Sql.Function(Name="pg_catalog.int2ne", ServerSideOnly=true)]
		public static bool? Int2ne(short? par2983, short? par2984)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2not

		[Sql.Function(Name="pg_catalog.int2not", ServerSideOnly=true)]
		public static short? Int2not(short? par2986)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2or

		[Sql.Function(Name="pg_catalog.int2or", ServerSideOnly=true)]
		public static short? Int2or(short? par2988, short? par2989)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2out

		[Sql.Function(Name="pg_catalog.int2out", ServerSideOnly=true)]
		public static object Int2out(short? par2991)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2pl

		[Sql.Function(Name="pg_catalog.int2pl", ServerSideOnly=true)]
		public static short? Int2pl(short? par2993, short? par2994)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2recv

		[Sql.Function(Name="pg_catalog.int2recv", ServerSideOnly=true)]
		public static short? Int2recv(object par2996)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2send

		[Sql.Function(Name="pg_catalog.int2send", ServerSideOnly=true)]
		public static byte[] Int2send(short? par2998)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2shl

		[Sql.Function(Name="pg_catalog.int2shl", ServerSideOnly=true)]
		public static short? Int2shl(short? par3000, int? par3001)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2shr

		[Sql.Function(Name="pg_catalog.int2shr", ServerSideOnly=true)]
		public static short? Int2shr(short? par3003, int? par3004)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2smaller

		[Sql.Function(Name="pg_catalog.int2smaller", ServerSideOnly=true)]
		public static short? Int2smaller(short? par3006, short? par3007)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2um

		[Sql.Function(Name="pg_catalog.int2um", ServerSideOnly=true)]
		public static short? Int2um(short? par3009)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2up

		[Sql.Function(Name="pg_catalog.int2up", ServerSideOnly=true)]
		public static short? Int2up(short? par3011)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2vectorin

		[Sql.Function(Name="pg_catalog.int2vectorin", ServerSideOnly=true)]
		public static object Int2vectorin(object par3013)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2vectorout

		[Sql.Function(Name="pg_catalog.int2vectorout", ServerSideOnly=true)]
		public static object Int2vectorout(object par3015)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2vectorrecv

		[Sql.Function(Name="pg_catalog.int2vectorrecv", ServerSideOnly=true)]
		public static object Int2vectorrecv(object par3017)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2vectorsend

		[Sql.Function(Name="pg_catalog.int2vectorsend", ServerSideOnly=true)]
		public static byte[] Int2vectorsend(object par3019)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int2xor

		[Sql.Function(Name="pg_catalog.int2xor", ServerSideOnly=true)]
		public static short? Int2xor(short? par3021, short? par3022)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4

		[Sql.Function(Name="pg_catalog.int4", ServerSideOnly=true)]
		public static int? Int4(object par3040)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4Accum

		[Sql.Function(Name="pg_catalog.int4_accum", ServerSideOnly=true)]
		public static object Int4Accum(object par3042, int? par3043)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4AccumInv

		[Sql.Function(Name="pg_catalog.int4_accum_inv", ServerSideOnly=true)]
		public static object Int4AccumInv(object par3045, int? par3046)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4AvgAccum

		[Sql.Function(Name="pg_catalog.int4_avg_accum", ServerSideOnly=true)]
		public static object Int4AvgAccum(object par3048, int? par3049)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4AvgAccumInv

		[Sql.Function(Name="pg_catalog.int4_avg_accum_inv", ServerSideOnly=true)]
		public static object Int4AvgAccumInv(object par3051, int? par3052)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4AvgCombine

		[Sql.Function(Name="pg_catalog.int4_avg_combine", ServerSideOnly=true)]
		public static object Int4AvgCombine(object par3054, object par3055)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4MulCash

		[Sql.Function(Name="pg_catalog.int4_mul_cash", ServerSideOnly=true)]
		public static decimal? Int4MulCash(int? par3057, decimal? par3058)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4Sum

		[Sql.Function(Name="pg_catalog.int4_sum", ServerSideOnly=true)]
		public static long? Int4Sum(long? par3060, int? par3061)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42div

		[Sql.Function(Name="pg_catalog.int42div", ServerSideOnly=true)]
		public static int? Int42div(int? par3063, short? par3064)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42eq

		[Sql.Function(Name="pg_catalog.int42eq", ServerSideOnly=true)]
		public static bool? Int42eq(int? par3066, short? par3067)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42ge

		[Sql.Function(Name="pg_catalog.int42ge", ServerSideOnly=true)]
		public static bool? Int42ge(int? par3069, short? par3070)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42gt

		[Sql.Function(Name="pg_catalog.int42gt", ServerSideOnly=true)]
		public static bool? Int42gt(int? par3072, short? par3073)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42le

		[Sql.Function(Name="pg_catalog.int42le", ServerSideOnly=true)]
		public static bool? Int42le(int? par3075, short? par3076)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42lt

		[Sql.Function(Name="pg_catalog.int42lt", ServerSideOnly=true)]
		public static bool? Int42lt(int? par3078, short? par3079)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42mi

		[Sql.Function(Name="pg_catalog.int42mi", ServerSideOnly=true)]
		public static int? Int42mi(int? par3081, short? par3082)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42mul

		[Sql.Function(Name="pg_catalog.int42mul", ServerSideOnly=true)]
		public static int? Int42mul(int? par3084, short? par3085)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42ne

		[Sql.Function(Name="pg_catalog.int42ne", ServerSideOnly=true)]
		public static bool? Int42ne(int? par3087, short? par3088)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int42pl

		[Sql.Function(Name="pg_catalog.int42pl", ServerSideOnly=true)]
		public static int? Int42pl(int? par3090, short? par3091)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48div

		[Sql.Function(Name="pg_catalog.int48div", ServerSideOnly=true)]
		public static long? Int48div(int? par3093, long? par3094)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48eq

		[Sql.Function(Name="pg_catalog.int48eq", ServerSideOnly=true)]
		public static bool? Int48eq(int? par3096, long? par3097)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48ge

		[Sql.Function(Name="pg_catalog.int48ge", ServerSideOnly=true)]
		public static bool? Int48ge(int? par3099, long? par3100)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48gt

		[Sql.Function(Name="pg_catalog.int48gt", ServerSideOnly=true)]
		public static bool? Int48gt(int? par3102, long? par3103)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48le

		[Sql.Function(Name="pg_catalog.int48le", ServerSideOnly=true)]
		public static bool? Int48le(int? par3105, long? par3106)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48lt

		[Sql.Function(Name="pg_catalog.int48lt", ServerSideOnly=true)]
		public static bool? Int48lt(int? par3108, long? par3109)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48mi

		[Sql.Function(Name="pg_catalog.int48mi", ServerSideOnly=true)]
		public static long? Int48mi(int? par3111, long? par3112)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48mul

		[Sql.Function(Name="pg_catalog.int48mul", ServerSideOnly=true)]
		public static long? Int48mul(int? par3114, long? par3115)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48ne

		[Sql.Function(Name="pg_catalog.int48ne", ServerSideOnly=true)]
		public static bool? Int48ne(int? par3117, long? par3118)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int48pl

		[Sql.Function(Name="pg_catalog.int48pl", ServerSideOnly=true)]
		public static long? Int48pl(int? par3120, long? par3121)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4abs

		[Sql.Function(Name="pg_catalog.int4abs", ServerSideOnly=true)]
		public static int? Int4abs(int? par3123)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4and

		[Sql.Function(Name="pg_catalog.int4and", ServerSideOnly=true)]
		public static int? Int4and(int? par3125, int? par3126)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4div

		[Sql.Function(Name="pg_catalog.int4div", ServerSideOnly=true)]
		public static int? Int4div(int? par3128, int? par3129)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4eq

		[Sql.Function(Name="pg_catalog.int4eq", ServerSideOnly=true)]
		public static bool? Int4eq(int? par3131, int? par3132)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4ge

		[Sql.Function(Name="pg_catalog.int4ge", ServerSideOnly=true)]
		public static bool? Int4ge(int? par3134, int? par3135)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4gt

		[Sql.Function(Name="pg_catalog.int4gt", ServerSideOnly=true)]
		public static bool? Int4gt(int? par3137, int? par3138)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4in

		[Sql.Function(Name="pg_catalog.int4in", ServerSideOnly=true)]
		public static int? Int4in(object par3140)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4inc

		[Sql.Function(Name="pg_catalog.int4inc", ServerSideOnly=true)]
		public static int? Int4inc(int? par3142)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4larger

		[Sql.Function(Name="pg_catalog.int4larger", ServerSideOnly=true)]
		public static int? Int4larger(int? par3144, int? par3145)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4le

		[Sql.Function(Name="pg_catalog.int4le", ServerSideOnly=true)]
		public static bool? Int4le(int? par3147, int? par3148)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4lt

		[Sql.Function(Name="pg_catalog.int4lt", ServerSideOnly=true)]
		public static bool? Int4lt(int? par3150, int? par3151)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4mi

		[Sql.Function(Name="pg_catalog.int4mi", ServerSideOnly=true)]
		public static int? Int4mi(int? par3153, int? par3154)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4mod

		[Sql.Function(Name="pg_catalog.int4mod", ServerSideOnly=true)]
		public static int? Int4mod(int? par3156, int? par3157)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4mul

		[Sql.Function(Name="pg_catalog.int4mul", ServerSideOnly=true)]
		public static int? Int4mul(int? par3159, int? par3160)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4ne

		[Sql.Function(Name="pg_catalog.int4ne", ServerSideOnly=true)]
		public static bool? Int4ne(int? par3162, int? par3163)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4not

		[Sql.Function(Name="pg_catalog.int4not", ServerSideOnly=true)]
		public static int? Int4not(int? par3165)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4or

		[Sql.Function(Name="pg_catalog.int4or", ServerSideOnly=true)]
		public static int? Int4or(int? par3167, int? par3168)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4out

		[Sql.Function(Name="pg_catalog.int4out", ServerSideOnly=true)]
		public static object Int4out(int? par3170)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4pl

		[Sql.Function(Name="pg_catalog.int4pl", ServerSideOnly=true)]
		public static int? Int4pl(int? par3172, int? par3173)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4range

		[Sql.Function(Name="pg_catalog.int4range", ServerSideOnly=true)]
		public static object Int4range(int? par3178, int? par3179, string par3180)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4rangeCanonical

		[Sql.Function(Name="pg_catalog.int4range_canonical", ServerSideOnly=true)]
		public static object Int4rangeCanonical(object par3182)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4rangeSubdiff

		[Sql.Function(Name="pg_catalog.int4range_subdiff", ServerSideOnly=true)]
		public static double? Int4rangeSubdiff(int? par3184, int? par3185)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4recv

		[Sql.Function(Name="pg_catalog.int4recv", ServerSideOnly=true)]
		public static int? Int4recv(object par3187)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4send

		[Sql.Function(Name="pg_catalog.int4send", ServerSideOnly=true)]
		public static byte[] Int4send(int? par3189)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4shl

		[Sql.Function(Name="pg_catalog.int4shl", ServerSideOnly=true)]
		public static int? Int4shl(int? par3191, int? par3192)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4shr

		[Sql.Function(Name="pg_catalog.int4shr", ServerSideOnly=true)]
		public static int? Int4shr(int? par3194, int? par3195)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4smaller

		[Sql.Function(Name="pg_catalog.int4smaller", ServerSideOnly=true)]
		public static int? Int4smaller(int? par3197, int? par3198)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4um

		[Sql.Function(Name="pg_catalog.int4um", ServerSideOnly=true)]
		public static int? Int4um(int? par3200)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4up

		[Sql.Function(Name="pg_catalog.int4up", ServerSideOnly=true)]
		public static int? Int4up(int? par3202)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int4xor

		[Sql.Function(Name="pg_catalog.int4xor", ServerSideOnly=true)]
		public static int? Int4xor(int? par3204, int? par3205)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8

		[Sql.Function(Name="pg_catalog.int8", ServerSideOnly=true)]
		public static long? Int8(short? par3221)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8Accum

		[Sql.Function(Name="pg_catalog.int8_accum", ServerSideOnly=true)]
		public static object Int8Accum(object par3223, long? par3224)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8AccumInv

		[Sql.Function(Name="pg_catalog.int8_accum_inv", ServerSideOnly=true)]
		public static object Int8AccumInv(object par3226, long? par3227)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8Avg

		[Sql.Function(Name="pg_catalog.int8_avg", ServerSideOnly=true)]
		public static decimal? Int8Avg(object par3229)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8AvgAccum

		[Sql.Function(Name="pg_catalog.int8_avg_accum", ServerSideOnly=true)]
		public static object Int8AvgAccum(object par3231, long? par3232)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8AvgAccumInv

		[Sql.Function(Name="pg_catalog.int8_avg_accum_inv", ServerSideOnly=true)]
		public static object Int8AvgAccumInv(object par3234, long? par3235)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8AvgCombine

		[Sql.Function(Name="pg_catalog.int8_avg_combine", ServerSideOnly=true)]
		public static object Int8AvgCombine(object par3237, object par3238)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8AvgDeserialize

		[Sql.Function(Name="pg_catalog.int8_avg_deserialize", ServerSideOnly=true)]
		public static object Int8AvgDeserialize(byte[] par3240, object par3241)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8AvgSerialize

		[Sql.Function(Name="pg_catalog.int8_avg_serialize", ServerSideOnly=true)]
		public static byte[] Int8AvgSerialize(object par3243)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8MulCash

		[Sql.Function(Name="pg_catalog.int8_mul_cash", ServerSideOnly=true)]
		public static decimal? Int8MulCash(long? par3245, decimal? par3246)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8Sum

		[Sql.Function(Name="pg_catalog.int8_sum", ServerSideOnly=true)]
		public static decimal? Int8Sum(decimal? par3248, long? par3249)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82div

		[Sql.Function(Name="pg_catalog.int82div", ServerSideOnly=true)]
		public static long? Int82div(long? par3251, short? par3252)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82eq

		[Sql.Function(Name="pg_catalog.int82eq", ServerSideOnly=true)]
		public static bool? Int82eq(long? par3254, short? par3255)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82ge

		[Sql.Function(Name="pg_catalog.int82ge", ServerSideOnly=true)]
		public static bool? Int82ge(long? par3257, short? par3258)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82gt

		[Sql.Function(Name="pg_catalog.int82gt", ServerSideOnly=true)]
		public static bool? Int82gt(long? par3260, short? par3261)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82le

		[Sql.Function(Name="pg_catalog.int82le", ServerSideOnly=true)]
		public static bool? Int82le(long? par3263, short? par3264)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82lt

		[Sql.Function(Name="pg_catalog.int82lt", ServerSideOnly=true)]
		public static bool? Int82lt(long? par3266, short? par3267)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82mi

		[Sql.Function(Name="pg_catalog.int82mi", ServerSideOnly=true)]
		public static long? Int82mi(long? par3269, short? par3270)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82mul

		[Sql.Function(Name="pg_catalog.int82mul", ServerSideOnly=true)]
		public static long? Int82mul(long? par3272, short? par3273)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82ne

		[Sql.Function(Name="pg_catalog.int82ne", ServerSideOnly=true)]
		public static bool? Int82ne(long? par3275, short? par3276)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int82pl

		[Sql.Function(Name="pg_catalog.int82pl", ServerSideOnly=true)]
		public static long? Int82pl(long? par3278, short? par3279)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84div

		[Sql.Function(Name="pg_catalog.int84div", ServerSideOnly=true)]
		public static long? Int84div(long? par3281, int? par3282)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84eq

		[Sql.Function(Name="pg_catalog.int84eq", ServerSideOnly=true)]
		public static bool? Int84eq(long? par3284, int? par3285)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84ge

		[Sql.Function(Name="pg_catalog.int84ge", ServerSideOnly=true)]
		public static bool? Int84ge(long? par3287, int? par3288)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84gt

		[Sql.Function(Name="pg_catalog.int84gt", ServerSideOnly=true)]
		public static bool? Int84gt(long? par3290, int? par3291)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84le

		[Sql.Function(Name="pg_catalog.int84le", ServerSideOnly=true)]
		public static bool? Int84le(long? par3293, int? par3294)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84lt

		[Sql.Function(Name="pg_catalog.int84lt", ServerSideOnly=true)]
		public static bool? Int84lt(long? par3296, int? par3297)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84mi

		[Sql.Function(Name="pg_catalog.int84mi", ServerSideOnly=true)]
		public static long? Int84mi(long? par3299, int? par3300)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84mul

		[Sql.Function(Name="pg_catalog.int84mul", ServerSideOnly=true)]
		public static long? Int84mul(long? par3302, int? par3303)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84ne

		[Sql.Function(Name="pg_catalog.int84ne", ServerSideOnly=true)]
		public static bool? Int84ne(long? par3305, int? par3306)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int84pl

		[Sql.Function(Name="pg_catalog.int84pl", ServerSideOnly=true)]
		public static long? Int84pl(long? par3308, int? par3309)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8abs

		[Sql.Function(Name="pg_catalog.int8abs", ServerSideOnly=true)]
		public static long? Int8abs(long? par3311)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8and

		[Sql.Function(Name="pg_catalog.int8and", ServerSideOnly=true)]
		public static long? Int8and(long? par3313, long? par3314)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8dec

		[Sql.Function(Name="pg_catalog.int8dec", ServerSideOnly=true)]
		public static long? Int8dec(long? par3316)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8decAny

		[Sql.Function(Name="pg_catalog.int8dec_any", ServerSideOnly=true)]
		public static long? Int8decAny(long? par3318, object par3319)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8div

		[Sql.Function(Name="pg_catalog.int8div", ServerSideOnly=true)]
		public static long? Int8div(long? par3321, long? par3322)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8eq

		[Sql.Function(Name="pg_catalog.int8eq", ServerSideOnly=true)]
		public static bool? Int8eq(long? par3324, long? par3325)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8ge

		[Sql.Function(Name="pg_catalog.int8ge", ServerSideOnly=true)]
		public static bool? Int8ge(long? par3327, long? par3328)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8gt

		[Sql.Function(Name="pg_catalog.int8gt", ServerSideOnly=true)]
		public static bool? Int8gt(long? par3330, long? par3331)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8in

		[Sql.Function(Name="pg_catalog.int8in", ServerSideOnly=true)]
		public static long? Int8in(object par3333)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8inc

		[Sql.Function(Name="pg_catalog.int8inc", ServerSideOnly=true)]
		public static long? Int8inc(long? par3335)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8incAny

		[Sql.Function(Name="pg_catalog.int8inc_any", ServerSideOnly=true)]
		public static long? Int8incAny(long? par3337, object par3338)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8incFloat8Float8

		[Sql.Function(Name="pg_catalog.int8inc_float8_float8", ServerSideOnly=true)]
		public static long? Int8incFloat8Float8(long? par3340, double? par3341, double? par3342)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8larger

		[Sql.Function(Name="pg_catalog.int8larger", ServerSideOnly=true)]
		public static long? Int8larger(long? par3344, long? par3345)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8le

		[Sql.Function(Name="pg_catalog.int8le", ServerSideOnly=true)]
		public static bool? Int8le(long? par3347, long? par3348)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8lt

		[Sql.Function(Name="pg_catalog.int8lt", ServerSideOnly=true)]
		public static bool? Int8lt(long? par3350, long? par3351)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8mi

		[Sql.Function(Name="pg_catalog.int8mi", ServerSideOnly=true)]
		public static long? Int8mi(long? par3353, long? par3354)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8mod

		[Sql.Function(Name="pg_catalog.int8mod", ServerSideOnly=true)]
		public static long? Int8mod(long? par3356, long? par3357)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8mul

		[Sql.Function(Name="pg_catalog.int8mul", ServerSideOnly=true)]
		public static long? Int8mul(long? par3359, long? par3360)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8ne

		[Sql.Function(Name="pg_catalog.int8ne", ServerSideOnly=true)]
		public static bool? Int8ne(long? par3362, long? par3363)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8not

		[Sql.Function(Name="pg_catalog.int8not", ServerSideOnly=true)]
		public static long? Int8not(long? par3365)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8or

		[Sql.Function(Name="pg_catalog.int8or", ServerSideOnly=true)]
		public static long? Int8or(long? par3367, long? par3368)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8out

		[Sql.Function(Name="pg_catalog.int8out", ServerSideOnly=true)]
		public static object Int8out(long? par3370)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8pl

		[Sql.Function(Name="pg_catalog.int8pl", ServerSideOnly=true)]
		public static long? Int8pl(long? par3372, long? par3373)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8plInet

		[Sql.Function(Name="pg_catalog.int8pl_inet", ServerSideOnly=true)]
		public static NpgsqlInet? Int8plInet(long? par3375, NpgsqlInet? par3376)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8range

		[Sql.Function(Name="pg_catalog.int8range", ServerSideOnly=true)]
		public static object Int8range(long? par3381, long? par3382, string par3383)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8rangeCanonical

		[Sql.Function(Name="pg_catalog.int8range_canonical", ServerSideOnly=true)]
		public static object Int8rangeCanonical(object par3385)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8rangeSubdiff

		[Sql.Function(Name="pg_catalog.int8range_subdiff", ServerSideOnly=true)]
		public static double? Int8rangeSubdiff(long? par3387, long? par3388)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8recv

		[Sql.Function(Name="pg_catalog.int8recv", ServerSideOnly=true)]
		public static long? Int8recv(object par3390)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8send

		[Sql.Function(Name="pg_catalog.int8send", ServerSideOnly=true)]
		public static byte[] Int8send(long? par3392)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8shl

		[Sql.Function(Name="pg_catalog.int8shl", ServerSideOnly=true)]
		public static long? Int8shl(long? par3394, int? par3395)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8shr

		[Sql.Function(Name="pg_catalog.int8shr", ServerSideOnly=true)]
		public static long? Int8shr(long? par3397, int? par3398)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8smaller

		[Sql.Function(Name="pg_catalog.int8smaller", ServerSideOnly=true)]
		public static long? Int8smaller(long? par3400, long? par3401)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8um

		[Sql.Function(Name="pg_catalog.int8um", ServerSideOnly=true)]
		public static long? Int8um(long? par3403)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8up

		[Sql.Function(Name="pg_catalog.int8up", ServerSideOnly=true)]
		public static long? Int8up(long? par3405)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Int8xor

		[Sql.Function(Name="pg_catalog.int8xor", ServerSideOnly=true)]
		public static long? Int8xor(long? par3407, long? par3408)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntegerPlDate

		[Sql.Function(Name="pg_catalog.integer_pl_date", ServerSideOnly=true)]
		public static NpgsqlDate? IntegerPlDate(int? par3410, NpgsqlDate? par3411)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InterLb

		[Sql.Function(Name="pg_catalog.inter_lb", ServerSideOnly=true)]
		public static bool? InterLb(NpgsqlLine? par3413, NpgsqlBox? par3414)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InterSb

		[Sql.Function(Name="pg_catalog.inter_sb", ServerSideOnly=true)]
		public static bool? InterSb(NpgsqlLSeg? par3416, NpgsqlBox? par3417)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InterSl

		[Sql.Function(Name="pg_catalog.inter_sl", ServerSideOnly=true)]
		public static bool? InterSl(NpgsqlLSeg? par3419, NpgsqlLine? par3420)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InternalIn

		[Sql.Function(Name="pg_catalog.internal_in", ServerSideOnly=true)]
		public static object InternalIn(object par3422)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region InternalOut

		[Sql.Function(Name="pg_catalog.internal_out", ServerSideOnly=true)]
		public static object InternalOut(object par3424)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Interval

		[Sql.Function(Name="pg_catalog.interval", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? Interval(TimeSpan? par3431)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalAccum

		[Sql.Function(Name="pg_catalog.interval_accum", ServerSideOnly=true)]
		public static object IntervalAccum(object par3433, NpgsqlTimeSpan? par3434)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalAccumInv

		[Sql.Function(Name="pg_catalog.interval_accum_inv", ServerSideOnly=true)]
		public static object IntervalAccumInv(object par3436, NpgsqlTimeSpan? par3437)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalAvg

		[Sql.Function(Name="pg_catalog.interval_avg", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalAvg(object par3439)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalCmp

		[Sql.Function(Name="pg_catalog.interval_cmp", ServerSideOnly=true)]
		public static int? IntervalCmp(NpgsqlTimeSpan? par3441, NpgsqlTimeSpan? par3442)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalCombine

		[Sql.Function(Name="pg_catalog.interval_combine", ServerSideOnly=true)]
		public static object IntervalCombine(object par3444, object par3445)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalDiv

		[Sql.Function(Name="pg_catalog.interval_div", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalDiv(NpgsqlTimeSpan? par3447, double? par3448)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalEq

		[Sql.Function(Name="pg_catalog.interval_eq", ServerSideOnly=true)]
		public static bool? IntervalEq(NpgsqlTimeSpan? par3450, NpgsqlTimeSpan? par3451)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalGe

		[Sql.Function(Name="pg_catalog.interval_ge", ServerSideOnly=true)]
		public static bool? IntervalGe(NpgsqlTimeSpan? par3453, NpgsqlTimeSpan? par3454)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalGt

		[Sql.Function(Name="pg_catalog.interval_gt", ServerSideOnly=true)]
		public static bool? IntervalGt(NpgsqlTimeSpan? par3456, NpgsqlTimeSpan? par3457)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalHash

		[Sql.Function(Name="pg_catalog.interval_hash", ServerSideOnly=true)]
		public static int? IntervalHash(NpgsqlTimeSpan? par3459)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalHashExtended

		[Sql.Function(Name="pg_catalog.interval_hash_extended", ServerSideOnly=true)]
		public static long? IntervalHashExtended(NpgsqlTimeSpan? par3461, long? par3462)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalIn

		[Sql.Function(Name="pg_catalog.interval_in", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalIn(object par3464, int? par3465, int? par3466)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalLarger

		[Sql.Function(Name="pg_catalog.interval_larger", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalLarger(NpgsqlTimeSpan? par3468, NpgsqlTimeSpan? par3469)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalLe

		[Sql.Function(Name="pg_catalog.interval_le", ServerSideOnly=true)]
		public static bool? IntervalLe(NpgsqlTimeSpan? par3471, NpgsqlTimeSpan? par3472)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalLt

		[Sql.Function(Name="pg_catalog.interval_lt", ServerSideOnly=true)]
		public static bool? IntervalLt(NpgsqlTimeSpan? par3474, NpgsqlTimeSpan? par3475)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalMi

		[Sql.Function(Name="pg_catalog.interval_mi", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalMi(NpgsqlTimeSpan? par3477, NpgsqlTimeSpan? par3478)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalMul

		[Sql.Function(Name="pg_catalog.interval_mul", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalMul(NpgsqlTimeSpan? par3480, double? par3481)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalNe

		[Sql.Function(Name="pg_catalog.interval_ne", ServerSideOnly=true)]
		public static bool? IntervalNe(NpgsqlTimeSpan? par3483, NpgsqlTimeSpan? par3484)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalOut

		[Sql.Function(Name="pg_catalog.interval_out", ServerSideOnly=true)]
		public static object IntervalOut(NpgsqlTimeSpan? par3486)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalPl

		[Sql.Function(Name="pg_catalog.interval_pl", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalPl(NpgsqlTimeSpan? par3488, NpgsqlTimeSpan? par3489)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalPlDate

		[Sql.Function(Name="pg_catalog.interval_pl_date", ServerSideOnly=true)]
		public static DateTime? IntervalPlDate(NpgsqlTimeSpan? par3491, NpgsqlDate? par3492)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalPlTime

		[Sql.Function(Name="pg_catalog.interval_pl_time", ServerSideOnly=true)]
		public static TimeSpan? IntervalPlTime(NpgsqlTimeSpan? par3494, TimeSpan? par3495)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalPlTimestamp

		[Sql.Function(Name="pg_catalog.interval_pl_timestamp", ServerSideOnly=true)]
		public static DateTime? IntervalPlTimestamp(NpgsqlTimeSpan? par3497, DateTime? par3498)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalPlTimestamptz

		[Sql.Function(Name="pg_catalog.interval_pl_timestamptz", ServerSideOnly=true)]
		public static DateTimeOffset? IntervalPlTimestamptz(NpgsqlTimeSpan? par3500, DateTimeOffset? par3501)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalPlTimetz

		[Sql.Function(Name="pg_catalog.interval_pl_timetz", ServerSideOnly=true)]
		public static DateTimeOffset? IntervalPlTimetz(NpgsqlTimeSpan? par3503, DateTimeOffset? par3504)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalRecv

		[Sql.Function(Name="pg_catalog.interval_recv", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalRecv(object par3506, int? par3507, int? par3508)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalSend

		[Sql.Function(Name="pg_catalog.interval_send", ServerSideOnly=true)]
		public static byte[] IntervalSend(NpgsqlTimeSpan? par3510)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalSmaller

		[Sql.Function(Name="pg_catalog.interval_smaller", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalSmaller(NpgsqlTimeSpan? par3512, NpgsqlTimeSpan? par3513)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalTransform

		[Sql.Function(Name="pg_catalog.interval_transform", ServerSideOnly=true)]
		public static object IntervalTransform(object par3515)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IntervalUm

		[Sql.Function(Name="pg_catalog.interval_um", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? IntervalUm(NpgsqlTimeSpan? par3517)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Intervaltypmodin

		[Sql.Function(Name="pg_catalog.intervaltypmodin", ServerSideOnly=true)]
		public static int? Intervaltypmodin(object par3519)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Intervaltypmodout

		[Sql.Function(Name="pg_catalog.intervaltypmodout", ServerSideOnly=true)]
		public static object Intervaltypmodout(int? par3521)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Intinterval

		[Sql.Function(Name="pg_catalog.intinterval", ServerSideOnly=true)]
		public static bool? Intinterval(object par3523, object par3524)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Isclosed

		[Sql.Function(Name="pg_catalog.isclosed", ServerSideOnly=true)]
		public static bool? Isclosed(NpgsqlPath? par3526)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Isempty

		[Sql.Function(Name="pg_catalog.isempty", ServerSideOnly=true)]
		public static bool? Isempty(object par3528)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Isfinite

		[Sql.Function(Name="pg_catalog.isfinite", ServerSideOnly=true)]
		public static bool? Isfinite(object par3538)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ishorizontal

		[Sql.Function(Name="pg_catalog.ishorizontal", ServerSideOnly=true)]
		public static bool? Ishorizontal(NpgsqlLine? par3545)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IsoToKoi8r

		[Sql.Function(Name="pg_catalog.iso_to_koi8r", ServerSideOnly=true)]
		public static object IsoToKoi8r(int? par3546, int? par3547, object par3548, object par3549, int? par3550)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IsoToMic

		[Sql.Function(Name="pg_catalog.iso_to_mic", ServerSideOnly=true)]
		public static object IsoToMic(int? par3551, int? par3552, object par3553, object par3554, int? par3555)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IsoToWin1251

		[Sql.Function(Name="pg_catalog.iso_to_win1251", ServerSideOnly=true)]
		public static object IsoToWin1251(int? par3556, int? par3557, object par3558, object par3559, int? par3560)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region IsoToWin866

		[Sql.Function(Name="pg_catalog.iso_to_win866", ServerSideOnly=true)]
		public static object IsoToWin866(int? par3561, int? par3562, object par3563, object par3564, int? par3565)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Iso88591ToUtf8

		[Sql.Function(Name="pg_catalog.iso8859_1_to_utf8", ServerSideOnly=true)]
		public static object Iso88591ToUtf8(int? par3566, int? par3567, object par3568, object par3569, int? par3570)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Iso8859ToUtf8

		[Sql.Function(Name="pg_catalog.iso8859_to_utf8", ServerSideOnly=true)]
		public static object Iso8859ToUtf8(int? par3571, int? par3572, object par3573, object par3574, int? par3575)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Isopen

		[Sql.Function(Name="pg_catalog.isopen", ServerSideOnly=true)]
		public static bool? Isopen(NpgsqlPath? par3577)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Isparallel

		[Sql.Function(Name="pg_catalog.isparallel", ServerSideOnly=true)]
		public static bool? Isparallel(NpgsqlLine? par3582, NpgsqlLine? par3583)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Isperp

		[Sql.Function(Name="pg_catalog.isperp", ServerSideOnly=true)]
		public static bool? Isperp(NpgsqlLine? par3588, NpgsqlLine? par3589)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Isvertical

		[Sql.Function(Name="pg_catalog.isvertical", ServerSideOnly=true)]
		public static bool? Isvertical(NpgsqlLine? par3596)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JohabToUtf8

		[Sql.Function(Name="pg_catalog.johab_to_utf8", ServerSideOnly=true)]
		public static object JohabToUtf8(int? par3597, int? par3598, object par3599, object par3600, int? par3601)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonAgg

		[Sql.Function(Name="pg_catalog.json_agg", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static string JsonAgg<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par3603)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonAggFinalfn

		[Sql.Function(Name="pg_catalog.json_agg_finalfn", ServerSideOnly=true)]
		public static string JsonAggFinalfn(object par3605)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonAggTransfn

		[Sql.Function(Name="pg_catalog.json_agg_transfn", ServerSideOnly=true)]
		public static object JsonAggTransfn(object par3607, object par3608)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonArrayElement

		[Sql.Function(Name="pg_catalog.json_array_element", ServerSideOnly=true)]
		public static string JsonArrayElement(string from_json, int? element_index)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonArrayElementText

		[Sql.Function(Name="pg_catalog.json_array_element_text", ServerSideOnly=true)]
		public static string JsonArrayElementText(string from_json, int? element_index)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonArrayLength

		[Sql.Function(Name="pg_catalog.json_array_length", ServerSideOnly=true)]
		public static int? JsonArrayLength(string par3612)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonBuildArray

		[Sql.Function(Name="pg_catalog.json_build_array", ServerSideOnly=true)]
		public static string JsonBuildArray()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonBuildObject

		[Sql.Function(Name="pg_catalog.json_build_object", ServerSideOnly=true)]
		public static string JsonBuildObject()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonExtractPath

		[Sql.Function(Name="pg_catalog.json_extract_path", ServerSideOnly=true)]
		public static string JsonExtractPath(string from_json, object path_elems)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonExtractPathText

		[Sql.Function(Name="pg_catalog.json_extract_path_text", ServerSideOnly=true)]
		public static string JsonExtractPathText(string from_json, object path_elems)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonIn

		[Sql.Function(Name="pg_catalog.json_in", ServerSideOnly=true)]
		public static string JsonIn(object par3622)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonObject

		[Sql.Function(Name="pg_catalog.json_object", ServerSideOnly=true)]
		public static string JsonObject(object par3626, object par3627)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonObjectAgg

		[Sql.Function(Name="pg_catalog.json_object_agg", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static string JsonObjectAgg<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par3629, Expression<Func<TSource, object>> par3630)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonObjectAggFinalfn

		[Sql.Function(Name="pg_catalog.json_object_agg_finalfn", ServerSideOnly=true)]
		public static string JsonObjectAggFinalfn(object par3632)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonObjectAggTransfn

		[Sql.Function(Name="pg_catalog.json_object_agg_transfn", ServerSideOnly=true)]
		public static object JsonObjectAggTransfn(object par3634, object par3635, object par3636)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonObjectField

		[Sql.Function(Name="pg_catalog.json_object_field", ServerSideOnly=true)]
		public static string JsonObjectField(string from_json, string field_name)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonObjectFieldText

		[Sql.Function(Name="pg_catalog.json_object_field_text", ServerSideOnly=true)]
		public static string JsonObjectFieldText(string from_json, string field_name)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonOut

		[Sql.Function(Name="pg_catalog.json_out", ServerSideOnly=true)]
		public static object JsonOut(string par3641)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonPopulateRecord

		[Sql.Function(Name="pg_catalog.json_populate_record", ServerSideOnly=true)]
		public static object JsonPopulateRecord(object @base, string from_json, bool? use_json_as_text)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonRecv

		[Sql.Function(Name="pg_catalog.json_recv", ServerSideOnly=true)]
		public static string JsonRecv(object par3644)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonSend

		[Sql.Function(Name="pg_catalog.json_send", ServerSideOnly=true)]
		public static byte[] JsonSend(string par3646)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonStripNulls

		[Sql.Function(Name="pg_catalog.json_strip_nulls", ServerSideOnly=true)]
		public static string JsonStripNulls(string par3648)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonToRecord

		[Sql.Function(Name="pg_catalog.json_to_record", ServerSideOnly=true)]
		public static object JsonToRecord(string par3649)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonToTsvector

		[Sql.Function(Name="pg_catalog.json_to_tsvector", ServerSideOnly=true)]
		public static object JsonToTsvector(object par3655, string par3656, string par3657)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonTypeof

		[Sql.Function(Name="pg_catalog.json_typeof", ServerSideOnly=true)]
		public static string JsonTypeof(string par3659)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbAgg

		[Sql.Function(Name="pg_catalog.jsonb_agg", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static string JsonbAgg<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par3661)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbAggFinalfn

		[Sql.Function(Name="pg_catalog.jsonb_agg_finalfn", ServerSideOnly=true)]
		public static string JsonbAggFinalfn(object par3663)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbAggTransfn

		[Sql.Function(Name="pg_catalog.jsonb_agg_transfn", ServerSideOnly=true)]
		public static object JsonbAggTransfn(object par3665, object par3666)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbArrayElement

		[Sql.Function(Name="pg_catalog.jsonb_array_element", ServerSideOnly=true)]
		public static string JsonbArrayElement(string from_json, int? element_index)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbArrayElementText

		[Sql.Function(Name="pg_catalog.jsonb_array_element_text", ServerSideOnly=true)]
		public static string JsonbArrayElementText(string from_json, int? element_index)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbArrayLength

		[Sql.Function(Name="pg_catalog.jsonb_array_length", ServerSideOnly=true)]
		public static int? JsonbArrayLength(string par3670)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbBuildArray

		[Sql.Function(Name="pg_catalog.jsonb_build_array", ServerSideOnly=true)]
		public static string JsonbBuildArray()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbBuildObject

		[Sql.Function(Name="pg_catalog.jsonb_build_object", ServerSideOnly=true)]
		public static string JsonbBuildObject()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbCmp

		[Sql.Function(Name="pg_catalog.jsonb_cmp", ServerSideOnly=true)]
		public static int? JsonbCmp(string par3678, string par3679)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbConcat

		[Sql.Function(Name="pg_catalog.jsonb_concat", ServerSideOnly=true)]
		public static string JsonbConcat(string par3681, string par3682)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbContained

		[Sql.Function(Name="pg_catalog.jsonb_contained", ServerSideOnly=true)]
		public static bool? JsonbContained(string par3684, string par3685)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbContains

		[Sql.Function(Name="pg_catalog.jsonb_contains", ServerSideOnly=true)]
		public static bool? JsonbContains(string par3687, string par3688)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbDelete

		[Sql.Function(Name="pg_catalog.jsonb_delete", ServerSideOnly=true)]
		public static string JsonbDelete(string from_json, object path_elems)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbDeletePath

		[Sql.Function(Name="pg_catalog.jsonb_delete_path", ServerSideOnly=true)]
		public static string JsonbDeletePath(string par3697, object par3698)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbEq

		[Sql.Function(Name="pg_catalog.jsonb_eq", ServerSideOnly=true)]
		public static bool? JsonbEq(string par3700, string par3701)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbExists

		[Sql.Function(Name="pg_catalog.jsonb_exists", ServerSideOnly=true)]
		public static bool? JsonbExists(string par3703, string par3704)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbExistsAll

		[Sql.Function(Name="pg_catalog.jsonb_exists_all", ServerSideOnly=true)]
		public static bool? JsonbExistsAll(string par3706, object par3707)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbExistsAny

		[Sql.Function(Name="pg_catalog.jsonb_exists_any", ServerSideOnly=true)]
		public static bool? JsonbExistsAny(string par3709, object par3710)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbExtractPath

		[Sql.Function(Name="pg_catalog.jsonb_extract_path", ServerSideOnly=true)]
		public static string JsonbExtractPath(string from_json, object path_elems)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbExtractPathText

		[Sql.Function(Name="pg_catalog.jsonb_extract_path_text", ServerSideOnly=true)]
		public static string JsonbExtractPathText(string from_json, object path_elems)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbGe

		[Sql.Function(Name="pg_catalog.jsonb_ge", ServerSideOnly=true)]
		public static bool? JsonbGe(string par3714, string par3715)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbGt

		[Sql.Function(Name="pg_catalog.jsonb_gt", ServerSideOnly=true)]
		public static bool? JsonbGt(string par3717, string par3718)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbHash

		[Sql.Function(Name="pg_catalog.jsonb_hash", ServerSideOnly=true)]
		public static int? JsonbHash(string par3720)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbHashExtended

		[Sql.Function(Name="pg_catalog.jsonb_hash_extended", ServerSideOnly=true)]
		public static long? JsonbHashExtended(string par3722, long? par3723)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbIn

		[Sql.Function(Name="pg_catalog.jsonb_in", ServerSideOnly=true)]
		public static string JsonbIn(object par3725)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbInsert

		[Sql.Function(Name="pg_catalog.jsonb_insert", ServerSideOnly=true)]
		public static string JsonbInsert(string jsonb_in, object path, string replacement, bool? insert_after)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbLe

		[Sql.Function(Name="pg_catalog.jsonb_le", ServerSideOnly=true)]
		public static bool? JsonbLe(string par3728, string par3729)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbLt

		[Sql.Function(Name="pg_catalog.jsonb_lt", ServerSideOnly=true)]
		public static bool? JsonbLt(string par3731, string par3732)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbNe

		[Sql.Function(Name="pg_catalog.jsonb_ne", ServerSideOnly=true)]
		public static bool? JsonbNe(string par3734, string par3735)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbObject

		[Sql.Function(Name="pg_catalog.jsonb_object", ServerSideOnly=true)]
		public static string JsonbObject(object par3739, object par3740)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbObjectAgg

		[Sql.Function(Name="pg_catalog.jsonb_object_agg", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static string JsonbObjectAgg<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par3742, Expression<Func<TSource, object>> par3743)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbObjectAggFinalfn

		[Sql.Function(Name="pg_catalog.jsonb_object_agg_finalfn", ServerSideOnly=true)]
		public static string JsonbObjectAggFinalfn(object par3745)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbObjectAggTransfn

		[Sql.Function(Name="pg_catalog.jsonb_object_agg_transfn", ServerSideOnly=true)]
		public static object JsonbObjectAggTransfn(object par3747, object par3748, object par3749)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbObjectField

		[Sql.Function(Name="pg_catalog.jsonb_object_field", ServerSideOnly=true)]
		public static string JsonbObjectField(string from_json, string field_name)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbObjectFieldText

		[Sql.Function(Name="pg_catalog.jsonb_object_field_text", ServerSideOnly=true)]
		public static string JsonbObjectFieldText(string from_json, string field_name)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbOut

		[Sql.Function(Name="pg_catalog.jsonb_out", ServerSideOnly=true)]
		public static object JsonbOut(string par3754)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbPopulateRecord

		[Sql.Function(Name="pg_catalog.jsonb_populate_record", ServerSideOnly=true)]
		public static object JsonbPopulateRecord(object par3756, string par3757)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbPretty

		[Sql.Function(Name="pg_catalog.jsonb_pretty", ServerSideOnly=true)]
		public static string JsonbPretty(string par3761)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbRecv

		[Sql.Function(Name="pg_catalog.jsonb_recv", ServerSideOnly=true)]
		public static string JsonbRecv(object par3763)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbSend

		[Sql.Function(Name="pg_catalog.jsonb_send", ServerSideOnly=true)]
		public static byte[] JsonbSend(string par3765)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbSet

		[Sql.Function(Name="pg_catalog.jsonb_set", ServerSideOnly=true)]
		public static string JsonbSet(string jsonb_in, object path, string replacement, bool? create_if_missing)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbStripNulls

		[Sql.Function(Name="pg_catalog.jsonb_strip_nulls", ServerSideOnly=true)]
		public static string JsonbStripNulls(string par3768)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbToRecord

		[Sql.Function(Name="pg_catalog.jsonb_to_record", ServerSideOnly=true)]
		public static object JsonbToRecord(string par3769)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbToTsvector

		[Sql.Function(Name="pg_catalog.jsonb_to_tsvector", ServerSideOnly=true)]
		public static object JsonbToTsvector(object par3775, string par3776, string par3777)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JsonbTypeof

		[Sql.Function(Name="pg_catalog.jsonb_typeof", ServerSideOnly=true)]
		public static string JsonbTypeof(string par3779)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JustifyDays

		[Sql.Function(Name="pg_catalog.justify_days", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? JustifyDays(NpgsqlTimeSpan? par3781)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JustifyHours

		[Sql.Function(Name="pg_catalog.justify_hours", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? JustifyHours(NpgsqlTimeSpan? par3783)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region JustifyInterval

		[Sql.Function(Name="pg_catalog.justify_interval", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? JustifyInterval(NpgsqlTimeSpan? par3785)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Koi8rToIso

		[Sql.Function(Name="pg_catalog.koi8r_to_iso", ServerSideOnly=true)]
		public static object Koi8rToIso(int? par3786, int? par3787, object par3788, object par3789, int? par3790)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Koi8rToMic

		[Sql.Function(Name="pg_catalog.koi8r_to_mic", ServerSideOnly=true)]
		public static object Koi8rToMic(int? par3791, int? par3792, object par3793, object par3794, int? par3795)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Koi8rToUtf8

		[Sql.Function(Name="pg_catalog.koi8r_to_utf8", ServerSideOnly=true)]
		public static object Koi8rToUtf8(int? par3796, int? par3797, object par3798, object par3799, int? par3800)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Koi8rToWin1251

		[Sql.Function(Name="pg_catalog.koi8r_to_win1251", ServerSideOnly=true)]
		public static object Koi8rToWin1251(int? par3801, int? par3802, object par3803, object par3804, int? par3805)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Koi8rToWin866

		[Sql.Function(Name="pg_catalog.koi8r_to_win866", ServerSideOnly=true)]
		public static object Koi8rToWin866(int? par3806, int? par3807, object par3808, object par3809, int? par3810)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Koi8uToUtf8

		[Sql.Function(Name="pg_catalog.koi8u_to_utf8", ServerSideOnly=true)]
		public static object Koi8uToUtf8(int? par3811, int? par3812, object par3813, object par3814, int? par3815)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Lag

		[Sql.Function(Name="pg_catalog.lag", ServerSideOnly=true)]
		public static object Lag(object par3822, int? par3823, object par3824)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LanguageHandlerIn

		[Sql.Function(Name="pg_catalog.language_handler_in", ServerSideOnly=true)]
		public static object LanguageHandlerIn(object par3826)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LanguageHandlerOut

		[Sql.Function(Name="pg_catalog.language_handler_out", ServerSideOnly=true)]
		public static object LanguageHandlerOut(object par3828)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LastValue

		[Sql.Function(Name="pg_catalog.last_value", ServerSideOnly=true)]
		public static object LastValue(object par3830)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Lastval

		[Sql.Function(Name="pg_catalog.lastval", ServerSideOnly=true)]
		public static long? Lastval()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Latin1ToMic

		[Sql.Function(Name="pg_catalog.latin1_to_mic", ServerSideOnly=true)]
		public static object Latin1ToMic(int? par3832, int? par3833, object par3834, object par3835, int? par3836)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Latin2ToMic

		[Sql.Function(Name="pg_catalog.latin2_to_mic", ServerSideOnly=true)]
		public static object Latin2ToMic(int? par3837, int? par3838, object par3839, object par3840, int? par3841)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Latin2ToWin1250

		[Sql.Function(Name="pg_catalog.latin2_to_win1250", ServerSideOnly=true)]
		public static object Latin2ToWin1250(int? par3842, int? par3843, object par3844, object par3845, int? par3846)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Latin3ToMic

		[Sql.Function(Name="pg_catalog.latin3_to_mic", ServerSideOnly=true)]
		public static object Latin3ToMic(int? par3847, int? par3848, object par3849, object par3850, int? par3851)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Latin4ToMic

		[Sql.Function(Name="pg_catalog.latin4_to_mic", ServerSideOnly=true)]
		public static object Latin4ToMic(int? par3852, int? par3853, object par3854, object par3855, int? par3856)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Lead

		[Sql.Function(Name="pg_catalog.lead", ServerSideOnly=true)]
		public static object Lead(object par3863, int? par3864, object par3865)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Left

		[Sql.Function(Name="pg_catalog.left", ServerSideOnly=true)]
		public static string Left(string par3867, int? par3868)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Length

		[Sql.Function(Name="pg_catalog.length", ServerSideOnly=true)]
		public static int? Length(object par3885)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Like

		[Sql.Function(Name="pg_catalog.like", ServerSideOnly=true)]
		public static bool? Like(byte[] par3893, byte[] par3894)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LikeEscape

		[Sql.Function(Name="pg_catalog.like_escape", ServerSideOnly=true)]
		public static byte[] LikeEscape(byte[] par3899, byte[] par3900)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Likejoinsel

		[Sql.Function(Name="pg_catalog.likejoinsel", ServerSideOnly=true)]
		public static double? Likejoinsel(object par3902, int? par3903, object par3904, short? par3905, object par3906)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Likesel

		[Sql.Function(Name="pg_catalog.likesel", ServerSideOnly=true)]
		public static double? Likesel(object par3908, int? par3909, object par3910, int? par3911)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Line

		[Sql.Function(Name="pg_catalog.line", ServerSideOnly=true)]
		public static NpgsqlLine? Line(NpgsqlPoint? par3913, NpgsqlPoint? par3914)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineDistance

		[Sql.Function(Name="pg_catalog.line_distance", ServerSideOnly=true)]
		public static double? LineDistance(NpgsqlLine? par3916, NpgsqlLine? par3917)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineEq

		[Sql.Function(Name="pg_catalog.line_eq", ServerSideOnly=true)]
		public static bool? LineEq(NpgsqlLine? par3919, NpgsqlLine? par3920)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineHorizontal

		[Sql.Function(Name="pg_catalog.line_horizontal", ServerSideOnly=true)]
		public static bool? LineHorizontal(NpgsqlLine? par3922)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineIn

		[Sql.Function(Name="pg_catalog.line_in", ServerSideOnly=true)]
		public static NpgsqlLine? LineIn(object par3924)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineInterpt

		[Sql.Function(Name="pg_catalog.line_interpt", ServerSideOnly=true)]
		public static NpgsqlPoint? LineInterpt(NpgsqlLine? par3926, NpgsqlLine? par3927)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineIntersect

		[Sql.Function(Name="pg_catalog.line_intersect", ServerSideOnly=true)]
		public static bool? LineIntersect(NpgsqlLine? par3929, NpgsqlLine? par3930)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineOut

		[Sql.Function(Name="pg_catalog.line_out", ServerSideOnly=true)]
		public static object LineOut(NpgsqlLine? par3932)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineParallel

		[Sql.Function(Name="pg_catalog.line_parallel", ServerSideOnly=true)]
		public static bool? LineParallel(NpgsqlLine? par3934, NpgsqlLine? par3935)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LinePerp

		[Sql.Function(Name="pg_catalog.line_perp", ServerSideOnly=true)]
		public static bool? LinePerp(NpgsqlLine? par3937, NpgsqlLine? par3938)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineRecv

		[Sql.Function(Name="pg_catalog.line_recv", ServerSideOnly=true)]
		public static NpgsqlLine? LineRecv(object par3940)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineSend

		[Sql.Function(Name="pg_catalog.line_send", ServerSideOnly=true)]
		public static byte[] LineSend(NpgsqlLine? par3942)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LineVertical

		[Sql.Function(Name="pg_catalog.line_vertical", ServerSideOnly=true)]
		public static bool? LineVertical(NpgsqlLine? par3944)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ln

		[Sql.Function(Name="pg_catalog.ln", ServerSideOnly=true)]
		public static decimal? Ln(decimal? par3948)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoClose

		[Sql.Function(Name="pg_catalog.lo_close", ServerSideOnly=true)]
		public static int? LoClose(int? par3950)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoCreat

		[Sql.Function(Name="pg_catalog.lo_creat", ServerSideOnly=true)]
		public static int? LoCreat(int? par3952)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoCreate

		[Sql.Function(Name="pg_catalog.lo_create", ServerSideOnly=true)]
		public static int? LoCreate(int? par3954)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoExport

		[Sql.Function(Name="pg_catalog.lo_export", ServerSideOnly=true)]
		public static int? LoExport(int? par3956, string par3957)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoFromBytea

		[Sql.Function(Name="pg_catalog.lo_from_bytea", ServerSideOnly=true)]
		public static int? LoFromBytea(int? par3959, byte[] par3960)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoGet

		[Sql.Function(Name="pg_catalog.lo_get", ServerSideOnly=true)]
		public static byte[] LoGet(int? par3964, long? par3965, int? par3966)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoImport

		[Sql.Function(Name="pg_catalog.lo_import", ServerSideOnly=true)]
		public static int? LoImport(string par3970, int? par3971)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoLseek

		[Sql.Function(Name="pg_catalog.lo_lseek", ServerSideOnly=true)]
		public static int? LoLseek(int? par3973, int? par3974, int? par3975)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoLseek64

		[Sql.Function(Name="pg_catalog.lo_lseek64", ServerSideOnly=true)]
		public static long? LoLseek64(int? par3977, long? par3978, int? par3979)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoOpen

		[Sql.Function(Name="pg_catalog.lo_open", ServerSideOnly=true)]
		public static int? LoOpen(int? par3981, int? par3982)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoPut

		[Sql.Function(Name="pg_catalog.lo_put", ServerSideOnly=true)]
		public static object LoPut(int? par3983, long? par3984, byte[] par3985)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoTell

		[Sql.Function(Name="pg_catalog.lo_tell", ServerSideOnly=true)]
		public static int? LoTell(int? par3987)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoTell64

		[Sql.Function(Name="pg_catalog.lo_tell64", ServerSideOnly=true)]
		public static long? LoTell64(int? par3989)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoTruncate

		[Sql.Function(Name="pg_catalog.lo_truncate", ServerSideOnly=true)]
		public static int? LoTruncate(int? par3991, int? par3992)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoTruncate64

		[Sql.Function(Name="pg_catalog.lo_truncate64", ServerSideOnly=true)]
		public static int? LoTruncate64(int? par3994, long? par3995)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LoUnlink

		[Sql.Function(Name="pg_catalog.lo_unlink", ServerSideOnly=true)]
		public static int? LoUnlink(int? par3997)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Log

		[Sql.Function(Name="pg_catalog.log", ServerSideOnly=true)]
		public static decimal? Log(decimal? par4004)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Loread

		[Sql.Function(Name="pg_catalog.loread", ServerSideOnly=true)]
		public static byte[] Loread(int? par4006, int? par4007)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Lower

		[Sql.Function(Name="pg_catalog.lower", ServerSideOnly=true)]
		public static string Lower(string par4011)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LowerInc

		[Sql.Function(Name="pg_catalog.lower_inc", ServerSideOnly=true)]
		public static bool? LowerInc(object par4013)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LowerInf

		[Sql.Function(Name="pg_catalog.lower_inf", ServerSideOnly=true)]
		public static bool? LowerInf(object par4015)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Lowrite

		[Sql.Function(Name="pg_catalog.lowrite", ServerSideOnly=true)]
		public static int? Lowrite(int? par4017, byte[] par4018)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Lpad

		[Sql.Function(Name="pg_catalog.lpad", ServerSideOnly=true)]
		public static string Lpad(string par4024, int? par4025)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Lseg

		[Sql.Function(Name="pg_catalog.lseg", ServerSideOnly=true)]
		public static NpgsqlLSeg? Lseg(NpgsqlPoint? par4029, NpgsqlPoint? par4030)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegCenter

		[Sql.Function(Name="pg_catalog.lseg_center", ServerSideOnly=true)]
		public static NpgsqlPoint? LsegCenter(NpgsqlLSeg? par4032)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegDistance

		[Sql.Function(Name="pg_catalog.lseg_distance", ServerSideOnly=true)]
		public static double? LsegDistance(NpgsqlLSeg? par4034, NpgsqlLSeg? par4035)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegEq

		[Sql.Function(Name="pg_catalog.lseg_eq", ServerSideOnly=true)]
		public static bool? LsegEq(NpgsqlLSeg? par4037, NpgsqlLSeg? par4038)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegGe

		[Sql.Function(Name="pg_catalog.lseg_ge", ServerSideOnly=true)]
		public static bool? LsegGe(NpgsqlLSeg? par4040, NpgsqlLSeg? par4041)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegGt

		[Sql.Function(Name="pg_catalog.lseg_gt", ServerSideOnly=true)]
		public static bool? LsegGt(NpgsqlLSeg? par4043, NpgsqlLSeg? par4044)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegHorizontal

		[Sql.Function(Name="pg_catalog.lseg_horizontal", ServerSideOnly=true)]
		public static bool? LsegHorizontal(NpgsqlLSeg? par4046)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegIn

		[Sql.Function(Name="pg_catalog.lseg_in", ServerSideOnly=true)]
		public static NpgsqlLSeg? LsegIn(object par4048)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegInterpt

		[Sql.Function(Name="pg_catalog.lseg_interpt", ServerSideOnly=true)]
		public static NpgsqlPoint? LsegInterpt(NpgsqlLSeg? par4050, NpgsqlLSeg? par4051)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegIntersect

		[Sql.Function(Name="pg_catalog.lseg_intersect", ServerSideOnly=true)]
		public static bool? LsegIntersect(NpgsqlLSeg? par4053, NpgsqlLSeg? par4054)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegLe

		[Sql.Function(Name="pg_catalog.lseg_le", ServerSideOnly=true)]
		public static bool? LsegLe(NpgsqlLSeg? par4056, NpgsqlLSeg? par4057)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegLength

		[Sql.Function(Name="pg_catalog.lseg_length", ServerSideOnly=true)]
		public static double? LsegLength(NpgsqlLSeg? par4059)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegLt

		[Sql.Function(Name="pg_catalog.lseg_lt", ServerSideOnly=true)]
		public static bool? LsegLt(NpgsqlLSeg? par4061, NpgsqlLSeg? par4062)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegNe

		[Sql.Function(Name="pg_catalog.lseg_ne", ServerSideOnly=true)]
		public static bool? LsegNe(NpgsqlLSeg? par4064, NpgsqlLSeg? par4065)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegOut

		[Sql.Function(Name="pg_catalog.lseg_out", ServerSideOnly=true)]
		public static object LsegOut(NpgsqlLSeg? par4067)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegParallel

		[Sql.Function(Name="pg_catalog.lseg_parallel", ServerSideOnly=true)]
		public static bool? LsegParallel(NpgsqlLSeg? par4069, NpgsqlLSeg? par4070)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegPerp

		[Sql.Function(Name="pg_catalog.lseg_perp", ServerSideOnly=true)]
		public static bool? LsegPerp(NpgsqlLSeg? par4072, NpgsqlLSeg? par4073)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegRecv

		[Sql.Function(Name="pg_catalog.lseg_recv", ServerSideOnly=true)]
		public static NpgsqlLSeg? LsegRecv(object par4075)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegSend

		[Sql.Function(Name="pg_catalog.lseg_send", ServerSideOnly=true)]
		public static byte[] LsegSend(NpgsqlLSeg? par4077)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region LsegVertical

		[Sql.Function(Name="pg_catalog.lseg_vertical", ServerSideOnly=true)]
		public static bool? LsegVertical(NpgsqlLSeg? par4079)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ltrim

		[Sql.Function(Name="pg_catalog.ltrim", ServerSideOnly=true)]
		public static string Ltrim(string par4084)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr

		[Sql.Function(Name="pg_catalog.macaddr", ServerSideOnly=true)]
		public static PhysicalAddress Macaddr(PhysicalAddress par4086)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrAnd

		[Sql.Function(Name="pg_catalog.macaddr_and", ServerSideOnly=true)]
		public static PhysicalAddress MacaddrAnd(PhysicalAddress par4088, PhysicalAddress par4089)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrCmp

		[Sql.Function(Name="pg_catalog.macaddr_cmp", ServerSideOnly=true)]
		public static int? MacaddrCmp(PhysicalAddress par4091, PhysicalAddress par4092)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrEq

		[Sql.Function(Name="pg_catalog.macaddr_eq", ServerSideOnly=true)]
		public static bool? MacaddrEq(PhysicalAddress par4094, PhysicalAddress par4095)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrGe

		[Sql.Function(Name="pg_catalog.macaddr_ge", ServerSideOnly=true)]
		public static bool? MacaddrGe(PhysicalAddress par4097, PhysicalAddress par4098)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrGt

		[Sql.Function(Name="pg_catalog.macaddr_gt", ServerSideOnly=true)]
		public static bool? MacaddrGt(PhysicalAddress par4100, PhysicalAddress par4101)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrIn

		[Sql.Function(Name="pg_catalog.macaddr_in", ServerSideOnly=true)]
		public static PhysicalAddress MacaddrIn(object par4103)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrLe

		[Sql.Function(Name="pg_catalog.macaddr_le", ServerSideOnly=true)]
		public static bool? MacaddrLe(PhysicalAddress par4105, PhysicalAddress par4106)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrLt

		[Sql.Function(Name="pg_catalog.macaddr_lt", ServerSideOnly=true)]
		public static bool? MacaddrLt(PhysicalAddress par4108, PhysicalAddress par4109)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrNe

		[Sql.Function(Name="pg_catalog.macaddr_ne", ServerSideOnly=true)]
		public static bool? MacaddrNe(PhysicalAddress par4111, PhysicalAddress par4112)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrNot

		[Sql.Function(Name="pg_catalog.macaddr_not", ServerSideOnly=true)]
		public static PhysicalAddress MacaddrNot(PhysicalAddress par4114)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrOr

		[Sql.Function(Name="pg_catalog.macaddr_or", ServerSideOnly=true)]
		public static PhysicalAddress MacaddrOr(PhysicalAddress par4116, PhysicalAddress par4117)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrOut

		[Sql.Function(Name="pg_catalog.macaddr_out", ServerSideOnly=true)]
		public static object MacaddrOut(PhysicalAddress par4119)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrRecv

		[Sql.Function(Name="pg_catalog.macaddr_recv", ServerSideOnly=true)]
		public static PhysicalAddress MacaddrRecv(object par4121)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrSend

		[Sql.Function(Name="pg_catalog.macaddr_send", ServerSideOnly=true)]
		public static byte[] MacaddrSend(PhysicalAddress par4123)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MacaddrSortsupport

		[Sql.Function(Name="pg_catalog.macaddr_sortsupport", ServerSideOnly=true)]
		public static object MacaddrSortsupport(object par4124)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8

		[Sql.Function(Name="pg_catalog.macaddr8", ServerSideOnly=true)]
		public static PhysicalAddress Macaddr8(PhysicalAddress par4126)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8And

		[Sql.Function(Name="pg_catalog.macaddr8_and", ServerSideOnly=true)]
		public static PhysicalAddress Macaddr8And(PhysicalAddress par4128, PhysicalAddress par4129)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Cmp

		[Sql.Function(Name="pg_catalog.macaddr8_cmp", ServerSideOnly=true)]
		public static int? Macaddr8Cmp(PhysicalAddress par4131, PhysicalAddress par4132)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Eq

		[Sql.Function(Name="pg_catalog.macaddr8_eq", ServerSideOnly=true)]
		public static bool? Macaddr8Eq(PhysicalAddress par4134, PhysicalAddress par4135)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Ge

		[Sql.Function(Name="pg_catalog.macaddr8_ge", ServerSideOnly=true)]
		public static bool? Macaddr8Ge(PhysicalAddress par4137, PhysicalAddress par4138)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Gt

		[Sql.Function(Name="pg_catalog.macaddr8_gt", ServerSideOnly=true)]
		public static bool? Macaddr8Gt(PhysicalAddress par4140, PhysicalAddress par4141)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8In

		[Sql.Function(Name="pg_catalog.macaddr8_in", ServerSideOnly=true)]
		public static PhysicalAddress Macaddr8In(object par4143)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Le

		[Sql.Function(Name="pg_catalog.macaddr8_le", ServerSideOnly=true)]
		public static bool? Macaddr8Le(PhysicalAddress par4145, PhysicalAddress par4146)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Lt

		[Sql.Function(Name="pg_catalog.macaddr8_lt", ServerSideOnly=true)]
		public static bool? Macaddr8Lt(PhysicalAddress par4148, PhysicalAddress par4149)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Ne

		[Sql.Function(Name="pg_catalog.macaddr8_ne", ServerSideOnly=true)]
		public static bool? Macaddr8Ne(PhysicalAddress par4151, PhysicalAddress par4152)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Not

		[Sql.Function(Name="pg_catalog.macaddr8_not", ServerSideOnly=true)]
		public static PhysicalAddress Macaddr8Not(PhysicalAddress par4154)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Or

		[Sql.Function(Name="pg_catalog.macaddr8_or", ServerSideOnly=true)]
		public static PhysicalAddress Macaddr8Or(PhysicalAddress par4156, PhysicalAddress par4157)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Out

		[Sql.Function(Name="pg_catalog.macaddr8_out", ServerSideOnly=true)]
		public static object Macaddr8Out(PhysicalAddress par4159)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Recv

		[Sql.Function(Name="pg_catalog.macaddr8_recv", ServerSideOnly=true)]
		public static PhysicalAddress Macaddr8Recv(object par4161)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Send

		[Sql.Function(Name="pg_catalog.macaddr8_send", ServerSideOnly=true)]
		public static byte[] Macaddr8Send(PhysicalAddress par4163)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Macaddr8Set7bit

		[Sql.Function(Name="pg_catalog.macaddr8_set7bit", ServerSideOnly=true)]
		public static PhysicalAddress Macaddr8Set7bit(PhysicalAddress par4165)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MakeDate

		[Sql.Function(Name="pg_catalog.make_date", ServerSideOnly=true)]
		public static NpgsqlDate? MakeDate(int? year, int? month, int? day)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MakeInterval

		[Sql.Function(Name="pg_catalog.make_interval", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? MakeInterval(int? years, int? months, int? weeks, int? days, int? hours, int? mins, double? secs)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MakeTime

		[Sql.Function(Name="pg_catalog.make_time", ServerSideOnly=true)]
		public static TimeSpan? MakeTime(int? hour, int? min, double? sec)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MakeTimestamp

		[Sql.Function(Name="pg_catalog.make_timestamp", ServerSideOnly=true)]
		public static DateTime? MakeTimestamp(int? year, int? month, int? mday, int? hour, int? min, double? sec)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MakeTimestamptz

		[Sql.Function(Name="pg_catalog.make_timestamptz", ServerSideOnly=true)]
		public static DateTimeOffset? MakeTimestamptz(int? year, int? month, int? mday, int? hour, int? min, double? sec, string timezone)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Makeaclitem

		[Sql.Function(Name="pg_catalog.makeaclitem", ServerSideOnly=true)]
		public static object Makeaclitem(int? par4173, int? par4174, string par4175, bool? par4176)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Masklen

		[Sql.Function(Name="pg_catalog.masklen", ServerSideOnly=true)]
		public static int? Masklen(NpgsqlInet? par4178)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Max

		[Sql.Function(Name="pg_catalog.max", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static NpgsqlInet? Max<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, NpgsqlInet?>> par4220)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Md5

		[Sql.Function(Name="pg_catalog.md5", ServerSideOnly=true)]
		public static string Md5(byte[] par4224)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToAscii

		[Sql.Function(Name="pg_catalog.mic_to_ascii", ServerSideOnly=true)]
		public static object MicToAscii(int? par4225, int? par4226, object par4227, object par4228, int? par4229)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToBig5

		[Sql.Function(Name="pg_catalog.mic_to_big5", ServerSideOnly=true)]
		public static object MicToBig5(int? par4230, int? par4231, object par4232, object par4233, int? par4234)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToEucCn

		[Sql.Function(Name="pg_catalog.mic_to_euc_cn", ServerSideOnly=true)]
		public static object MicToEucCn(int? par4235, int? par4236, object par4237, object par4238, int? par4239)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToEucJp

		[Sql.Function(Name="pg_catalog.mic_to_euc_jp", ServerSideOnly=true)]
		public static object MicToEucJp(int? par4240, int? par4241, object par4242, object par4243, int? par4244)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToEucKr

		[Sql.Function(Name="pg_catalog.mic_to_euc_kr", ServerSideOnly=true)]
		public static object MicToEucKr(int? par4245, int? par4246, object par4247, object par4248, int? par4249)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToEucTw

		[Sql.Function(Name="pg_catalog.mic_to_euc_tw", ServerSideOnly=true)]
		public static object MicToEucTw(int? par4250, int? par4251, object par4252, object par4253, int? par4254)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToIso

		[Sql.Function(Name="pg_catalog.mic_to_iso", ServerSideOnly=true)]
		public static object MicToIso(int? par4255, int? par4256, object par4257, object par4258, int? par4259)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToKoi8r

		[Sql.Function(Name="pg_catalog.mic_to_koi8r", ServerSideOnly=true)]
		public static object MicToKoi8r(int? par4260, int? par4261, object par4262, object par4263, int? par4264)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToLatin1

		[Sql.Function(Name="pg_catalog.mic_to_latin1", ServerSideOnly=true)]
		public static object MicToLatin1(int? par4265, int? par4266, object par4267, object par4268, int? par4269)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToLatin2

		[Sql.Function(Name="pg_catalog.mic_to_latin2", ServerSideOnly=true)]
		public static object MicToLatin2(int? par4270, int? par4271, object par4272, object par4273, int? par4274)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToLatin3

		[Sql.Function(Name="pg_catalog.mic_to_latin3", ServerSideOnly=true)]
		public static object MicToLatin3(int? par4275, int? par4276, object par4277, object par4278, int? par4279)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToLatin4

		[Sql.Function(Name="pg_catalog.mic_to_latin4", ServerSideOnly=true)]
		public static object MicToLatin4(int? par4280, int? par4281, object par4282, object par4283, int? par4284)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToSjis

		[Sql.Function(Name="pg_catalog.mic_to_sjis", ServerSideOnly=true)]
		public static object MicToSjis(int? par4285, int? par4286, object par4287, object par4288, int? par4289)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToWin1250

		[Sql.Function(Name="pg_catalog.mic_to_win1250", ServerSideOnly=true)]
		public static object MicToWin1250(int? par4290, int? par4291, object par4292, object par4293, int? par4294)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToWin1251

		[Sql.Function(Name="pg_catalog.mic_to_win1251", ServerSideOnly=true)]
		public static object MicToWin1251(int? par4295, int? par4296, object par4297, object par4298, int? par4299)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MicToWin866

		[Sql.Function(Name="pg_catalog.mic_to_win866", ServerSideOnly=true)]
		public static object MicToWin866(int? par4300, int? par4301, object par4302, object par4303, int? par4304)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Min

		[Sql.Function(Name="pg_catalog.min", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static NpgsqlInet? Min<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, NpgsqlInet?>> par4346)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Mktinterval

		[Sql.Function(Name="pg_catalog.mktinterval", ServerSideOnly=true)]
		public static object Mktinterval(object par4348, object par4349)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Mod

		[Sql.Function(Name="pg_catalog.mod", ServerSideOnly=true)]
		public static long? Mod(long? par4360, long? par4361)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Mode

		[Sql.Function(Name="pg_catalog.mode", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static object Mode<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par4363)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ModeFinal

		[Sql.Function(Name="pg_catalog.mode_final", ServerSideOnly=true)]
		public static object ModeFinal(object par4365, object par4366)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Money

		[Sql.Function(Name="pg_catalog.money", ServerSideOnly=true)]
		public static decimal? Money(decimal? par4372)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MulDInterval

		[Sql.Function(Name="pg_catalog.mul_d_interval", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? MulDInterval(double? par4374, NpgsqlTimeSpan? par4375)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region MxidAge

		[Sql.Function(Name="pg_catalog.mxid_age", ServerSideOnly=true)]
		public static int? MxidAge(int? par4377)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Name

		[Sql.Function(Name="pg_catalog.name", ServerSideOnly=true)]
		public static string Name(string par4383)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nameeq

		[Sql.Function(Name="pg_catalog.nameeq", ServerSideOnly=true)]
		public static bool? Nameeq(string par4385, string par4386)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namege

		[Sql.Function(Name="pg_catalog.namege", ServerSideOnly=true)]
		public static bool? Namege(string par4388, string par4389)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namegt

		[Sql.Function(Name="pg_catalog.namegt", ServerSideOnly=true)]
		public static bool? Namegt(string par4391, string par4392)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nameiclike

		[Sql.Function(Name="pg_catalog.nameiclike", ServerSideOnly=true)]
		public static bool? Nameiclike(string par4394, string par4395)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nameicnlike

		[Sql.Function(Name="pg_catalog.nameicnlike", ServerSideOnly=true)]
		public static bool? Nameicnlike(string par4397, string par4398)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nameicregexeq

		[Sql.Function(Name="pg_catalog.nameicregexeq", ServerSideOnly=true)]
		public static bool? Nameicregexeq(string par4400, string par4401)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nameicregexne

		[Sql.Function(Name="pg_catalog.nameicregexne", ServerSideOnly=true)]
		public static bool? Nameicregexne(string par4403, string par4404)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namein

		[Sql.Function(Name="pg_catalog.namein", ServerSideOnly=true)]
		public static string Namein(object par4406)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namele

		[Sql.Function(Name="pg_catalog.namele", ServerSideOnly=true)]
		public static bool? Namele(string par4408, string par4409)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namelike

		[Sql.Function(Name="pg_catalog.namelike", ServerSideOnly=true)]
		public static bool? Namelike(string par4411, string par4412)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namelt

		[Sql.Function(Name="pg_catalog.namelt", ServerSideOnly=true)]
		public static bool? Namelt(string par4414, string par4415)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namene

		[Sql.Function(Name="pg_catalog.namene", ServerSideOnly=true)]
		public static bool? Namene(string par4417, string par4418)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namenlike

		[Sql.Function(Name="pg_catalog.namenlike", ServerSideOnly=true)]
		public static bool? Namenlike(string par4420, string par4421)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nameout

		[Sql.Function(Name="pg_catalog.nameout", ServerSideOnly=true)]
		public static object Nameout(string par4423)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namerecv

		[Sql.Function(Name="pg_catalog.namerecv", ServerSideOnly=true)]
		public static string Namerecv(object par4425)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nameregexeq

		[Sql.Function(Name="pg_catalog.nameregexeq", ServerSideOnly=true)]
		public static bool? Nameregexeq(string par4427, string par4428)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nameregexne

		[Sql.Function(Name="pg_catalog.nameregexne", ServerSideOnly=true)]
		public static bool? Nameregexne(string par4430, string par4431)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Namesend

		[Sql.Function(Name="pg_catalog.namesend", ServerSideOnly=true)]
		public static byte[] Namesend(string par4433)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Neqjoinsel

		[Sql.Function(Name="pg_catalog.neqjoinsel", ServerSideOnly=true)]
		public static double? Neqjoinsel(object par4435, int? par4436, object par4437, short? par4438, object par4439)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Neqsel

		[Sql.Function(Name="pg_catalog.neqsel", ServerSideOnly=true)]
		public static double? Neqsel(object par4441, int? par4442, object par4443, int? par4444)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Netmask

		[Sql.Function(Name="pg_catalog.netmask", ServerSideOnly=true)]
		public static NpgsqlInet? Netmask(NpgsqlInet? par4446)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Network

		[Sql.Function(Name="pg_catalog.network", ServerSideOnly=true)]
		public static NpgsqlInet? Network(NpgsqlInet? par4448)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkCmp

		[Sql.Function(Name="pg_catalog.network_cmp", ServerSideOnly=true)]
		public static int? NetworkCmp(NpgsqlInet? par4450, NpgsqlInet? par4451)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkEq

		[Sql.Function(Name="pg_catalog.network_eq", ServerSideOnly=true)]
		public static bool? NetworkEq(NpgsqlInet? par4453, NpgsqlInet? par4454)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkGe

		[Sql.Function(Name="pg_catalog.network_ge", ServerSideOnly=true)]
		public static bool? NetworkGe(NpgsqlInet? par4456, NpgsqlInet? par4457)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkGt

		[Sql.Function(Name="pg_catalog.network_gt", ServerSideOnly=true)]
		public static bool? NetworkGt(NpgsqlInet? par4459, NpgsqlInet? par4460)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkLarger

		[Sql.Function(Name="pg_catalog.network_larger", ServerSideOnly=true)]
		public static NpgsqlInet? NetworkLarger(NpgsqlInet? par4462, NpgsqlInet? par4463)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkLe

		[Sql.Function(Name="pg_catalog.network_le", ServerSideOnly=true)]
		public static bool? NetworkLe(NpgsqlInet? par4465, NpgsqlInet? par4466)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkLt

		[Sql.Function(Name="pg_catalog.network_lt", ServerSideOnly=true)]
		public static bool? NetworkLt(NpgsqlInet? par4468, NpgsqlInet? par4469)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkNe

		[Sql.Function(Name="pg_catalog.network_ne", ServerSideOnly=true)]
		public static bool? NetworkNe(NpgsqlInet? par4471, NpgsqlInet? par4472)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkOverlap

		[Sql.Function(Name="pg_catalog.network_overlap", ServerSideOnly=true)]
		public static bool? NetworkOverlap(NpgsqlInet? par4474, NpgsqlInet? par4475)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkSmaller

		[Sql.Function(Name="pg_catalog.network_smaller", ServerSideOnly=true)]
		public static NpgsqlInet? NetworkSmaller(NpgsqlInet? par4477, NpgsqlInet? par4478)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkSub

		[Sql.Function(Name="pg_catalog.network_sub", ServerSideOnly=true)]
		public static bool? NetworkSub(NpgsqlInet? par4480, NpgsqlInet? par4481)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkSubeq

		[Sql.Function(Name="pg_catalog.network_subeq", ServerSideOnly=true)]
		public static bool? NetworkSubeq(NpgsqlInet? par4483, NpgsqlInet? par4484)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkSup

		[Sql.Function(Name="pg_catalog.network_sup", ServerSideOnly=true)]
		public static bool? NetworkSup(NpgsqlInet? par4486, NpgsqlInet? par4487)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NetworkSupeq

		[Sql.Function(Name="pg_catalog.network_supeq", ServerSideOnly=true)]
		public static bool? NetworkSupeq(NpgsqlInet? par4489, NpgsqlInet? par4490)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Networkjoinsel

		[Sql.Function(Name="pg_catalog.networkjoinsel", ServerSideOnly=true)]
		public static double? Networkjoinsel(object par4492, int? par4493, object par4494, short? par4495, object par4496)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Networksel

		[Sql.Function(Name="pg_catalog.networksel", ServerSideOnly=true)]
		public static double? Networksel(object par4498, int? par4499, object par4500, int? par4501)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nextval

		[Sql.Function(Name="pg_catalog.nextval", ServerSideOnly=true)]
		public static long? Nextval(object par4503)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nlikejoinsel

		[Sql.Function(Name="pg_catalog.nlikejoinsel", ServerSideOnly=true)]
		public static double? Nlikejoinsel(object par4505, int? par4506, object par4507, short? par4508, object par4509)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Nlikesel

		[Sql.Function(Name="pg_catalog.nlikesel", ServerSideOnly=true)]
		public static double? Nlikesel(object par4511, int? par4512, object par4513, int? par4514)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Notlike

		[Sql.Function(Name="pg_catalog.notlike", ServerSideOnly=true)]
		public static bool? Notlike(byte[] par4522, byte[] par4523)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Now

		[Sql.Function(Name="pg_catalog.now", ServerSideOnly=true)]
		public static DateTimeOffset? Now()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Npoints

		[Sql.Function(Name="pg_catalog.npoints", ServerSideOnly=true)]
		public static int? Npoints(NpgsqlPolygon? par4528)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NthValue

		[Sql.Function(Name="pg_catalog.nth_value", ServerSideOnly=true)]
		public static object NthValue(object par4530, int? par4531)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Ntile

		[Sql.Function(Name="pg_catalog.ntile", ServerSideOnly=true)]
		public static int? Ntile(int? par4533)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumNonnulls

		[Sql.Function(Name="pg_catalog.num_nonnulls", ServerSideOnly=true)]
		public static int? NumNonnulls(object par4535)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumNulls

		[Sql.Function(Name="pg_catalog.num_nulls", ServerSideOnly=true)]
		public static int? NumNulls(object par4537)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Numeric

		[Sql.Function(Name="pg_catalog.numeric", ServerSideOnly=true)]
		public static decimal? Numeric(decimal? par4554)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericAbs

		[Sql.Function(Name="pg_catalog.numeric_abs", ServerSideOnly=true)]
		public static decimal? NumericAbs(decimal? par4556)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericAccum

		[Sql.Function(Name="pg_catalog.numeric_accum", ServerSideOnly=true)]
		public static object NumericAccum(object par4558, decimal? par4559)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericAccumInv

		[Sql.Function(Name="pg_catalog.numeric_accum_inv", ServerSideOnly=true)]
		public static object NumericAccumInv(object par4561, decimal? par4562)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericAdd

		[Sql.Function(Name="pg_catalog.numeric_add", ServerSideOnly=true)]
		public static decimal? NumericAdd(decimal? par4564, decimal? par4565)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericAvg

		[Sql.Function(Name="pg_catalog.numeric_avg", ServerSideOnly=true)]
		public static decimal? NumericAvg(object par4567)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericAvgAccum

		[Sql.Function(Name="pg_catalog.numeric_avg_accum", ServerSideOnly=true)]
		public static object NumericAvgAccum(object par4569, decimal? par4570)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericAvgCombine

		[Sql.Function(Name="pg_catalog.numeric_avg_combine", ServerSideOnly=true)]
		public static object NumericAvgCombine(object par4572, object par4573)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericAvgDeserialize

		[Sql.Function(Name="pg_catalog.numeric_avg_deserialize", ServerSideOnly=true)]
		public static object NumericAvgDeserialize(byte[] par4575, object par4576)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericAvgSerialize

		[Sql.Function(Name="pg_catalog.numeric_avg_serialize", ServerSideOnly=true)]
		public static byte[] NumericAvgSerialize(object par4578)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericCmp

		[Sql.Function(Name="pg_catalog.numeric_cmp", ServerSideOnly=true)]
		public static int? NumericCmp(decimal? par4580, decimal? par4581)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericCombine

		[Sql.Function(Name="pg_catalog.numeric_combine", ServerSideOnly=true)]
		public static object NumericCombine(object par4583, object par4584)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericDeserialize

		[Sql.Function(Name="pg_catalog.numeric_deserialize", ServerSideOnly=true)]
		public static object NumericDeserialize(byte[] par4586, object par4587)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericDiv

		[Sql.Function(Name="pg_catalog.numeric_div", ServerSideOnly=true)]
		public static decimal? NumericDiv(decimal? par4589, decimal? par4590)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericDivTrunc

		[Sql.Function(Name="pg_catalog.numeric_div_trunc", ServerSideOnly=true)]
		public static decimal? NumericDivTrunc(decimal? par4592, decimal? par4593)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericEq

		[Sql.Function(Name="pg_catalog.numeric_eq", ServerSideOnly=true)]
		public static bool? NumericEq(decimal? par4595, decimal? par4596)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericExp

		[Sql.Function(Name="pg_catalog.numeric_exp", ServerSideOnly=true)]
		public static decimal? NumericExp(decimal? par4598)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericFac

		[Sql.Function(Name="pg_catalog.numeric_fac", ServerSideOnly=true)]
		public static decimal? NumericFac(long? par4600)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericGe

		[Sql.Function(Name="pg_catalog.numeric_ge", ServerSideOnly=true)]
		public static bool? NumericGe(decimal? par4602, decimal? par4603)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericGt

		[Sql.Function(Name="pg_catalog.numeric_gt", ServerSideOnly=true)]
		public static bool? NumericGt(decimal? par4605, decimal? par4606)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericIn

		[Sql.Function(Name="pg_catalog.numeric_in", ServerSideOnly=true)]
		public static decimal? NumericIn(object par4608, int? par4609, int? par4610)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericInc

		[Sql.Function(Name="pg_catalog.numeric_inc", ServerSideOnly=true)]
		public static decimal? NumericInc(decimal? par4612)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericLarger

		[Sql.Function(Name="pg_catalog.numeric_larger", ServerSideOnly=true)]
		public static decimal? NumericLarger(decimal? par4614, decimal? par4615)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericLe

		[Sql.Function(Name="pg_catalog.numeric_le", ServerSideOnly=true)]
		public static bool? NumericLe(decimal? par4617, decimal? par4618)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericLn

		[Sql.Function(Name="pg_catalog.numeric_ln", ServerSideOnly=true)]
		public static decimal? NumericLn(decimal? par4620)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericLog

		[Sql.Function(Name="pg_catalog.numeric_log", ServerSideOnly=true)]
		public static decimal? NumericLog(decimal? par4622, decimal? par4623)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericLt

		[Sql.Function(Name="pg_catalog.numeric_lt", ServerSideOnly=true)]
		public static bool? NumericLt(decimal? par4625, decimal? par4626)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericMod

		[Sql.Function(Name="pg_catalog.numeric_mod", ServerSideOnly=true)]
		public static decimal? NumericMod(decimal? par4628, decimal? par4629)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericMul

		[Sql.Function(Name="pg_catalog.numeric_mul", ServerSideOnly=true)]
		public static decimal? NumericMul(decimal? par4631, decimal? par4632)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericNe

		[Sql.Function(Name="pg_catalog.numeric_ne", ServerSideOnly=true)]
		public static bool? NumericNe(decimal? par4634, decimal? par4635)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericOut

		[Sql.Function(Name="pg_catalog.numeric_out", ServerSideOnly=true)]
		public static object NumericOut(decimal? par4637)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPolyAvg

		[Sql.Function(Name="pg_catalog.numeric_poly_avg", ServerSideOnly=true)]
		public static decimal? NumericPolyAvg(object par4639)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPolyCombine

		[Sql.Function(Name="pg_catalog.numeric_poly_combine", ServerSideOnly=true)]
		public static object NumericPolyCombine(object par4641, object par4642)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPolyDeserialize

		[Sql.Function(Name="pg_catalog.numeric_poly_deserialize", ServerSideOnly=true)]
		public static object NumericPolyDeserialize(byte[] par4644, object par4645)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPolySerialize

		[Sql.Function(Name="pg_catalog.numeric_poly_serialize", ServerSideOnly=true)]
		public static byte[] NumericPolySerialize(object par4647)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPolyStddevPop

		[Sql.Function(Name="pg_catalog.numeric_poly_stddev_pop", ServerSideOnly=true)]
		public static decimal? NumericPolyStddevPop(object par4649)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPolyStddevSamp

		[Sql.Function(Name="pg_catalog.numeric_poly_stddev_samp", ServerSideOnly=true)]
		public static decimal? NumericPolyStddevSamp(object par4651)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPolySum

		[Sql.Function(Name="pg_catalog.numeric_poly_sum", ServerSideOnly=true)]
		public static decimal? NumericPolySum(object par4653)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPolyVarPop

		[Sql.Function(Name="pg_catalog.numeric_poly_var_pop", ServerSideOnly=true)]
		public static decimal? NumericPolyVarPop(object par4655)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPolyVarSamp

		[Sql.Function(Name="pg_catalog.numeric_poly_var_samp", ServerSideOnly=true)]
		public static decimal? NumericPolyVarSamp(object par4657)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericPower

		[Sql.Function(Name="pg_catalog.numeric_power", ServerSideOnly=true)]
		public static decimal? NumericPower(decimal? par4659, decimal? par4660)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericRecv

		[Sql.Function(Name="pg_catalog.numeric_recv", ServerSideOnly=true)]
		public static decimal? NumericRecv(object par4662, int? par4663, int? par4664)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericSend

		[Sql.Function(Name="pg_catalog.numeric_send", ServerSideOnly=true)]
		public static byte[] NumericSend(decimal? par4666)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericSerialize

		[Sql.Function(Name="pg_catalog.numeric_serialize", ServerSideOnly=true)]
		public static byte[] NumericSerialize(object par4668)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericSmaller

		[Sql.Function(Name="pg_catalog.numeric_smaller", ServerSideOnly=true)]
		public static decimal? NumericSmaller(decimal? par4670, decimal? par4671)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericSortsupport

		[Sql.Function(Name="pg_catalog.numeric_sortsupport", ServerSideOnly=true)]
		public static object NumericSortsupport(object par4672)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericSqrt

		[Sql.Function(Name="pg_catalog.numeric_sqrt", ServerSideOnly=true)]
		public static decimal? NumericSqrt(decimal? par4674)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericStddevPop

		[Sql.Function(Name="pg_catalog.numeric_stddev_pop", ServerSideOnly=true)]
		public static decimal? NumericStddevPop(object par4676)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericStddevSamp

		[Sql.Function(Name="pg_catalog.numeric_stddev_samp", ServerSideOnly=true)]
		public static decimal? NumericStddevSamp(object par4678)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericSub

		[Sql.Function(Name="pg_catalog.numeric_sub", ServerSideOnly=true)]
		public static decimal? NumericSub(decimal? par4680, decimal? par4681)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericSum

		[Sql.Function(Name="pg_catalog.numeric_sum", ServerSideOnly=true)]
		public static decimal? NumericSum(object par4683)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericTransform

		[Sql.Function(Name="pg_catalog.numeric_transform", ServerSideOnly=true)]
		public static object NumericTransform(object par4685)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericUminus

		[Sql.Function(Name="pg_catalog.numeric_uminus", ServerSideOnly=true)]
		public static decimal? NumericUminus(decimal? par4687)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericUplus

		[Sql.Function(Name="pg_catalog.numeric_uplus", ServerSideOnly=true)]
		public static decimal? NumericUplus(decimal? par4689)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericVarPop

		[Sql.Function(Name="pg_catalog.numeric_var_pop", ServerSideOnly=true)]
		public static decimal? NumericVarPop(object par4691)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumericVarSamp

		[Sql.Function(Name="pg_catalog.numeric_var_samp", ServerSideOnly=true)]
		public static decimal? NumericVarSamp(object par4693)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Numerictypmodin

		[Sql.Function(Name="pg_catalog.numerictypmodin", ServerSideOnly=true)]
		public static int? Numerictypmodin(object par4695)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Numerictypmodout

		[Sql.Function(Name="pg_catalog.numerictypmodout", ServerSideOnly=true)]
		public static object Numerictypmodout(int? par4697)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Numnode

		[Sql.Function(Name="pg_catalog.numnode", ServerSideOnly=true)]
		public static int? Numnode(object par4699)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Numrange

		[Sql.Function(Name="pg_catalog.numrange", ServerSideOnly=true)]
		public static object Numrange(decimal? par4704, decimal? par4705, string par4706)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region NumrangeSubdiff

		[Sql.Function(Name="pg_catalog.numrange_subdiff", ServerSideOnly=true)]
		public static double? NumrangeSubdiff(decimal? par4708, decimal? par4709)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ObjDescription

		[Sql.Function(Name="pg_catalog.obj_description", ServerSideOnly=true)]
		public static string ObjDescription(int? par4714)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OctetLength

		[Sql.Function(Name="pg_catalog.octet_length", ServerSideOnly=true)]
		public static int? OctetLength(byte[] par4722)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oid

		[Sql.Function(Name="pg_catalog.oid", ServerSideOnly=true)]
		public static int? Oid(long? par4724)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oideq

		[Sql.Function(Name="pg_catalog.oideq", ServerSideOnly=true)]
		public static bool? Oideq(int? par4726, int? par4727)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidge

		[Sql.Function(Name="pg_catalog.oidge", ServerSideOnly=true)]
		public static bool? Oidge(int? par4729, int? par4730)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidgt

		[Sql.Function(Name="pg_catalog.oidgt", ServerSideOnly=true)]
		public static bool? Oidgt(int? par4732, int? par4733)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidin

		[Sql.Function(Name="pg_catalog.oidin", ServerSideOnly=true)]
		public static int? Oidin(object par4735)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidlarger

		[Sql.Function(Name="pg_catalog.oidlarger", ServerSideOnly=true)]
		public static int? Oidlarger(int? par4737, int? par4738)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidle

		[Sql.Function(Name="pg_catalog.oidle", ServerSideOnly=true)]
		public static bool? Oidle(int? par4740, int? par4741)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidlt

		[Sql.Function(Name="pg_catalog.oidlt", ServerSideOnly=true)]
		public static bool? Oidlt(int? par4743, int? par4744)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidne

		[Sql.Function(Name="pg_catalog.oidne", ServerSideOnly=true)]
		public static bool? Oidne(int? par4746, int? par4747)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidout

		[Sql.Function(Name="pg_catalog.oidout", ServerSideOnly=true)]
		public static object Oidout(int? par4749)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidrecv

		[Sql.Function(Name="pg_catalog.oidrecv", ServerSideOnly=true)]
		public static int? Oidrecv(object par4751)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidsend

		[Sql.Function(Name="pg_catalog.oidsend", ServerSideOnly=true)]
		public static byte[] Oidsend(int? par4753)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidsmaller

		[Sql.Function(Name="pg_catalog.oidsmaller", ServerSideOnly=true)]
		public static int? Oidsmaller(int? par4755, int? par4756)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectoreq

		[Sql.Function(Name="pg_catalog.oidvectoreq", ServerSideOnly=true)]
		public static bool? Oidvectoreq(object par4758, object par4759)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectorge

		[Sql.Function(Name="pg_catalog.oidvectorge", ServerSideOnly=true)]
		public static bool? Oidvectorge(object par4761, object par4762)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectorgt

		[Sql.Function(Name="pg_catalog.oidvectorgt", ServerSideOnly=true)]
		public static bool? Oidvectorgt(object par4764, object par4765)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectorin

		[Sql.Function(Name="pg_catalog.oidvectorin", ServerSideOnly=true)]
		public static object Oidvectorin(object par4767)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectorle

		[Sql.Function(Name="pg_catalog.oidvectorle", ServerSideOnly=true)]
		public static bool? Oidvectorle(object par4769, object par4770)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectorlt

		[Sql.Function(Name="pg_catalog.oidvectorlt", ServerSideOnly=true)]
		public static bool? Oidvectorlt(object par4772, object par4773)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectorne

		[Sql.Function(Name="pg_catalog.oidvectorne", ServerSideOnly=true)]
		public static bool? Oidvectorne(object par4775, object par4776)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectorout

		[Sql.Function(Name="pg_catalog.oidvectorout", ServerSideOnly=true)]
		public static object Oidvectorout(object par4778)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectorrecv

		[Sql.Function(Name="pg_catalog.oidvectorrecv", ServerSideOnly=true)]
		public static object Oidvectorrecv(object par4780)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectorsend

		[Sql.Function(Name="pg_catalog.oidvectorsend", ServerSideOnly=true)]
		public static byte[] Oidvectorsend(object par4782)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Oidvectortypes

		[Sql.Function(Name="pg_catalog.oidvectortypes", ServerSideOnly=true)]
		public static string Oidvectortypes(object par4784)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OnPb

		[Sql.Function(Name="pg_catalog.on_pb", ServerSideOnly=true)]
		public static bool? OnPb(NpgsqlPoint? par4786, NpgsqlBox? par4787)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OnPl

		[Sql.Function(Name="pg_catalog.on_pl", ServerSideOnly=true)]
		public static bool? OnPl(NpgsqlPoint? par4789, NpgsqlLine? par4790)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OnPpath

		[Sql.Function(Name="pg_catalog.on_ppath", ServerSideOnly=true)]
		public static bool? OnPpath(NpgsqlPoint? par4792, NpgsqlPath? par4793)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OnPs

		[Sql.Function(Name="pg_catalog.on_ps", ServerSideOnly=true)]
		public static bool? OnPs(NpgsqlPoint? par4795, NpgsqlLSeg? par4796)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OnSb

		[Sql.Function(Name="pg_catalog.on_sb", ServerSideOnly=true)]
		public static bool? OnSb(NpgsqlLSeg? par4798, NpgsqlBox? par4799)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OnSl

		[Sql.Function(Name="pg_catalog.on_sl", ServerSideOnly=true)]
		public static bool? OnSl(NpgsqlLSeg? par4801, NpgsqlLine? par4802)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OpaqueIn

		[Sql.Function(Name="pg_catalog.opaque_in", ServerSideOnly=true)]
		public static object OpaqueIn(object par4804)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OpaqueOut

		[Sql.Function(Name="pg_catalog.opaque_out", ServerSideOnly=true)]
		public static object OpaqueOut(object par4806)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OrderedSetTransition

		[Sql.Function(Name="pg_catalog.ordered_set_transition", ServerSideOnly=true)]
		public static object OrderedSetTransition(object par4808, object par4809)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region OrderedSetTransitionMulti

		[Sql.Function(Name="pg_catalog.ordered_set_transition_multi", ServerSideOnly=true)]
		public static object OrderedSetTransitionMulti(object par4811, object par4812)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Overlaps

		[Sql.Function(Name="pg_catalog.overlaps", ServerSideOnly=true)]
		public static bool? Overlaps(DateTime? par4874, NpgsqlTimeSpan? par4875, DateTime? par4876, DateTime? par4877)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Overlay

		[Sql.Function(Name="pg_catalog.overlay", ServerSideOnly=true)]
		public static byte[] Overlay(byte[] par4902, byte[] par4903, int? par4904)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ParseIdent

		[Sql.Function(Name="pg_catalog.parse_ident", ServerSideOnly=true)]
		public static object ParseIdent(string str, bool? strict)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Path

		[Sql.Function(Name="pg_catalog.path", ServerSideOnly=true)]
		public static NpgsqlPath? Path(NpgsqlPolygon? par4907)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathAdd

		[Sql.Function(Name="pg_catalog.path_add", ServerSideOnly=true)]
		public static NpgsqlPath? PathAdd(NpgsqlPath? par4909, NpgsqlPath? par4910)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathAddPt

		[Sql.Function(Name="pg_catalog.path_add_pt", ServerSideOnly=true)]
		public static NpgsqlPath? PathAddPt(NpgsqlPath? par4912, NpgsqlPoint? par4913)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathCenter

		[Sql.Function(Name="pg_catalog.path_center", ServerSideOnly=true)]
		public static NpgsqlPoint? PathCenter(NpgsqlPath? par4915)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathContainPt

		[Sql.Function(Name="pg_catalog.path_contain_pt", ServerSideOnly=true)]
		public static bool? PathContainPt(NpgsqlPath? par4917, NpgsqlPoint? par4918)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathDistance

		[Sql.Function(Name="pg_catalog.path_distance", ServerSideOnly=true)]
		public static double? PathDistance(NpgsqlPath? par4920, NpgsqlPath? par4921)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathDivPt

		[Sql.Function(Name="pg_catalog.path_div_pt", ServerSideOnly=true)]
		public static NpgsqlPath? PathDivPt(NpgsqlPath? par4923, NpgsqlPoint? par4924)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathIn

		[Sql.Function(Name="pg_catalog.path_in", ServerSideOnly=true)]
		public static NpgsqlPath? PathIn(object par4926)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathInter

		[Sql.Function(Name="pg_catalog.path_inter", ServerSideOnly=true)]
		public static bool? PathInter(NpgsqlPath? par4928, NpgsqlPath? par4929)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathLength

		[Sql.Function(Name="pg_catalog.path_length", ServerSideOnly=true)]
		public static double? PathLength(NpgsqlPath? par4931)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathMulPt

		[Sql.Function(Name="pg_catalog.path_mul_pt", ServerSideOnly=true)]
		public static NpgsqlPath? PathMulPt(NpgsqlPath? par4933, NpgsqlPoint? par4934)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathNEq

		[Sql.Function(Name="pg_catalog.path_n_eq", ServerSideOnly=true)]
		public static bool? PathNEq(NpgsqlPath? par4936, NpgsqlPath? par4937)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathNGe

		[Sql.Function(Name="pg_catalog.path_n_ge", ServerSideOnly=true)]
		public static bool? PathNGe(NpgsqlPath? par4939, NpgsqlPath? par4940)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathNGt

		[Sql.Function(Name="pg_catalog.path_n_gt", ServerSideOnly=true)]
		public static bool? PathNGt(NpgsqlPath? par4942, NpgsqlPath? par4943)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathNLe

		[Sql.Function(Name="pg_catalog.path_n_le", ServerSideOnly=true)]
		public static bool? PathNLe(NpgsqlPath? par4945, NpgsqlPath? par4946)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathNLt

		[Sql.Function(Name="pg_catalog.path_n_lt", ServerSideOnly=true)]
		public static bool? PathNLt(NpgsqlPath? par4948, NpgsqlPath? par4949)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathNpoints

		[Sql.Function(Name="pg_catalog.path_npoints", ServerSideOnly=true)]
		public static int? PathNpoints(NpgsqlPath? par4951)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathOut

		[Sql.Function(Name="pg_catalog.path_out", ServerSideOnly=true)]
		public static object PathOut(NpgsqlPath? par4953)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathRecv

		[Sql.Function(Name="pg_catalog.path_recv", ServerSideOnly=true)]
		public static NpgsqlPath? PathRecv(object par4955)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathSend

		[Sql.Function(Name="pg_catalog.path_send", ServerSideOnly=true)]
		public static byte[] PathSend(NpgsqlPath? par4957)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PathSubPt

		[Sql.Function(Name="pg_catalog.path_sub_pt", ServerSideOnly=true)]
		public static NpgsqlPath? PathSubPt(NpgsqlPath? par4959, NpgsqlPoint? par4960)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Pclose

		[Sql.Function(Name="pg_catalog.pclose", ServerSideOnly=true)]
		public static NpgsqlPath? Pclose(NpgsqlPath? par4962)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentRank

		[Sql.Function(Name="pg_catalog.percent_rank", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static double? PercentRank<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par4965)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentRankFinal

		[Sql.Function(Name="pg_catalog.percent_rank_final", ServerSideOnly=true)]
		public static double? PercentRankFinal(object par4967, object par4968)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentileCont

		[Sql.Function(Name="pg_catalog.percentile_cont", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static object PercentileCont<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par4979, Expression<Func<TSource, NpgsqlTimeSpan?>> par4980)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentileContFloat8Final

		[Sql.Function(Name="pg_catalog.percentile_cont_float8_final", ServerSideOnly=true)]
		public static double? PercentileContFloat8Final(object par4982, double? par4983)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentileContFloat8MultiFinal

		[Sql.Function(Name="pg_catalog.percentile_cont_float8_multi_final", ServerSideOnly=true)]
		public static object PercentileContFloat8MultiFinal(object par4985, object par4986)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentileContIntervalFinal

		[Sql.Function(Name="pg_catalog.percentile_cont_interval_final", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? PercentileContIntervalFinal(object par4988, double? par4989)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentileContIntervalMultiFinal

		[Sql.Function(Name="pg_catalog.percentile_cont_interval_multi_final", ServerSideOnly=true)]
		public static object PercentileContIntervalMultiFinal(object par4991, object par4992)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentileDisc

		[Sql.Function(Name="pg_catalog.percentile_disc", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static object PercentileDisc<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par4997, Expression<Func<TSource, object>> par4998)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentileDiscFinal

		[Sql.Function(Name="pg_catalog.percentile_disc_final", ServerSideOnly=true)]
		public static object PercentileDiscFinal(object par5000, double? par5001, object par5002)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PercentileDiscMultiFinal

		[Sql.Function(Name="pg_catalog.percentile_disc_multi_final", ServerSideOnly=true)]
		public static object PercentileDiscMultiFinal(object par5004, object par5005, object par5006)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgAdvisoryLock

		[Sql.Function(Name="pg_catalog.pg_advisory_lock", ServerSideOnly=true)]
		public static object PgAdvisoryLock(int? par5008, int? par5009)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgAdvisoryLockShared

		[Sql.Function(Name="pg_catalog.pg_advisory_lock_shared", ServerSideOnly=true)]
		public static object PgAdvisoryLockShared(int? par5011, int? par5012)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgAdvisoryUnlock

		[Sql.Function(Name="pg_catalog.pg_advisory_unlock", ServerSideOnly=true)]
		public static bool? PgAdvisoryUnlock(int? par5016, int? par5017)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgAdvisoryUnlockAll

		[Sql.Function(Name="pg_catalog.pg_advisory_unlock_all", ServerSideOnly=true)]
		public static object PgAdvisoryUnlockAll()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgAdvisoryUnlockShared

		[Sql.Function(Name="pg_catalog.pg_advisory_unlock_shared", ServerSideOnly=true)]
		public static bool? PgAdvisoryUnlockShared(int? par5021, int? par5022)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgAdvisoryXactLock

		[Sql.Function(Name="pg_catalog.pg_advisory_xact_lock", ServerSideOnly=true)]
		public static object PgAdvisoryXactLock(int? par5024, int? par5025)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgAdvisoryXactLockShared

		[Sql.Function(Name="pg_catalog.pg_advisory_xact_lock_shared", ServerSideOnly=true)]
		public static object PgAdvisoryXactLockShared(int? par5027, int? par5028)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgBackendPid

		[Sql.Function(Name="pg_catalog.pg_backend_pid", ServerSideOnly=true)]
		public static int? PgBackendPid()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgBackupStartTime

		[Sql.Function(Name="pg_catalog.pg_backup_start_time", ServerSideOnly=true)]
		public static DateTimeOffset? PgBackupStartTime()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgBlockingPids

		[Sql.Function(Name="pg_catalog.pg_blocking_pids", ServerSideOnly=true)]
		public static object PgBlockingPids(int? par5032)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCancelBackend

		[Sql.Function(Name="pg_catalog.pg_cancel_backend", ServerSideOnly=true)]
		public static bool? PgCancelBackend(int? par5034)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCharToEncoding

		[Sql.Function(Name="pg_catalog.pg_char_to_encoding", ServerSideOnly=true)]
		public static int? PgCharToEncoding(string par5036)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgClientEncoding

		[Sql.Function(Name="pg_catalog.pg_client_encoding", ServerSideOnly=true)]
		public static string PgClientEncoding()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCollationActualVersion

		[Sql.Function(Name="pg_catalog.pg_collation_actual_version", ServerSideOnly=true)]
		public static string PgCollationActualVersion(int? par5039)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCollationFor

		[Sql.Function(Name="pg_catalog.pg_collation_for", ServerSideOnly=true)]
		public static string PgCollationFor(object par5041)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCollationIsVisible

		[Sql.Function(Name="pg_catalog.pg_collation_is_visible", ServerSideOnly=true)]
		public static bool? PgCollationIsVisible(int? par5043)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgColumnIsUpdatable

		[Sql.Function(Name="pg_catalog.pg_column_is_updatable", ServerSideOnly=true)]
		public static bool? PgColumnIsUpdatable(object par5045, short? par5046, bool? par5047)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgColumnSize

		[Sql.Function(Name="pg_catalog.pg_column_size", ServerSideOnly=true)]
		public static int? PgColumnSize(object par5049)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgConfLoadTime

		[Sql.Function(Name="pg_catalog.pg_conf_load_time", ServerSideOnly=true)]
		public static DateTimeOffset? PgConfLoadTime()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgControlCheckpoint

		[Sql.Function(Name="pg_catalog.pg_control_checkpoint", ServerSideOnly=true)]
		public static pg_control_checkpointResult PgControlCheckpoint()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgControlInit

		[Sql.Function(Name="pg_catalog.pg_control_init", ServerSideOnly=true)]
		public static pg_control_initResult PgControlInit()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgControlRecovery

		[Sql.Function(Name="pg_catalog.pg_control_recovery", ServerSideOnly=true)]
		public static pg_control_recoveryResult PgControlRecovery()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgControlSystem

		[Sql.Function(Name="pg_catalog.pg_control_system", ServerSideOnly=true)]
		public static pg_control_systemResult PgControlSystem()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgConversionIsVisible

		[Sql.Function(Name="pg_catalog.pg_conversion_is_visible", ServerSideOnly=true)]
		public static bool? PgConversionIsVisible(int? par5052)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCreateLogicalReplicationSlot

		[Sql.Function(Name="pg_catalog.pg_create_logical_replication_slot", ServerSideOnly=true)]
		public static pg_create_logical_replication_slotResult PgCreateLogicalReplicationSlot(string slot_name, string plugin, bool? temporary)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCreatePhysicalReplicationSlot

		[Sql.Function(Name="pg_catalog.pg_create_physical_replication_slot", ServerSideOnly=true)]
		public static pg_create_physical_replication_slotResult PgCreatePhysicalReplicationSlot(string slot_name, bool? immediately_reserve, bool? temporary)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCreateRestorePoint

		[Sql.Function(Name="pg_catalog.pg_create_restore_point", ServerSideOnly=true)]
		public static object PgCreateRestorePoint(string par5054)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCurrentLogfile

		[Sql.Function(Name="pg_catalog.pg_current_logfile", ServerSideOnly=true)]
		public static string PgCurrentLogfile(string par5057)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCurrentWalFlushLsn

		[Sql.Function(Name="pg_catalog.pg_current_wal_flush_lsn", ServerSideOnly=true)]
		public static object PgCurrentWalFlushLsn()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCurrentWalInsertLsn

		[Sql.Function(Name="pg_catalog.pg_current_wal_insert_lsn", ServerSideOnly=true)]
		public static object PgCurrentWalInsertLsn()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgCurrentWalLsn

		[Sql.Function(Name="pg_catalog.pg_current_wal_lsn", ServerSideOnly=true)]
		public static object PgCurrentWalLsn()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDatabaseSize

		[Sql.Function(Name="pg_catalog.pg_database_size", ServerSideOnly=true)]
		public static long? PgDatabaseSize(int? par5064)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDdlCommandIn

		[Sql.Function(Name="pg_catalog.pg_ddl_command_in", ServerSideOnly=true)]
		public static object PgDdlCommandIn(object par5066)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDdlCommandOut

		[Sql.Function(Name="pg_catalog.pg_ddl_command_out", ServerSideOnly=true)]
		public static object PgDdlCommandOut(object par5068)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDdlCommandRecv

		[Sql.Function(Name="pg_catalog.pg_ddl_command_recv", ServerSideOnly=true)]
		public static object PgDdlCommandRecv(object par5070)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDdlCommandSend

		[Sql.Function(Name="pg_catalog.pg_ddl_command_send", ServerSideOnly=true)]
		public static byte[] PgDdlCommandSend(object par5072)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDependenciesIn

		[Sql.Function(Name="pg_catalog.pg_dependencies_in", ServerSideOnly=true)]
		public static object PgDependenciesIn(object par5074)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDependenciesOut

		[Sql.Function(Name="pg_catalog.pg_dependencies_out", ServerSideOnly=true)]
		public static object PgDependenciesOut(object par5076)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDependenciesRecv

		[Sql.Function(Name="pg_catalog.pg_dependencies_recv", ServerSideOnly=true)]
		public static object PgDependenciesRecv(object par5078)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDependenciesSend

		[Sql.Function(Name="pg_catalog.pg_dependencies_send", ServerSideOnly=true)]
		public static byte[] PgDependenciesSend(object par5080)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDescribeObject

		[Sql.Function(Name="pg_catalog.pg_describe_object", ServerSideOnly=true)]
		public static string PgDescribeObject(int? par5082, int? par5083, int? par5084)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgDropReplicationSlot

		[Sql.Function(Name="pg_catalog.pg_drop_replication_slot", ServerSideOnly=true)]
		public static object PgDropReplicationSlot(string par5085)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgEncodingMaxLength

		[Sql.Function(Name="pg_catalog.pg_encoding_max_length", ServerSideOnly=true)]
		public static int? PgEncodingMaxLength(int? par5087)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgEncodingToChar

		[Sql.Function(Name="pg_catalog.pg_encoding_to_char", ServerSideOnly=true)]
		public static string PgEncodingToChar(int? par5089)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgEventTriggerTableRewriteOid

		[Sql.Function(Name="pg_catalog.pg_event_trigger_table_rewrite_oid", ServerSideOnly=true)]
		public static int? PgEventTriggerTableRewriteOid()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgEventTriggerTableRewriteReason

		[Sql.Function(Name="pg_catalog.pg_event_trigger_table_rewrite_reason", ServerSideOnly=true)]
		public static int? PgEventTriggerTableRewriteReason()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgExportSnapshot

		[Sql.Function(Name="pg_catalog.pg_export_snapshot", ServerSideOnly=true)]
		public static string PgExportSnapshot()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgExtensionConfigDump

		[Sql.Function(Name="pg_catalog.pg_extension_config_dump", ServerSideOnly=true)]
		public static object PgExtensionConfigDump(object par5092, string par5093)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgFilenodeRelation

		[Sql.Function(Name="pg_catalog.pg_filenode_relation", ServerSideOnly=true)]
		public static object PgFilenodeRelation(int? par5095, int? par5096)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgFunctionIsVisible

		[Sql.Function(Name="pg_catalog.pg_function_is_visible", ServerSideOnly=true)]
		public static bool? PgFunctionIsVisible(int? par5098)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetConstraintdef

		[Sql.Function(Name="pg_catalog.pg_get_constraintdef", ServerSideOnly=true)]
		public static string PgGetConstraintdef(int? par5102, bool? par5103)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetExpr

		[Sql.Function(Name="pg_catalog.pg_get_expr", ServerSideOnly=true)]
		public static string PgGetExpr(object par5108, int? par5109, bool? par5110)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetFunctionArgDefault

		[Sql.Function(Name="pg_catalog.pg_get_function_arg_default", ServerSideOnly=true)]
		public static string PgGetFunctionArgDefault(int? par5112, int? par5113)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetFunctionArguments

		[Sql.Function(Name="pg_catalog.pg_get_function_arguments", ServerSideOnly=true)]
		public static string PgGetFunctionArguments(int? par5115)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetFunctionIdentityArguments

		[Sql.Function(Name="pg_catalog.pg_get_function_identity_arguments", ServerSideOnly=true)]
		public static string PgGetFunctionIdentityArguments(int? par5117)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetFunctionResult

		[Sql.Function(Name="pg_catalog.pg_get_function_result", ServerSideOnly=true)]
		public static string PgGetFunctionResult(int? par5119)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetFunctiondef

		[Sql.Function(Name="pg_catalog.pg_get_functiondef", ServerSideOnly=true)]
		public static string PgGetFunctiondef(int? par5121)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetIndexdef

		[Sql.Function(Name="pg_catalog.pg_get_indexdef", ServerSideOnly=true)]
		public static string PgGetIndexdef(int? par5125, int? par5126, bool? par5127)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetObjectAddress

		[Sql.Function(Name="pg_catalog.pg_get_object_address", ServerSideOnly=true)]
		public static pg_get_object_addressResult PgGetObjectAddress(string type, object object_names, object object_args)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetPartitionConstraintdef

		[Sql.Function(Name="pg_catalog.pg_get_partition_constraintdef", ServerSideOnly=true)]
		public static string PgGetPartitionConstraintdef(int? par5129)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetPartkeydef

		[Sql.Function(Name="pg_catalog.pg_get_partkeydef", ServerSideOnly=true)]
		public static string PgGetPartkeydef(int? par5131)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetReplicaIdentityIndex

		[Sql.Function(Name="pg_catalog.pg_get_replica_identity_index", ServerSideOnly=true)]
		public static object PgGetReplicaIdentityIndex(object par5133)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetRuledef

		[Sql.Function(Name="pg_catalog.pg_get_ruledef", ServerSideOnly=true)]
		public static string PgGetRuledef(int? par5137, bool? par5138)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetSerialSequence

		[Sql.Function(Name="pg_catalog.pg_get_serial_sequence", ServerSideOnly=true)]
		public static string PgGetSerialSequence(string par5140, string par5141)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetStatisticsobjdef

		[Sql.Function(Name="pg_catalog.pg_get_statisticsobjdef", ServerSideOnly=true)]
		public static string PgGetStatisticsobjdef(int? par5143)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetTriggerdef

		[Sql.Function(Name="pg_catalog.pg_get_triggerdef", ServerSideOnly=true)]
		public static string PgGetTriggerdef(int? par5147, bool? par5148)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetUserbyid

		[Sql.Function(Name="pg_catalog.pg_get_userbyid", ServerSideOnly=true)]
		public static string PgGetUserbyid(int? par5150)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgGetViewdef

		[Sql.Function(Name="pg_catalog.pg_get_viewdef", ServerSideOnly=true)]
		public static string PgGetViewdef(int? par5162, int? par5163)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgHasRole

		[Sql.Function(Name="pg_catalog.pg_has_role", ServerSideOnly=true)]
		public static bool? PgHasRole(int? par5184, string par5185)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIdentifyObject

		[Sql.Function(Name="pg_catalog.pg_identify_object", ServerSideOnly=true)]
		public static pg_identify_objectResult PgIdentifyObject(int? classid, int? objid, int? objsubid)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIdentifyObjectAsAddress

		[Sql.Function(Name="pg_catalog.pg_identify_object_as_address", ServerSideOnly=true)]
		public static pg_identify_object_as_addressResult PgIdentifyObjectAsAddress(int? classid, int? objid, int? objsubid)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgImportSystemCollations

		[Sql.Function(Name="pg_catalog.pg_import_system_collations", ServerSideOnly=true)]
		public static int? PgImportSystemCollations(object par5187)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIndexColumnHasProperty

		[Sql.Function(Name="pg_catalog.pg_index_column_has_property", ServerSideOnly=true)]
		public static bool? PgIndexColumnHasProperty(object par5189, int? par5190, string par5191)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIndexHasProperty

		[Sql.Function(Name="pg_catalog.pg_index_has_property", ServerSideOnly=true)]
		public static bool? PgIndexHasProperty(object par5193, string par5194)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIndexamHasProperty

		[Sql.Function(Name="pg_catalog.pg_indexam_has_property", ServerSideOnly=true)]
		public static bool? PgIndexamHasProperty(int? par5196, string par5197)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIndexesSize

		[Sql.Function(Name="pg_catalog.pg_indexes_size", ServerSideOnly=true)]
		public static long? PgIndexesSize(object par5199)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIsInBackup

		[Sql.Function(Name="pg_catalog.pg_is_in_backup", ServerSideOnly=true)]
		public static bool? PgIsInBackup()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIsInRecovery

		[Sql.Function(Name="pg_catalog.pg_is_in_recovery", ServerSideOnly=true)]
		public static bool? PgIsInRecovery()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIsOtherTempSchema

		[Sql.Function(Name="pg_catalog.pg_is_other_temp_schema", ServerSideOnly=true)]
		public static bool? PgIsOtherTempSchema(int? par5203)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIsWalReplayPaused

		[Sql.Function(Name="pg_catalog.pg_is_wal_replay_paused", ServerSideOnly=true)]
		public static bool? PgIsWalReplayPaused()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgIsolationTestSessionIsBlocked

		[Sql.Function(Name="pg_catalog.pg_isolation_test_session_is_blocked", ServerSideOnly=true)]
		public static bool? PgIsolationTestSessionIsBlocked(int? par5206, object par5207)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgJitAvailable

		[Sql.Function(Name="pg_catalog.pg_jit_available", ServerSideOnly=true)]
		public static bool? PgJitAvailable()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLastCommittedXact

		[Sql.Function(Name="pg_catalog.pg_last_committed_xact", ServerSideOnly=true)]
		public static pg_last_committed_xactResult PgLastCommittedXact()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLastWalReceiveLsn

		[Sql.Function(Name="pg_catalog.pg_last_wal_receive_lsn", ServerSideOnly=true)]
		public static object PgLastWalReceiveLsn()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLastWalReplayLsn

		[Sql.Function(Name="pg_catalog.pg_last_wal_replay_lsn", ServerSideOnly=true)]
		public static object PgLastWalReplayLsn()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLastXactReplayTimestamp

		[Sql.Function(Name="pg_catalog.pg_last_xact_replay_timestamp", ServerSideOnly=true)]
		public static DateTimeOffset? PgLastXactReplayTimestamp()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLogicalEmitMessage

		[Sql.Function(Name="pg_catalog.pg_logical_emit_message", ServerSideOnly=true)]
		public static object PgLogicalEmitMessage(bool? par5217, string par5218, byte[] par5219)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnCmp

		[Sql.Function(Name="pg_catalog.pg_lsn_cmp", ServerSideOnly=true)]
		public static int? PgLsnCmp(object par5225, object par5226)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnEq

		[Sql.Function(Name="pg_catalog.pg_lsn_eq", ServerSideOnly=true)]
		public static bool? PgLsnEq(object par5228, object par5229)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnGe

		[Sql.Function(Name="pg_catalog.pg_lsn_ge", ServerSideOnly=true)]
		public static bool? PgLsnGe(object par5231, object par5232)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnGt

		[Sql.Function(Name="pg_catalog.pg_lsn_gt", ServerSideOnly=true)]
		public static bool? PgLsnGt(object par5234, object par5235)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnHash

		[Sql.Function(Name="pg_catalog.pg_lsn_hash", ServerSideOnly=true)]
		public static int? PgLsnHash(object par5237)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnHashExtended

		[Sql.Function(Name="pg_catalog.pg_lsn_hash_extended", ServerSideOnly=true)]
		public static long? PgLsnHashExtended(object par5239, long? par5240)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnIn

		[Sql.Function(Name="pg_catalog.pg_lsn_in", ServerSideOnly=true)]
		public static object PgLsnIn(object par5242)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnLe

		[Sql.Function(Name="pg_catalog.pg_lsn_le", ServerSideOnly=true)]
		public static bool? PgLsnLe(object par5244, object par5245)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnLt

		[Sql.Function(Name="pg_catalog.pg_lsn_lt", ServerSideOnly=true)]
		public static bool? PgLsnLt(object par5247, object par5248)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnMi

		[Sql.Function(Name="pg_catalog.pg_lsn_mi", ServerSideOnly=true)]
		public static decimal? PgLsnMi(object par5250, object par5251)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnNe

		[Sql.Function(Name="pg_catalog.pg_lsn_ne", ServerSideOnly=true)]
		public static bool? PgLsnNe(object par5253, object par5254)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnOut

		[Sql.Function(Name="pg_catalog.pg_lsn_out", ServerSideOnly=true)]
		public static object PgLsnOut(object par5256)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnRecv

		[Sql.Function(Name="pg_catalog.pg_lsn_recv", ServerSideOnly=true)]
		public static object PgLsnRecv(object par5258)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgLsnSend

		[Sql.Function(Name="pg_catalog.pg_lsn_send", ServerSideOnly=true)]
		public static byte[] PgLsnSend(object par5260)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgMyTempSchema

		[Sql.Function(Name="pg_catalog.pg_my_temp_schema", ServerSideOnly=true)]
		public static int? PgMyTempSchema()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNdistinctIn

		[Sql.Function(Name="pg_catalog.pg_ndistinct_in", ServerSideOnly=true)]
		public static object PgNdistinctIn(object par5263)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNdistinctOut

		[Sql.Function(Name="pg_catalog.pg_ndistinct_out", ServerSideOnly=true)]
		public static object PgNdistinctOut(object par5265)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNdistinctRecv

		[Sql.Function(Name="pg_catalog.pg_ndistinct_recv", ServerSideOnly=true)]
		public static object PgNdistinctRecv(object par5267)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNdistinctSend

		[Sql.Function(Name="pg_catalog.pg_ndistinct_send", ServerSideOnly=true)]
		public static byte[] PgNdistinctSend(object par5269)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNodeTreeIn

		[Sql.Function(Name="pg_catalog.pg_node_tree_in", ServerSideOnly=true)]
		public static object PgNodeTreeIn(object par5271)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNodeTreeOut

		[Sql.Function(Name="pg_catalog.pg_node_tree_out", ServerSideOnly=true)]
		public static object PgNodeTreeOut(object par5273)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNodeTreeRecv

		[Sql.Function(Name="pg_catalog.pg_node_tree_recv", ServerSideOnly=true)]
		public static object PgNodeTreeRecv(object par5275)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNodeTreeSend

		[Sql.Function(Name="pg_catalog.pg_node_tree_send", ServerSideOnly=true)]
		public static byte[] PgNodeTreeSend(object par5277)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNotificationQueueUsage

		[Sql.Function(Name="pg_catalog.pg_notification_queue_usage", ServerSideOnly=true)]
		public static double? PgNotificationQueueUsage()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgNotify

		[Sql.Function(Name="pg_catalog.pg_notify", ServerSideOnly=true)]
		public static object PgNotify(string par5279, string par5280)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgOpclassIsVisible

		[Sql.Function(Name="pg_catalog.pg_opclass_is_visible", ServerSideOnly=true)]
		public static bool? PgOpclassIsVisible(int? par5282)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgOperatorIsVisible

		[Sql.Function(Name="pg_catalog.pg_operator_is_visible", ServerSideOnly=true)]
		public static bool? PgOperatorIsVisible(int? par5284)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgOpfamilyIsVisible

		[Sql.Function(Name="pg_catalog.pg_opfamily_is_visible", ServerSideOnly=true)]
		public static bool? PgOpfamilyIsVisible(int? par5286)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgPostmasterStartTime

		[Sql.Function(Name="pg_catalog.pg_postmaster_start_time", ServerSideOnly=true)]
		public static DateTimeOffset? PgPostmasterStartTime()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReadBinaryFile

		[Sql.Function(Name="pg_catalog.pg_read_binary_file", ServerSideOnly=true)]
		public static byte[] PgReadBinaryFile(string par5298)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReadFile

		[Sql.Function(Name="pg_catalog.pg_read_file", ServerSideOnly=true)]
		public static string PgReadFile(string par5309)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReadFileOld

		[Sql.Function(Name="pg_catalog.pg_read_file_old", ServerSideOnly=true)]
		public static string PgReadFileOld(string par5311, long? par5312, long? par5313)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgRelationFilenode

		[Sql.Function(Name="pg_catalog.pg_relation_filenode", ServerSideOnly=true)]
		public static int? PgRelationFilenode(object par5315)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgRelationFilepath

		[Sql.Function(Name="pg_catalog.pg_relation_filepath", ServerSideOnly=true)]
		public static string PgRelationFilepath(object par5317)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgRelationIsPublishable

		[Sql.Function(Name="pg_catalog.pg_relation_is_publishable", ServerSideOnly=true)]
		public static bool? PgRelationIsPublishable(object par5319)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgRelationIsUpdatable

		[Sql.Function(Name="pg_catalog.pg_relation_is_updatable", ServerSideOnly=true)]
		public static int? PgRelationIsUpdatable(object par5321, bool? par5322)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgRelationSize

		[Sql.Function(Name="pg_catalog.pg_relation_size", ServerSideOnly=true)]
		public static long? PgRelationSize(object par5326, string par5327)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReloadConf

		[Sql.Function(Name="pg_catalog.pg_reload_conf", ServerSideOnly=true)]
		public static bool? PgReloadConf()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginAdvance

		[Sql.Function(Name="pg_catalog.pg_replication_origin_advance", ServerSideOnly=true)]
		public static object PgReplicationOriginAdvance(string par5329, object par5330)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginCreate

		[Sql.Function(Name="pg_catalog.pg_replication_origin_create", ServerSideOnly=true)]
		public static int? PgReplicationOriginCreate(string par5332)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginDrop

		[Sql.Function(Name="pg_catalog.pg_replication_origin_drop", ServerSideOnly=true)]
		public static object PgReplicationOriginDrop(string par5333)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginOid

		[Sql.Function(Name="pg_catalog.pg_replication_origin_oid", ServerSideOnly=true)]
		public static int? PgReplicationOriginOid(string par5335)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginProgress

		[Sql.Function(Name="pg_catalog.pg_replication_origin_progress", ServerSideOnly=true)]
		public static object PgReplicationOriginProgress(string par5337, bool? par5338)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginSessionIsSetup

		[Sql.Function(Name="pg_catalog.pg_replication_origin_session_is_setup", ServerSideOnly=true)]
		public static bool? PgReplicationOriginSessionIsSetup()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginSessionProgress

		[Sql.Function(Name="pg_catalog.pg_replication_origin_session_progress", ServerSideOnly=true)]
		public static object PgReplicationOriginSessionProgress(bool? par5341)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginSessionReset

		[Sql.Function(Name="pg_catalog.pg_replication_origin_session_reset", ServerSideOnly=true)]
		public static object PgReplicationOriginSessionReset()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginSessionSetup

		[Sql.Function(Name="pg_catalog.pg_replication_origin_session_setup", ServerSideOnly=true)]
		public static object PgReplicationOriginSessionSetup(string par5342)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginXactReset

		[Sql.Function(Name="pg_catalog.pg_replication_origin_xact_reset", ServerSideOnly=true)]
		public static object PgReplicationOriginXactReset()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationOriginXactSetup

		[Sql.Function(Name="pg_catalog.pg_replication_origin_xact_setup", ServerSideOnly=true)]
		public static object PgReplicationOriginXactSetup(object par5343, DateTimeOffset? par5344)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgReplicationSlotAdvance

		[Sql.Function(Name="pg_catalog.pg_replication_slot_advance", ServerSideOnly=true)]
		public static pg_replication_slot_advanceResult PgReplicationSlotAdvance(string slot_name, object upto_lsn)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgRotateLogfile

		[Sql.Function(Name="pg_catalog.pg_rotate_logfile", ServerSideOnly=true)]
		public static bool? PgRotateLogfile()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgRotateLogfileOld

		[Sql.Function(Name="pg_catalog.pg_rotate_logfile_old", ServerSideOnly=true)]
		public static bool? PgRotateLogfileOld()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgSafeSnapshotBlockingPids

		[Sql.Function(Name="pg_catalog.pg_safe_snapshot_blocking_pids", ServerSideOnly=true)]
		public static object PgSafeSnapshotBlockingPids(int? par5348)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgSequenceLastValue

		[Sql.Function(Name="pg_catalog.pg_sequence_last_value", ServerSideOnly=true)]
		public static long? PgSequenceLastValue(object par5350)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgSequenceParameters

		[Sql.Function(Name="pg_catalog.pg_sequence_parameters", ServerSideOnly=true)]
		public static pg_sequence_parametersResult PgSequenceParameters(int? sequence_oid)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgSizeBytes

		[Sql.Function(Name="pg_catalog.pg_size_bytes", ServerSideOnly=true)]
		public static long? PgSizeBytes(string par5352)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgSizePretty

		[Sql.Function(Name="pg_catalog.pg_size_pretty", ServerSideOnly=true)]
		public static string PgSizePretty(decimal? par5356)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgSleep

		[Sql.Function(Name="pg_catalog.pg_sleep", ServerSideOnly=true)]
		public static object PgSleep(double? par5357)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgSleepFor

		[Sql.Function(Name="pg_catalog.pg_sleep_for", ServerSideOnly=true)]
		public static object PgSleepFor(NpgsqlTimeSpan? par5358)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgSleepUntil

		[Sql.Function(Name="pg_catalog.pg_sleep_until", ServerSideOnly=true)]
		public static object PgSleepUntil(DateTimeOffset? par5359)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStartBackup

		[Sql.Function(Name="pg_catalog.pg_start_backup", ServerSideOnly=true)]
		public static object PgStartBackup(string label, bool? fast, bool? exclusive)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatClearSnapshot

		[Sql.Function(Name="pg_catalog.pg_stat_clear_snapshot", ServerSideOnly=true)]
		public static object PgStatClearSnapshot()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatFile

		[Sql.Function(Name="pg_catalog.pg_stat_file", ServerSideOnly=true)]
		public static pg_stat_fileResult PgStatFile(string filename, bool? missing_ok)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetAnalyzeCount

		[Sql.Function(Name="pg_catalog.pg_stat_get_analyze_count", ServerSideOnly=true)]
		public static long? PgStatGetAnalyzeCount(int? par5362)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetArchiver

		[Sql.Function(Name="pg_catalog.pg_stat_get_archiver", ServerSideOnly=true)]
		public static pg_stat_get_archiverResult PgStatGetArchiver()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetAutoanalyzeCount

		[Sql.Function(Name="pg_catalog.pg_stat_get_autoanalyze_count", ServerSideOnly=true)]
		public static long? PgStatGetAutoanalyzeCount(int? par5364)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetAutovacuumCount

		[Sql.Function(Name="pg_catalog.pg_stat_get_autovacuum_count", ServerSideOnly=true)]
		public static long? PgStatGetAutovacuumCount(int? par5366)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendActivity

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_activity", ServerSideOnly=true)]
		public static string PgStatGetBackendActivity(int? par5368)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendActivityStart

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_activity_start", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetBackendActivityStart(int? par5370)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendClientAddr

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_client_addr", ServerSideOnly=true)]
		public static NpgsqlInet? PgStatGetBackendClientAddr(int? par5372)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendClientPort

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_client_port", ServerSideOnly=true)]
		public static int? PgStatGetBackendClientPort(int? par5374)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendDbid

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_dbid", ServerSideOnly=true)]
		public static int? PgStatGetBackendDbid(int? par5376)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendPid

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_pid", ServerSideOnly=true)]
		public static int? PgStatGetBackendPid(int? par5378)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendStart

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_start", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetBackendStart(int? par5380)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendUserid

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_userid", ServerSideOnly=true)]
		public static int? PgStatGetBackendUserid(int? par5382)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendWaitEvent

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_wait_event", ServerSideOnly=true)]
		public static string PgStatGetBackendWaitEvent(int? par5384)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendWaitEventType

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_wait_event_type", ServerSideOnly=true)]
		public static string PgStatGetBackendWaitEventType(int? par5386)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBackendXactStart

		[Sql.Function(Name="pg_catalog.pg_stat_get_backend_xact_start", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetBackendXactStart(int? par5388)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBgwriterBufWrittenCheckpoints

		[Sql.Function(Name="pg_catalog.pg_stat_get_bgwriter_buf_written_checkpoints", ServerSideOnly=true)]
		public static long? PgStatGetBgwriterBufWrittenCheckpoints()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBgwriterBufWrittenClean

		[Sql.Function(Name="pg_catalog.pg_stat_get_bgwriter_buf_written_clean", ServerSideOnly=true)]
		public static long? PgStatGetBgwriterBufWrittenClean()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBgwriterMaxwrittenClean

		[Sql.Function(Name="pg_catalog.pg_stat_get_bgwriter_maxwritten_clean", ServerSideOnly=true)]
		public static long? PgStatGetBgwriterMaxwrittenClean()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBgwriterRequestedCheckpoints

		[Sql.Function(Name="pg_catalog.pg_stat_get_bgwriter_requested_checkpoints", ServerSideOnly=true)]
		public static long? PgStatGetBgwriterRequestedCheckpoints()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBgwriterStatResetTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_bgwriter_stat_reset_time", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetBgwriterStatResetTime()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBgwriterTimedCheckpoints

		[Sql.Function(Name="pg_catalog.pg_stat_get_bgwriter_timed_checkpoints", ServerSideOnly=true)]
		public static long? PgStatGetBgwriterTimedCheckpoints()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBlocksFetched

		[Sql.Function(Name="pg_catalog.pg_stat_get_blocks_fetched", ServerSideOnly=true)]
		public static long? PgStatGetBlocksFetched(int? par5396)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBlocksHit

		[Sql.Function(Name="pg_catalog.pg_stat_get_blocks_hit", ServerSideOnly=true)]
		public static long? PgStatGetBlocksHit(int? par5398)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBufAlloc

		[Sql.Function(Name="pg_catalog.pg_stat_get_buf_alloc", ServerSideOnly=true)]
		public static long? PgStatGetBufAlloc()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBufFsyncBackend

		[Sql.Function(Name="pg_catalog.pg_stat_get_buf_fsync_backend", ServerSideOnly=true)]
		public static long? PgStatGetBufFsyncBackend()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetBufWrittenBackend

		[Sql.Function(Name="pg_catalog.pg_stat_get_buf_written_backend", ServerSideOnly=true)]
		public static long? PgStatGetBufWrittenBackend()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetCheckpointSyncTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_checkpoint_sync_time", ServerSideOnly=true)]
		public static double? PgStatGetCheckpointSyncTime()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetCheckpointWriteTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_checkpoint_write_time", ServerSideOnly=true)]
		public static double? PgStatGetCheckpointWriteTime()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbBlkReadTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_blk_read_time", ServerSideOnly=true)]
		public static double? PgStatGetDbBlkReadTime(int? par5405)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbBlkWriteTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_blk_write_time", ServerSideOnly=true)]
		public static double? PgStatGetDbBlkWriteTime(int? par5407)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbBlocksFetched

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_blocks_fetched", ServerSideOnly=true)]
		public static long? PgStatGetDbBlocksFetched(int? par5409)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbBlocksHit

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_blocks_hit", ServerSideOnly=true)]
		public static long? PgStatGetDbBlocksHit(int? par5411)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbConflictAll

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_conflict_all", ServerSideOnly=true)]
		public static long? PgStatGetDbConflictAll(int? par5413)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbConflictBufferpin

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_conflict_bufferpin", ServerSideOnly=true)]
		public static long? PgStatGetDbConflictBufferpin(int? par5415)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbConflictLock

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_conflict_lock", ServerSideOnly=true)]
		public static long? PgStatGetDbConflictLock(int? par5417)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbConflictSnapshot

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_conflict_snapshot", ServerSideOnly=true)]
		public static long? PgStatGetDbConflictSnapshot(int? par5419)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbConflictStartupDeadlock

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_conflict_startup_deadlock", ServerSideOnly=true)]
		public static long? PgStatGetDbConflictStartupDeadlock(int? par5421)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbConflictTablespace

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_conflict_tablespace", ServerSideOnly=true)]
		public static long? PgStatGetDbConflictTablespace(int? par5423)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbDeadlocks

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_deadlocks", ServerSideOnly=true)]
		public static long? PgStatGetDbDeadlocks(int? par5425)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbNumbackends

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_numbackends", ServerSideOnly=true)]
		public static int? PgStatGetDbNumbackends(int? par5427)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbStatResetTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_stat_reset_time", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetDbStatResetTime(int? par5429)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbTempBytes

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_temp_bytes", ServerSideOnly=true)]
		public static long? PgStatGetDbTempBytes(int? par5431)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbTempFiles

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_temp_files", ServerSideOnly=true)]
		public static long? PgStatGetDbTempFiles(int? par5433)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbTuplesDeleted

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_tuples_deleted", ServerSideOnly=true)]
		public static long? PgStatGetDbTuplesDeleted(int? par5435)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbTuplesFetched

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_tuples_fetched", ServerSideOnly=true)]
		public static long? PgStatGetDbTuplesFetched(int? par5437)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbTuplesInserted

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_tuples_inserted", ServerSideOnly=true)]
		public static long? PgStatGetDbTuplesInserted(int? par5439)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbTuplesReturned

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_tuples_returned", ServerSideOnly=true)]
		public static long? PgStatGetDbTuplesReturned(int? par5441)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbTuplesUpdated

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_tuples_updated", ServerSideOnly=true)]
		public static long? PgStatGetDbTuplesUpdated(int? par5443)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbXactCommit

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_xact_commit", ServerSideOnly=true)]
		public static long? PgStatGetDbXactCommit(int? par5445)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDbXactRollback

		[Sql.Function(Name="pg_catalog.pg_stat_get_db_xact_rollback", ServerSideOnly=true)]
		public static long? PgStatGetDbXactRollback(int? par5447)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetDeadTuples

		[Sql.Function(Name="pg_catalog.pg_stat_get_dead_tuples", ServerSideOnly=true)]
		public static long? PgStatGetDeadTuples(int? par5449)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetFunctionCalls

		[Sql.Function(Name="pg_catalog.pg_stat_get_function_calls", ServerSideOnly=true)]
		public static long? PgStatGetFunctionCalls(int? par5451)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetFunctionSelfTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_function_self_time", ServerSideOnly=true)]
		public static double? PgStatGetFunctionSelfTime(int? par5453)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetFunctionTotalTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_function_total_time", ServerSideOnly=true)]
		public static double? PgStatGetFunctionTotalTime(int? par5455)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetLastAnalyzeTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_last_analyze_time", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetLastAnalyzeTime(int? par5457)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetLastAutoanalyzeTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_last_autoanalyze_time", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetLastAutoanalyzeTime(int? par5459)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetLastAutovacuumTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_last_autovacuum_time", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetLastAutovacuumTime(int? par5461)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetLastVacuumTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_last_vacuum_time", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetLastVacuumTime(int? par5463)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetLiveTuples

		[Sql.Function(Name="pg_catalog.pg_stat_get_live_tuples", ServerSideOnly=true)]
		public static long? PgStatGetLiveTuples(int? par5465)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetModSinceAnalyze

		[Sql.Function(Name="pg_catalog.pg_stat_get_mod_since_analyze", ServerSideOnly=true)]
		public static long? PgStatGetModSinceAnalyze(int? par5467)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetNumscans

		[Sql.Function(Name="pg_catalog.pg_stat_get_numscans", ServerSideOnly=true)]
		public static long? PgStatGetNumscans(int? par5469)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetSnapshotTimestamp

		[Sql.Function(Name="pg_catalog.pg_stat_get_snapshot_timestamp", ServerSideOnly=true)]
		public static DateTimeOffset? PgStatGetSnapshotTimestamp()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetSubscription

		[Sql.Function(Name="pg_catalog.pg_stat_get_subscription", ServerSideOnly=true)]
		public static pg_stat_get_subscriptionResult PgStatGetSubscription(int? subid)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetTuplesDeleted

		[Sql.Function(Name="pg_catalog.pg_stat_get_tuples_deleted", ServerSideOnly=true)]
		public static long? PgStatGetTuplesDeleted(int? par5472)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetTuplesFetched

		[Sql.Function(Name="pg_catalog.pg_stat_get_tuples_fetched", ServerSideOnly=true)]
		public static long? PgStatGetTuplesFetched(int? par5474)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetTuplesHotUpdated

		[Sql.Function(Name="pg_catalog.pg_stat_get_tuples_hot_updated", ServerSideOnly=true)]
		public static long? PgStatGetTuplesHotUpdated(int? par5476)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetTuplesInserted

		[Sql.Function(Name="pg_catalog.pg_stat_get_tuples_inserted", ServerSideOnly=true)]
		public static long? PgStatGetTuplesInserted(int? par5478)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetTuplesReturned

		[Sql.Function(Name="pg_catalog.pg_stat_get_tuples_returned", ServerSideOnly=true)]
		public static long? PgStatGetTuplesReturned(int? par5480)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetTuplesUpdated

		[Sql.Function(Name="pg_catalog.pg_stat_get_tuples_updated", ServerSideOnly=true)]
		public static long? PgStatGetTuplesUpdated(int? par5482)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetVacuumCount

		[Sql.Function(Name="pg_catalog.pg_stat_get_vacuum_count", ServerSideOnly=true)]
		public static long? PgStatGetVacuumCount(int? par5484)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetWalReceiver

		[Sql.Function(Name="pg_catalog.pg_stat_get_wal_receiver", ServerSideOnly=true)]
		public static pg_stat_get_wal_receiverResult PgStatGetWalReceiver()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactBlocksFetched

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_blocks_fetched", ServerSideOnly=true)]
		public static long? PgStatGetXactBlocksFetched(int? par5486)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactBlocksHit

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_blocks_hit", ServerSideOnly=true)]
		public static long? PgStatGetXactBlocksHit(int? par5488)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactFunctionCalls

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_function_calls", ServerSideOnly=true)]
		public static long? PgStatGetXactFunctionCalls(int? par5490)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactFunctionSelfTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_function_self_time", ServerSideOnly=true)]
		public static double? PgStatGetXactFunctionSelfTime(int? par5492)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactFunctionTotalTime

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_function_total_time", ServerSideOnly=true)]
		public static double? PgStatGetXactFunctionTotalTime(int? par5494)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactNumscans

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_numscans", ServerSideOnly=true)]
		public static long? PgStatGetXactNumscans(int? par5496)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactTuplesDeleted

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_tuples_deleted", ServerSideOnly=true)]
		public static long? PgStatGetXactTuplesDeleted(int? par5498)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactTuplesFetched

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_tuples_fetched", ServerSideOnly=true)]
		public static long? PgStatGetXactTuplesFetched(int? par5500)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactTuplesHotUpdated

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_tuples_hot_updated", ServerSideOnly=true)]
		public static long? PgStatGetXactTuplesHotUpdated(int? par5502)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactTuplesInserted

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_tuples_inserted", ServerSideOnly=true)]
		public static long? PgStatGetXactTuplesInserted(int? par5504)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactTuplesReturned

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_tuples_returned", ServerSideOnly=true)]
		public static long? PgStatGetXactTuplesReturned(int? par5506)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatGetXactTuplesUpdated

		[Sql.Function(Name="pg_catalog.pg_stat_get_xact_tuples_updated", ServerSideOnly=true)]
		public static long? PgStatGetXactTuplesUpdated(int? par5508)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatReset

		[Sql.Function(Name="pg_catalog.pg_stat_reset", ServerSideOnly=true)]
		public static object PgStatReset()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatResetShared

		[Sql.Function(Name="pg_catalog.pg_stat_reset_shared", ServerSideOnly=true)]
		public static object PgStatResetShared(string par5509)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatResetSingleFunctionCounters

		[Sql.Function(Name="pg_catalog.pg_stat_reset_single_function_counters", ServerSideOnly=true)]
		public static object PgStatResetSingleFunctionCounters(int? par5510)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatResetSingleTableCounters

		[Sql.Function(Name="pg_catalog.pg_stat_reset_single_table_counters", ServerSideOnly=true)]
		public static object PgStatResetSingleTableCounters(int? par5511)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgStatisticsObjIsVisible

		[Sql.Function(Name="pg_catalog.pg_statistics_obj_is_visible", ServerSideOnly=true)]
		public static bool? PgStatisticsObjIsVisible(int? par5513)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgSwitchWal

		[Sql.Function(Name="pg_catalog.pg_switch_wal", ServerSideOnly=true)]
		public static object PgSwitchWal()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTableIsVisible

		[Sql.Function(Name="pg_catalog.pg_table_is_visible", ServerSideOnly=true)]
		public static bool? PgTableIsVisible(int? par5517)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTableSize

		[Sql.Function(Name="pg_catalog.pg_table_size", ServerSideOnly=true)]
		public static long? PgTableSize(object par5519)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTablespaceLocation

		[Sql.Function(Name="pg_catalog.pg_tablespace_location", ServerSideOnly=true)]
		public static string PgTablespaceLocation(int? par5522)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTablespaceSize

		[Sql.Function(Name="pg_catalog.pg_tablespace_size", ServerSideOnly=true)]
		public static long? PgTablespaceSize(string par5526)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTerminateBackend

		[Sql.Function(Name="pg_catalog.pg_terminate_backend", ServerSideOnly=true)]
		public static bool? PgTerminateBackend(int? par5528)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTotalRelationSize

		[Sql.Function(Name="pg_catalog.pg_total_relation_size", ServerSideOnly=true)]
		public static long? PgTotalRelationSize(object par5530)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTriggerDepth

		[Sql.Function(Name="pg_catalog.pg_trigger_depth", ServerSideOnly=true)]
		public static int? PgTriggerDepth()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTryAdvisoryLock

		[Sql.Function(Name="pg_catalog.pg_try_advisory_lock", ServerSideOnly=true)]
		public static bool? PgTryAdvisoryLock(int? par5535, int? par5536)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTryAdvisoryLockShared

		[Sql.Function(Name="pg_catalog.pg_try_advisory_lock_shared", ServerSideOnly=true)]
		public static bool? PgTryAdvisoryLockShared(int? par5540, int? par5541)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTryAdvisoryXactLock

		[Sql.Function(Name="pg_catalog.pg_try_advisory_xact_lock", ServerSideOnly=true)]
		public static bool? PgTryAdvisoryXactLock(int? par5545, int? par5546)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTryAdvisoryXactLockShared

		[Sql.Function(Name="pg_catalog.pg_try_advisory_xact_lock_shared", ServerSideOnly=true)]
		public static bool? PgTryAdvisoryXactLockShared(int? par5550, int? par5551)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTsConfigIsVisible

		[Sql.Function(Name="pg_catalog.pg_ts_config_is_visible", ServerSideOnly=true)]
		public static bool? PgTsConfigIsVisible(int? par5553)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTsDictIsVisible

		[Sql.Function(Name="pg_catalog.pg_ts_dict_is_visible", ServerSideOnly=true)]
		public static bool? PgTsDictIsVisible(int? par5555)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTsParserIsVisible

		[Sql.Function(Name="pg_catalog.pg_ts_parser_is_visible", ServerSideOnly=true)]
		public static bool? PgTsParserIsVisible(int? par5557)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTsTemplateIsVisible

		[Sql.Function(Name="pg_catalog.pg_ts_template_is_visible", ServerSideOnly=true)]
		public static bool? PgTsTemplateIsVisible(int? par5559)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTypeIsVisible

		[Sql.Function(Name="pg_catalog.pg_type_is_visible", ServerSideOnly=true)]
		public static bool? PgTypeIsVisible(int? par5561)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgTypeof

		[Sql.Function(Name="pg_catalog.pg_typeof", ServerSideOnly=true)]
		public static object PgTypeof(object par5563)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgWalLsnDiff

		[Sql.Function(Name="pg_catalog.pg_wal_lsn_diff", ServerSideOnly=true)]
		public static decimal? PgWalLsnDiff(object par5565, object par5566)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgWalReplayPause

		[Sql.Function(Name="pg_catalog.pg_wal_replay_pause", ServerSideOnly=true)]
		public static object PgWalReplayPause()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgWalReplayResume

		[Sql.Function(Name="pg_catalog.pg_wal_replay_resume", ServerSideOnly=true)]
		public static object PgWalReplayResume()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgWalfileName

		[Sql.Function(Name="pg_catalog.pg_walfile_name", ServerSideOnly=true)]
		public static string PgWalfileName(object par5568)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgWalfileNameOffset

		[Sql.Function(Name="pg_catalog.pg_walfile_name_offset", ServerSideOnly=true)]
		public static pg_walfile_name_offsetResult PgWalfileNameOffset(object lsn)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PgXactCommitTimestamp

		[Sql.Function(Name="pg_catalog.pg_xact_commit_timestamp", ServerSideOnly=true)]
		public static DateTimeOffset? PgXactCommitTimestamp(int? par5570)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PhrasetoTsquery

		[Sql.Function(Name="pg_catalog.phraseto_tsquery", ServerSideOnly=true)]
		public static object PhrasetoTsquery(object par5574, string par5575)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Pi

		[Sql.Function(Name="pg_catalog.pi", ServerSideOnly=true)]
		public static double? Pi()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PlaintoTsquery

		[Sql.Function(Name="pg_catalog.plainto_tsquery", ServerSideOnly=true)]
		public static object PlaintoTsquery(string par5581)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PlpgsqlCallHandler

		[Sql.Function(Name="pg_catalog.plpgsql_call_handler", ServerSideOnly=true)]
		public static object PlpgsqlCallHandler()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PlpgsqlInlineHandler

		[Sql.Function(Name="pg_catalog.plpgsql_inline_handler", ServerSideOnly=true)]
		public static object PlpgsqlInlineHandler(object par5583)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PlpgsqlValidator

		[Sql.Function(Name="pg_catalog.plpgsql_validator", ServerSideOnly=true)]
		public static object PlpgsqlValidator(int? par5584)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Point

		[Sql.Function(Name="pg_catalog.point", ServerSideOnly=true)]
		public static NpgsqlPoint? Point(NpgsqlPolygon? par5597)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointAbove

		[Sql.Function(Name="pg_catalog.point_above", ServerSideOnly=true)]
		public static bool? PointAbove(NpgsqlPoint? par5599, NpgsqlPoint? par5600)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointAdd

		[Sql.Function(Name="pg_catalog.point_add", ServerSideOnly=true)]
		public static NpgsqlPoint? PointAdd(NpgsqlPoint? par5602, NpgsqlPoint? par5603)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointBelow

		[Sql.Function(Name="pg_catalog.point_below", ServerSideOnly=true)]
		public static bool? PointBelow(NpgsqlPoint? par5605, NpgsqlPoint? par5606)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointDistance

		[Sql.Function(Name="pg_catalog.point_distance", ServerSideOnly=true)]
		public static double? PointDistance(NpgsqlPoint? par5608, NpgsqlPoint? par5609)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointDiv

		[Sql.Function(Name="pg_catalog.point_div", ServerSideOnly=true)]
		public static NpgsqlPoint? PointDiv(NpgsqlPoint? par5611, NpgsqlPoint? par5612)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointEq

		[Sql.Function(Name="pg_catalog.point_eq", ServerSideOnly=true)]
		public static bool? PointEq(NpgsqlPoint? par5614, NpgsqlPoint? par5615)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointHoriz

		[Sql.Function(Name="pg_catalog.point_horiz", ServerSideOnly=true)]
		public static bool? PointHoriz(NpgsqlPoint? par5617, NpgsqlPoint? par5618)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointIn

		[Sql.Function(Name="pg_catalog.point_in", ServerSideOnly=true)]
		public static NpgsqlPoint? PointIn(object par5620)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointLeft

		[Sql.Function(Name="pg_catalog.point_left", ServerSideOnly=true)]
		public static bool? PointLeft(NpgsqlPoint? par5622, NpgsqlPoint? par5623)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointMul

		[Sql.Function(Name="pg_catalog.point_mul", ServerSideOnly=true)]
		public static NpgsqlPoint? PointMul(NpgsqlPoint? par5625, NpgsqlPoint? par5626)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointNe

		[Sql.Function(Name="pg_catalog.point_ne", ServerSideOnly=true)]
		public static bool? PointNe(NpgsqlPoint? par5628, NpgsqlPoint? par5629)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointOut

		[Sql.Function(Name="pg_catalog.point_out", ServerSideOnly=true)]
		public static object PointOut(NpgsqlPoint? par5631)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointRecv

		[Sql.Function(Name="pg_catalog.point_recv", ServerSideOnly=true)]
		public static NpgsqlPoint? PointRecv(object par5633)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointRight

		[Sql.Function(Name="pg_catalog.point_right", ServerSideOnly=true)]
		public static bool? PointRight(NpgsqlPoint? par5635, NpgsqlPoint? par5636)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointSend

		[Sql.Function(Name="pg_catalog.point_send", ServerSideOnly=true)]
		public static byte[] PointSend(NpgsqlPoint? par5638)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointSub

		[Sql.Function(Name="pg_catalog.point_sub", ServerSideOnly=true)]
		public static NpgsqlPoint? PointSub(NpgsqlPoint? par5640, NpgsqlPoint? par5641)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PointVert

		[Sql.Function(Name="pg_catalog.point_vert", ServerSideOnly=true)]
		public static bool? PointVert(NpgsqlPoint? par5643, NpgsqlPoint? par5644)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyAbove

		[Sql.Function(Name="pg_catalog.poly_above", ServerSideOnly=true)]
		public static bool? PolyAbove(NpgsqlPolygon? par5646, NpgsqlPolygon? par5647)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyBelow

		[Sql.Function(Name="pg_catalog.poly_below", ServerSideOnly=true)]
		public static bool? PolyBelow(NpgsqlPolygon? par5649, NpgsqlPolygon? par5650)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyCenter

		[Sql.Function(Name="pg_catalog.poly_center", ServerSideOnly=true)]
		public static NpgsqlPoint? PolyCenter(NpgsqlPolygon? par5652)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyContain

		[Sql.Function(Name="pg_catalog.poly_contain", ServerSideOnly=true)]
		public static bool? PolyContain(NpgsqlPolygon? par5654, NpgsqlPolygon? par5655)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyContainPt

		[Sql.Function(Name="pg_catalog.poly_contain_pt", ServerSideOnly=true)]
		public static bool? PolyContainPt(NpgsqlPolygon? par5657, NpgsqlPoint? par5658)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyContained

		[Sql.Function(Name="pg_catalog.poly_contained", ServerSideOnly=true)]
		public static bool? PolyContained(NpgsqlPolygon? par5660, NpgsqlPolygon? par5661)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyDistance

		[Sql.Function(Name="pg_catalog.poly_distance", ServerSideOnly=true)]
		public static double? PolyDistance(NpgsqlPolygon? par5663, NpgsqlPolygon? par5664)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyIn

		[Sql.Function(Name="pg_catalog.poly_in", ServerSideOnly=true)]
		public static NpgsqlPolygon? PolyIn(object par5666)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyLeft

		[Sql.Function(Name="pg_catalog.poly_left", ServerSideOnly=true)]
		public static bool? PolyLeft(NpgsqlPolygon? par5668, NpgsqlPolygon? par5669)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyNpoints

		[Sql.Function(Name="pg_catalog.poly_npoints", ServerSideOnly=true)]
		public static int? PolyNpoints(NpgsqlPolygon? par5671)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyOut

		[Sql.Function(Name="pg_catalog.poly_out", ServerSideOnly=true)]
		public static object PolyOut(NpgsqlPolygon? par5673)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyOverabove

		[Sql.Function(Name="pg_catalog.poly_overabove", ServerSideOnly=true)]
		public static bool? PolyOverabove(NpgsqlPolygon? par5675, NpgsqlPolygon? par5676)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyOverbelow

		[Sql.Function(Name="pg_catalog.poly_overbelow", ServerSideOnly=true)]
		public static bool? PolyOverbelow(NpgsqlPolygon? par5678, NpgsqlPolygon? par5679)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyOverlap

		[Sql.Function(Name="pg_catalog.poly_overlap", ServerSideOnly=true)]
		public static bool? PolyOverlap(NpgsqlPolygon? par5681, NpgsqlPolygon? par5682)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyOverleft

		[Sql.Function(Name="pg_catalog.poly_overleft", ServerSideOnly=true)]
		public static bool? PolyOverleft(NpgsqlPolygon? par5684, NpgsqlPolygon? par5685)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyOverright

		[Sql.Function(Name="pg_catalog.poly_overright", ServerSideOnly=true)]
		public static bool? PolyOverright(NpgsqlPolygon? par5687, NpgsqlPolygon? par5688)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyRecv

		[Sql.Function(Name="pg_catalog.poly_recv", ServerSideOnly=true)]
		public static NpgsqlPolygon? PolyRecv(object par5690)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolyRight

		[Sql.Function(Name="pg_catalog.poly_right", ServerSideOnly=true)]
		public static bool? PolyRight(NpgsqlPolygon? par5692, NpgsqlPolygon? par5693)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolySame

		[Sql.Function(Name="pg_catalog.poly_same", ServerSideOnly=true)]
		public static bool? PolySame(NpgsqlPolygon? par5695, NpgsqlPolygon? par5696)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PolySend

		[Sql.Function(Name="pg_catalog.poly_send", ServerSideOnly=true)]
		public static byte[] PolySend(NpgsqlPolygon? par5698)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Polygon

		[Sql.Function(Name="pg_catalog.polygon", ServerSideOnly=true)]
		public static NpgsqlPolygon? Polygon(NpgsqlCircle? par5707)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Popen

		[Sql.Function(Name="pg_catalog.popen", ServerSideOnly=true)]
		public static NpgsqlPath? Popen(NpgsqlPath? par5709)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Position

		[Sql.Function(Name="pg_catalog.position", ServerSideOnly=true)]
		public static int? Position(string par5717, string par5718)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Positionjoinsel

		[Sql.Function(Name="pg_catalog.positionjoinsel", ServerSideOnly=true)]
		public static double? Positionjoinsel(object par5720, int? par5721, object par5722, short? par5723, object par5724)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Positionsel

		[Sql.Function(Name="pg_catalog.positionsel", ServerSideOnly=true)]
		public static double? Positionsel(object par5726, int? par5727, object par5728, int? par5729)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PostgresqlFdwValidator

		[Sql.Function(Name="pg_catalog.postgresql_fdw_validator", ServerSideOnly=true)]
		public static bool? PostgresqlFdwValidator(object par5731, int? par5732)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Pow

		[Sql.Function(Name="pg_catalog.pow", ServerSideOnly=true)]
		public static decimal? Pow(decimal? par5737, decimal? par5738)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Power

		[Sql.Function(Name="pg_catalog.power", ServerSideOnly=true)]
		public static decimal? Power(decimal? par5743, decimal? par5744)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Prefixjoinsel

		[Sql.Function(Name="pg_catalog.prefixjoinsel", ServerSideOnly=true)]
		public static double? Prefixjoinsel(object par5746, int? par5747, object par5748, short? par5749, object par5750)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Prefixsel

		[Sql.Function(Name="pg_catalog.prefixsel", ServerSideOnly=true)]
		public static double? Prefixsel(object par5752, int? par5753, object par5754, int? par5755)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PrsdEnd

		[Sql.Function(Name="pg_catalog.prsd_end", ServerSideOnly=true)]
		public static object PrsdEnd(object par5756)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PrsdHeadline

		[Sql.Function(Name="pg_catalog.prsd_headline", ServerSideOnly=true)]
		public static object PrsdHeadline(object par5758, object par5759, object par5760)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PrsdLextype

		[Sql.Function(Name="pg_catalog.prsd_lextype", ServerSideOnly=true)]
		public static object PrsdLextype(object par5762)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PrsdNexttoken

		[Sql.Function(Name="pg_catalog.prsd_nexttoken", ServerSideOnly=true)]
		public static object PrsdNexttoken(object par5764, object par5765, object par5766)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PrsdStart

		[Sql.Function(Name="pg_catalog.prsd_start", ServerSideOnly=true)]
		public static object PrsdStart(object par5768, int? par5769)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PtContainedCircle

		[Sql.Function(Name="pg_catalog.pt_contained_circle", ServerSideOnly=true)]
		public static bool? PtContainedCircle(NpgsqlPoint? par5771, NpgsqlCircle? par5772)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region PtContainedPoly

		[Sql.Function(Name="pg_catalog.pt_contained_poly", ServerSideOnly=true)]
		public static bool? PtContainedPoly(NpgsqlPoint? par5774, NpgsqlPolygon? par5775)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region QueryToXml

		[Sql.Function(Name="pg_catalog.query_to_xml", ServerSideOnly=true)]
		public static string QueryToXml(string query, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region QueryToXmlAndXmlschema

		[Sql.Function(Name="pg_catalog.query_to_xml_and_xmlschema", ServerSideOnly=true)]
		public static string QueryToXmlAndXmlschema(string query, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region QueryToXmlschema

		[Sql.Function(Name="pg_catalog.query_to_xmlschema", ServerSideOnly=true)]
		public static string QueryToXmlschema(string query, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Querytree

		[Sql.Function(Name="pg_catalog.querytree", ServerSideOnly=true)]
		public static string Querytree(object par5780)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region QuoteIdent

		[Sql.Function(Name="pg_catalog.quote_ident", ServerSideOnly=true)]
		public static string QuoteIdent(string par5782)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region QuoteLiteral

		[Sql.Function(Name="pg_catalog.quote_literal", ServerSideOnly=true)]
		public static string QuoteLiteral(object par5786)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region QuoteNullable

		[Sql.Function(Name="pg_catalog.quote_nullable", ServerSideOnly=true)]
		public static string QuoteNullable(object par5790)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Radians

		[Sql.Function(Name="pg_catalog.radians", ServerSideOnly=true)]
		public static double? Radians(double? par5792)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Radius

		[Sql.Function(Name="pg_catalog.radius", ServerSideOnly=true)]
		public static double? Radius(NpgsqlCircle? par5794)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Random

		[Sql.Function(Name="pg_catalog.random", ServerSideOnly=true)]
		public static double? Random()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeAdjacent

		[Sql.Function(Name="pg_catalog.range_adjacent", ServerSideOnly=true)]
		public static bool? RangeAdjacent(object par5797, object par5798)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeAfter

		[Sql.Function(Name="pg_catalog.range_after", ServerSideOnly=true)]
		public static bool? RangeAfter(object par5800, object par5801)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeBefore

		[Sql.Function(Name="pg_catalog.range_before", ServerSideOnly=true)]
		public static bool? RangeBefore(object par5803, object par5804)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeCmp

		[Sql.Function(Name="pg_catalog.range_cmp", ServerSideOnly=true)]
		public static int? RangeCmp(object par5806, object par5807)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeContainedBy

		[Sql.Function(Name="pg_catalog.range_contained_by", ServerSideOnly=true)]
		public static bool? RangeContainedBy(object par5809, object par5810)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeContains

		[Sql.Function(Name="pg_catalog.range_contains", ServerSideOnly=true)]
		public static bool? RangeContains(object par5812, object par5813)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeContainsElem

		[Sql.Function(Name="pg_catalog.range_contains_elem", ServerSideOnly=true)]
		public static bool? RangeContainsElem(object par5815, object par5816)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeEq

		[Sql.Function(Name="pg_catalog.range_eq", ServerSideOnly=true)]
		public static bool? RangeEq(object par5818, object par5819)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeGe

		[Sql.Function(Name="pg_catalog.range_ge", ServerSideOnly=true)]
		public static bool? RangeGe(object par5821, object par5822)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeGistConsistent

		[Sql.Function(Name="pg_catalog.range_gist_consistent", ServerSideOnly=true)]
		public static bool? RangeGistConsistent(object par5824, object par5825, short? par5826, int? par5827, object par5828)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeGistPenalty

		[Sql.Function(Name="pg_catalog.range_gist_penalty", ServerSideOnly=true)]
		public static object RangeGistPenalty(object par5830, object par5831, object par5832)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeGistPicksplit

		[Sql.Function(Name="pg_catalog.range_gist_picksplit", ServerSideOnly=true)]
		public static object RangeGistPicksplit(object par5834, object par5835)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeGistSame

		[Sql.Function(Name="pg_catalog.range_gist_same", ServerSideOnly=true)]
		public static object RangeGistSame(object par5837, object par5838, object par5839)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeGistUnion

		[Sql.Function(Name="pg_catalog.range_gist_union", ServerSideOnly=true)]
		public static object RangeGistUnion(object par5841, object par5842)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeGt

		[Sql.Function(Name="pg_catalog.range_gt", ServerSideOnly=true)]
		public static bool? RangeGt(object par5844, object par5845)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeIn

		[Sql.Function(Name="pg_catalog.range_in", ServerSideOnly=true)]
		public static object RangeIn(object par5847, int? par5848, int? par5849)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeIntersect

		[Sql.Function(Name="pg_catalog.range_intersect", ServerSideOnly=true)]
		public static object RangeIntersect(object par5851, object par5852)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeLe

		[Sql.Function(Name="pg_catalog.range_le", ServerSideOnly=true)]
		public static bool? RangeLe(object par5854, object par5855)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeLt

		[Sql.Function(Name="pg_catalog.range_lt", ServerSideOnly=true)]
		public static bool? RangeLt(object par5857, object par5858)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeMerge

		[Sql.Function(Name="pg_catalog.range_merge", ServerSideOnly=true)]
		public static object RangeMerge(object par5860, object par5861)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeMinus

		[Sql.Function(Name="pg_catalog.range_minus", ServerSideOnly=true)]
		public static object RangeMinus(object par5863, object par5864)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeNe

		[Sql.Function(Name="pg_catalog.range_ne", ServerSideOnly=true)]
		public static bool? RangeNe(object par5866, object par5867)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeOut

		[Sql.Function(Name="pg_catalog.range_out", ServerSideOnly=true)]
		public static object RangeOut(object par5869)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeOverlaps

		[Sql.Function(Name="pg_catalog.range_overlaps", ServerSideOnly=true)]
		public static bool? RangeOverlaps(object par5871, object par5872)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeOverleft

		[Sql.Function(Name="pg_catalog.range_overleft", ServerSideOnly=true)]
		public static bool? RangeOverleft(object par5874, object par5875)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeOverright

		[Sql.Function(Name="pg_catalog.range_overright", ServerSideOnly=true)]
		public static bool? RangeOverright(object par5877, object par5878)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeRecv

		[Sql.Function(Name="pg_catalog.range_recv", ServerSideOnly=true)]
		public static object RangeRecv(object par5880, int? par5881, int? par5882)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeSend

		[Sql.Function(Name="pg_catalog.range_send", ServerSideOnly=true)]
		public static byte[] RangeSend(object par5884)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeTypanalyze

		[Sql.Function(Name="pg_catalog.range_typanalyze", ServerSideOnly=true)]
		public static bool? RangeTypanalyze(object par5886)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RangeUnion

		[Sql.Function(Name="pg_catalog.range_union", ServerSideOnly=true)]
		public static object RangeUnion(object par5888, object par5889)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Rangesel

		[Sql.Function(Name="pg_catalog.rangesel", ServerSideOnly=true)]
		public static double? Rangesel(object par5891, int? par5892, object par5893, int? par5894)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Rank

		[Sql.Function(Name="pg_catalog.rank", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static long? Rank<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, object>> par5897)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RankFinal

		[Sql.Function(Name="pg_catalog.rank_final", ServerSideOnly=true)]
		public static long? RankFinal(object par5899, object par5900)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordEq

		[Sql.Function(Name="pg_catalog.record_eq", ServerSideOnly=true)]
		public static bool? RecordEq(object par5902, object par5903)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordGe

		[Sql.Function(Name="pg_catalog.record_ge", ServerSideOnly=true)]
		public static bool? RecordGe(object par5905, object par5906)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordGt

		[Sql.Function(Name="pg_catalog.record_gt", ServerSideOnly=true)]
		public static bool? RecordGt(object par5908, object par5909)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordImageEq

		[Sql.Function(Name="pg_catalog.record_image_eq", ServerSideOnly=true)]
		public static bool? RecordImageEq(object par5911, object par5912)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordImageGe

		[Sql.Function(Name="pg_catalog.record_image_ge", ServerSideOnly=true)]
		public static bool? RecordImageGe(object par5914, object par5915)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordImageGt

		[Sql.Function(Name="pg_catalog.record_image_gt", ServerSideOnly=true)]
		public static bool? RecordImageGt(object par5917, object par5918)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordImageLe

		[Sql.Function(Name="pg_catalog.record_image_le", ServerSideOnly=true)]
		public static bool? RecordImageLe(object par5920, object par5921)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordImageLt

		[Sql.Function(Name="pg_catalog.record_image_lt", ServerSideOnly=true)]
		public static bool? RecordImageLt(object par5923, object par5924)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordImageNe

		[Sql.Function(Name="pg_catalog.record_image_ne", ServerSideOnly=true)]
		public static bool? RecordImageNe(object par5926, object par5927)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordIn

		[Sql.Function(Name="pg_catalog.record_in", ServerSideOnly=true)]
		public static object RecordIn(object par5928, int? par5929, int? par5930)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordLe

		[Sql.Function(Name="pg_catalog.record_le", ServerSideOnly=true)]
		public static bool? RecordLe(object par5932, object par5933)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordLt

		[Sql.Function(Name="pg_catalog.record_lt", ServerSideOnly=true)]
		public static bool? RecordLt(object par5935, object par5936)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordNe

		[Sql.Function(Name="pg_catalog.record_ne", ServerSideOnly=true)]
		public static bool? RecordNe(object par5938, object par5939)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordOut

		[Sql.Function(Name="pg_catalog.record_out", ServerSideOnly=true)]
		public static object RecordOut(object par5941)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordRecv

		[Sql.Function(Name="pg_catalog.record_recv", ServerSideOnly=true)]
		public static object RecordRecv(object par5942, int? par5943, int? par5944)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RecordSend

		[Sql.Function(Name="pg_catalog.record_send", ServerSideOnly=true)]
		public static byte[] RecordSend(object par5946)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regclass

		[Sql.Function(Name="pg_catalog.regclass", ServerSideOnly=true)]
		public static object Regclass(string par5948)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regclassin

		[Sql.Function(Name="pg_catalog.regclassin", ServerSideOnly=true)]
		public static object Regclassin(object par5950)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regclassout

		[Sql.Function(Name="pg_catalog.regclassout", ServerSideOnly=true)]
		public static object Regclassout(object par5952)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regclassrecv

		[Sql.Function(Name="pg_catalog.regclassrecv", ServerSideOnly=true)]
		public static object Regclassrecv(object par5954)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regclasssend

		[Sql.Function(Name="pg_catalog.regclasssend", ServerSideOnly=true)]
		public static byte[] Regclasssend(object par5956)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regconfigin

		[Sql.Function(Name="pg_catalog.regconfigin", ServerSideOnly=true)]
		public static object Regconfigin(object par5958)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regconfigout

		[Sql.Function(Name="pg_catalog.regconfigout", ServerSideOnly=true)]
		public static object Regconfigout(object par5960)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regconfigrecv

		[Sql.Function(Name="pg_catalog.regconfigrecv", ServerSideOnly=true)]
		public static object Regconfigrecv(object par5962)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regconfigsend

		[Sql.Function(Name="pg_catalog.regconfigsend", ServerSideOnly=true)]
		public static byte[] Regconfigsend(object par5964)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regdictionaryin

		[Sql.Function(Name="pg_catalog.regdictionaryin", ServerSideOnly=true)]
		public static object Regdictionaryin(object par5966)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regdictionaryout

		[Sql.Function(Name="pg_catalog.regdictionaryout", ServerSideOnly=true)]
		public static object Regdictionaryout(object par5968)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regdictionaryrecv

		[Sql.Function(Name="pg_catalog.regdictionaryrecv", ServerSideOnly=true)]
		public static object Regdictionaryrecv(object par5970)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regdictionarysend

		[Sql.Function(Name="pg_catalog.regdictionarysend", ServerSideOnly=true)]
		public static byte[] Regdictionarysend(object par5972)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regexeqjoinsel

		[Sql.Function(Name="pg_catalog.regexeqjoinsel", ServerSideOnly=true)]
		public static double? Regexeqjoinsel(object par5974, int? par5975, object par5976, short? par5977, object par5978)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regexeqsel

		[Sql.Function(Name="pg_catalog.regexeqsel", ServerSideOnly=true)]
		public static double? Regexeqsel(object par5980, int? par5981, object par5982, int? par5983)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regexnejoinsel

		[Sql.Function(Name="pg_catalog.regexnejoinsel", ServerSideOnly=true)]
		public static double? Regexnejoinsel(object par5985, int? par5986, object par5987, short? par5988, object par5989)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regexnesel

		[Sql.Function(Name="pg_catalog.regexnesel", ServerSideOnly=true)]
		public static double? Regexnesel(object par5991, int? par5992, object par5993, int? par5994)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegexpMatch

		[Sql.Function(Name="pg_catalog.regexp_match", ServerSideOnly=true)]
		public static object RegexpMatch(string par5999, string par6000, string par6001)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegexpReplace

		[Sql.Function(Name="pg_catalog.regexp_replace", ServerSideOnly=true)]
		public static string RegexpReplace(string par6012, string par6013, string par6014, string par6015)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegexpSplitToArray

		[Sql.Function(Name="pg_catalog.regexp_split_to_array", ServerSideOnly=true)]
		public static object RegexpSplitToArray(string par6020, string par6021, string par6022)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regnamespacein

		[Sql.Function(Name="pg_catalog.regnamespacein", ServerSideOnly=true)]
		public static object Regnamespacein(object par6029)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regnamespaceout

		[Sql.Function(Name="pg_catalog.regnamespaceout", ServerSideOnly=true)]
		public static object Regnamespaceout(object par6031)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regnamespacerecv

		[Sql.Function(Name="pg_catalog.regnamespacerecv", ServerSideOnly=true)]
		public static object Regnamespacerecv(object par6033)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regnamespacesend

		[Sql.Function(Name="pg_catalog.regnamespacesend", ServerSideOnly=true)]
		public static byte[] Regnamespacesend(object par6035)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regoperatorin

		[Sql.Function(Name="pg_catalog.regoperatorin", ServerSideOnly=true)]
		public static object Regoperatorin(object par6037)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regoperatorout

		[Sql.Function(Name="pg_catalog.regoperatorout", ServerSideOnly=true)]
		public static object Regoperatorout(object par6039)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regoperatorrecv

		[Sql.Function(Name="pg_catalog.regoperatorrecv", ServerSideOnly=true)]
		public static object Regoperatorrecv(object par6041)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regoperatorsend

		[Sql.Function(Name="pg_catalog.regoperatorsend", ServerSideOnly=true)]
		public static byte[] Regoperatorsend(object par6043)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regoperin

		[Sql.Function(Name="pg_catalog.regoperin", ServerSideOnly=true)]
		public static object Regoperin(object par6045)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regoperout

		[Sql.Function(Name="pg_catalog.regoperout", ServerSideOnly=true)]
		public static object Regoperout(object par6047)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regoperrecv

		[Sql.Function(Name="pg_catalog.regoperrecv", ServerSideOnly=true)]
		public static object Regoperrecv(object par6049)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regopersend

		[Sql.Function(Name="pg_catalog.regopersend", ServerSideOnly=true)]
		public static byte[] Regopersend(object par6051)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regprocedurein

		[Sql.Function(Name="pg_catalog.regprocedurein", ServerSideOnly=true)]
		public static object Regprocedurein(object par6053)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regprocedureout

		[Sql.Function(Name="pg_catalog.regprocedureout", ServerSideOnly=true)]
		public static object Regprocedureout(object par6055)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regprocedurerecv

		[Sql.Function(Name="pg_catalog.regprocedurerecv", ServerSideOnly=true)]
		public static object Regprocedurerecv(object par6057)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regproceduresend

		[Sql.Function(Name="pg_catalog.regproceduresend", ServerSideOnly=true)]
		public static byte[] Regproceduresend(object par6059)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regprocin

		[Sql.Function(Name="pg_catalog.regprocin", ServerSideOnly=true)]
		public static object Regprocin(object par6061)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regprocout

		[Sql.Function(Name="pg_catalog.regprocout", ServerSideOnly=true)]
		public static object Regprocout(object par6063)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regprocrecv

		[Sql.Function(Name="pg_catalog.regprocrecv", ServerSideOnly=true)]
		public static object Regprocrecv(object par6065)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regprocsend

		[Sql.Function(Name="pg_catalog.regprocsend", ServerSideOnly=true)]
		public static byte[] Regprocsend(object par6067)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegrAvgx

		[Sql.Function(Name="pg_catalog.regr_avgx", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? RegrAvgx<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par6069, Expression<Func<TSource, double?>> par6070)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegrAvgy

		[Sql.Function(Name="pg_catalog.regr_avgy", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? RegrAvgy<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par6072, Expression<Func<TSource, double?>> par6073)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegrCount

		[Sql.Function(Name="pg_catalog.regr_count", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static long? RegrCount<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par6075, Expression<Func<TSource, double?>> par6076)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegrIntercept

		[Sql.Function(Name="pg_catalog.regr_intercept", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? RegrIntercept<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par6078, Expression<Func<TSource, double?>> par6079)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegrR2

		[Sql.Function(Name="pg_catalog.regr_r2", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? RegrR2<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par6081, Expression<Func<TSource, double?>> par6082)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegrSlope

		[Sql.Function(Name="pg_catalog.regr_slope", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? RegrSlope<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par6084, Expression<Func<TSource, double?>> par6085)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegrSxx

		[Sql.Function(Name="pg_catalog.regr_sxx", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? RegrSxx<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par6087, Expression<Func<TSource, double?>> par6088)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegrSxy

		[Sql.Function(Name="pg_catalog.regr_sxy", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? RegrSxy<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par6090, Expression<Func<TSource, double?>> par6091)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RegrSyy

		[Sql.Function(Name="pg_catalog.regr_syy", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static double? RegrSyy<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, double?>> par6093, Expression<Func<TSource, double?>> par6094)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regrolein

		[Sql.Function(Name="pg_catalog.regrolein", ServerSideOnly=true)]
		public static object Regrolein(object par6096)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regroleout

		[Sql.Function(Name="pg_catalog.regroleout", ServerSideOnly=true)]
		public static object Regroleout(object par6098)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regrolerecv

		[Sql.Function(Name="pg_catalog.regrolerecv", ServerSideOnly=true)]
		public static object Regrolerecv(object par6100)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regrolesend

		[Sql.Function(Name="pg_catalog.regrolesend", ServerSideOnly=true)]
		public static byte[] Regrolesend(object par6102)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regtypein

		[Sql.Function(Name="pg_catalog.regtypein", ServerSideOnly=true)]
		public static object Regtypein(object par6104)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regtypeout

		[Sql.Function(Name="pg_catalog.regtypeout", ServerSideOnly=true)]
		public static object Regtypeout(object par6106)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regtyperecv

		[Sql.Function(Name="pg_catalog.regtyperecv", ServerSideOnly=true)]
		public static object Regtyperecv(object par6108)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Regtypesend

		[Sql.Function(Name="pg_catalog.regtypesend", ServerSideOnly=true)]
		public static byte[] Regtypesend(object par6110)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltime

		[Sql.Function(Name="pg_catalog.reltime", ServerSideOnly=true)]
		public static object Reltime(NpgsqlTimeSpan? par6112)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimeeq

		[Sql.Function(Name="pg_catalog.reltimeeq", ServerSideOnly=true)]
		public static bool? Reltimeeq(object par6114, object par6115)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimege

		[Sql.Function(Name="pg_catalog.reltimege", ServerSideOnly=true)]
		public static bool? Reltimege(object par6117, object par6118)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimegt

		[Sql.Function(Name="pg_catalog.reltimegt", ServerSideOnly=true)]
		public static bool? Reltimegt(object par6120, object par6121)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimein

		[Sql.Function(Name="pg_catalog.reltimein", ServerSideOnly=true)]
		public static object Reltimein(object par6123)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimele

		[Sql.Function(Name="pg_catalog.reltimele", ServerSideOnly=true)]
		public static bool? Reltimele(object par6125, object par6126)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimelt

		[Sql.Function(Name="pg_catalog.reltimelt", ServerSideOnly=true)]
		public static bool? Reltimelt(object par6128, object par6129)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimene

		[Sql.Function(Name="pg_catalog.reltimene", ServerSideOnly=true)]
		public static bool? Reltimene(object par6131, object par6132)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimeout

		[Sql.Function(Name="pg_catalog.reltimeout", ServerSideOnly=true)]
		public static object Reltimeout(object par6134)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimerecv

		[Sql.Function(Name="pg_catalog.reltimerecv", ServerSideOnly=true)]
		public static object Reltimerecv(object par6136)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reltimesend

		[Sql.Function(Name="pg_catalog.reltimesend", ServerSideOnly=true)]
		public static byte[] Reltimesend(object par6138)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Repeat

		[Sql.Function(Name="pg_catalog.repeat", ServerSideOnly=true)]
		public static string Repeat(string par6140, int? par6141)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Replace

		[Sql.Function(Name="pg_catalog.replace", ServerSideOnly=true)]
		public static string Replace(string par6143, string par6144, string par6145)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Reverse

		[Sql.Function(Name="pg_catalog.reverse", ServerSideOnly=true)]
		public static string Reverse(string par6147)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeyCascadeDel

		[Sql.Function(Name="pg_catalog.\"RI_FKey_cascade_del\"", ServerSideOnly=true)]
		public static object RiFKeyCascadeDel()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeyCascadeUpd

		[Sql.Function(Name="pg_catalog.\"RI_FKey_cascade_upd\"", ServerSideOnly=true)]
		public static object RiFKeyCascadeUpd()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeyCheckIns

		[Sql.Function(Name="pg_catalog.\"RI_FKey_check_ins\"", ServerSideOnly=true)]
		public static object RiFKeyCheckIns()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeyCheckUpd

		[Sql.Function(Name="pg_catalog.\"RI_FKey_check_upd\"", ServerSideOnly=true)]
		public static object RiFKeyCheckUpd()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeyNoactionDel

		[Sql.Function(Name="pg_catalog.\"RI_FKey_noaction_del\"", ServerSideOnly=true)]
		public static object RiFKeyNoactionDel()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeyNoactionUpd

		[Sql.Function(Name="pg_catalog.\"RI_FKey_noaction_upd\"", ServerSideOnly=true)]
		public static object RiFKeyNoactionUpd()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeyRestrictDel

		[Sql.Function(Name="pg_catalog.\"RI_FKey_restrict_del\"", ServerSideOnly=true)]
		public static object RiFKeyRestrictDel()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeyRestrictUpd

		[Sql.Function(Name="pg_catalog.\"RI_FKey_restrict_upd\"", ServerSideOnly=true)]
		public static object RiFKeyRestrictUpd()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeySetdefaultDel

		[Sql.Function(Name="pg_catalog.\"RI_FKey_setdefault_del\"", ServerSideOnly=true)]
		public static object RiFKeySetdefaultDel()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeySetdefaultUpd

		[Sql.Function(Name="pg_catalog.\"RI_FKey_setdefault_upd\"", ServerSideOnly=true)]
		public static object RiFKeySetdefaultUpd()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeySetnullDel

		[Sql.Function(Name="pg_catalog.\"RI_FKey_setnull_del\"", ServerSideOnly=true)]
		public static object RiFKeySetnullDel()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RiFKeySetnullUpd

		[Sql.Function(Name="pg_catalog.\"RI_FKey_setnull_upd\"", ServerSideOnly=true)]
		public static object RiFKeySetnullUpd()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Right

		[Sql.Function(Name="pg_catalog.right", ServerSideOnly=true)]
		public static string Right(string par6161, int? par6162)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Round

		[Sql.Function(Name="pg_catalog.round", ServerSideOnly=true)]
		public static decimal? Round(decimal? par6169)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RowNumber

		[Sql.Function(Name="pg_catalog.row_number", ServerSideOnly=true)]
		public static long? RowNumber()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RowSecurityActive

		[Sql.Function(Name="pg_catalog.row_security_active", ServerSideOnly=true)]
		public static bool? RowSecurityActive(string par6174)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region RowToJson

		[Sql.Function(Name="pg_catalog.row_to_json", ServerSideOnly=true)]
		public static string RowToJson(object par6178, bool? par6179)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Rpad

		[Sql.Function(Name="pg_catalog.rpad", ServerSideOnly=true)]
		public static string Rpad(string par6185, int? par6186)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Rtrim

		[Sql.Function(Name="pg_catalog.rtrim", ServerSideOnly=true)]
		public static string Rtrim(string par6191)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SatisfiesHashPartition

		[Sql.Function(Name="pg_catalog.satisfies_hash_partition", ServerSideOnly=true)]
		public static bool? SatisfiesHashPartition(int? par6193, int? par6194, int? par6195, object par6196)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Scalargejoinsel

		[Sql.Function(Name="pg_catalog.scalargejoinsel", ServerSideOnly=true)]
		public static double? Scalargejoinsel(object par6198, int? par6199, object par6200, short? par6201, object par6202)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Scalargesel

		[Sql.Function(Name="pg_catalog.scalargesel", ServerSideOnly=true)]
		public static double? Scalargesel(object par6204, int? par6205, object par6206, int? par6207)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Scalargtjoinsel

		[Sql.Function(Name="pg_catalog.scalargtjoinsel", ServerSideOnly=true)]
		public static double? Scalargtjoinsel(object par6209, int? par6210, object par6211, short? par6212, object par6213)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Scalargtsel

		[Sql.Function(Name="pg_catalog.scalargtsel", ServerSideOnly=true)]
		public static double? Scalargtsel(object par6215, int? par6216, object par6217, int? par6218)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Scalarlejoinsel

		[Sql.Function(Name="pg_catalog.scalarlejoinsel", ServerSideOnly=true)]
		public static double? Scalarlejoinsel(object par6220, int? par6221, object par6222, short? par6223, object par6224)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Scalarlesel

		[Sql.Function(Name="pg_catalog.scalarlesel", ServerSideOnly=true)]
		public static double? Scalarlesel(object par6226, int? par6227, object par6228, int? par6229)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Scalarltjoinsel

		[Sql.Function(Name="pg_catalog.scalarltjoinsel", ServerSideOnly=true)]
		public static double? Scalarltjoinsel(object par6231, int? par6232, object par6233, short? par6234, object par6235)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Scalarltsel

		[Sql.Function(Name="pg_catalog.scalarltsel", ServerSideOnly=true)]
		public static double? Scalarltsel(object par6237, int? par6238, object par6239, int? par6240)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Scale

		[Sql.Function(Name="pg_catalog.scale", ServerSideOnly=true)]
		public static int? Scale(decimal? par6242)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SchemaToXml

		[Sql.Function(Name="pg_catalog.schema_to_xml", ServerSideOnly=true)]
		public static string SchemaToXml(string schema, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SchemaToXmlAndXmlschema

		[Sql.Function(Name="pg_catalog.schema_to_xml_and_xmlschema", ServerSideOnly=true)]
		public static string SchemaToXmlAndXmlschema(string schema, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SchemaToXmlschema

		[Sql.Function(Name="pg_catalog.schema_to_xmlschema", ServerSideOnly=true)]
		public static string SchemaToXmlschema(string schema, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SessionUser

		[Sql.Function(Name="pg_catalog.session_user", ServerSideOnly=true)]
		public static string SessionUser()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SetBit

		[Sql.Function(Name="pg_catalog.set_bit", ServerSideOnly=true)]
		public static byte[] SetBit(byte[] par6252, int? par6253, int? par6254)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SetByte

		[Sql.Function(Name="pg_catalog.set_byte", ServerSideOnly=true)]
		public static byte[] SetByte(byte[] par6256, int? par6257, int? par6258)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SetConfig

		[Sql.Function(Name="pg_catalog.set_config", ServerSideOnly=true)]
		public static string SetConfig(string par6260, string par6261, bool? par6262)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SetMasklen

		[Sql.Function(Name="pg_catalog.set_masklen", ServerSideOnly=true)]
		public static NpgsqlInet? SetMasklen(NpgsqlInet? par6267, int? par6268)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Setseed

		[Sql.Function(Name="pg_catalog.setseed", ServerSideOnly=true)]
		public static object Setseed(double? par6269)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Setval

		[Sql.Function(Name="pg_catalog.setval", ServerSideOnly=true)]
		public static long? Setval(object par6274, long? par6275, bool? par6276)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Setweight

		[Sql.Function(Name="pg_catalog.setweight", ServerSideOnly=true)]
		public static object Setweight(object par6282, object par6283)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Sha224

		[Sql.Function(Name="pg_catalog.sha224", ServerSideOnly=true)]
		public static byte[] Sha224(byte[] par6285)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Sha256

		[Sql.Function(Name="pg_catalog.sha256", ServerSideOnly=true)]
		public static byte[] Sha256(byte[] par6287)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Sha384

		[Sql.Function(Name="pg_catalog.sha384", ServerSideOnly=true)]
		public static byte[] Sha384(byte[] par6289)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Sha512

		[Sql.Function(Name="pg_catalog.sha512", ServerSideOnly=true)]
		public static byte[] Sha512(byte[] par6291)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ShellIn

		[Sql.Function(Name="pg_catalog.shell_in", ServerSideOnly=true)]
		public static object ShellIn(object par6293)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ShellOut

		[Sql.Function(Name="pg_catalog.shell_out", ServerSideOnly=true)]
		public static object ShellOut(object par6295)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ShiftJis2004ToEucJis2004

		[Sql.Function(Name="pg_catalog.shift_jis_2004_to_euc_jis_2004", ServerSideOnly=true)]
		public static object ShiftJis2004ToEucJis2004(int? par6296, int? par6297, object par6298, object par6299, int? par6300)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ShiftJis2004ToUtf8

		[Sql.Function(Name="pg_catalog.shift_jis_2004_to_utf8", ServerSideOnly=true)]
		public static object ShiftJis2004ToUtf8(int? par6301, int? par6302, object par6303, object par6304, int? par6305)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ShobjDescription

		[Sql.Function(Name="pg_catalog.shobj_description", ServerSideOnly=true)]
		public static string ShobjDescription(int? par6307, string par6308)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Sign

		[Sql.Function(Name="pg_catalog.sign", ServerSideOnly=true)]
		public static double? Sign(double? par6312)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SimilarEscape

		[Sql.Function(Name="pg_catalog.similar_escape", ServerSideOnly=true)]
		public static string SimilarEscape(string par6314, string par6315)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Sin

		[Sql.Function(Name="pg_catalog.sin", ServerSideOnly=true)]
		public static double? Sin(double? par6317)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Sind

		[Sql.Function(Name="pg_catalog.sind", ServerSideOnly=true)]
		public static double? Sind(double? par6319)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SjisToEucJp

		[Sql.Function(Name="pg_catalog.sjis_to_euc_jp", ServerSideOnly=true)]
		public static object SjisToEucJp(int? par6320, int? par6321, object par6322, object par6323, int? par6324)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SjisToMic

		[Sql.Function(Name="pg_catalog.sjis_to_mic", ServerSideOnly=true)]
		public static object SjisToMic(int? par6325, int? par6326, object par6327, object par6328, int? par6329)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SjisToUtf8

		[Sql.Function(Name="pg_catalog.sjis_to_utf8", ServerSideOnly=true)]
		public static object SjisToUtf8(int? par6330, int? par6331, object par6332, object par6333, int? par6334)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Slope

		[Sql.Function(Name="pg_catalog.slope", ServerSideOnly=true)]
		public static double? Slope(NpgsqlPoint? par6336, NpgsqlPoint? par6337)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Smgreq

		[Sql.Function(Name="pg_catalog.smgreq", ServerSideOnly=true)]
		public static bool? Smgreq(object par6339, object par6340)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Smgrin

		[Sql.Function(Name="pg_catalog.smgrin", ServerSideOnly=true)]
		public static object Smgrin(object par6342)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Smgrne

		[Sql.Function(Name="pg_catalog.smgrne", ServerSideOnly=true)]
		public static bool? Smgrne(object par6344, object par6345)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Smgrout

		[Sql.Function(Name="pg_catalog.smgrout", ServerSideOnly=true)]
		public static object Smgrout(object par6347)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgBboxQuadConfig

		[Sql.Function(Name="pg_catalog.spg_bbox_quad_config", ServerSideOnly=true)]
		public static object SpgBboxQuadConfig(object par6348, object par6349)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgBoxQuadChoose

		[Sql.Function(Name="pg_catalog.spg_box_quad_choose", ServerSideOnly=true)]
		public static object SpgBoxQuadChoose(object par6350, object par6351)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgBoxQuadConfig

		[Sql.Function(Name="pg_catalog.spg_box_quad_config", ServerSideOnly=true)]
		public static object SpgBoxQuadConfig(object par6352, object par6353)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgBoxQuadInnerConsistent

		[Sql.Function(Name="pg_catalog.spg_box_quad_inner_consistent", ServerSideOnly=true)]
		public static object SpgBoxQuadInnerConsistent(object par6354, object par6355)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgBoxQuadLeafConsistent

		[Sql.Function(Name="pg_catalog.spg_box_quad_leaf_consistent", ServerSideOnly=true)]
		public static bool? SpgBoxQuadLeafConsistent(object par6357, object par6358)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgBoxQuadPicksplit

		[Sql.Function(Name="pg_catalog.spg_box_quad_picksplit", ServerSideOnly=true)]
		public static object SpgBoxQuadPicksplit(object par6359, object par6360)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgKdChoose

		[Sql.Function(Name="pg_catalog.spg_kd_choose", ServerSideOnly=true)]
		public static object SpgKdChoose(object par6361, object par6362)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgKdConfig

		[Sql.Function(Name="pg_catalog.spg_kd_config", ServerSideOnly=true)]
		public static object SpgKdConfig(object par6363, object par6364)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgKdInnerConsistent

		[Sql.Function(Name="pg_catalog.spg_kd_inner_consistent", ServerSideOnly=true)]
		public static object SpgKdInnerConsistent(object par6365, object par6366)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgKdPicksplit

		[Sql.Function(Name="pg_catalog.spg_kd_picksplit", ServerSideOnly=true)]
		public static object SpgKdPicksplit(object par6367, object par6368)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgPolyQuadCompress

		[Sql.Function(Name="pg_catalog.spg_poly_quad_compress", ServerSideOnly=true)]
		public static NpgsqlBox? SpgPolyQuadCompress(NpgsqlPolygon? par6370)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgQuadChoose

		[Sql.Function(Name="pg_catalog.spg_quad_choose", ServerSideOnly=true)]
		public static object SpgQuadChoose(object par6371, object par6372)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgQuadConfig

		[Sql.Function(Name="pg_catalog.spg_quad_config", ServerSideOnly=true)]
		public static object SpgQuadConfig(object par6373, object par6374)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgQuadInnerConsistent

		[Sql.Function(Name="pg_catalog.spg_quad_inner_consistent", ServerSideOnly=true)]
		public static object SpgQuadInnerConsistent(object par6375, object par6376)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgQuadLeafConsistent

		[Sql.Function(Name="pg_catalog.spg_quad_leaf_consistent", ServerSideOnly=true)]
		public static bool? SpgQuadLeafConsistent(object par6378, object par6379)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgQuadPicksplit

		[Sql.Function(Name="pg_catalog.spg_quad_picksplit", ServerSideOnly=true)]
		public static object SpgQuadPicksplit(object par6380, object par6381)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgRangeQuadChoose

		[Sql.Function(Name="pg_catalog.spg_range_quad_choose", ServerSideOnly=true)]
		public static object SpgRangeQuadChoose(object par6382, object par6383)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgRangeQuadConfig

		[Sql.Function(Name="pg_catalog.spg_range_quad_config", ServerSideOnly=true)]
		public static object SpgRangeQuadConfig(object par6384, object par6385)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgRangeQuadInnerConsistent

		[Sql.Function(Name="pg_catalog.spg_range_quad_inner_consistent", ServerSideOnly=true)]
		public static object SpgRangeQuadInnerConsistent(object par6386, object par6387)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgRangeQuadLeafConsistent

		[Sql.Function(Name="pg_catalog.spg_range_quad_leaf_consistent", ServerSideOnly=true)]
		public static bool? SpgRangeQuadLeafConsistent(object par6389, object par6390)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgRangeQuadPicksplit

		[Sql.Function(Name="pg_catalog.spg_range_quad_picksplit", ServerSideOnly=true)]
		public static object SpgRangeQuadPicksplit(object par6391, object par6392)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgTextChoose

		[Sql.Function(Name="pg_catalog.spg_text_choose", ServerSideOnly=true)]
		public static object SpgTextChoose(object par6393, object par6394)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgTextConfig

		[Sql.Function(Name="pg_catalog.spg_text_config", ServerSideOnly=true)]
		public static object SpgTextConfig(object par6395, object par6396)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgTextInnerConsistent

		[Sql.Function(Name="pg_catalog.spg_text_inner_consistent", ServerSideOnly=true)]
		public static object SpgTextInnerConsistent(object par6397, object par6398)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgTextLeafConsistent

		[Sql.Function(Name="pg_catalog.spg_text_leaf_consistent", ServerSideOnly=true)]
		public static bool? SpgTextLeafConsistent(object par6400, object par6401)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SpgTextPicksplit

		[Sql.Function(Name="pg_catalog.spg_text_picksplit", ServerSideOnly=true)]
		public static object SpgTextPicksplit(object par6402, object par6403)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Spghandler

		[Sql.Function(Name="pg_catalog.spghandler", ServerSideOnly=true)]
		public static object Spghandler(object par6405)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SplitPart

		[Sql.Function(Name="pg_catalog.split_part", ServerSideOnly=true)]
		public static string SplitPart(string par6407, string par6408, int? par6409)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Sqrt

		[Sql.Function(Name="pg_catalog.sqrt", ServerSideOnly=true)]
		public static decimal? Sqrt(decimal? par6413)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region StartsWith

		[Sql.Function(Name="pg_catalog.starts_with", ServerSideOnly=true)]
		public static bool? StartsWith(string par6415, string par6416)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region StatementTimestamp

		[Sql.Function(Name="pg_catalog.statement_timestamp", ServerSideOnly=true)]
		public static DateTimeOffset? StatementTimestamp()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Stddev

		[Sql.Function(Name="pg_catalog.stddev", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static decimal? Stddev<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, decimal?>> par6429)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region StddevPop

		[Sql.Function(Name="pg_catalog.stddev_pop", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static decimal? StddevPop<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, decimal?>> par6441)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region StddevSamp

		[Sql.Function(Name="pg_catalog.stddev_samp", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static decimal? StddevSamp<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, decimal?>> par6453)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region StringAgg

		[Sql.Function(Name="pg_catalog.string_agg", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0, 1 })]
		public static byte[] StringAgg<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, byte[]>> par6458, Expression<Func<TSource, byte[]>> par6459)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region StringAggFinalfn

		[Sql.Function(Name="pg_catalog.string_agg_finalfn", ServerSideOnly=true)]
		public static string StringAggFinalfn(object par6461)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region StringAggTransfn

		[Sql.Function(Name="pg_catalog.string_agg_transfn", ServerSideOnly=true)]
		public static object StringAggTransfn(object par6463, string par6464, string par6465)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region StringToArray

		[Sql.Function(Name="pg_catalog.string_to_array", ServerSideOnly=true)]
		public static object StringToArray(string par6471, string par6472)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Strip

		[Sql.Function(Name="pg_catalog.strip", ServerSideOnly=true)]
		public static object Strip(object par6474)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Strpos

		[Sql.Function(Name="pg_catalog.strpos", ServerSideOnly=true)]
		public static int? Strpos(string par6476, string par6477)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Substr

		[Sql.Function(Name="pg_catalog.substr", ServerSideOnly=true)]
		public static string Substr(string par6490, int? par6491)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Substring

		[Sql.Function(Name="pg_catalog.substring", ServerSideOnly=true)]
		public static string Substring(string par6518, int? par6519)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Sum

		[Sql.Function(Name="pg_catalog.sum", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static decimal? Sum<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, decimal?>> par6535)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region SuppressRedundantUpdatesTrigger

		[Sql.Function(Name="pg_catalog.suppress_redundant_updates_trigger", ServerSideOnly=true)]
		public static object SuppressRedundantUpdatesTrigger()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region System

		[Sql.Function(Name="pg_catalog.system", ServerSideOnly=true)]
		public static object System(object par6538)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TableToXml

		[Sql.Function(Name="pg_catalog.table_to_xml", ServerSideOnly=true)]
		public static string TableToXml(object tbl, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TableToXmlAndXmlschema

		[Sql.Function(Name="pg_catalog.table_to_xml_and_xmlschema", ServerSideOnly=true)]
		public static string TableToXmlAndXmlschema(object tbl, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TableToXmlschema

		[Sql.Function(Name="pg_catalog.table_to_xmlschema", ServerSideOnly=true)]
		public static string TableToXmlschema(object tbl, bool? nulls, bool? tableforest, string targetns)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tan

		[Sql.Function(Name="pg_catalog.tan", ServerSideOnly=true)]
		public static double? Tan(double? par6543)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tand

		[Sql.Function(Name="pg_catalog.tand", ServerSideOnly=true)]
		public static double? Tand(double? par6545)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Text

		[Sql.Function(Name="pg_catalog.text", ServerSideOnly=true)]
		public static string Text(object par6557)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextGe

		[Sql.Function(Name="pg_catalog.text_ge", ServerSideOnly=true)]
		public static bool? TextGe(string par6559, string par6560)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextGt

		[Sql.Function(Name="pg_catalog.text_gt", ServerSideOnly=true)]
		public static bool? TextGt(string par6562, string par6563)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextLarger

		[Sql.Function(Name="pg_catalog.text_larger", ServerSideOnly=true)]
		public static string TextLarger(string par6565, string par6566)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextLe

		[Sql.Function(Name="pg_catalog.text_le", ServerSideOnly=true)]
		public static bool? TextLe(string par6568, string par6569)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextLt

		[Sql.Function(Name="pg_catalog.text_lt", ServerSideOnly=true)]
		public static bool? TextLt(string par6571, string par6572)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextPatternGe

		[Sql.Function(Name="pg_catalog.text_pattern_ge", ServerSideOnly=true)]
		public static bool? TextPatternGe(string par6574, string par6575)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextPatternGt

		[Sql.Function(Name="pg_catalog.text_pattern_gt", ServerSideOnly=true)]
		public static bool? TextPatternGt(string par6577, string par6578)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextPatternLe

		[Sql.Function(Name="pg_catalog.text_pattern_le", ServerSideOnly=true)]
		public static bool? TextPatternLe(string par6580, string par6581)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextPatternLt

		[Sql.Function(Name="pg_catalog.text_pattern_lt", ServerSideOnly=true)]
		public static bool? TextPatternLt(string par6583, string par6584)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TextSmaller

		[Sql.Function(Name="pg_catalog.text_smaller", ServerSideOnly=true)]
		public static string TextSmaller(string par6586, string par6587)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textanycat

		[Sql.Function(Name="pg_catalog.textanycat", ServerSideOnly=true)]
		public static string Textanycat(string par6589, object par6590)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textcat

		[Sql.Function(Name="pg_catalog.textcat", ServerSideOnly=true)]
		public static string Textcat(string par6592, string par6593)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Texteq

		[Sql.Function(Name="pg_catalog.texteq", ServerSideOnly=true)]
		public static bool? Texteq(string par6595, string par6596)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Texticlike

		[Sql.Function(Name="pg_catalog.texticlike", ServerSideOnly=true)]
		public static bool? Texticlike(string par6598, string par6599)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Texticnlike

		[Sql.Function(Name="pg_catalog.texticnlike", ServerSideOnly=true)]
		public static bool? Texticnlike(string par6601, string par6602)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Texticregexeq

		[Sql.Function(Name="pg_catalog.texticregexeq", ServerSideOnly=true)]
		public static bool? Texticregexeq(string par6604, string par6605)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Texticregexne

		[Sql.Function(Name="pg_catalog.texticregexne", ServerSideOnly=true)]
		public static bool? Texticregexne(string par6607, string par6608)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textin

		[Sql.Function(Name="pg_catalog.textin", ServerSideOnly=true)]
		public static string Textin(object par6610)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textlen

		[Sql.Function(Name="pg_catalog.textlen", ServerSideOnly=true)]
		public static int? Textlen(string par6612)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textlike

		[Sql.Function(Name="pg_catalog.textlike", ServerSideOnly=true)]
		public static bool? Textlike(string par6614, string par6615)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textne

		[Sql.Function(Name="pg_catalog.textne", ServerSideOnly=true)]
		public static bool? Textne(string par6617, string par6618)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textnlike

		[Sql.Function(Name="pg_catalog.textnlike", ServerSideOnly=true)]
		public static bool? Textnlike(string par6620, string par6621)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textout

		[Sql.Function(Name="pg_catalog.textout", ServerSideOnly=true)]
		public static object Textout(string par6623)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textrecv

		[Sql.Function(Name="pg_catalog.textrecv", ServerSideOnly=true)]
		public static string Textrecv(object par6625)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textregexeq

		[Sql.Function(Name="pg_catalog.textregexeq", ServerSideOnly=true)]
		public static bool? Textregexeq(string par6627, string par6628)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textregexne

		[Sql.Function(Name="pg_catalog.textregexne", ServerSideOnly=true)]
		public static bool? Textregexne(string par6630, string par6631)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Textsend

		[Sql.Function(Name="pg_catalog.textsend", ServerSideOnly=true)]
		public static byte[] Textsend(string par6633)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ThesaurusInit

		[Sql.Function(Name="pg_catalog.thesaurus_init", ServerSideOnly=true)]
		public static object ThesaurusInit(object par6635)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ThesaurusLexize

		[Sql.Function(Name="pg_catalog.thesaurus_lexize", ServerSideOnly=true)]
		public static object ThesaurusLexize(object par6637, object par6638, object par6639, object par6640)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tideq

		[Sql.Function(Name="pg_catalog.tideq", ServerSideOnly=true)]
		public static bool? Tideq(object par6642, object par6643)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidge

		[Sql.Function(Name="pg_catalog.tidge", ServerSideOnly=true)]
		public static bool? Tidge(object par6645, object par6646)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidgt

		[Sql.Function(Name="pg_catalog.tidgt", ServerSideOnly=true)]
		public static bool? Tidgt(object par6648, object par6649)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidin

		[Sql.Function(Name="pg_catalog.tidin", ServerSideOnly=true)]
		public static object Tidin(object par6651)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidlarger

		[Sql.Function(Name="pg_catalog.tidlarger", ServerSideOnly=true)]
		public static object Tidlarger(object par6653, object par6654)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidle

		[Sql.Function(Name="pg_catalog.tidle", ServerSideOnly=true)]
		public static bool? Tidle(object par6656, object par6657)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidlt

		[Sql.Function(Name="pg_catalog.tidlt", ServerSideOnly=true)]
		public static bool? Tidlt(object par6659, object par6660)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidne

		[Sql.Function(Name="pg_catalog.tidne", ServerSideOnly=true)]
		public static bool? Tidne(object par6662, object par6663)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidout

		[Sql.Function(Name="pg_catalog.tidout", ServerSideOnly=true)]
		public static object Tidout(object par6665)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidrecv

		[Sql.Function(Name="pg_catalog.tidrecv", ServerSideOnly=true)]
		public static object Tidrecv(object par6667)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidsend

		[Sql.Function(Name="pg_catalog.tidsend", ServerSideOnly=true)]
		public static byte[] Tidsend(object par6669)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tidsmaller

		[Sql.Function(Name="pg_catalog.tidsmaller", ServerSideOnly=true)]
		public static object Tidsmaller(object par6671, object par6672)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Time

		[Sql.Function(Name="pg_catalog.time", ServerSideOnly=true)]
		public static TimeSpan? Time(DateTimeOffset? par6685)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeCmp

		[Sql.Function(Name="pg_catalog.time_cmp", ServerSideOnly=true)]
		public static int? TimeCmp(TimeSpan? par6687, TimeSpan? par6688)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeEq

		[Sql.Function(Name="pg_catalog.time_eq", ServerSideOnly=true)]
		public static bool? TimeEq(TimeSpan? par6690, TimeSpan? par6691)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeGe

		[Sql.Function(Name="pg_catalog.time_ge", ServerSideOnly=true)]
		public static bool? TimeGe(TimeSpan? par6693, TimeSpan? par6694)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeGt

		[Sql.Function(Name="pg_catalog.time_gt", ServerSideOnly=true)]
		public static bool? TimeGt(TimeSpan? par6696, TimeSpan? par6697)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeHash

		[Sql.Function(Name="pg_catalog.time_hash", ServerSideOnly=true)]
		public static int? TimeHash(TimeSpan? par6699)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeHashExtended

		[Sql.Function(Name="pg_catalog.time_hash_extended", ServerSideOnly=true)]
		public static long? TimeHashExtended(TimeSpan? par6701, long? par6702)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeIn

		[Sql.Function(Name="pg_catalog.time_in", ServerSideOnly=true)]
		public static TimeSpan? TimeIn(object par6704, int? par6705, int? par6706)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeLarger

		[Sql.Function(Name="pg_catalog.time_larger", ServerSideOnly=true)]
		public static TimeSpan? TimeLarger(TimeSpan? par6708, TimeSpan? par6709)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeLe

		[Sql.Function(Name="pg_catalog.time_le", ServerSideOnly=true)]
		public static bool? TimeLe(TimeSpan? par6711, TimeSpan? par6712)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeLt

		[Sql.Function(Name="pg_catalog.time_lt", ServerSideOnly=true)]
		public static bool? TimeLt(TimeSpan? par6714, TimeSpan? par6715)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeMiInterval

		[Sql.Function(Name="pg_catalog.time_mi_interval", ServerSideOnly=true)]
		public static TimeSpan? TimeMiInterval(TimeSpan? par6717, NpgsqlTimeSpan? par6718)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeMiTime

		[Sql.Function(Name="pg_catalog.time_mi_time", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? TimeMiTime(TimeSpan? par6720, TimeSpan? par6721)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeNe

		[Sql.Function(Name="pg_catalog.time_ne", ServerSideOnly=true)]
		public static bool? TimeNe(TimeSpan? par6723, TimeSpan? par6724)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeOut

		[Sql.Function(Name="pg_catalog.time_out", ServerSideOnly=true)]
		public static object TimeOut(TimeSpan? par6726)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimePlInterval

		[Sql.Function(Name="pg_catalog.time_pl_interval", ServerSideOnly=true)]
		public static TimeSpan? TimePlInterval(TimeSpan? par6728, NpgsqlTimeSpan? par6729)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeRecv

		[Sql.Function(Name="pg_catalog.time_recv", ServerSideOnly=true)]
		public static TimeSpan? TimeRecv(object par6731, int? par6732, int? par6733)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeSend

		[Sql.Function(Name="pg_catalog.time_send", ServerSideOnly=true)]
		public static byte[] TimeSend(TimeSpan? par6735)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeSmaller

		[Sql.Function(Name="pg_catalog.time_smaller", ServerSideOnly=true)]
		public static TimeSpan? TimeSmaller(TimeSpan? par6737, TimeSpan? par6738)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimeTransform

		[Sql.Function(Name="pg_catalog.time_transform", ServerSideOnly=true)]
		public static object TimeTransform(object par6740)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimedatePl

		[Sql.Function(Name="pg_catalog.timedate_pl", ServerSideOnly=true)]
		public static DateTime? TimedatePl(TimeSpan? par6742, NpgsqlDate? par6743)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timemi

		[Sql.Function(Name="pg_catalog.timemi", ServerSideOnly=true)]
		public static object Timemi(object par6745, object par6746)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timenow

		[Sql.Function(Name="pg_catalog.timenow", ServerSideOnly=true)]
		public static object Timenow()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timeofday

		[Sql.Function(Name="pg_catalog.timeofday", ServerSideOnly=true)]
		public static string Timeofday()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timepl

		[Sql.Function(Name="pg_catalog.timepl", ServerSideOnly=true)]
		public static object Timepl(object par6750, object par6751)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timestamp

		[Sql.Function(Name="pg_catalog.timestamp", ServerSideOnly=true)]
		public static DateTime? Timestamp(DateTimeOffset? par6763)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampCmp

		[Sql.Function(Name="pg_catalog.timestamp_cmp", ServerSideOnly=true)]
		public static int? TimestampCmp(DateTime? par6765, DateTime? par6766)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampCmpDate

		[Sql.Function(Name="pg_catalog.timestamp_cmp_date", ServerSideOnly=true)]
		public static int? TimestampCmpDate(DateTime? par6768, NpgsqlDate? par6769)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampCmpTimestamptz

		[Sql.Function(Name="pg_catalog.timestamp_cmp_timestamptz", ServerSideOnly=true)]
		public static int? TimestampCmpTimestamptz(DateTime? par6771, DateTimeOffset? par6772)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampEq

		[Sql.Function(Name="pg_catalog.timestamp_eq", ServerSideOnly=true)]
		public static bool? TimestampEq(DateTime? par6774, DateTime? par6775)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampEqDate

		[Sql.Function(Name="pg_catalog.timestamp_eq_date", ServerSideOnly=true)]
		public static bool? TimestampEqDate(DateTime? par6777, NpgsqlDate? par6778)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampEqTimestamptz

		[Sql.Function(Name="pg_catalog.timestamp_eq_timestamptz", ServerSideOnly=true)]
		public static bool? TimestampEqTimestamptz(DateTime? par6780, DateTimeOffset? par6781)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampGe

		[Sql.Function(Name="pg_catalog.timestamp_ge", ServerSideOnly=true)]
		public static bool? TimestampGe(DateTime? par6783, DateTime? par6784)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampGeDate

		[Sql.Function(Name="pg_catalog.timestamp_ge_date", ServerSideOnly=true)]
		public static bool? TimestampGeDate(DateTime? par6786, NpgsqlDate? par6787)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampGeTimestamptz

		[Sql.Function(Name="pg_catalog.timestamp_ge_timestamptz", ServerSideOnly=true)]
		public static bool? TimestampGeTimestamptz(DateTime? par6789, DateTimeOffset? par6790)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampGt

		[Sql.Function(Name="pg_catalog.timestamp_gt", ServerSideOnly=true)]
		public static bool? TimestampGt(DateTime? par6792, DateTime? par6793)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampGtDate

		[Sql.Function(Name="pg_catalog.timestamp_gt_date", ServerSideOnly=true)]
		public static bool? TimestampGtDate(DateTime? par6795, NpgsqlDate? par6796)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampGtTimestamptz

		[Sql.Function(Name="pg_catalog.timestamp_gt_timestamptz", ServerSideOnly=true)]
		public static bool? TimestampGtTimestamptz(DateTime? par6798, DateTimeOffset? par6799)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampHash

		[Sql.Function(Name="pg_catalog.timestamp_hash", ServerSideOnly=true)]
		public static int? TimestampHash(DateTime? par6801)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampHashExtended

		[Sql.Function(Name="pg_catalog.timestamp_hash_extended", ServerSideOnly=true)]
		public static long? TimestampHashExtended(DateTime? par6803, long? par6804)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampIn

		[Sql.Function(Name="pg_catalog.timestamp_in", ServerSideOnly=true)]
		public static DateTime? TimestampIn(object par6806, int? par6807, int? par6808)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampIzoneTransform

		[Sql.Function(Name="pg_catalog.timestamp_izone_transform", ServerSideOnly=true)]
		public static object TimestampIzoneTransform(object par6810)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampLarger

		[Sql.Function(Name="pg_catalog.timestamp_larger", ServerSideOnly=true)]
		public static DateTime? TimestampLarger(DateTime? par6812, DateTime? par6813)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampLe

		[Sql.Function(Name="pg_catalog.timestamp_le", ServerSideOnly=true)]
		public static bool? TimestampLe(DateTime? par6815, DateTime? par6816)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampLeDate

		[Sql.Function(Name="pg_catalog.timestamp_le_date", ServerSideOnly=true)]
		public static bool? TimestampLeDate(DateTime? par6818, NpgsqlDate? par6819)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampLeTimestamptz

		[Sql.Function(Name="pg_catalog.timestamp_le_timestamptz", ServerSideOnly=true)]
		public static bool? TimestampLeTimestamptz(DateTime? par6821, DateTimeOffset? par6822)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampLt

		[Sql.Function(Name="pg_catalog.timestamp_lt", ServerSideOnly=true)]
		public static bool? TimestampLt(DateTime? par6824, DateTime? par6825)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampLtDate

		[Sql.Function(Name="pg_catalog.timestamp_lt_date", ServerSideOnly=true)]
		public static bool? TimestampLtDate(DateTime? par6827, NpgsqlDate? par6828)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampLtTimestamptz

		[Sql.Function(Name="pg_catalog.timestamp_lt_timestamptz", ServerSideOnly=true)]
		public static bool? TimestampLtTimestamptz(DateTime? par6830, DateTimeOffset? par6831)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampMi

		[Sql.Function(Name="pg_catalog.timestamp_mi", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? TimestampMi(DateTime? par6833, DateTime? par6834)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampMiInterval

		[Sql.Function(Name="pg_catalog.timestamp_mi_interval", ServerSideOnly=true)]
		public static DateTime? TimestampMiInterval(DateTime? par6836, NpgsqlTimeSpan? par6837)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampNe

		[Sql.Function(Name="pg_catalog.timestamp_ne", ServerSideOnly=true)]
		public static bool? TimestampNe(DateTime? par6839, DateTime? par6840)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampNeDate

		[Sql.Function(Name="pg_catalog.timestamp_ne_date", ServerSideOnly=true)]
		public static bool? TimestampNeDate(DateTime? par6842, NpgsqlDate? par6843)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampNeTimestamptz

		[Sql.Function(Name="pg_catalog.timestamp_ne_timestamptz", ServerSideOnly=true)]
		public static bool? TimestampNeTimestamptz(DateTime? par6845, DateTimeOffset? par6846)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampOut

		[Sql.Function(Name="pg_catalog.timestamp_out", ServerSideOnly=true)]
		public static object TimestampOut(DateTime? par6848)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampPlInterval

		[Sql.Function(Name="pg_catalog.timestamp_pl_interval", ServerSideOnly=true)]
		public static DateTime? TimestampPlInterval(DateTime? par6850, NpgsqlTimeSpan? par6851)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampRecv

		[Sql.Function(Name="pg_catalog.timestamp_recv", ServerSideOnly=true)]
		public static DateTime? TimestampRecv(object par6853, int? par6854, int? par6855)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampSend

		[Sql.Function(Name="pg_catalog.timestamp_send", ServerSideOnly=true)]
		public static byte[] TimestampSend(DateTime? par6857)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampSmaller

		[Sql.Function(Name="pg_catalog.timestamp_smaller", ServerSideOnly=true)]
		public static DateTime? TimestampSmaller(DateTime? par6859, DateTime? par6860)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampSortsupport

		[Sql.Function(Name="pg_catalog.timestamp_sortsupport", ServerSideOnly=true)]
		public static object TimestampSortsupport(object par6861)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampTransform

		[Sql.Function(Name="pg_catalog.timestamp_transform", ServerSideOnly=true)]
		public static object TimestampTransform(object par6863)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestampZoneTransform

		[Sql.Function(Name="pg_catalog.timestamp_zone_transform", ServerSideOnly=true)]
		public static object TimestampZoneTransform(object par6865)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timestamptypmodin

		[Sql.Function(Name="pg_catalog.timestamptypmodin", ServerSideOnly=true)]
		public static int? Timestamptypmodin(object par6867)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timestamptypmodout

		[Sql.Function(Name="pg_catalog.timestamptypmodout", ServerSideOnly=true)]
		public static object Timestamptypmodout(int? par6869)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timestamptz

		[Sql.Function(Name="pg_catalog.timestamptz", ServerSideOnly=true)]
		public static DateTimeOffset? Timestamptz(DateTime? par6884)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzCmp

		[Sql.Function(Name="pg_catalog.timestamptz_cmp", ServerSideOnly=true)]
		public static int? TimestamptzCmp(DateTimeOffset? par6886, DateTimeOffset? par6887)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzCmpDate

		[Sql.Function(Name="pg_catalog.timestamptz_cmp_date", ServerSideOnly=true)]
		public static int? TimestamptzCmpDate(DateTimeOffset? par6889, NpgsqlDate? par6890)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzCmpTimestamp

		[Sql.Function(Name="pg_catalog.timestamptz_cmp_timestamp", ServerSideOnly=true)]
		public static int? TimestamptzCmpTimestamp(DateTimeOffset? par6892, DateTime? par6893)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzEq

		[Sql.Function(Name="pg_catalog.timestamptz_eq", ServerSideOnly=true)]
		public static bool? TimestamptzEq(DateTimeOffset? par6895, DateTimeOffset? par6896)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzEqDate

		[Sql.Function(Name="pg_catalog.timestamptz_eq_date", ServerSideOnly=true)]
		public static bool? TimestamptzEqDate(DateTimeOffset? par6898, NpgsqlDate? par6899)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzEqTimestamp

		[Sql.Function(Name="pg_catalog.timestamptz_eq_timestamp", ServerSideOnly=true)]
		public static bool? TimestamptzEqTimestamp(DateTimeOffset? par6901, DateTime? par6902)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzGe

		[Sql.Function(Name="pg_catalog.timestamptz_ge", ServerSideOnly=true)]
		public static bool? TimestamptzGe(DateTimeOffset? par6904, DateTimeOffset? par6905)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzGeDate

		[Sql.Function(Name="pg_catalog.timestamptz_ge_date", ServerSideOnly=true)]
		public static bool? TimestamptzGeDate(DateTimeOffset? par6907, NpgsqlDate? par6908)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzGeTimestamp

		[Sql.Function(Name="pg_catalog.timestamptz_ge_timestamp", ServerSideOnly=true)]
		public static bool? TimestamptzGeTimestamp(DateTimeOffset? par6910, DateTime? par6911)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzGt

		[Sql.Function(Name="pg_catalog.timestamptz_gt", ServerSideOnly=true)]
		public static bool? TimestamptzGt(DateTimeOffset? par6913, DateTimeOffset? par6914)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzGtDate

		[Sql.Function(Name="pg_catalog.timestamptz_gt_date", ServerSideOnly=true)]
		public static bool? TimestamptzGtDate(DateTimeOffset? par6916, NpgsqlDate? par6917)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzGtTimestamp

		[Sql.Function(Name="pg_catalog.timestamptz_gt_timestamp", ServerSideOnly=true)]
		public static bool? TimestamptzGtTimestamp(DateTimeOffset? par6919, DateTime? par6920)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzIn

		[Sql.Function(Name="pg_catalog.timestamptz_in", ServerSideOnly=true)]
		public static DateTimeOffset? TimestamptzIn(object par6922, int? par6923, int? par6924)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzLarger

		[Sql.Function(Name="pg_catalog.timestamptz_larger", ServerSideOnly=true)]
		public static DateTimeOffset? TimestamptzLarger(DateTimeOffset? par6926, DateTimeOffset? par6927)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzLe

		[Sql.Function(Name="pg_catalog.timestamptz_le", ServerSideOnly=true)]
		public static bool? TimestamptzLe(DateTimeOffset? par6929, DateTimeOffset? par6930)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzLeDate

		[Sql.Function(Name="pg_catalog.timestamptz_le_date", ServerSideOnly=true)]
		public static bool? TimestamptzLeDate(DateTimeOffset? par6932, NpgsqlDate? par6933)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzLeTimestamp

		[Sql.Function(Name="pg_catalog.timestamptz_le_timestamp", ServerSideOnly=true)]
		public static bool? TimestamptzLeTimestamp(DateTimeOffset? par6935, DateTime? par6936)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzLt

		[Sql.Function(Name="pg_catalog.timestamptz_lt", ServerSideOnly=true)]
		public static bool? TimestamptzLt(DateTimeOffset? par6938, DateTimeOffset? par6939)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzLtDate

		[Sql.Function(Name="pg_catalog.timestamptz_lt_date", ServerSideOnly=true)]
		public static bool? TimestamptzLtDate(DateTimeOffset? par6941, NpgsqlDate? par6942)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzLtTimestamp

		[Sql.Function(Name="pg_catalog.timestamptz_lt_timestamp", ServerSideOnly=true)]
		public static bool? TimestamptzLtTimestamp(DateTimeOffset? par6944, DateTime? par6945)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzMi

		[Sql.Function(Name="pg_catalog.timestamptz_mi", ServerSideOnly=true)]
		public static NpgsqlTimeSpan? TimestamptzMi(DateTimeOffset? par6947, DateTimeOffset? par6948)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzMiInterval

		[Sql.Function(Name="pg_catalog.timestamptz_mi_interval", ServerSideOnly=true)]
		public static DateTimeOffset? TimestamptzMiInterval(DateTimeOffset? par6950, NpgsqlTimeSpan? par6951)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzNe

		[Sql.Function(Name="pg_catalog.timestamptz_ne", ServerSideOnly=true)]
		public static bool? TimestamptzNe(DateTimeOffset? par6953, DateTimeOffset? par6954)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzNeDate

		[Sql.Function(Name="pg_catalog.timestamptz_ne_date", ServerSideOnly=true)]
		public static bool? TimestamptzNeDate(DateTimeOffset? par6956, NpgsqlDate? par6957)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzNeTimestamp

		[Sql.Function(Name="pg_catalog.timestamptz_ne_timestamp", ServerSideOnly=true)]
		public static bool? TimestamptzNeTimestamp(DateTimeOffset? par6959, DateTime? par6960)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzOut

		[Sql.Function(Name="pg_catalog.timestamptz_out", ServerSideOnly=true)]
		public static object TimestamptzOut(DateTimeOffset? par6962)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzPlInterval

		[Sql.Function(Name="pg_catalog.timestamptz_pl_interval", ServerSideOnly=true)]
		public static DateTimeOffset? TimestamptzPlInterval(DateTimeOffset? par6964, NpgsqlTimeSpan? par6965)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzRecv

		[Sql.Function(Name="pg_catalog.timestamptz_recv", ServerSideOnly=true)]
		public static DateTimeOffset? TimestamptzRecv(object par6967, int? par6968, int? par6969)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzSend

		[Sql.Function(Name="pg_catalog.timestamptz_send", ServerSideOnly=true)]
		public static byte[] TimestamptzSend(DateTimeOffset? par6971)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimestamptzSmaller

		[Sql.Function(Name="pg_catalog.timestamptz_smaller", ServerSideOnly=true)]
		public static DateTimeOffset? TimestamptzSmaller(DateTimeOffset? par6973, DateTimeOffset? par6974)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timestamptztypmodin

		[Sql.Function(Name="pg_catalog.timestamptztypmodin", ServerSideOnly=true)]
		public static int? Timestamptztypmodin(object par6976)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timestamptztypmodout

		[Sql.Function(Name="pg_catalog.timestamptztypmodout", ServerSideOnly=true)]
		public static object Timestamptztypmodout(int? par6978)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timetypmodin

		[Sql.Function(Name="pg_catalog.timetypmodin", ServerSideOnly=true)]
		public static int? Timetypmodin(object par6980)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timetypmodout

		[Sql.Function(Name="pg_catalog.timetypmodout", ServerSideOnly=true)]
		public static object Timetypmodout(int? par6982)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timetz

		[Sql.Function(Name="pg_catalog.timetz", ServerSideOnly=true)]
		public static DateTimeOffset? Timetz(TimeSpan? par6989)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzCmp

		[Sql.Function(Name="pg_catalog.timetz_cmp", ServerSideOnly=true)]
		public static int? TimetzCmp(DateTimeOffset? par6991, DateTimeOffset? par6992)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzEq

		[Sql.Function(Name="pg_catalog.timetz_eq", ServerSideOnly=true)]
		public static bool? TimetzEq(DateTimeOffset? par6994, DateTimeOffset? par6995)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzGe

		[Sql.Function(Name="pg_catalog.timetz_ge", ServerSideOnly=true)]
		public static bool? TimetzGe(DateTimeOffset? par6997, DateTimeOffset? par6998)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzGt

		[Sql.Function(Name="pg_catalog.timetz_gt", ServerSideOnly=true)]
		public static bool? TimetzGt(DateTimeOffset? par7000, DateTimeOffset? par7001)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzHash

		[Sql.Function(Name="pg_catalog.timetz_hash", ServerSideOnly=true)]
		public static int? TimetzHash(DateTimeOffset? par7003)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzHashExtended

		[Sql.Function(Name="pg_catalog.timetz_hash_extended", ServerSideOnly=true)]
		public static long? TimetzHashExtended(DateTimeOffset? par7005, long? par7006)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzIn

		[Sql.Function(Name="pg_catalog.timetz_in", ServerSideOnly=true)]
		public static DateTimeOffset? TimetzIn(object par7008, int? par7009, int? par7010)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzLarger

		[Sql.Function(Name="pg_catalog.timetz_larger", ServerSideOnly=true)]
		public static DateTimeOffset? TimetzLarger(DateTimeOffset? par7012, DateTimeOffset? par7013)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzLe

		[Sql.Function(Name="pg_catalog.timetz_le", ServerSideOnly=true)]
		public static bool? TimetzLe(DateTimeOffset? par7015, DateTimeOffset? par7016)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzLt

		[Sql.Function(Name="pg_catalog.timetz_lt", ServerSideOnly=true)]
		public static bool? TimetzLt(DateTimeOffset? par7018, DateTimeOffset? par7019)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzMiInterval

		[Sql.Function(Name="pg_catalog.timetz_mi_interval", ServerSideOnly=true)]
		public static DateTimeOffset? TimetzMiInterval(DateTimeOffset? par7021, NpgsqlTimeSpan? par7022)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzNe

		[Sql.Function(Name="pg_catalog.timetz_ne", ServerSideOnly=true)]
		public static bool? TimetzNe(DateTimeOffset? par7024, DateTimeOffset? par7025)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzOut

		[Sql.Function(Name="pg_catalog.timetz_out", ServerSideOnly=true)]
		public static object TimetzOut(DateTimeOffset? par7027)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzPlInterval

		[Sql.Function(Name="pg_catalog.timetz_pl_interval", ServerSideOnly=true)]
		public static DateTimeOffset? TimetzPlInterval(DateTimeOffset? par7029, NpgsqlTimeSpan? par7030)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzRecv

		[Sql.Function(Name="pg_catalog.timetz_recv", ServerSideOnly=true)]
		public static DateTimeOffset? TimetzRecv(object par7032, int? par7033, int? par7034)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzSend

		[Sql.Function(Name="pg_catalog.timetz_send", ServerSideOnly=true)]
		public static byte[] TimetzSend(DateTimeOffset? par7036)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzSmaller

		[Sql.Function(Name="pg_catalog.timetz_smaller", ServerSideOnly=true)]
		public static DateTimeOffset? TimetzSmaller(DateTimeOffset? par7038, DateTimeOffset? par7039)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TimetzdatePl

		[Sql.Function(Name="pg_catalog.timetzdate_pl", ServerSideOnly=true)]
		public static DateTimeOffset? TimetzdatePl(DateTimeOffset? par7041, NpgsqlDate? par7042)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timetztypmodin

		[Sql.Function(Name="pg_catalog.timetztypmodin", ServerSideOnly=true)]
		public static int? Timetztypmodin(object par7044)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timetztypmodout

		[Sql.Function(Name="pg_catalog.timetztypmodout", ServerSideOnly=true)]
		public static object Timetztypmodout(int? par7046)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Timezone

		[Sql.Function(Name="pg_catalog.timezone", ServerSideOnly=true)]
		public static DateTimeOffset? Timezone(NpgsqlTimeSpan? par7063, DateTime? par7064)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tinterval

		[Sql.Function(Name="pg_catalog.tinterval", ServerSideOnly=true)]
		public static object Tinterval(object par7066, object par7067)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalct

		[Sql.Function(Name="pg_catalog.tintervalct", ServerSideOnly=true)]
		public static bool? Tintervalct(object par7069, object par7070)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalend

		[Sql.Function(Name="pg_catalog.tintervalend", ServerSideOnly=true)]
		public static object Tintervalend(object par7072)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervaleq

		[Sql.Function(Name="pg_catalog.tintervaleq", ServerSideOnly=true)]
		public static bool? Tintervaleq(object par7074, object par7075)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalge

		[Sql.Function(Name="pg_catalog.tintervalge", ServerSideOnly=true)]
		public static bool? Tintervalge(object par7077, object par7078)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalgt

		[Sql.Function(Name="pg_catalog.tintervalgt", ServerSideOnly=true)]
		public static bool? Tintervalgt(object par7080, object par7081)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalin

		[Sql.Function(Name="pg_catalog.tintervalin", ServerSideOnly=true)]
		public static object Tintervalin(object par7083)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalle

		[Sql.Function(Name="pg_catalog.tintervalle", ServerSideOnly=true)]
		public static bool? Tintervalle(object par7085, object par7086)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalleneq

		[Sql.Function(Name="pg_catalog.tintervalleneq", ServerSideOnly=true)]
		public static bool? Tintervalleneq(object par7088, object par7089)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervallenge

		[Sql.Function(Name="pg_catalog.tintervallenge", ServerSideOnly=true)]
		public static bool? Tintervallenge(object par7091, object par7092)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervallengt

		[Sql.Function(Name="pg_catalog.tintervallengt", ServerSideOnly=true)]
		public static bool? Tintervallengt(object par7094, object par7095)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervallenle

		[Sql.Function(Name="pg_catalog.tintervallenle", ServerSideOnly=true)]
		public static bool? Tintervallenle(object par7097, object par7098)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervallenlt

		[Sql.Function(Name="pg_catalog.tintervallenlt", ServerSideOnly=true)]
		public static bool? Tintervallenlt(object par7100, object par7101)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervallenne

		[Sql.Function(Name="pg_catalog.tintervallenne", ServerSideOnly=true)]
		public static bool? Tintervallenne(object par7103, object par7104)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervallt

		[Sql.Function(Name="pg_catalog.tintervallt", ServerSideOnly=true)]
		public static bool? Tintervallt(object par7106, object par7107)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalne

		[Sql.Function(Name="pg_catalog.tintervalne", ServerSideOnly=true)]
		public static bool? Tintervalne(object par7109, object par7110)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalout

		[Sql.Function(Name="pg_catalog.tintervalout", ServerSideOnly=true)]
		public static object Tintervalout(object par7112)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalov

		[Sql.Function(Name="pg_catalog.tintervalov", ServerSideOnly=true)]
		public static bool? Tintervalov(object par7114, object par7115)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalrecv

		[Sql.Function(Name="pg_catalog.tintervalrecv", ServerSideOnly=true)]
		public static object Tintervalrecv(object par7117)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalrel

		[Sql.Function(Name="pg_catalog.tintervalrel", ServerSideOnly=true)]
		public static object Tintervalrel(object par7119)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalsame

		[Sql.Function(Name="pg_catalog.tintervalsame", ServerSideOnly=true)]
		public static bool? Tintervalsame(object par7121, object par7122)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalsend

		[Sql.Function(Name="pg_catalog.tintervalsend", ServerSideOnly=true)]
		public static byte[] Tintervalsend(object par7124)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tintervalstart

		[Sql.Function(Name="pg_catalog.tintervalstart", ServerSideOnly=true)]
		public static object Tintervalstart(object par7126)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToAscii

		[Sql.Function(Name="pg_catalog.to_ascii", ServerSideOnly=true)]
		public static string ToAscii(string par7133, string par7134)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToChar

		[Sql.Function(Name="pg_catalog.to_char", ServerSideOnly=true)]
		public static string ToChar(DateTime? par7157, string par7158)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToDate

		[Sql.Function(Name="pg_catalog.to_date", ServerSideOnly=true)]
		public static NpgsqlDate? ToDate(string par7160, string par7161)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToHex

		[Sql.Function(Name="pg_catalog.to_hex", ServerSideOnly=true)]
		public static string ToHex(long? par7165)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToJson

		[Sql.Function(Name="pg_catalog.to_json", ServerSideOnly=true)]
		public static string ToJson(object par7167)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToJsonb

		[Sql.Function(Name="pg_catalog.to_jsonb", ServerSideOnly=true)]
		public static string ToJsonb(object par7169)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToNumber

		[Sql.Function(Name="pg_catalog.to_number", ServerSideOnly=true)]
		public static decimal? ToNumber(string par7171, string par7172)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToRegclass

		[Sql.Function(Name="pg_catalog.to_regclass", ServerSideOnly=true)]
		public static object ToRegclass(string par7174)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToRegnamespace

		[Sql.Function(Name="pg_catalog.to_regnamespace", ServerSideOnly=true)]
		public static object ToRegnamespace(string par7176)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToRegoper

		[Sql.Function(Name="pg_catalog.to_regoper", ServerSideOnly=true)]
		public static object ToRegoper(string par7178)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToRegoperator

		[Sql.Function(Name="pg_catalog.to_regoperator", ServerSideOnly=true)]
		public static object ToRegoperator(string par7180)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToRegproc

		[Sql.Function(Name="pg_catalog.to_regproc", ServerSideOnly=true)]
		public static object ToRegproc(string par7182)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToRegprocedure

		[Sql.Function(Name="pg_catalog.to_regprocedure", ServerSideOnly=true)]
		public static object ToRegprocedure(string par7184)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToRegrole

		[Sql.Function(Name="pg_catalog.to_regrole", ServerSideOnly=true)]
		public static object ToRegrole(string par7186)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToRegtype

		[Sql.Function(Name="pg_catalog.to_regtype", ServerSideOnly=true)]
		public static object ToRegtype(string par7188)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToTimestamp

		[Sql.Function(Name="pg_catalog.to_timestamp", ServerSideOnly=true)]
		public static DateTimeOffset? ToTimestamp(string par7192, string par7193)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToTsquery

		[Sql.Function(Name="pg_catalog.to_tsquery", ServerSideOnly=true)]
		public static object ToTsquery(string par7198)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region ToTsvector

		[Sql.Function(Name="pg_catalog.to_tsvector", ServerSideOnly=true)]
		public static object ToTsvector(object par7212, string par7213)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TransactionTimestamp

		[Sql.Function(Name="pg_catalog.transaction_timestamp", ServerSideOnly=true)]
		public static DateTimeOffset? TransactionTimestamp()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Translate

		[Sql.Function(Name="pg_catalog.translate", ServerSideOnly=true)]
		public static string Translate(string par7216, string par7217, string par7218)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TriggerIn

		[Sql.Function(Name="pg_catalog.trigger_in", ServerSideOnly=true)]
		public static object TriggerIn(object par7220)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TriggerOut

		[Sql.Function(Name="pg_catalog.trigger_out", ServerSideOnly=true)]
		public static object TriggerOut(object par7222)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Trunc

		[Sql.Function(Name="pg_catalog.trunc", ServerSideOnly=true)]
		public static PhysicalAddress Trunc(PhysicalAddress par7233)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsDelete

		[Sql.Function(Name="pg_catalog.ts_delete", ServerSideOnly=true)]
		public static object TsDelete(object par7238, object par7239)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsFilter

		[Sql.Function(Name="pg_catalog.ts_filter", ServerSideOnly=true)]
		public static object TsFilter(object par7241, object par7242)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsHeadline

		[Sql.Function(Name="pg_catalog.ts_headline", ServerSideOnly=true)]
		public static string TsHeadline(string par7289, object par7290)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsLexize

		[Sql.Function(Name="pg_catalog.ts_lexize", ServerSideOnly=true)]
		public static object TsLexize(object par7292, string par7293)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsMatchQv

		[Sql.Function(Name="pg_catalog.ts_match_qv", ServerSideOnly=true)]
		public static bool? TsMatchQv(object par7295, object par7296)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsMatchTq

		[Sql.Function(Name="pg_catalog.ts_match_tq", ServerSideOnly=true)]
		public static bool? TsMatchTq(string par7298, object par7299)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsMatchTt

		[Sql.Function(Name="pg_catalog.ts_match_tt", ServerSideOnly=true)]
		public static bool? TsMatchTt(string par7301, string par7302)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsMatchVq

		[Sql.Function(Name="pg_catalog.ts_match_vq", ServerSideOnly=true)]
		public static bool? TsMatchVq(object par7304, object par7305)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsRank

		[Sql.Function(Name="pg_catalog.ts_rank", ServerSideOnly=true)]
		public static float? TsRank(object par7320, object par7321)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsRankCd

		[Sql.Function(Name="pg_catalog.ts_rank_cd", ServerSideOnly=true)]
		public static float? TsRankCd(object par7336, object par7337)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsRewrite

		[Sql.Function(Name="pg_catalog.ts_rewrite", ServerSideOnly=true)]
		public static object TsRewrite(object par7343, string par7344)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsTypanalyze

		[Sql.Function(Name="pg_catalog.ts_typanalyze", ServerSideOnly=true)]
		public static bool? TsTypanalyze(object par7346)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsmHandlerIn

		[Sql.Function(Name="pg_catalog.tsm_handler_in", ServerSideOnly=true)]
		public static object TsmHandlerIn(object par7348)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsmHandlerOut

		[Sql.Function(Name="pg_catalog.tsm_handler_out", ServerSideOnly=true)]
		public static object TsmHandlerOut(object par7350)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsmatchjoinsel

		[Sql.Function(Name="pg_catalog.tsmatchjoinsel", ServerSideOnly=true)]
		public static double? Tsmatchjoinsel(object par7352, int? par7353, object par7354, short? par7355, object par7356)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsmatchsel

		[Sql.Function(Name="pg_catalog.tsmatchsel", ServerSideOnly=true)]
		public static double? Tsmatchsel(object par7358, int? par7359, object par7360, int? par7361)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqMcontained

		[Sql.Function(Name="pg_catalog.tsq_mcontained", ServerSideOnly=true)]
		public static bool? TsqMcontained(object par7363, object par7364)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqMcontains

		[Sql.Function(Name="pg_catalog.tsq_mcontains", ServerSideOnly=true)]
		public static bool? TsqMcontains(object par7366, object par7367)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryAnd

		[Sql.Function(Name="pg_catalog.tsquery_and", ServerSideOnly=true)]
		public static object TsqueryAnd(object par7369, object par7370)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryCmp

		[Sql.Function(Name="pg_catalog.tsquery_cmp", ServerSideOnly=true)]
		public static int? TsqueryCmp(object par7372, object par7373)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryEq

		[Sql.Function(Name="pg_catalog.tsquery_eq", ServerSideOnly=true)]
		public static bool? TsqueryEq(object par7375, object par7376)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryGe

		[Sql.Function(Name="pg_catalog.tsquery_ge", ServerSideOnly=true)]
		public static bool? TsqueryGe(object par7378, object par7379)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryGt

		[Sql.Function(Name="pg_catalog.tsquery_gt", ServerSideOnly=true)]
		public static bool? TsqueryGt(object par7381, object par7382)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryLe

		[Sql.Function(Name="pg_catalog.tsquery_le", ServerSideOnly=true)]
		public static bool? TsqueryLe(object par7384, object par7385)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryLt

		[Sql.Function(Name="pg_catalog.tsquery_lt", ServerSideOnly=true)]
		public static bool? TsqueryLt(object par7387, object par7388)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryNe

		[Sql.Function(Name="pg_catalog.tsquery_ne", ServerSideOnly=true)]
		public static bool? TsqueryNe(object par7390, object par7391)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryNot

		[Sql.Function(Name="pg_catalog.tsquery_not", ServerSideOnly=true)]
		public static object TsqueryNot(object par7393)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryOr

		[Sql.Function(Name="pg_catalog.tsquery_or", ServerSideOnly=true)]
		public static object TsqueryOr(object par7395, object par7396)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsqueryPhrase

		[Sql.Function(Name="pg_catalog.tsquery_phrase", ServerSideOnly=true)]
		public static object TsqueryPhrase(object par7401, object par7402, int? par7403)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsqueryin

		[Sql.Function(Name="pg_catalog.tsqueryin", ServerSideOnly=true)]
		public static object Tsqueryin(object par7405)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsqueryout

		[Sql.Function(Name="pg_catalog.tsqueryout", ServerSideOnly=true)]
		public static object Tsqueryout(object par7407)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsqueryrecv

		[Sql.Function(Name="pg_catalog.tsqueryrecv", ServerSideOnly=true)]
		public static object Tsqueryrecv(object par7409)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsquerysend

		[Sql.Function(Name="pg_catalog.tsquerysend", ServerSideOnly=true)]
		public static byte[] Tsquerysend(object par7411)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsrange

		[Sql.Function(Name="pg_catalog.tsrange", ServerSideOnly=true)]
		public static object Tsrange(DateTime? par7416, DateTime? par7417, string par7418)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsrangeSubdiff

		[Sql.Function(Name="pg_catalog.tsrange_subdiff", ServerSideOnly=true)]
		public static double? TsrangeSubdiff(DateTime? par7420, DateTime? par7421)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tstzrange

		[Sql.Function(Name="pg_catalog.tstzrange", ServerSideOnly=true)]
		public static object Tstzrange(DateTimeOffset? par7426, DateTimeOffset? par7427, string par7428)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TstzrangeSubdiff

		[Sql.Function(Name="pg_catalog.tstzrange_subdiff", ServerSideOnly=true)]
		public static double? TstzrangeSubdiff(DateTimeOffset? par7430, DateTimeOffset? par7431)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorCmp

		[Sql.Function(Name="pg_catalog.tsvector_cmp", ServerSideOnly=true)]
		public static int? TsvectorCmp(object par7433, object par7434)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorConcat

		[Sql.Function(Name="pg_catalog.tsvector_concat", ServerSideOnly=true)]
		public static object TsvectorConcat(object par7436, object par7437)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorEq

		[Sql.Function(Name="pg_catalog.tsvector_eq", ServerSideOnly=true)]
		public static bool? TsvectorEq(object par7439, object par7440)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorGe

		[Sql.Function(Name="pg_catalog.tsvector_ge", ServerSideOnly=true)]
		public static bool? TsvectorGe(object par7442, object par7443)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorGt

		[Sql.Function(Name="pg_catalog.tsvector_gt", ServerSideOnly=true)]
		public static bool? TsvectorGt(object par7445, object par7446)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorLe

		[Sql.Function(Name="pg_catalog.tsvector_le", ServerSideOnly=true)]
		public static bool? TsvectorLe(object par7448, object par7449)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorLt

		[Sql.Function(Name="pg_catalog.tsvector_lt", ServerSideOnly=true)]
		public static bool? TsvectorLt(object par7451, object par7452)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorNe

		[Sql.Function(Name="pg_catalog.tsvector_ne", ServerSideOnly=true)]
		public static bool? TsvectorNe(object par7454, object par7455)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorToArray

		[Sql.Function(Name="pg_catalog.tsvector_to_array", ServerSideOnly=true)]
		public static object TsvectorToArray(object par7457)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorUpdateTrigger

		[Sql.Function(Name="pg_catalog.tsvector_update_trigger", ServerSideOnly=true)]
		public static object TsvectorUpdateTrigger()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TsvectorUpdateTriggerColumn

		[Sql.Function(Name="pg_catalog.tsvector_update_trigger_column", ServerSideOnly=true)]
		public static object TsvectorUpdateTriggerColumn()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsvectorin

		[Sql.Function(Name="pg_catalog.tsvectorin", ServerSideOnly=true)]
		public static object Tsvectorin(object par7461)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsvectorout

		[Sql.Function(Name="pg_catalog.tsvectorout", ServerSideOnly=true)]
		public static object Tsvectorout(object par7463)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsvectorrecv

		[Sql.Function(Name="pg_catalog.tsvectorrecv", ServerSideOnly=true)]
		public static object Tsvectorrecv(object par7465)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Tsvectorsend

		[Sql.Function(Name="pg_catalog.tsvectorsend", ServerSideOnly=true)]
		public static byte[] Tsvectorsend(object par7467)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidCurrent

		[Sql.Function(Name="pg_catalog.txid_current", ServerSideOnly=true)]
		public static long? TxidCurrent()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidCurrentIfAssigned

		[Sql.Function(Name="pg_catalog.txid_current_if_assigned", ServerSideOnly=true)]
		public static long? TxidCurrentIfAssigned()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidCurrentSnapshot

		[Sql.Function(Name="pg_catalog.txid_current_snapshot", ServerSideOnly=true)]
		public static object TxidCurrentSnapshot()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidSnapshotIn

		[Sql.Function(Name="pg_catalog.txid_snapshot_in", ServerSideOnly=true)]
		public static object TxidSnapshotIn(object par7472)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidSnapshotOut

		[Sql.Function(Name="pg_catalog.txid_snapshot_out", ServerSideOnly=true)]
		public static object TxidSnapshotOut(object par7474)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidSnapshotRecv

		[Sql.Function(Name="pg_catalog.txid_snapshot_recv", ServerSideOnly=true)]
		public static object TxidSnapshotRecv(object par7476)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidSnapshotSend

		[Sql.Function(Name="pg_catalog.txid_snapshot_send", ServerSideOnly=true)]
		public static byte[] TxidSnapshotSend(object par7478)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidSnapshotXmax

		[Sql.Function(Name="pg_catalog.txid_snapshot_xmax", ServerSideOnly=true)]
		public static long? TxidSnapshotXmax(object par7481)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidSnapshotXmin

		[Sql.Function(Name="pg_catalog.txid_snapshot_xmin", ServerSideOnly=true)]
		public static long? TxidSnapshotXmin(object par7483)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidStatus

		[Sql.Function(Name="pg_catalog.txid_status", ServerSideOnly=true)]
		public static string TxidStatus(long? par7485)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region TxidVisibleInSnapshot

		[Sql.Function(Name="pg_catalog.txid_visible_in_snapshot", ServerSideOnly=true)]
		public static bool? TxidVisibleInSnapshot(long? par7487, object par7488)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UhcToUtf8

		[Sql.Function(Name="pg_catalog.uhc_to_utf8", ServerSideOnly=true)]
		public static object UhcToUtf8(int? par7489, int? par7490, object par7491, object par7492, int? par7493)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UniqueKeyRecheck

		[Sql.Function(Name="pg_catalog.unique_key_recheck", ServerSideOnly=true)]
		public static object UniqueKeyRecheck()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Unknownin

		[Sql.Function(Name="pg_catalog.unknownin", ServerSideOnly=true)]
		public static object Unknownin(object par7496)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Unknownout

		[Sql.Function(Name="pg_catalog.unknownout", ServerSideOnly=true)]
		public static object Unknownout(object par7498)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Unknownrecv

		[Sql.Function(Name="pg_catalog.unknownrecv", ServerSideOnly=true)]
		public static object Unknownrecv(object par7500)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Unknownsend

		[Sql.Function(Name="pg_catalog.unknownsend", ServerSideOnly=true)]
		public static byte[] Unknownsend(object par7502)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Upper

		[Sql.Function(Name="pg_catalog.upper", ServerSideOnly=true)]
		public static string Upper(string par7507)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UpperInc

		[Sql.Function(Name="pg_catalog.upper_inc", ServerSideOnly=true)]
		public static bool? UpperInc(object par7509)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UpperInf

		[Sql.Function(Name="pg_catalog.upper_inf", ServerSideOnly=true)]
		public static bool? UpperInf(object par7511)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToAscii

		[Sql.Function(Name="pg_catalog.utf8_to_ascii", ServerSideOnly=true)]
		public static object Utf8ToAscii(int? par7512, int? par7513, object par7514, object par7515, int? par7516)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToBig5

		[Sql.Function(Name="pg_catalog.utf8_to_big5", ServerSideOnly=true)]
		public static object Utf8ToBig5(int? par7517, int? par7518, object par7519, object par7520, int? par7521)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToEucCn

		[Sql.Function(Name="pg_catalog.utf8_to_euc_cn", ServerSideOnly=true)]
		public static object Utf8ToEucCn(int? par7522, int? par7523, object par7524, object par7525, int? par7526)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToEucJis2004

		[Sql.Function(Name="pg_catalog.utf8_to_euc_jis_2004", ServerSideOnly=true)]
		public static object Utf8ToEucJis2004(int? par7527, int? par7528, object par7529, object par7530, int? par7531)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToEucJp

		[Sql.Function(Name="pg_catalog.utf8_to_euc_jp", ServerSideOnly=true)]
		public static object Utf8ToEucJp(int? par7532, int? par7533, object par7534, object par7535, int? par7536)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToEucKr

		[Sql.Function(Name="pg_catalog.utf8_to_euc_kr", ServerSideOnly=true)]
		public static object Utf8ToEucKr(int? par7537, int? par7538, object par7539, object par7540, int? par7541)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToEucTw

		[Sql.Function(Name="pg_catalog.utf8_to_euc_tw", ServerSideOnly=true)]
		public static object Utf8ToEucTw(int? par7542, int? par7543, object par7544, object par7545, int? par7546)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToGb18030

		[Sql.Function(Name="pg_catalog.utf8_to_gb18030", ServerSideOnly=true)]
		public static object Utf8ToGb18030(int? par7547, int? par7548, object par7549, object par7550, int? par7551)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToGbk

		[Sql.Function(Name="pg_catalog.utf8_to_gbk", ServerSideOnly=true)]
		public static object Utf8ToGbk(int? par7552, int? par7553, object par7554, object par7555, int? par7556)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToIso88591

		[Sql.Function(Name="pg_catalog.utf8_to_iso8859_1", ServerSideOnly=true)]
		public static object Utf8ToIso88591(int? par7557, int? par7558, object par7559, object par7560, int? par7561)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToIso8859

		[Sql.Function(Name="pg_catalog.utf8_to_iso8859", ServerSideOnly=true)]
		public static object Utf8ToIso8859(int? par7562, int? par7563, object par7564, object par7565, int? par7566)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToJohab

		[Sql.Function(Name="pg_catalog.utf8_to_johab", ServerSideOnly=true)]
		public static object Utf8ToJohab(int? par7567, int? par7568, object par7569, object par7570, int? par7571)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToKoi8r

		[Sql.Function(Name="pg_catalog.utf8_to_koi8r", ServerSideOnly=true)]
		public static object Utf8ToKoi8r(int? par7572, int? par7573, object par7574, object par7575, int? par7576)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToKoi8u

		[Sql.Function(Name="pg_catalog.utf8_to_koi8u", ServerSideOnly=true)]
		public static object Utf8ToKoi8u(int? par7577, int? par7578, object par7579, object par7580, int? par7581)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToShiftJis2004

		[Sql.Function(Name="pg_catalog.utf8_to_shift_jis_2004", ServerSideOnly=true)]
		public static object Utf8ToShiftJis2004(int? par7582, int? par7583, object par7584, object par7585, int? par7586)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToSjis

		[Sql.Function(Name="pg_catalog.utf8_to_sjis", ServerSideOnly=true)]
		public static object Utf8ToSjis(int? par7587, int? par7588, object par7589, object par7590, int? par7591)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToUhc

		[Sql.Function(Name="pg_catalog.utf8_to_uhc", ServerSideOnly=true)]
		public static object Utf8ToUhc(int? par7592, int? par7593, object par7594, object par7595, int? par7596)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Utf8ToWin

		[Sql.Function(Name="pg_catalog.utf8_to_win", ServerSideOnly=true)]
		public static object Utf8ToWin(int? par7597, int? par7598, object par7599, object par7600, int? par7601)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidCmp

		[Sql.Function(Name="pg_catalog.uuid_cmp", ServerSideOnly=true)]
		public static int? UuidCmp(Guid? par7603, Guid? par7604)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidEq

		[Sql.Function(Name="pg_catalog.uuid_eq", ServerSideOnly=true)]
		public static bool? UuidEq(Guid? par7606, Guid? par7607)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidGe

		[Sql.Function(Name="pg_catalog.uuid_ge", ServerSideOnly=true)]
		public static bool? UuidGe(Guid? par7609, Guid? par7610)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidGt

		[Sql.Function(Name="pg_catalog.uuid_gt", ServerSideOnly=true)]
		public static bool? UuidGt(Guid? par7612, Guid? par7613)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidHash

		[Sql.Function(Name="pg_catalog.uuid_hash", ServerSideOnly=true)]
		public static int? UuidHash(Guid? par7615)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidHashExtended

		[Sql.Function(Name="pg_catalog.uuid_hash_extended", ServerSideOnly=true)]
		public static long? UuidHashExtended(Guid? par7617, long? par7618)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidIn

		[Sql.Function(Name="pg_catalog.uuid_in", ServerSideOnly=true)]
		public static Guid? UuidIn(object par7620)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidLe

		[Sql.Function(Name="pg_catalog.uuid_le", ServerSideOnly=true)]
		public static bool? UuidLe(Guid? par7622, Guid? par7623)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidLt

		[Sql.Function(Name="pg_catalog.uuid_lt", ServerSideOnly=true)]
		public static bool? UuidLt(Guid? par7625, Guid? par7626)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidNe

		[Sql.Function(Name="pg_catalog.uuid_ne", ServerSideOnly=true)]
		public static bool? UuidNe(Guid? par7628, Guid? par7629)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidOut

		[Sql.Function(Name="pg_catalog.uuid_out", ServerSideOnly=true)]
		public static object UuidOut(Guid? par7631)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidRecv

		[Sql.Function(Name="pg_catalog.uuid_recv", ServerSideOnly=true)]
		public static Guid? UuidRecv(object par7633)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidSend

		[Sql.Function(Name="pg_catalog.uuid_send", ServerSideOnly=true)]
		public static byte[] UuidSend(Guid? par7635)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region UuidSortsupport

		[Sql.Function(Name="pg_catalog.uuid_sortsupport", ServerSideOnly=true)]
		public static object UuidSortsupport(object par7636)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VarPop

		[Sql.Function(Name="pg_catalog.var_pop", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static decimal? VarPop<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, decimal?>> par7648)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VarSamp

		[Sql.Function(Name="pg_catalog.var_samp", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static decimal? VarSamp<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, decimal?>> par7660)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbit

		[Sql.Function(Name="pg_catalog.varbit", ServerSideOnly=true)]
		public static BitArray Varbit(BitArray par7662, int? par7663, bool? par7664)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VarbitIn

		[Sql.Function(Name="pg_catalog.varbit_in", ServerSideOnly=true)]
		public static BitArray VarbitIn(object par7666, int? par7667, int? par7668)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VarbitOut

		[Sql.Function(Name="pg_catalog.varbit_out", ServerSideOnly=true)]
		public static object VarbitOut(BitArray par7670)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VarbitRecv

		[Sql.Function(Name="pg_catalog.varbit_recv", ServerSideOnly=true)]
		public static BitArray VarbitRecv(object par7672, int? par7673, int? par7674)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VarbitSend

		[Sql.Function(Name="pg_catalog.varbit_send", ServerSideOnly=true)]
		public static byte[] VarbitSend(BitArray par7676)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VarbitTransform

		[Sql.Function(Name="pg_catalog.varbit_transform", ServerSideOnly=true)]
		public static object VarbitTransform(object par7678)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbitcmp

		[Sql.Function(Name="pg_catalog.varbitcmp", ServerSideOnly=true)]
		public static int? Varbitcmp(BitArray par7680, BitArray par7681)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbiteq

		[Sql.Function(Name="pg_catalog.varbiteq", ServerSideOnly=true)]
		public static bool? Varbiteq(BitArray par7683, BitArray par7684)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbitge

		[Sql.Function(Name="pg_catalog.varbitge", ServerSideOnly=true)]
		public static bool? Varbitge(BitArray par7686, BitArray par7687)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbitgt

		[Sql.Function(Name="pg_catalog.varbitgt", ServerSideOnly=true)]
		public static bool? Varbitgt(BitArray par7689, BitArray par7690)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbitle

		[Sql.Function(Name="pg_catalog.varbitle", ServerSideOnly=true)]
		public static bool? Varbitle(BitArray par7692, BitArray par7693)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbitlt

		[Sql.Function(Name="pg_catalog.varbitlt", ServerSideOnly=true)]
		public static bool? Varbitlt(BitArray par7695, BitArray par7696)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbitne

		[Sql.Function(Name="pg_catalog.varbitne", ServerSideOnly=true)]
		public static bool? Varbitne(BitArray par7698, BitArray par7699)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbittypmodin

		[Sql.Function(Name="pg_catalog.varbittypmodin", ServerSideOnly=true)]
		public static int? Varbittypmodin(object par7701)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varbittypmodout

		[Sql.Function(Name="pg_catalog.varbittypmodout", ServerSideOnly=true)]
		public static object Varbittypmodout(int? par7703)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varchar

		[Sql.Function(Name="pg_catalog.varchar", ServerSideOnly=true)]
		public static string Varchar(string par7707, int? par7708, bool? par7709)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VarcharTransform

		[Sql.Function(Name="pg_catalog.varchar_transform", ServerSideOnly=true)]
		public static object VarcharTransform(object par7711)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varcharin

		[Sql.Function(Name="pg_catalog.varcharin", ServerSideOnly=true)]
		public static string Varcharin(object par7713, int? par7714, int? par7715)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varcharout

		[Sql.Function(Name="pg_catalog.varcharout", ServerSideOnly=true)]
		public static object Varcharout(string par7717)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varcharrecv

		[Sql.Function(Name="pg_catalog.varcharrecv", ServerSideOnly=true)]
		public static string Varcharrecv(object par7719, int? par7720, int? par7721)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varcharsend

		[Sql.Function(Name="pg_catalog.varcharsend", ServerSideOnly=true)]
		public static byte[] Varcharsend(string par7723)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varchartypmodin

		[Sql.Function(Name="pg_catalog.varchartypmodin", ServerSideOnly=true)]
		public static int? Varchartypmodin(object par7725)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Varchartypmodout

		[Sql.Function(Name="pg_catalog.varchartypmodout", ServerSideOnly=true)]
		public static object Varchartypmodout(int? par7727)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Variance

		[Sql.Function(Name="pg_catalog.variance", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static decimal? Variance<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, decimal?>> par7739)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Version

		[Sql.Function(Name="pg_catalog.version", ServerSideOnly=true)]
		public static string Version()
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VoidIn

		[Sql.Function(Name="pg_catalog.void_in", ServerSideOnly=true)]
		public static object VoidIn(object par7741)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VoidOut

		[Sql.Function(Name="pg_catalog.void_out", ServerSideOnly=true)]
		public static object VoidOut(object par7743)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VoidRecv

		[Sql.Function(Name="pg_catalog.void_recv", ServerSideOnly=true)]
		public static object VoidRecv(object par7744)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region VoidSend

		[Sql.Function(Name="pg_catalog.void_send", ServerSideOnly=true)]
		public static byte[] VoidSend(object par7746)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region WebsearchToTsquery

		[Sql.Function(Name="pg_catalog.websearch_to_tsquery", ServerSideOnly=true)]
		public static object WebsearchToTsquery(string par7751)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Width

		[Sql.Function(Name="pg_catalog.width", ServerSideOnly=true)]
		public static double? Width(NpgsqlBox? par7753)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region WidthBucket

		[Sql.Function(Name="pg_catalog.width_bucket", ServerSideOnly=true)]
		public static int? WidthBucket(object par7765, object par7766)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region WinToUtf8

		[Sql.Function(Name="pg_catalog.win_to_utf8", ServerSideOnly=true)]
		public static object WinToUtf8(int? par7767, int? par7768, object par7769, object par7770, int? par7771)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win1250ToLatin2

		[Sql.Function(Name="pg_catalog.win1250_to_latin2", ServerSideOnly=true)]
		public static object Win1250ToLatin2(int? par7772, int? par7773, object par7774, object par7775, int? par7776)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win1250ToMic

		[Sql.Function(Name="pg_catalog.win1250_to_mic", ServerSideOnly=true)]
		public static object Win1250ToMic(int? par7777, int? par7778, object par7779, object par7780, int? par7781)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win1251ToIso

		[Sql.Function(Name="pg_catalog.win1251_to_iso", ServerSideOnly=true)]
		public static object Win1251ToIso(int? par7782, int? par7783, object par7784, object par7785, int? par7786)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win1251ToKoi8r

		[Sql.Function(Name="pg_catalog.win1251_to_koi8r", ServerSideOnly=true)]
		public static object Win1251ToKoi8r(int? par7787, int? par7788, object par7789, object par7790, int? par7791)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win1251ToMic

		[Sql.Function(Name="pg_catalog.win1251_to_mic", ServerSideOnly=true)]
		public static object Win1251ToMic(int? par7792, int? par7793, object par7794, object par7795, int? par7796)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win1251ToWin866

		[Sql.Function(Name="pg_catalog.win1251_to_win866", ServerSideOnly=true)]
		public static object Win1251ToWin866(int? par7797, int? par7798, object par7799, object par7800, int? par7801)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win866ToIso

		[Sql.Function(Name="pg_catalog.win866_to_iso", ServerSideOnly=true)]
		public static object Win866ToIso(int? par7802, int? par7803, object par7804, object par7805, int? par7806)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win866ToKoi8r

		[Sql.Function(Name="pg_catalog.win866_to_koi8r", ServerSideOnly=true)]
		public static object Win866ToKoi8r(int? par7807, int? par7808, object par7809, object par7810, int? par7811)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win866ToMic

		[Sql.Function(Name="pg_catalog.win866_to_mic", ServerSideOnly=true)]
		public static object Win866ToMic(int? par7812, int? par7813, object par7814, object par7815, int? par7816)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Win866ToWin1251

		[Sql.Function(Name="pg_catalog.win866_to_win1251", ServerSideOnly=true)]
		public static object Win866ToWin1251(int? par7817, int? par7818, object par7819, object par7820, int? par7821)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xideq

		[Sql.Function(Name="pg_catalog.xideq", ServerSideOnly=true)]
		public static bool? Xideq(int? par7823, int? par7824)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xideqint4

		[Sql.Function(Name="pg_catalog.xideqint4", ServerSideOnly=true)]
		public static bool? Xideqint4(int? par7826, int? par7827)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xidin

		[Sql.Function(Name="pg_catalog.xidin", ServerSideOnly=true)]
		public static int? Xidin(object par7829)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xidneq

		[Sql.Function(Name="pg_catalog.xidneq", ServerSideOnly=true)]
		public static bool? Xidneq(int? par7831, int? par7832)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xidneqint4

		[Sql.Function(Name="pg_catalog.xidneqint4", ServerSideOnly=true)]
		public static bool? Xidneqint4(int? par7834, int? par7835)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xidout

		[Sql.Function(Name="pg_catalog.xidout", ServerSideOnly=true)]
		public static object Xidout(int? par7837)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xidrecv

		[Sql.Function(Name="pg_catalog.xidrecv", ServerSideOnly=true)]
		public static int? Xidrecv(object par7839)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xidsend

		[Sql.Function(Name="pg_catalog.xidsend", ServerSideOnly=true)]
		public static byte[] Xidsend(int? par7841)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xml

		[Sql.Function(Name="pg_catalog.xml", ServerSideOnly=true)]
		public static string Xml(string par7843)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region XmlIn

		[Sql.Function(Name="pg_catalog.xml_in", ServerSideOnly=true)]
		public static string XmlIn(object par7845)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region XmlIsWellFormed

		[Sql.Function(Name="pg_catalog.xml_is_well_formed", ServerSideOnly=true)]
		public static bool? XmlIsWellFormed(string par7847)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region XmlIsWellFormedContent

		[Sql.Function(Name="pg_catalog.xml_is_well_formed_content", ServerSideOnly=true)]
		public static bool? XmlIsWellFormedContent(string par7849)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region XmlIsWellFormedDocument

		[Sql.Function(Name="pg_catalog.xml_is_well_formed_document", ServerSideOnly=true)]
		public static bool? XmlIsWellFormedDocument(string par7851)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region XmlOut

		[Sql.Function(Name="pg_catalog.xml_out", ServerSideOnly=true)]
		public static object XmlOut(string par7853)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region XmlRecv

		[Sql.Function(Name="pg_catalog.xml_recv", ServerSideOnly=true)]
		public static string XmlRecv(object par7855)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region XmlSend

		[Sql.Function(Name="pg_catalog.xml_send", ServerSideOnly=true)]
		public static byte[] XmlSend(string par7857)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xmlagg

		[Sql.Function(Name="pg_catalog.xmlagg", ServerSideOnly=true, IsAggregate = true, ArgIndices = new[] { 0 })]
		public static string Xmlagg<TSource>(this IEnumerable<TSource> src, Expression<Func<TSource, string>> par7859)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xmlcomment

		[Sql.Function(Name="pg_catalog.xmlcomment", ServerSideOnly=true)]
		public static string Xmlcomment(string par7861)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xmlconcat2

		[Sql.Function(Name="pg_catalog.xmlconcat2", ServerSideOnly=true)]
		public static string Xmlconcat2(string par7863, string par7864)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xmlexists

		[Sql.Function(Name="pg_catalog.xmlexists", ServerSideOnly=true)]
		public static bool? Xmlexists(string par7866, string par7867)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xmlvalidate

		[Sql.Function(Name="pg_catalog.xmlvalidate", ServerSideOnly=true)]
		public static bool? Xmlvalidate(string par7869, string par7870)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region Xpath

		[Sql.Function(Name="pg_catalog.xpath", ServerSideOnly=true)]
		public static object Xpath(string par7876, string par7877)
		{
			throw new InvalidOperationException();
		}

		#endregion

		#region XpathExists

		[Sql.Function(Name="pg_catalog.xpath_exists", ServerSideOnly=true)]
		public static bool? XpathExists(string par7883, string par7884)
		{
			throw new InvalidOperationException();
		}

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Contact Find(this ITable<Contact> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Importance Find(this ITable<Importance> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Task Find(this ITable<Task> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TaskUser Find(this ITable<TaskUser> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static User Find(this ITable<User> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}

#pragma warning restore 1591
