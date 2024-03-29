﻿using Sample.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace Sample.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
