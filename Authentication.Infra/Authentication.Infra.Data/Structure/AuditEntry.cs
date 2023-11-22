﻿using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Authentication.Infra.Data.Structure;
public class AuditEntry
{
    public AuditEntry(EntityEntry entry) => Entry = entry;

    public EntityEntry Entry { get; }

    public string UserId { get; set; }

    public string TableName { get; set; }

    public Dictionary<string, object> KeyValues { get; } = new ();

    public Dictionary<string, object> OldValues { get; } = new ();

    public Dictionary<string, object> NewValues { get; } = new ();

    public AuditType AuditType { get; set; }

    public List<string> ChangedColumns { get; } = new ();

    public Audit ToAudit()
    {
        var audit = new Audit
        {
            Id = Guid.NewGuid(),
            UserId = UserId,
            Type = AuditType.ToString(),
            TableName = TableName,
            DateTime = DateTime.Now,
            PrimaryKey = JsonSerializer.Serialize(KeyValues),
            OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues),
            NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues),
            AffectedColumns = ChangedColumns.Count == 0 ? null : JsonSerializer.Serialize(ChangedColumns)
        };

        return audit;
    }
}

public enum AuditType
{
    None = 0,
    Create = 1,
    Update = 2,
    Delete = 3
}