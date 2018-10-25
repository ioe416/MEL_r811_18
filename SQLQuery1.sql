SELECT [WorkRequest].[RequestID], [Machines].[BTNumber], [WorkRequest].[RequestDate], [Type].[Type],
[Priority].[Priority], [WorkRequest].[WorkRequested]
FROM [WorkRequest] INNER JOIN [Machines] ON [Machines].[MachineID] = [WorkRequest].[MachineID]
INNER JOIN [Type] ON [Type].[TypeID] = [WorkRequest].[RequestType]
INNER JOIN [Priority] ON [Priority].[PriorityID] = [WorkRequest].[RequestPriority]