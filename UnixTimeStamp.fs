namespace DateTimeHelper

open System

module UnixTimeStamp =
    let convertToDateTimeOffset (timeStamp: int64) =
        DateTimeOffset.FromUnixTimeSeconds(timeStamp)

    let convertToUtcDateTime (timeStamp: int64) =
        convertToDateTimeOffset(timeStamp).UtcDateTime
