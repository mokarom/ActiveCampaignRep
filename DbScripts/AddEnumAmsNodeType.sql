IF (SELECT COUNT(*) FROM [Global].[EnumAMSNodeTypes] WHERE [EnumAMSNodeType] = 30022) = 0
	INSERT INTO [Global].[EnumAMSNodeTypes] ([EnumAMSNodeType],[AMSNodeTypeName],[AMSNodeTypeDescription],[AMSNodeTypeResourceKeyId],[AMSNodeTypeCreatedDate])
	VALUES ('30022','TestAmsNodetype','TestAmsNodetype', null, '2019/02/03')