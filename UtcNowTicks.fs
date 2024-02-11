namespace DateTimeHelper

open System

module UtcNowTicks =
    let convertToUtcDateTime (ticks: int64) =
        new DateTime(ticks, DateTimeKind.Utc)

    let convertToDateTimeOffset (ticks: int64) =
        new DateTimeOffset(convertToUtcDateTime ticks)
