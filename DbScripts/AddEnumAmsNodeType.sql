IF (SELECT COUNT(*) FROM [Global].[EnumAMSNodeTypes] WHERE [EnumAMSNodeType] = 30023) = 0
	INSERT INTO [Global].[EnumAMSNodeTypes] ([EnumAMSNodeType],[AMSNodeTypeName],[AMSNodeTypeDescription],[AMSNodeTypeResourceKeyId],[AMSNodeTypeCreatedDate])
	VALUES ('30023','TestAmsNodetype','TestAmsNodetype', null, '2019/02/03')